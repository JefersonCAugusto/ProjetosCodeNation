using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;

namespace Codenation.Challenge
{
    public class Country
    {

        public State[] Top10StatesByArea()
        {
            int numbLine = 0;
            string path = @"C:\Users\Guto\codenation\csharp-3\Source\DataBase.txt";   
            string[] lines = ReadFile(path, ref numbLine);
            Regex rx = new Regex(@"^(\w+ *\w* *\w* *\w*)\t{1}[0-9, ]*\t{1}([0-9, ]*)\t{1}", RegexOptions.None);
            State[] st = new State[numbLine];                                                                                                                         
            int i = 0;
            foreach (string ln in lines)
            {
                var mt = rx.Match(ln);
                if (mt.Success)
                {
                    string name = mt.Groups[1].Value;                                   //carrega nome
                    string acronym = CallAcronyn(name);                                 //extrai a sigla
                    double area = double.Parse(mt.Groups[2].Value.Replace(" ", null));  //carrega Área
                    st[i] = new State(name, acronym);                                   //instancia objetos nos indices
                    st[i].Area = area;                                                  //nao defini area no construtor
                    i++;
                }
            }
                return st.OrderByDescending(list10 => list10.Area).Take(10).ToArray();               //saída
            
            
        }


        private static string[] ReadFile(string path,ref int numbLine)
        {
            if (!File.Exists(path))     //verifica se existe algum tipo de arquivo
                throw new FileNotFoundException();              
             
            try
            {                           //recupera a quantidade de linhas do arquivo.
                numbLine = File.ReadLines(@"C:\Users\Guto\codenation\csharp-3\Source\DataBase.txt").Count();
            }
            catch(Exception e)
            {
                Console.WriteLine("unexpected error: "+ e.Message);
            }
            string[] lines = new string[numbLine];
            try
            {                           //le o arquivo.
                 lines = File.ReadAllLines(path, Encoding.UTF8);
            
            }
            catch(SystemException e)
            {
                Console.WriteLine("Unexpected error: " + e.Message);
            }
            return lines;               //retorna arquivo.
        }
        private static string CallAcronyn(string name)
        {
            string path = @"C:\Users\Guto\codenation\csharp-3\Source\DataBaseAcronyn.csv";      //esse csv é formado pelos estados seguidos de sua sigla
            string initials = "Not_Fount";                                                      //caso não encontre a sigla, resposta padrão.
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
            return initials;                                        //caso não encontre o nome do estado na lista
        }
    }
}
