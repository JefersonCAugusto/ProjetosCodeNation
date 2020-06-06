using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Source.Models;
namespace Source.ConfigFluentAPI
{
    public class ConfigCandidate : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> modelBuilder)
        {
            modelBuilder.ToTable("candidate").HasKey(x => x.UserId);
            modelBuilder.Property(x => x.Id).HasColumnName("user_id").IsRequired();
            modelBuilder.Property(x => x.AccelerationId).HasColumnName("acceleration_id").IsRequired();
            modelBuilder.Property(x => x.CompanyId).HasColumnName("company_id").IsRequired();
            modelBuilder.Property(x => x.Status).HasColumnName("status").IsRequired();
            modelBuilder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();

        }
    }
}
