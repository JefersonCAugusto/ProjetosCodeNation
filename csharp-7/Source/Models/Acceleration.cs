using System;
using System.Collections.Generic;

namespace Source.Models
{
    public class Acceleration
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public int ChallengeId { get; set; }
        public DateTime CreatedAt { get; set; }


        // Foreign key
        public int AccelerationId { get; set; }


        // Navigation properties

        public ICollection<Candidate> Candidates { get; set; }
        public Challenge Challenge { get; set; }




    }
}
