using Microsoft.EntityFrameworkCore;
using Source.Models;

namespace Codenation.Challenge.Models
{
    public class CodenationContext : DbContext
    {
        public CodenationContext()
        {
        }


        //mapeamento das entidades
        public DbSet<Company> Companies { get; set; }
        public DbSet<Acceleration> Accelerations { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Source.Models.Challenge> Challenges { get; set; }
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<User> Users { get; set; }

        //string de conexao
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Codenation;Trusted_Connection=True");            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}