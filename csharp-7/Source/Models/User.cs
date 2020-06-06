using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Source.Models
{
    [Table("user")]
    public class User
    {

        [Key]
        [Column("id")]
        public int Id { get; set; }


        [Required]
        [MaxLength(100)]
        [Column("full_name")]
        public string FullName { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("email")]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("nickname")]
        public string NickName { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("password")]
        public string Password { get; set; }

        [Timestamp]
        [Required]
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }


//foreignKey 
       // public int UserId { get; set; }

// Navigation properties
        [ForeignKey("UserId")]
        public ICollection<Candidate> Candidates { get; set; }
        [ForeignKey("UserId")]
        public ICollection<Submission> Submissions { get; set; }
    }
}

