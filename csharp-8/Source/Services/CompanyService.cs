using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly CodenationContext _context;

        public CompanyService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Company> FindByAccelerationId(int accelerationId)
        {
            //deve retornar uma lista de empresas a partir do id da aceleração
            return _context.Candidates.Where(x => x.AccelerationId == accelerationId).Select(x => x.Company).ToList();
        }

        public Company FindById(int id)
        {
            //deve retornar uma empresa a partir do id da empresa
            return _context.Companies.Where(x => x.Id == id).Select(x => x).FirstOrDefault();

        }

        public IList<Company> FindByUserId(int userId)
        {
            //deve retornar uma lista de empresas a partir do id do usuário
            return _context.Candidates.Where(x => x.UserId == userId).Select(x => x.Company).ToList();
        }

        public Company Save(Company company)
        {//deve retorna uma empresa após salvar os dados. 
         //Caso o Id da instância não seja fornecido, 
         // fará a inserção da empresa, caso contrário fará a atualização dos dados da empresa com o Id informado
         //deve retornar um usuário após salvar os dados. Caso o Id seja zero, fará a inserção do usuário, 
         //caso contrário fará a atualização dos dados do usuário com o Id informado
            if( FindById(company.Id)==null)
            {
                _context.Companies.Add(company);
                _context.SaveChanges();
                return _context.Companies.Last(); 
            }
            else
            {
                var update = _context.Companies.Where(x => x.Id == company.Id).SingleOrDefault();
                update = company;
                _context.SaveChanges();
                return update; 
            }
        }
    }
}
