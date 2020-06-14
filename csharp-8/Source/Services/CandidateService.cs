using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly CodenationContext _context;

        public CandidateService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Candidate> FindByAccelerationId(int accelerationId)
        {
            //deve retornar uma lista de candidatos a partir do id da aceleração
            return _context.Candidates.Where(x => x.CompanyId == accelerationId).Select(x => x).ToList();

        }

        public IList<Candidate> FindByCompanyId(int companyId)
        {
            //eve retornar uma lista candidatos a partir do id da empresa
            return _context.Candidates.Where(x => x.CompanyId == companyId).Select(x => x).ToList();

        }

        public Candidate FindById(int userId, int accelerationId, int companyId)
        {
            //deve retornar um candidato a partir do id do usuário, do id da aceleração e do id da empresa
            return _context.Candidates.Where(x => x.AccelerationId == accelerationId &&
                   x.CompanyId == companyId && x.UserId == userId)
                   .FirstOrDefault();
        }

        public Candidate Save(Candidate candidate)
        {//deve retornar um candidato após salvar os dados. 
         //Caso a tupla UserId, AccelartionId e CompanyId não exista, fará a inserção do candidato, 
         //caso contrário fará a atualização dos dados do candidato
            if (!(_context.Candidates.Any(x => x.UserId == candidate.UserId &&
            x.AccelerationId == candidate.AccelerationId &&
            x.CompanyId == candidate.CompanyId))) //not exist 
            {
                _context.Candidates.Add(candidate);
                _context.SaveChanges();
                return _context.Candidates.Last();
            }
            else //exist
            {
                var update = _context.Candidates.Where(x => x.UserId == candidate.UserId &&
             x.AccelerationId == candidate.AccelerationId &&
             x.CompanyId == candidate.CompanyId).SingleOrDefault();
                update = candidate;
                _context.SaveChanges();
                return update;
            }
        }
    }
}
