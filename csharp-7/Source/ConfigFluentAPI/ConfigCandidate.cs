using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Codenation.Challenge.Models;
namespace Source.ConfigFluentAPI
{
    public class ConfigCandidate : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> modelBuilder)
        {
            modelBuilder.ToTable("candidate").HasKey(x => new { x.UserId, x.AccelerationId, x.CompanyId });
            modelBuilder.Property(x => x.UserId).HasColumnName("user_id").IsRequired();
            modelBuilder.Property(x => x.AccelerationId).HasColumnName("acceleration_id").IsRequired();
            modelBuilder.Property(x => x.CompanyId).HasColumnName("company_id").IsRequired();
            modelBuilder.Property(x => x.Status).HasColumnName("status").IsRequired();
            modelBuilder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();
        }
    }
}
