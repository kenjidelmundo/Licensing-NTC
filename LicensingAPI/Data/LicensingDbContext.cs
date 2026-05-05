using Licensing.Entities;
using Microsoft.EntityFrameworkCore;

namespace LicensingAPI.Data
{
    public class LicensingDbContext : DbContext
    {
        public LicensingDbContext(DbContextOptions<LicensingDbContext> options)
            : base(options) { }

        // ✅ this is the only SOA header table you use
        public DbSet<TechSOA> accessSOA { get; set; }

        // ✅ WDN table - ADDED ONLY
        public DbSet<LicensingAPI.Entities.AccessWDN> accessWDN { get; set; }

        // ✅ KEEP all your other entities below (unchanged)
        public DbSet<TechSOADetails> tblSOADetails { get; set; }

        public DbSet<TechCCFormula> CitizenCharterFormula { get; set; }
        public DbSet<TechCCGroup> CitizenCharterGroup { get; set; }
        public DbSet<TechCCStages> CitizenCharterStages { get; set; }

        public DbSet<LicensingAPI.Entities.TechEODService> TechEODService { get; set; }

        public DbSet<TechFees> tblFees { get; set; }
        public DbSet<TechSUFRate> SUFRate { get; set; }
        public DbSet<TechService> TechService { get; set; }

        // keyless (keep yours if you have them)
        public DbSet<TechFeesNew> TechFeesNew { get; set; }
        public DbSet<TechFeesNewMod> TechFeesNewMod { get; set; }
        public DbSet<TechFeesRen> TechFeesRen { get; set; }
        public DbSet<TechFeesSUFRate> TechFeesSUFRate { get; set; }
        public DbSet<TechSurcharge> TechSurcharge { get; set; }
        public DbSet<TechFeesSurchargeRSL50> TechFeesSurchargeRSL50 { get; set; }
        public DbSet<TechFeesSurchargeRSL100> TechFeesSurchargeRSL100 { get; set; }

        // ✅ Address tables
        public DbSet<AddrProvince> AddrProvinces { get; set; }
        public DbSet<AddrMunicipality> AddrMunicipalities { get; set; }
        public DbSet<AddrBarangay> AddrBarangays { get; set; }
        public DbSet<AddrRegion> AddrRegions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ✅ OPTIONAL: force map to accessSOA (safe)
            modelBuilder.Entity<TechSOA>(e =>
            {
                e.ToTable("accessSOA", "dbo");
                e.HasKey(x => x.ID);
            });

            // ✅ WDN table mapping - ADDED ONLY
            modelBuilder.Entity<LicensingAPI.Entities.AccessWDN>(e =>
            {
                e.ToTable("accessWDN", "dbo");
                e.HasKey(x => x.ID);

                e.Property(x => x.ID)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                e.Property(x => x.Issued)
                    .HasColumnName("ISSUED");

                e.Property(x => x.PermitPre)
                    .HasColumnName("PERMIT_PRE")
                    .HasMaxLength(255);

                e.Property(x => x.PermitNo)
                    .HasColumnName("PERMIT_NO")
                    .HasMaxLength(255);

                e.Property(x => x.PermitYear)
                    .HasColumnName("PERMIT_YEAR")
                    .HasMaxLength(255);

                e.Property(x => x.LicenseStatus)
                    .HasColumnName("LICENSE_STATUS")
                    .HasMaxLength(255);

                e.Property(x => x.NameOfCompany)
                    .HasColumnName("NAME OF COMPANY")
                    .HasMaxLength(255);

                e.Property(x => x.Address)
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(255);

                e.Property(x => x.Validity)
                    .HasColumnName("VALIDITY");

                e.Property(x => x.Ece)
                    .HasColumnName("ECE")
                    .HasMaxLength(255);

                e.Property(x => x.OrNo)
                    .HasColumnName("O R NO")
                    .HasMaxLength(255);

                e.Property(x => x.Date)
                    .HasColumnName("DATE");

                e.Property(x => x.Amount)
                    .HasColumnName("AMOUNT")
                    .HasColumnType("money");

                e.Property(x => x.ScanLicense)
                    .HasColumnName("Scan License")
                    .HasColumnType("ntext");

                e.Property(x => x.TypeOfService)
                    .HasColumnName("TYPE_OF_SERVICE")
                    .HasMaxLength(255);

                e.Property(x => x.IssuanceAddress)
                    .HasColumnName("ISSUANCE_ADDRESS")
                    .HasMaxLength(255);

                e.Property(x => x.EngrAssigned)
                    .HasColumnName("ENGR_ASSIGNED")
                    .HasMaxLength(255);

                e.Property(x => x.EngrLicense)
                    .HasColumnName("ENGR_LICENSE")
                    .HasMaxLength(255);

                e.Property(x => x.EngrLicenseValidity)
                    .HasColumnName("ENGR_LICENSE_VALIDITY");

                e.Property(x => x.NameOfTechnician)
                    .HasColumnName("NAME_OF_TECHNICIAN")
                    .HasMaxLength(255);

                e.Property(x => x.Remarks)
                    .HasColumnName("REMARKS")
                    .HasMaxLength(255);

                e.Property(x => x.ValidFrom)
                    .HasColumnName("Valid From");

                e.Property(x => x.OldPermitNo)
                    .HasColumnName("OLD PERMIT NO")
                    .HasMaxLength(255);

                e.Property(x => x.Contact)
                    .HasColumnName("Contact")
                    .HasMaxLength(255);

                e.Property(x => x.Encoded)
                    .HasColumnName("Encoded")
                    .HasMaxLength(255);

                e.Property(x => x.AccountableForm)
                    .HasColumnName("AccountableForm")
                    .HasMaxLength(255);

                e.Property(x => x.DateInspected)
                    .HasColumnName("DateInspected")
                    .HasMaxLength(10);

                e.Property(x => x.InspectionMO)
                    .HasColumnName("InspectionMO")
                    .HasMaxLength(50);

                e.Property(x => x.AdminCase)
                    .HasColumnName("AdminCase")
                    .HasColumnType("ntext");

                e.Property(x => x.AdminCaseRemark)
                    .HasColumnName("AdminCaseRemark")
                    .HasColumnType("ntext");
            });

