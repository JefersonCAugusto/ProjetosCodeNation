using Codenation.Challenge.Models;
using Remotion.Linq.Parsing.Structure.IntermediateModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Source.Models
{
    public class SeedingService
    {
        private CodenationContext _context;

        public SeedingService(CodenationContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Users.Any() || _context.Companies.Any() || _context.Challenges.Any() )
            {
                return;
            }
            User us1 = new User("Jeferson", "i@home.com", "Developer", "FASF$#$%#$", new DateTime(2020, 02, 11));

            User us2 = new User("Carlos", "he@home.com", "Developer", "234fffwrf$d", new DateTime(2020, 06, 12));

            User us3 = new User("Maria", "she@home.com", "Developer", "wr43f545f2fw", new DateTime(2019,26,11));

            Company co1 = new Company("Codenation", "Codenation-curso-c#", new DateTime(2019, 06, 12));

            Company co2 = new Company("Stone", "Stone-", new DateTime(2019, 06, 12));

            Challenge ch1 = new Challenge("C#", "C-sharp-Teste", new DateTime(2020, 06, 12));

            Challenge ch2 = new Challenge("Pyton", "Pyton-teste", new DateTime(2020, 06, 12));


            _context.Users.AddRange(us1, us2, us3);
            _context.Companies.AddRange(co1, co2);
            _context.Challenges.AddRange(ch1, ch2);

            _context.SaveChanges();  //alterar para assincrono

        }
    }
}
