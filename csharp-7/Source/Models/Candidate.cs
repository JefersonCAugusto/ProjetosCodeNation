using Codenation.Challenge.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Source.Models
{
    public class Candidate
    {
        public int UserId { get; set; }
        public int AccelerationId { get; set; }
        public int CompanyId { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }

        //Navigation Properties
       public User User { get; set; }
       public Acceleration Acceleration { get; set; }
       public Company Company { get; set; }

    }
}
