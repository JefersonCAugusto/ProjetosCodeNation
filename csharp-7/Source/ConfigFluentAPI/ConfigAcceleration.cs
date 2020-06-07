using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Codenation.Challenge.Models;
namespace Source.ConfigFluentAPI
{
    public class ConfigAcceleration : IEntityTypeConfiguration<Acceleration>
    {
        public void Configure(EntityTypeBuilder<Acceleration> modelBuilder)
        {
            modelBuilder.ToTable("acceleration").HasKey(x => x.Id);
            modelBuilder.Property(x => x.Id).HasColumnName("id").IsRequired();
            modelBuilder.Property(x => x.Name).HasColumnName("name").IsRequired().HasMaxLength(100);
            modelBuilder.Property(x => x.Slug).HasColumnName("slug").IsRequired().HasMaxLength(50);
            modelBuilder.Property(x => x.ChallengeId).HasColumnName("challenge_id").IsRequired();
            modelBuilder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();
            modelBuilder.HasMany(x => x.Candidates).WithOne(x => x.Acceleration).HasForeignKey(x => x.AccelerationId);
        }
    }
}
