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
        public int UserId { get; set; }     //depois tenta alterar essa propriedade para "Id" e apagar a referencia de foreignkey

        [Required]
        [Column("acceleration_id")]
        public int AccelerationId { get; set; }

        [Required]
        [Column("company_id")]
        public int CompanyId { get; set; }

        [Required]
        [Column("status")]
        public int Status { get; set; }

        [Timestamp]
        [Required]
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        //Foreign key
        public int Id { get; set; }

        //Navigation Properties
        public User User { get; set; }
        public Acceleration Acceleration { get; set; }
        public Company Company { get; set; }

    }
}
