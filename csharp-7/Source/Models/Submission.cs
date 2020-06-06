using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Source.Models
{
    [Table("submission")]
    public class Submission
    {
        [Required]
        [Key]
        [Column("id_user")]
        public int UserId { get; set; }


        [Required]
        [Column("challenge_id")]
        public int ChallengeId { get; set; }

        [Required]
        [Column("score")]
        public  Decimal Score { get; set; }

        [Timestamp]
        [Required]
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        //foreignKey 
        // public int Id { get; set; } 
        // Navigation properties
         public User User { get; set; }
         public Challenge Challenge { get; set; }

    }
}
