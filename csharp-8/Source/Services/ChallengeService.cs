using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;
namespace Codenation.Challenge.Services
{
    public class ChallengeService : IChallengeService
    {
        private CodenationContext _context;

        public ChallengeService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Models.Challenge> FindByAccelerationIdAndUserId(int accelerationId, int userId)
        {
       //deve retornar uma lista de desafios a partir do id da aceleração e do id do usuário
            return _context.Candidates.Where(x => x.AccelerationId == accelerationId && x.UserId == userId)
                .Select(x => x.Acceleration).Select(x => x.Challenge).ToList();
        }

        public Models.Challenge Save(Models.Challenge challenge)
        {//deve retornar um desafio após salvar os dados. 
         //Caso o Id seja zero, fará a inserção da aceleração, 
         //caso contrário fará a atualização dos dados da aceleração com o Id fornecido.
            if (challenge.Id == 0)
            {
                _context.Challenges.Add(challenge);
                _context.SaveChanges();
                return _context.Challenges.Last();
            }
            else
            {
                var update = _context.Challenges.Where(x => x.Id == challenge.Id).SingleOrDefault();
                update = challenge;
                _context.SaveChanges();
                return update;
            }
        }
    }
}