            // ✅ keep your other mappings as-is
            modelBuilder.Entity<TechSOADetails>(e =>
            {
                e.ToTable("tblSOADetails", "dbo");
                e.HasKey(x => x.ID);
            });

            modelBuilder.Entity<LicensingAPI.Entities.TechEODService>(e =>
            {
                e.ToTable("tblEODService", "dbo");
                e.HasKey(x => x.EODservicesID);
            });

            modelBuilder.Entity<TechCCGroup>(e =>
            {
                e.ToTable("tblCitizenCharterGroup", "dbo");
                e.HasKey(x => x.CitizenCharterGroupID);

                e.HasMany(x => x.TechCCFormula)
                 .WithOne(f => f.CitizenCharterGroup)
                 .HasForeignKey(f => f.CitizenCharterGroupID)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<TechCCFormula>(e =>
            {
                e.ToTable("tblCitizenCharterFormula", "dbo");
                e.HasKey(x => x.CitizenCharterComputeFeeID);
            });

            modelBuilder.Entity<TechCCStages>(e =>
            {
                e.ToTable("tblCitizenCharterStages", "dbo");
                e.HasKey(x => x.StagesID);
            });

            modelBuilder.Entity<TechFees>(e =>
            {
                e.ToTable("tblFees", "dbo");
                e.HasKey(x => x.ID);
            });

            modelBuilder.Entity<TechSUFRate>(e =>
            {
                e.ToTable("tblSUFRate", "dbo");
                e.HasKey(x => x.ID);
            });

            modelBuilder.Entity<TechService>(e =>
            {
                e.ToTable("tblTechService", "dbo");
                e.HasKey(x => x.TechServiceID);
            });

            // ============================
            // ✅ ADDRESS ONLY (NO OTHER CHANGES)
            // ============================

            modelBuilder.Entity<AddrProvince>(e =>
            {
                e.ToTable("dbo_addr_province", "dbo");
                e.HasKey(x => x.ProvinceId);
                e.Property(x => x.ProvinceId).HasColumnName("province_id");
                e.Property(x => x.RegionId).HasColumnName("region_id");
                e.Property(x => x.ProvinceName).HasColumnName("province_name");
            });

            modelBuilder.Entity<AddrMunicipality>(e =>
            {
                e.ToTable("dbo_addr_municipality", "dbo");
                e.HasKey(x => x.MunicipalityId);
                e.Property(x => x.MunicipalityId).HasColumnName("municipality_id");
                e.Property(x => x.ProvinceId).HasColumnName("province_id");
                e.Property(x => x.MunicipalityName).HasColumnName("municipality_name");
            });

            modelBuilder.Entity<AddrBarangay>(e =>
            {
                e.ToTable("dbo_addr_barangay", "dbo");
                e.HasKey(x => x.BarangayId);
                e.Property(x => x.BarangayId).HasColumnName("barangay_id");
                e.Property(x => x.MunicipalityId).HasColumnName("municipality_id");
                e.Property(x => x.BarangayName).HasColumnName("barangay_name");
                e.Property(x => x.Remark).HasColumnName("remark");
            });

            modelBuilder.Entity<AddrRegion>(e =>
            {
                e.ToTable("dbo_addr_region", "dbo");
                e.HasKey(x => x.RegionId);
                e.Property(x => x.RegionId).HasColumnName("region_id");
                e.Property(x => x.RegionName).HasColumnName("region_name");
                e.Property(x => x.RegionDescription).HasColumnName("region_description");
            });

            // Province -> Municipalities
            modelBuilder.Entity<AddrProvince>()
                .HasMany(p => p.Municipalities)
                .WithOne(m => m.Province)
                .HasForeignKey(m => m.ProvinceId)
                .HasPrincipalKey(p => p.ProvinceId)
                .OnDelete(DeleteBehavior.Restrict);

            // Municipality -> Barangays
            modelBuilder.Entity<AddrMunicipality>()
                .HasMany(m => m.Barangays)
                .WithOne(b => b.Municipality)
                .HasForeignKey(b => b.MunicipalityId)
                .HasPrincipalKey(m => m.MunicipalityId)
                .OnDelete(DeleteBehavior.Restrict);

            // ============================
            // ✅ keyless (yours)
            // ============================
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