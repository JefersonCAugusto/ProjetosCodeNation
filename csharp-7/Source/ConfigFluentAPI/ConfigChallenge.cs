using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Codenation.Challenge.Models;
namespace Source.ConfigFluentAPI
{
    public class ConfigChallenge : IEntityTypeConfiguration<Codenation.Challenge.Models.Challenge>
    {
        public void Configure(EntityTypeBuilder<Codenation.Challenge.Models.Challenge> modelBuilder)
        {
            modelBuilder.ToTable("challenge").HasKey(x => x.Id);
            modelBuilder.Property(x => x.Id).HasColumnName("id").IsRequired();
            modelBuilder.Property(x => x.Name).HasColumnName("name").IsRequired().HasMaxLength(100);
            modelBuilder.Property(x => x.Slug).HasColumnName("slug").IsRequired().HasMaxLength(50);
            modelBuilder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();
            modelBuilder.HasMany(x => x.Accelerations).WithOne(x => x.Challenge).HasForeignKey(x => x.ChallengeId);
            modelBuilder.HasMany(x => x.Submissions).WithOne(x => x.Challenge).HasForeignKey(x => x.ChallengeId);
        }
    }
}