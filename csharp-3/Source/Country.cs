using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
namespace Codenation.Challenge
{
    public class Country
    {

        public State[] Top10StatesByArea() 
        {
            string path = @"C:\Users\Guto\codenation\csharp-3\Source\DataBase.txt";   // copiei toda a p�gina do wiki e coloquei em arquivo txt   
            string[] lines = File.ReadAllLines(path, Encoding.UTF8);
            Regex rx = new Regex(@"^(\w+ *\w* *\w* *\w*)\t{1}[0-9, ]*\t{1}([0-9, ]*)\t{1}", RegexOptions.None); 
            State[] st = new State[27];     // as unicas firmas din�micas de informar esse indice que pensei foram:
                                            //instanciar dentro do foreach, mas n�o acho pratico,
                                            //fazer um matchs fora do foreach e informar o n�meto de match, mas seria 
                                            //um custo muito alto desnecess�rio. Alguem sugere algo? 
            int i = 0;
            foreach (string ln in lines)
            {
                var mt = rx.Match(ln);
                if (mt.Success)
                {
                    string name = mt.Groups[1].Value;                                   //carrega nome
                    string acronym = CallAcronyn(name);                                 //extrai a sigla
                    double area = double.Parse(mt.Groups[2].Value.Replace(" ", null));  //carrega �rea
                    st[i] = new State(name, acronym);                                   //instancia objetos nos indices
                    st[i].Area = area;                                                  //nao defini area no construtor
                    i++;
                }
            }

            return st.OrderByDescending(list10 => list10.Area).Take(10).ToArray();               //sa�da

        }
        private static string CallAcronyn(string name)
        {
            string path = @"C:\Users\Guto\codenation\csharp-3\Source\DataBaseAcronyn.csv";      //esse csv � formado pelos estados seguidos de sua sigla
            string initials = "Not_Fount";                                                      //caso n�o encontre a sigla, resposta padr�o.
            string[] lines = File.ReadAllLines(path, Encoding.UTF8);                           
            Regex rx2 = new Regex(@"^(.*),{1}(\w{2})", RegexOptions.None);                      //cria filtro
            foreach (string ln in lines)
            {
                var mt = rx2.Match(ln);                          
                if (mt.Success)
                {
                    string temp2 = mt.Groups[1].Value;
                    if (name == temp2)                              //se a linha do arquivo csv corresponder ao mesmo nome de
                    {                                               //do "Country.Name" retorna com a sigla
                        initials = mt.Groups[2].Value;
                        return initials;
                    }
                }
            }
            return initials;                                        //caso n�o encontre o nome do estado na lista
        }
    }
}
