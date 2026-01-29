using LicensingAPI.Entities;   // TechEODService
using Licensing.Entities;      // all other entities
using Microsoft.EntityFrameworkCore;

namespace LicensingAPI.Data
{
    public class LicensingDbContext : DbContext
    {
        public LicensingDbContext(DbContextOptions<LicensingDbContext> options)
            : base(options) { }

        // =========================
        // MAIN TABLES
        // =========================
        public DbSet<TechSOA> tblStatementOfAccount { get; set; }
        public DbSet<TechSOADetails> tblSOADetails { get; set; }

        public DbSet<TechCCFormula> CitizenCharterFormula { get; set; }
        public DbSet<TechCCGroup> CitizenCharterGroup { get; set; }
        public DbSet<TechCCStages> CitizenCharterStages { get; set; }

        public DbSet<TechEODService> TechEODService { get; set; }
        public DbSet<TechFees> tblFees { get; set; }
        public DbSet<TechSUFRate> SUFRate { get; set; }
        public DbSet<TechService> TechService { get; set; }

        // =========================
        // SCALAR FUNCTION RESULT SETS (KEYLESS)
        // =========================
        public DbSet<TechFeesNew> TechFeesNew { get; set; }
        public DbSet<TechFeesNewMod> TechFeesNewMod { get; set; }
        public DbSet<TechFeesRen> TechFeesRen { get; set; }

        public DbSet<TechFeesSUFRate> TechFeesSUFRate { get; set; }

        public DbSet<TechSurcharge> TechSurcharge { get; set; }
        public DbSet<TechFeesSurchargeRSL50> TechFeesSurchargeRSL50 { get; set; }
        public DbSet<TechFeesSurchargeRSL100> TechFeesSurchargeRSL100 { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // =========================
            // tblStatementOfAccount
            // =========================
            modelBuilder.Entity<TechSOA>(entity =>
            {
                entity.ToTable("tblStatementOfAccount", "dbo");
                entity.HasKey(x => x.SOAID);

                // Ensure collection is mapped
                entity.HasMany(x => x.TechSOADetails)
                      .WithOne(d => d.StatementOfAccount)
                      .HasForeignKey(d => d.SOAID)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // =========================
            // tblSOADetails
            // =========================
            modelBuilder.Entity<TechSOADetails>(entity =>
            {
                entity.ToTable("tblSOADetails", "dbo");
                entity.HasKey(x => x.ID);
            });

            // =========================
            // tblCitizenCharterGroup
            // =========================
            modelBuilder.Entity<TechCCGroup>(entity =>
            {
                entity.ToTable("tblCitizenCharterGroup", "dbo");
                entity.HasKey(x => x.CitizenCharterGroupID);

                entity.HasMany(x => x.TechCCFormula)
                      .WithOne(f => f.CitizenCharterGroup)
                      .HasForeignKey(f => f.CitizenCharterGroupID)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // =========================
            // tblCitizenCharterFormula
            // =========================
            modelBuilder.Entity<TechCCFormula>(entity =>
            {
                entity.ToTable("tblCitizenCharterFormula", "dbo");
                entity.HasKey(x => x.CitizenCharterComputeFeeID);

                // IMPORTANT: use real DB column names
                entity.Property(x => x.CitizenCharterComputeFeeID).HasColumnName("CitizenCharterComputeFeeID");
                entity.Property(x => x.CitizenCharterGroupID).HasColumnName("CitizenCharterGroupID");
                entity.Property(x => x.Title).HasColumnName("Title");
                entity.Property(x => x.Formula).HasColumnName("Formula");
                entity.Property(x => x.Legend).HasColumnName("Legend");
                entity.Property(x => x.Notes).HasColumnName("Notes");
            });

            // =========================
            // tblCitizenCharterStages
            // =========================
            modelBuilder.Entity<TechCCStages>(entity =>
            {
                entity.ToTable("tblCitizenCharterStages", "dbo");
                entity.HasKey(x => x.StagesID);
            });

            // =========================
            // tblEODService
            // =========================
            modelBuilder.Entity<TechEODService>(entity =>
            {
                entity.ToTable("tblEODService", "dbo");
                entity.HasKey(x => x.EODservicesID);
            });

            // =========================
            // tblFees
            // =========================
            modelBuilder.Entity<TechFees>(entity =>
            {
                entity.ToTable("tblFees", "dbo");
                entity.HasKey(x => x.ID);
            });

            // =========================
            // tblSUFRate
            // =========================
            modelBuilder.Entity<TechSUFRate>(entity =>
            {
                entity.ToTable("tblSUFRate", "dbo");
                entity.HasKey(x => x.ID);
            });

            // =========================
            // tblTechService
            // =========================
            modelBuilder.Entity<TechService>(entity =>
            {
                entity.ToTable("tblTechService", "dbo");
                entity.HasKey(x => x.TechServiceID);
            });

            // =========================
            // KEYLESS FUNCTION RESULTS (NOT TABLES)
            // =========================
            modelBuilder.Entity<TechFeesNew>().HasNoKey().ToView(null);
            modelBuilder.Entity<TechFeesNewMod>().HasNoKey().ToView(null);
            modelBuilder.Entity<TechFeesRen>().HasNoKey().ToView(null);

            modelBuilder.Entity<TechFeesSUFRate>().HasNoKey().ToView(null);

            modelBuilder.Entity<TechSurcharge>().HasNoKey().ToView(null);
            modelBuilder.Entity<TechFeesSurchargeRSL50>().HasNoKey().ToView(null);
            modelBuilder.Entity<TechFeesSurchargeRSL100>().HasNoKey().ToView(null);
        }
    }
}
