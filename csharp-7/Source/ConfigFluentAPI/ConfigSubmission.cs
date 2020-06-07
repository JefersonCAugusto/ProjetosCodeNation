using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Codenation.Challenge.Models;
using System.Security.Cryptography.X509Certificates;

namespace Source.ConfigFluentAPI
{
    public class ConfigSubmission : IEntityTypeConfiguration<Submission>
    {
        public void Configure(EntityTypeBuilder<Submission> modelBuilder)
        {
            modelBuilder.ToTable("submission").HasKey(x => new { x.UserId, x.ChallengeId });
            modelBuilder.Property(x => x.UserId).HasColumnName("user_id").IsRequired();
            modelBuilder.Property(x => x.ChallengeId).HasColumnName("challenge_id").IsRequired();
            modelBuilder.Property(x => x.Score).HasColumnName("score").IsRequired();
            modelBuilder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();
        }
    }
}
