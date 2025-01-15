using JobsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JobsApi.Data 
{
    public class DataContext : DbContext 
    {
        private readonly IConfiguration _config;

        public DataContext(IConfiguration config)
        {
            _config = config;
        }

        public virtual DbSet<User> Users {get; set;}
        public virtual DbSet<Job> Jobs {get; set;}
        public virtual DbSet<Company> Companies {get; set;}


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"),
                    optionsBuilder => optionsBuilder.EnableRetryOnFailure());
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("JobsApiDatabaseSchema");

            modelBuilder.Entity<User>()
                .ToTable("Users", "JobsApiDatabaseSchema")
                .HasKey(u => u.UserId);

            modelBuilder.Entity<Job>()
                .ToTable("Jobs", "JobsApiDatabaseSchema")
                .HasKey(j => j.JobId);

            modelBuilder.Entity<Company>()
                .ToTable("Companies", "JobsApiDatabaseSchema")
                .HasKey(c => c.CompanyId);
        }
    }
}