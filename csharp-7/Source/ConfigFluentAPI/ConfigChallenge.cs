using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Source.Models;
namespace Source.ConfigFluentAPI
{
    public class ConfigChallenge : IEntityTypeConfiguration<Challenge>
    {
        public void Configure(EntityTypeBuilder<Challenge> modelBuilder)
        {
            modelBuilder.ToTable("challenge").HasKey(x => x.Id);
            modelBuilder.Property(x => x.Id).HasColumnName("id").IsRequired();
            modelBuilder.Property(x => x.Name).HasColumnName("name").IsRequired().HasColumnType("varchar").HasMaxLength(100);
            modelBuilder.Property(x => x.Slug).HasColumnName("slug").IsRequired().HasColumnType("varchar").HasMaxLength(50);
            modelBuilder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired().
                HasColumnType("timestamp");

            //relacionamentos
            modelBuilder.HasMany(x => x.Accelerations).WithOne(x => x.Challenge).HasForeignKey(x => x.ChallengeId);//.IsRequired().HasForeignKey(x=>x.ChallengeId);
            modelBuilder.HasMany(x => x.Submissions).WithOne(x => x.Challenge).HasForeignKey(x => x.ChallengeId);//.IsRequired().HasForeignKey(x=>x.ChallengeId);

        }
    }
}