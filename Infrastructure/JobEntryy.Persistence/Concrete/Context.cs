﻿using JobEntryy.Domain.Entities;
using JobEntryy.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobEntryy.Persistence.Concrete
{
    public class Context : IdentityDbContext<AppUser,AppRole,Guid>
    {
        public static string SqlConnection = "Server=DESKTOP-DQGN1O7;Database=JobEntryy;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true;Integrated Security=True;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(SqlConnection);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Industry> Industries { get; set; }
        public DbSet<CompanyIndustry> CompanyIndustries { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<UserPackage> UserPackages { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobDetail> JobDetails { get; set; }
        public DbSet<JobApplicationInfo> JobApplicationInfos { get; set; }
    }
}
