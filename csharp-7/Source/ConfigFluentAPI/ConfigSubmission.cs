using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Source.Models;
namespace Source.ConfigFluentAPI
{
    public class ConfigSubmission : IEntityTypeConfiguration<Submission>
    {
        public void Configure(EntityTypeBuilder<Submission> modelBuilder)
        {
            modelBuilder.ToTable("submission").HasKey(x => x.UserId);
            modelBuilder.Property(x => x.User).HasColumnName("user_id").IsRequired();
            modelBuilder.Property(x => x.ChallengeId).HasColumnName("challenge_id").IsRequired();
            modelBuilder.Property(x => x.Score).HasColumnName("score").IsRequired();
            modelBuilder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();

        }
    }
}
