using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Codenation.Challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace Codenation.Challenge.Services
{
    public class UserService : IUserService
    {
        private CodenationContext _context;

        public UserService(CodenationContext context)
        {
            _context = context;
        }

        public IList<User> FindByAccelerationName(string name)
        {
            //deve retornar uma lista de usuários a partir do nome da aceleração

            return _context.Accelerations          // na tabla acceleration
                     .Where(x => x.Name == name)     //    onde o name corresponder a name
                     .SelectMany(x => x.Candidates)  // pegue todos os candidates
                     .Select(x => x.User)            // pegue todos os users
                     .ToList();                      // retorne uma lista
                                                     //   throw new System.NotImplementedException();
        }

        public IList<User> FindByCompanyId(int companyId)
        {
            //deve retornar uma lista de usuários a relacionado com a empresa pelo id da empresa 
            var user = from c in _context.Candidates
                       where c.CompanyId == companyId
                       select c.User;
            List<User> u1 = new List<User>();
            u1.AddRange(user);
            return u1;
        }

        public User FindById(int id)
        {
            //deve retornar um usuário a partir do id do usuário
            return _context.Users.Where(x => x.Id == id).SingleOrDefault();
        }

        public User Save(User user)
        {
            //deve retornar um usuário após salvar os dados. 
            //Caso o Id seja zero, fará a inserção do usuário, 
            //caso contrário fará a atualização dos dados do usuário com o Id informado
            if (user.Id == 0)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return _context.Users.Last();
               


            }
            else
            {
                var update = _context.Users.Where(x => x.Id == user.Id).SingleOrDefault();
                update = user;
                _context.SaveChanges();
                return update;
            }
        }

       
    }
}
