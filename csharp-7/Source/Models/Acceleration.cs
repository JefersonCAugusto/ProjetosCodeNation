using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Source.Models
{
    [Table("acceleration")]
    public class Acceleration
    {
        [Key]
        [Required]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Column("slug")]
        [MaxLength(50)]
        public string Slug { get; set; }

        //foreignkey
        [Required]
        [Column("challenge_id")]
       // [ForeignKey("Challenge")]
        public int ChallengeId { get; set; }

        [Timestamp]
        [Required]
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }


        // Foreign key
        //public int AccelerationId { get; set; }


        // Navigation properties
        [ForeignKey("AccelerationId")]
        public ICollection<Candidate> Candidates { get; set; }
        [ForeignKey("Id")]
        public Challenge Challenge { get; set; }




    }
}
