using JobEntryy.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobEntryy.Persistence.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Industry> Industries { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobDetail> JobDetails { get; set; }
        public DbSet<JobApplicationInfo> JobApplicationInfos { get; set; }
    }
}
