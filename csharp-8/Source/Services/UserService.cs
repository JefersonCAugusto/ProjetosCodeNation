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
            //deve retornar uma lista de usu�rios a partir do nome da acelera��o

            return _context.Accelerations          // na tabla acceleration
                     .Where(x => x.Name == name)     //    onde o name corresponder a name
                     .SelectMany(x => x.Candidates)  // pegue todos os candidates
                     .Select(x => x.User)            // pegue todos os users
                     .ToList();                      // retorne uma lista
                                                     //   throw new System.NotImplementedException();
        }

        public IList<User> FindByCompanyId(int companyId)
        {
            //deve retornar uma lista de usu�rios a relacionado com a empresa pelo id da empresa 
            var user = from c in _context.Candidates
                       where c.CompanyId == companyId
                       select c.User;
            List<User> u1 = new List<User>();
            u1.AddRange(user);
            return u1;
        }

        public User FindById(int id)
        {
            //deve retornar um usu�rio a partir do id do usu�rio
            return _context.Users.Where(x => x.Id == id).SingleOrDefault();
        }

        public User Save(User user)
        {
            //deve retornar um usu�rio ap�s salvar os dados. 
            //Caso o Id seja zero, far� a inser��o do usu�rio, 
            //caso contr�rio far� a atualiza��o dos dados do usu�rio com o Id informado
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
