using System;
namespace Codenation.Challenge.Models
{
    public class Submission
    {
        public int UserId { get; set; }
        public int ChallengeId { get; set; }
        public  decimal Score { get; set; }
        public DateTime CreatedAt { get; set; }
        #region// Navigation properties
        public User User { get; set; }
        public Codenation.Challenge.Models.Challenge Challenge { get; set; }
        #endregion
    }
}