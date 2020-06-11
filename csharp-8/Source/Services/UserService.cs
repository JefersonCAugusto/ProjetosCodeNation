using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace Codenation.Challenge.Services
{
    public class UserService : IUserService
    {
        private CodenationContext _context;

        public UserService(CodenationContext context)
        {
            throw new System.NotImplementedException();
        }

        public IList<User> FindByAccelerationName(string name)
        {
            //deve retornar uma lista de usuários a partir do nome da aceleração
            var de= from d in _context.Accelerations

            throw new System.NotImplementedException();
        }

        public IList<User> FindByCompanyId(int companyId)
        {
            //deve retornar uma lista de usuários a relacionado com a empresa pelo id da empresa
            var candidate = from c in _context.Candidates
                            where c.CompanyId == companyId
                            select c;

            var user = from us in _context.Users
                       from ca in _context.Candidates
                       
                       on new {ca.CompanyId,} equals new {co.Id} into

                       
                     
                        
        }

        public  User FindById(int id)
        {
            return _context.Users.Where(x => x.Id == id).SingleOrDefault();
        }

        public User Save(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
