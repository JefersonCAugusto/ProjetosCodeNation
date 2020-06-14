using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class SubmissionService : ISubmissionService
    {
        private readonly CodenationContext _context;
        public SubmissionService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Submission> FindByChallengeIdAndAccelerationId(int challengeId, int accelerationId)
        {
            //deve retornar uma lista de submissões a partir do id do desafio e do id da aceleração
            return _context.Accelerations.Where(x => x.ChallengeId == challengeId && x.Id == accelerationId).
                Select(x => x.Challenge).SelectMany(x => x.Submissions).ToList();
            
        }

        public decimal FindHigherScoreByChallengeId(int challengeId)
        {
            //deve retornar o valor do maior score a partir do id do desafio
            return _context.Submissions
                        .Where(x => x.ChallengeId == challengeId)
                        .OrderByDescending(x => x.Score)
                        .FirstOrDefault()
                        .Score;
        }

        public Submission Save(Submission submission)
        {//deve retornar uma submissão após salvar os dados. Caso a tupla UserId e ChallengeId não exista, 
            //fará a inserção da submissão, caso contrário fará a atualização dos dados da submissão
            if(!(_context.Submissions.Any(x=>x.UserId==submission.UserId && x.ChallengeId==submission.ChallengeId))) //not exist 
            { 
                _context.Submissions.Add(submission);
                _context.SaveChanges();
                return _context.Submissions.Last();
            }
            else //exist
            {
                var update = _context.Submissions
                             .Where(x => x.UserId == submission.UserId && x.ChallengeId==submission.ChallengeId)
                             .SingleOrDefault();
                update = submission;
                _context.SaveChanges();
                return update;
            }
        }
    }
}
