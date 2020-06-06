using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Source.ConfigFluentAPI
{
    public class ConfigUser : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> modelBuilder)
        {
            modelBuilder.ToTable("user").HasKey(x => x.Id);
            modelBuilder.Property(x => x.Id).HasColumnName("user").IsRequired();
            modelBuilder.Property(x => x.FullName).HasColumnName("full_name").IsRequired().HasMaxLength(100);
            modelBuilder.Property(x => x.Email).HasColumnName("email").IsRequired().HasMaxLength(100);
            modelBuilder.Property(x => x.NickName).HasColumnName("nickname").IsRequired().HasMaxLength(50);
            modelBuilder.Property(x => x.Password).HasColumnName("password").IsRequired().HasMaxLength(255);
            modelBuilder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired().HasColumnType("timestamp");
        }
    }
}
