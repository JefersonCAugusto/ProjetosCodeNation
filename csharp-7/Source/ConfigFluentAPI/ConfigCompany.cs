using Codenation.Challenge.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Source.ConfigFluentAPI
{
    public class ConfigCompany : IEntityTypeConfiguration<Company>

    {
        public void Configure(EntityTypeBuilder<Company> modelBuilder)
        {
            modelBuilder.ToTable("company").HasKey(x => x.Id);
            modelBuilder.Property(x => x.Id).HasColumnName("id").IsRequired();
            modelBuilder.Property(x => x.Name).HasColumnName("name").IsRequired().HasMaxLength(100);
            modelBuilder.Property(x => x.Slug).HasColumnName("slug").IsRequired().HasMaxLength(50);
            modelBuilder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired().HasColumnType("timestamp");
            modelBuilder.HasMany(x => x.Candidates).WithOne(x => x.Company).HasForeignKey(x => x.CompanyId);
        }
    }
}
