using Source.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public string Slug { get; set; }
        public DateTime CreatedAt { get; set; }


        //foreignKey 
        public int CompanyId { get; set; }

        // Navigation properties
         public ICollection<Candidate>   Candidates { get; set; }
    }
}