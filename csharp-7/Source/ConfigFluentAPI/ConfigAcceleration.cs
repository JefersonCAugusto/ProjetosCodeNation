using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Source.Models;
namespace Source.ConfigFluentAPI
{
    public class ConfigAcceleration : IEntityTypeConfiguration<Acceleration>
    {
        public void Configure(EntityTypeBuilder<Acceleration> modelBuilder)
        {
            modelBuilder.ToTable("aceleration").HasKey(x => x.Id);
            modelBuilder.Property(x => x.Id).HasColumnName("id").IsRequired();
            modelBuilder.Property(x => x.Name).HasColumnName("name").IsRequired().HasColumnType("varchar").HasMaxLength(100);
            modelBuilder.Property(x => x.Slug).HasColumnName("slug").IsRequired().HasColumnType("varchar").HasMaxLength(50);
            modelBuilder.Property(x => x.ChallengeId).HasColumnName("challenge_id").IsRequired();
            modelBuilder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired().HasColumnType("timestamp");

            //relacionamentos
            modelBuilder.HasMany(x => x.Candidates).WithOne(x => x.Acceleration).HasForeignKey(x => x.AccelerationId);



        }
    }
}
