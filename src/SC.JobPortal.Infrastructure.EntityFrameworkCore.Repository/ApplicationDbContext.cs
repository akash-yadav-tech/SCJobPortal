using Microsoft.EntityFrameworkCore;
using SC.JobPortal.Core.Configuration;
using SC.JobPortal.Core.Models;
using HardModel = SC.JobPortal.Infrastructure.EntityFrameworkCore.Models;
using System;

namespace SC.JobPortal.Infrastructure.EntityFrameworkCore.Repository
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IApplicationSettingsProvider _applicationSettingsProvider;
        public ApplicationDbContext(IApplicationSettingsProvider applicationSettingsProvider)
        {
            _applicationSettingsProvider = applicationSettingsProvider;
        }

        public ApplicationDbContext()
        {   
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            // var applicationConnectionString = _applicationSettingsProvider.Get<string>(ApplicationSettingKey.ApplicationConnectionString);

            // hardcode connection string while creating migration. On Prodcutions DB will be created from SQl Scripts.
            var applicationConnectionString = @"Data Source = .; Initial Catalog = scjobportal; Trusted_Connection=True;";
            // define the database to use
            optionsBuilder.UseSqlServer(applicationConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HardModel.JobApplication>().HasKey(jobApplication => new { jobApplication.CandidateId, jobApplication.JobId });
            modelBuilder.Entity<HardModel.Job>().HasData(
            new { Id = 1,Description = ".Net Core Developer" },
            new { Id = 2, Description = "Python Developer" },
            new { Id = 3, Description = "Database Administrator" },
            new { Id = 4, Description = "SQL Developer" });
        }

        public DbSet<HardModel.Job> Jobs { get; set; }
        public DbSet<HardModel.JobApplication> JobApplications { get; set; }
        public DbSet<HardModel.Candidate> Candidates { get; set; }
    }
}
