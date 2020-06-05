using Codenation.Challenge.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Source.Models
{   [Table("candidate")]
    public class Candidate
    {
        [Key]
        [Required]
        [Column("user_id")]
        public int UserId { get; set; }

        [Required]
        [Column("acceleration_id")]
        public int AccelerationId { get; set; }

        [Required]
        [Column("company_id")]
        public int CompanyId { get; set; }

        [Required]
        [Column("status")]
        public int Status { get; set; }

        [Required]
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        //chaves estrangeiras
        public ICollection<User> Users { get; set; }
        public ICollection<Acceleration> Accelerations { get; set; }
        public ICollection<Company> Companies { get; set; }


    }
}
