using Source.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    [Table("company")]
    public class Company
    {
        [Key]
        [Column("id")]
        [Required]
        public int Id { get; set; }

        [MaxLength(100)]
        [Column("name")]
        [Required]
        public string  Name { get; set; }

        [MaxLength(50)]
        [Column("slug")]
        [Required]
        public string Slug { get; set; }

        [Timestamp]
        [Column("created_at")]
        [Required]
        public DateTime CreatedAt { get; set; }


        //foreignKey 
        //public int CompanyId { get; set; }

        // Navigation properties
        [ForeignKey("CompanyId")]
        public ICollection<Candidate>   Candidates { get; set; }
    }
}