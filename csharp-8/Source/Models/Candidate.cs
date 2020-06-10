using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    [Table("candidate")]
    public class Candidate
    {
        [Column("user_id")]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Column("acceleration_id")]
        public int AccelerationId { get; set; }

        [ForeignKey("AccelerationId")]
        public virtual Acceleration Acceleration { get; set; }

        [Column("company_id")]
        public int CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }

        [Column("status")]
        [Required]
        public int Status { get; set; }

        [Column("created_at")]
        [Required]
        public DateTime CreatedAt { get; set; }

        public Candidate(int userId, User user, int accelerationId, Acceleration acceleration, int companyId, Company company, int status, DateTime createdAt)
        {
            UserId = userId;
            User = user;
            AccelerationId = accelerationId;
            Acceleration = acceleration;
            CompanyId = companyId;
            Company = company;
            Status = status;
            CreatedAt = createdAt;
        }
        public Candidate()
        {

        }
    }
}