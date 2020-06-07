using Microsoft.EntityFrameworkCore;
using Source.Models;
using Source.ConfigFluentAPI;
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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Codenation;Trusted_Connection=True");            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ConfigAcceleration());


            modelBuilder.ApplyConfiguration(new ConfigCandidate());
           // modelBuilder.Entity<Candidate>().HasOne<User>(x => x.UserId).WithOne(x => x.Id).HasForeignkey<User>(x=>x.Id);

            modelBuilder.ApplyConfiguration(new ConfigChallenge());
            modelBuilder.ApplyConfiguration(new ConfigCompany());
            modelBuilder.ApplyConfiguration(new ConfigSubmission());
            modelBuilder.ApplyConfiguration(new ConfigUser());
            
        }
    }
}