using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Source.Models
{
    [Table("challenge")]
    public class Challenge
    {
        [Required]
        [Column("id")]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        [Column("name")]
        public string Name { get; set; }

        [MaxLength(50)]
        [Required]
        [Column("slug")]
        public string Slug { get; set; }

        [Timestamp]
        [Required]
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        // Foreign key
        public int ChallengeId { get; set; }


        // Navigation properties
        public ICollection<Acceleration> Accelerations { get; set; }
        public ICollection<Submission> Submissions { get; set; }


    }
}
