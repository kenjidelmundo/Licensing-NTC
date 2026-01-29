using LicensingAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace LicensingAPI.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        public DbSet<TechEODService> TechEODServices { get; set; }
        public DbSet<SOA> SOAs { get; set; }
        public DbSet<SOA_Details> SOA_Details { get; set; }

        public DbSet<CitizenCharterGroup> CitizenCharterGroups { get; set; }
        public DbSet<CitizenCharterStages> CitizenCharterStages { get; set; }
        public DbSet<CitizenCharterFormula> CitizenCharterFormulas { get; set; }
        public DbSet<Fees> Fees { get; set; }
        public DbSet<SUFRate> SUFRates { get; set; }
        public DbSet<TechService> TechServices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CitizenCharterGroup>()
                .HasKey(e => e.GroupId);

            modelBuilder.Entity<CitizenCharterStages>()
                .HasKey(e => e.StageId);

            modelBuilder.Entity<CitizenCharterFormula>()
                .HasKey(e => e.FormulaId);

            modelBuilder.Entity<Fees>()
                .HasKey(e => e.FeeId);

            modelBuilder.Entity<SUFRate>()
                .HasKey(e => e.SUFRateId);

            modelBuilder.Entity<TechService>()
                .HasKey(e => e.TechServiceId);

            modelBuilder.Entity<SOA>()
                .HasKey(e => e.SOAId);

            modelBuilder.Entity<SOA_Details>()
                .HasKey(e => e.SOADetailId);

            modelBuilder.Entity<TechEODService>()
                .HasKey(e => e.Id);

            base.OnModelCreating(modelBuilder);
        }

    }




}
