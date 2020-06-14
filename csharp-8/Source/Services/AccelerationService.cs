using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class AccelerationService : IAccelerationService
    {
        private readonly CodenationContext _context;

        public AccelerationService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Acceleration> FindByCompanyId(int companyId)
        {
            //deve retornar uma lista de acelera��es a partir do id da empresa
            return _context.Candidates.Where(x => x.CompanyId == companyId).Select(x => x.Acceleration).ToList();
        }

        public Acceleration FindById(int id)
        {
            // deve retornar uma acelera��o a partir do id da acelera��o
            return _context.Accelerations.Where(x => x.Id == id).SingleOrDefault();
        }

        public Acceleration Save(Acceleration acceleration)
        {//deve retornar uma acelera��o depois de salvar os dados. 
         //Caso o Id seja zero, far� a inser��o da acelera��o, 
         //caso contr�rio far� a atualiza��o dos dados da acelera��o com o Id informado
            if (acceleration.Id == 0)
            {
                _context.Accelerations.Add(acceleration);
                _context.SaveChanges();
                return _context.Accelerations.Last();
            }
            else
            {
                var update = _context.Accelerations.Where(x => x.Id == acceleration.Id).SingleOrDefault();
                update = acceleration;
                _context.SaveChanges();
                return update;
            }
        }
    }
}
