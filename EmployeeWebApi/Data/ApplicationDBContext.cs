using EmployeeWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeWebApi.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
       : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<employee>().ToTable("Employee");
            modelBuilder.Entity<department>().ToTable("Departement");
            modelBuilder.Entity<location>().ToTable("Location");
            modelBuilder.Entity<job>().ToTable("Job");
            modelBuilder.Entity<job_history>().ToTable("HistoryJob");
            modelBuilder.Entity<countrie>().ToTable("Country");
            modelBuilder.Entity<region>().ToTable("Region");
        }

        #region Propriétes Navigations
        public DbSet<employee> Employees { get; set; }
        public DbSet<department> Departements { get; set; }
        public DbSet<location> Locations { get; set; }
        public DbSet<job> Jobs { get; set; }
        public DbSet<job_history> Histories { get; set; }
        public DbSet<countrie> Countries { get; set; }
        public DbSet<region>Regions { get; set; }
        #endregion

    }
}

