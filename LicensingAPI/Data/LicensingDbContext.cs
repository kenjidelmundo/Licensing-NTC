using Licensing.Entities;
using Microsoft.EntityFrameworkCore;

namespace LicensingAPI.Data
{
    public class LicensingDbContext : DbContext
    {
        public LicensingDbContext(DbContextOptions<LicensingDbContext> options)
            : base(options) { }

        // ============================
        // ACCESS / LICENSE TABLES
        // ============================

        public DbSet<TechSOA> accessSOA { get; set; }

        public DbSet<LicensingAPI.Entities.AccessWDN> accessWDN { get; set; }

        public DbSet<LicensingAPI.Entities.AccessDTH> accessDTH { get; set; }

        public DbSet<LicensingAPI.Entities.AccessMPSC> accessMPSC { get; set; }

        public DbSet<LicensingAPI.Entities.AccessMPDP> accessMPDP { get; set; }

        public DbSet<LicensingAPI.Entities.AccessPermitTransport> accessPermitTransport { get; set; }

        public DbSet<LicensingAPI.Entities.AccessPermitSellTransfer> accessPermitSellTransfer { get; set; }

        public DbSet<LicensingAPI.Entities.AccessGROC> accessGROC { get; set; }

        public DbSet<LicensingAPI.Entities.AccessRLM> accessRLM { get; set; }

        public DbSet<LicensingAPI.Entities.AccessROC> accessROC { get; set; }

        public DbSet<LicensingAPI.Entities.AccessSROP> accessSROP { get; set; }

        public DbSet<LicensingAPI.Entities.AccessAmateurFull> accessAmateurFull { get; set; }

        public DbSet<LicensingAPI.Entities.AccessPermitPossess> accessPermitPossess { get; set; }

        public DbSet<LicensingAPI.Entities.AccessPermitPurchase> accessPermitPurchase { get; set; }

        // ✅ NEWLY ADDED: Marine SL
        public DbSet<LicensingAPI.Entities.AccessMarineSL> accessMarineSL { get; set; }

        // ============================
        // SOA / FEES / CITIZEN CHARTER
        // ============================

        public DbSet<TechSOADetails> tblSOADetails { get; set; }

        public DbSet<TechCCFormula> CitizenCharterFormula { get; set; }

        public DbSet<TechCCGroup> CitizenCharterGroup { get; set; }

        public DbSet<TechCCStages> CitizenCharterStages { get; set; }

        public DbSet<LicensingAPI.Entities.TechEODService> TechEODService { get; set; }

        public DbSet<TechFees> tblFees { get; set; }

        public DbSet<TechSUFRate> SUFRate { get; set; }

        public DbSet<TechService> TechService { get; set; }

        // ============================
        // KEYLESS QUERY MODELS
        // ============================

        public DbSet<TechFeesNew> TechFeesNew { get; set; }

        public DbSet<TechFeesNewMod> TechFeesNewMod { get; set; }

        public DbSet<TechFeesRen> TechFeesRen { get; set; }

        public DbSet<TechFeesSUFRate> TechFeesSUFRate { get; set; }

        public DbSet<TechSurcharge> TechSurcharge { get; set; }

        public DbSet<TechFeesSurchargeRSL50> TechFeesSurchargeRSL50 { get; set; }

        public DbSet<TechFeesSurchargeRSL100> TechFeesSurchargeRSL100 { get; set; }

        // ============================
        // ADDRESS TABLES
        // ============================

        public DbSet<AddrProvince> AddrProvinces { get; set; }

        public DbSet<AddrMunicipality> AddrMunicipalities { get; set; }

        public DbSet<AddrBarangay> AddrBarangays { get; set; }

        public DbSet<AddrRegion> AddrRegions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ============================
            // SOA
            // ============================

            modelBuilder.Entity<TechSOA>(e =>
            {
                e.ToTable("accessSOA", "dbo");
                e.HasKey(x => x.ID);
            });

            // ============================
            // WDN
            // ============================

            modelBuilder.Entity<LicensingAPI.Entities.AccessWDN>(e =>
            {
                e.ToTable("accessWDN", "dbo");
                e.HasKey(x => x.ID);

                e.Property(x => x.ID).HasColumnName("ID").ValueGeneratedNever();
                e.Property(x => x.Amount).HasColumnName("AMOUNT").HasColumnType("money");
                e.Property(x => x.ScanLicense).HasColumnName("Scan License").HasColumnType("ntext");
                e.Property(x => x.AdminCase).HasColumnName("AdminCase").HasColumnType("ntext");
                e.Property(x => x.AdminCaseRemark).HasColumnName("AdminCaseRemark").HasColumnType("ntext");
            });

            // ============================
            // DTH
            // ============================

            modelBuilder.Entity<LicensingAPI.Entities.AccessDTH>(e =>
            {
                e.ToTable("accessDTH", "dbo");
                e.HasKey(x => x.ID);

                e.Property(x => x.ID).HasColumnName("ID").ValueGeneratedNever();
                e.Property(x => x.Amount).HasColumnName("AMOUNT").HasColumnType("numeric(18,2)");
                e.Property(x => x.ScanLicense).HasColumnName("Scan License").HasColumnType("nvarchar(max)");
                e.Property(x => x.AdminCaseRemark).HasColumnName("AdminCaseRemark").HasColumnType("nvarchar(max)");
                e.Property(x => x.Amount2).HasColumnName("AMOUNT2").HasColumnType("numeric(18,2)");
                e.Property(x => x.RowVer).HasColumnName("RowVer").IsRowVersion();
            });

            // ============================
            // MPSC
            // ============================

            modelBuilder.Entity<LicensingAPI.Entities.AccessMPSC>(e =>
            {
                e.ToTable("accessMPSC", "dbo");
                e.HasKey(x => x.ID);

                e.Property(x => x.ID).HasColumnName("ID").ValueGeneratedNever();
                e.Property(x => x.OfficialReceipt).HasColumnName("Official Receipt").HasColumnType("numeric(18,2)");
                e.Property(x => x.Amount).HasColumnName("Amount").HasColumnType("numeric(18,2)");
                e.Property(x => x.Amount2).HasColumnName("Amount2").HasColumnType("numeric(18,2)");
                e.Property(x => x.AdminCaseRemark).HasColumnName("AdminCaseRemark").HasColumnType("nvarchar(max)");
                e.Property(x => x.RowVer).HasColumnName("RowVer").IsRowVersion();
            });

            // ============================
            // MPDP
            // ============================

            modelBuilder.Entity<LicensingAPI.Entities.AccessMPDP>(e =>
            {
                e.ToTable("accessMPDP", "dbo");
                e.HasKey(x => x.ID);

                e.Property(x => x.ID).HasColumnName("ID").ValueGeneratedNever();
                e.Property(x => x.OfficialReceipt).HasColumnName("OFFICIAL RECEIPT").HasColumnType("numeric(18,2)");
                e.Property(x => x.Amount2).HasColumnName("Amount2").HasColumnType("numeric(18,2)");
                e.Property(x => x.AdminCaseRemark).HasColumnName("AdminCaseRemark").HasColumnType("nvarchar(max)");
                e.Property(x => x.RowVer).HasColumnName("RowVer").IsRowVersion();
            });

            // ============================
            // PERMIT TRANSPORT
            // ============================

            modelBuilder.Entity<LicensingAPI.Entities.AccessPermitTransport>(e =>
            {
                e.ToTable("accessPermitTransport", "dbo");
                e.HasKey(x => x.ID);

                e.Property(x => x.ID).HasColumnName("ID").ValueGeneratedNever();
                e.Property(x => x.OfficialReceipt).HasColumnName("Official Receipt").HasColumnType("decimal(18,0)");
                e.Property(x => x.Amount).HasColumnName("Amount").HasColumnType("money");
            });

            // ============================
            // PERMIT SELL TRANSFER
            // ============================

            modelBuilder.Entity<LicensingAPI.Entities.AccessPermitSellTransfer>(e =>
            {
                e.ToTable("accessPermitSellTransfer", "dbo");
                e.HasKey(x => x.ID);

                e.Property(x => x.ID).HasColumnName("ID").ValueGeneratedNever();
                e.Property(x => x.OfficialReceipt).HasColumnName("Official Receipt").HasColumnType("decimal(18,0)");
                e.Property(x => x.Amount).HasColumnName("Amount").HasColumnType("money");
            });

            // ============================
            // GROC
            // ============================

            modelBuilder.Entity<LicensingAPI.Entities.AccessGROC>(e =>
            {
                e.ToTable("accessGROC", "dbo");
                e.HasKey(x => x.ID);

                e.Property(x => x.ID).HasColumnName("ID").ValueGeneratedNever();
                e.Property(x => x.Amount).HasColumnName("AMOUNT").HasColumnType("money");
                e.Property(x => x.Amount2).HasColumnName("AMOUNT2").HasColumnType("money");
                e.Property(x => x.AdminCaseRemark).HasColumnName("AdminCaseRemark").HasColumnType("ntext");
                e.Property(x => x.CertOfCompletionSerialGROC)
                    .HasColumnName("CertOfCompletionSerialGROC")
                    .HasColumnType("varchar(255)");
                e.Property(x => x.RowVer).HasColumnName("RowVer").IsRowVersion();
            });

            // ============================
            // RLM
            // ============================

            modelBuilder.Entity<LicensingAPI.Entities.AccessRLM>(e =>
            {
                e.ToTable("accessRLM", "dbo");
                e.HasKey(x => x.ID);

                e.Property(x => x.ID).HasColumnName("ID").ValueGeneratedOnAdd();
                e.Property(x => x.Amount).HasColumnName("Amount").HasColumnType("money");
                e.Property(x => x.Amount2).HasColumnName("Amount2").HasColumnType("money");
            });

            // ============================
            // ROC
            // ============================

            modelBuilder.Entity<LicensingAPI.Entities.AccessROC>(e =>
            {
                e.ToTable("accessROC", "dbo");
                e.HasKey(x => x.ID);

                e.Property(x => x.ID).HasColumnName("ID").ValueGeneratedNever();
                e.Property(x => x.Amount).HasColumnName("AMOUNT").HasColumnType("money");
                e.Property(x => x.Amount2).HasColumnName("AMOUNT2").HasColumnType("money");
                e.Property(x => x.AdminCase).HasColumnName("AdminCase").HasColumnType("ntext");
                e.Property(x => x.AdminCaseRemark).HasColumnName("AdminCaseRemark").HasColumnType("ntext");
                e.Property(x => x.RowVer).HasColumnName("RowVer").IsRowVersion();
            });

            // ============================
            // SROP
            // ============================

            modelBuilder.Entity<LicensingAPI.Entities.AccessSROP>(e =>
            {
                e.ToTable("accessSROP", "dbo");
                e.HasKey(x => x.ID);

                e.Property(x => x.ID).HasColumnName("ID").ValueGeneratedNever();
                e.Property(x => x.Amount).HasColumnName("AMOUNT").HasColumnType("money");
                e.Property(x => x.Amount2).HasColumnName("AMOUNT2").HasColumnType("money");
                e.Property(x => x.CertOfCompletionSerialSROP)
                    .HasColumnName("CertOfCompletionSerialSROP")
                    .HasColumnType("varchar(255)");
                e.Property(x => x.RowVer).HasColumnName("RowVer").IsRowVersion();
            });

            // ============================
            // AMATEUR FULL
            // ============================

            modelBuilder.Entity<LicensingAPI.Entities.AccessAmateurFull>(e =>
            {
                e.ToTable("accessAmateurFull", "dbo");
                e.HasKey(x => x.ID);

                e.Property(x => x.ID).HasColumnName("ID").ValueGeneratedOnAdd();

                e.Property(x => x.Amount).HasColumnName("AMOUNT").HasColumnType("numeric(18,2)");
                e.Property(x => x.Elem2).HasColumnName("ELEM2").HasColumnType("numeric(18,2)");
                e.Property(x => x.Elem3).HasColumnName("ELEM3").HasColumnType("numeric(18,2)");
                e.Property(x => x.Elem4).HasColumnName("ELEM4").HasColumnType("numeric(18,2)");
                e.Property(x => x.Elem5).HasColumnName("ELEM5").HasColumnType("numeric(18,2)");
                e.Property(x => x.Elem6).HasColumnName("ELEM6").HasColumnType("numeric(18,2)");
                e.Property(x => x.Elem7).HasColumnName("ELEM7").HasColumnType("numeric(18,2)");
                e.Property(x => x.Serial).HasColumnName("SERIAL").HasColumnType("numeric(18,2)");
                e.Property(x => x.LastModified).HasColumnName("LAST MODIFIED").HasMaxLength(10);
                e.Property(x => x.RowVer).HasColumnName("RowVer").IsRowVersion();
            });

            // ============================
            // PERMIT POSSESS
            // ============================

            modelBuilder.Entity<LicensingAPI.Entities.AccessPermitPossess>(e =>
            {
                e.ToTable("accessPermitPossess", "dbo");
                e.HasKey(x => x.ID);

                e.Property(x => x.ID).HasColumnName("ID").ValueGeneratedNever();

                e.Property(x => x.PermitNo).HasColumnName("PERMIT NO").HasMaxLength(255);
                e.Property(x => x.Applicant).HasColumnName("APPLICANT").HasMaxLength(255);
                e.Property(x => x.Address).HasColumnName("ADDRESS").HasMaxLength(255);

                e.Property(x => x.MakeModelType1).HasColumnName("MAKE/MODEL/TYPE 1").HasMaxLength(255);
                e.Property(x => x.MakeModelType2).HasColumnName("MAKE/MODEL/TYPE 2").HasMaxLength(255);
                e.Property(x => x.MakeModelType3).HasColumnName("MAKE/MODEL/TYPE 3").HasMaxLength(255);
                e.Property(x => x.MakeModelType4).HasColumnName("MAKE/MODEL/TYPE 4").HasMaxLength(255);
                e.Property(x => x.MakeModelType5).HasColumnName("MAKE/MODEL/TYPE 5").HasMaxLength(255);
                e.Property(x => x.MakeModelType6).HasColumnName("MAKE/MODEL/TYPE 6").HasMaxLength(255);
                e.Property(x => x.MakeModelType7).HasColumnName("MAKE/MODEL/TYPE 7").HasMaxLength(255);
                e.Property(x => x.MakeModelType8).HasColumnName("MAKE/MODEL/TYPE 8").HasMaxLength(255);
                e.Property(x => x.MakeModelType9).HasColumnName("MAKE/MODEL/TYPE 9").HasMaxLength(255);
                e.Property(x => x.MakeModelType10).HasColumnName("MAKE/MODEL/TYPE 10").HasMaxLength(255);

                e.Property(x => x.NoOfUnits).HasColumnName("No Of Units").HasMaxLength(255);
                e.Property(x => x.Fx).HasColumnName("FX");
                e.Property(x => x.Fb).HasColumnName("FB");
                e.Property(x => x.FxAndFb).HasColumnName("FX and FB");
                e.Property(x => x.Ml).HasColumnName("ML");
                e.Property(x => x.P).HasColumnName("P");
                e.Property(x => x.Repeater).HasColumnName("Repeater");

                e.Property(x => x.Serial1).HasColumnName("Serial 1").HasMaxLength(255);
                e.Property(x => x.Serial2).HasColumnName("Serial 2").HasMaxLength(255);
                e.Property(x => x.Serial3).HasColumnName("Serial 3").HasMaxLength(255);
                e.Property(x => x.Serial4).HasColumnName("Serial 4").HasMaxLength(255);
                e.Property(x => x.Serial5).HasColumnName("Serial 5").HasMaxLength(255);
                e.Property(x => x.Serial6).HasColumnName("Serial 6").HasMaxLength(255);
                e.Property(x => x.Serial7).HasColumnName("Serial 7").HasMaxLength(255);
                e.Property(x => x.Serial8).HasColumnName("Serial 8").HasMaxLength(255);
                e.Property(x => x.Serial9).HasColumnName("Serial 9").HasMaxLength(255);
                e.Property(x => x.Serial10).HasColumnName("Serial 10").HasMaxLength(255);
                e.Property(x => x.Serial11).HasColumnName("Serial 11").HasMaxLength(255);
                e.Property(x => x.Serial12).HasColumnName("Serial 12").HasMaxLength(255);
                e.Property(x => x.Serial13).HasColumnName("Serial 13").HasMaxLength(255);
                e.Property(x => x.Serial14).HasColumnName("Serial 14").HasMaxLength(255);
                e.Property(x => x.Serial15).HasColumnName("Serial 15").HasMaxLength(255);
                e.Property(x => x.Serial16).HasColumnName("Serial 16").HasMaxLength(255);
                e.Property(x => x.Serial17).HasColumnName("Serial 17").HasMaxLength(255);
                e.Property(x => x.Serial18).HasColumnName("Serial 18").HasMaxLength(255);
                e.Property(x => x.Serial19).HasColumnName("Serial 19").HasMaxLength(255);
                e.Property(x => x.Serial20).HasColumnName("Serial 20").HasMaxLength(255);
                e.Property(x => x.Serial21).HasColumnName("Serial 21").HasMaxLength(255);
                e.Property(x => x.Serial22).HasColumnName("Serial 22").HasMaxLength(255);
                e.Property(x => x.Serial23).HasColumnName("Serial 23").HasMaxLength(255);
                e.Property(x => x.Serial24).HasColumnName("Serial 24").HasMaxLength(255);
                e.Property(x => x.Serial25).HasColumnName("Serial 25").HasMaxLength(255);

                e.Property(x => x.FrequencyRange).HasColumnName("Frequency Range").HasMaxLength(255);
                e.Property(x => x.RfPowerOutput).HasColumnName("RF Power Output").HasMaxLength(255);
                e.Property(x => x.SourceOfEquipment).HasColumnName("Source of Equipment").HasMaxLength(255);
                e.Property(x => x.AddressOfSource).HasColumnName("Address of Source").HasMaxLength(255);
                e.Property(x => x.PermitToPurchaseRegistrationNo)
                    .HasColumnName("Permit to Purchase/Registration No")
                    .HasMaxLength(255);
                e.Property(x => x.PlaceOfStorage).HasColumnName("Place of Storage").HasMaxLength(255);
                e.Property(x => x.Intended).HasColumnName("Intended").HasMaxLength(255);

                e.Property(x => x.DateProcessed).HasColumnName("Date Processed");
                e.Property(x => x.PossessFee).HasColumnName("PossessFee").HasColumnType("money");
                e.Property(x => x.OfficialReceipt).HasColumnName("Official Receipt").HasColumnType("decimal(18,0)");
                e.Property(x => x.Date).HasColumnName("Date");
                e.Property(x => x.Encoded).HasColumnName("Encoded").HasMaxLength(255);
                e.Property(x => x.ApprovingOfficer).HasColumnName("Approving Officer").HasMaxLength(255);

                e.Property(x => x.FillingFee).HasColumnName("FillingFee").HasColumnType("money");
                e.Property(x => x.DocStamp).HasColumnName("DocStamp").HasColumnType("money");
                e.Property(x => x.TotalAmount).HasColumnName("TotalAmount").HasColumnType("money");
                e.Property(x => x.TotalPossessFee).HasColumnName("TotalPossessFee").HasColumnType("money");

                e.Property(x => x.CityMunicipality).HasColumnName("CityMunicipality").HasMaxLength(255);
                e.Property(x => x.Province).HasColumnName("Province").HasMaxLength(255);
                e.Property(x => x.CallSign).HasColumnName("CALL-SIGN").HasMaxLength(255);
                e.Property(x => x.UnitCount).HasColumnName("UnitCount");
            });

            // ============================
            // PERMIT PURCHASE
            // ============================

            modelBuilder.Entity<LicensingAPI.Entities.AccessPermitPurchase>(e =>
            {
                e.ToTable("accessPermitPurchase", "dbo");
                e.HasKey(x => x.ID);

                e.Property(x => x.ID).HasColumnName("ID").ValueGeneratedNever();

                e.Property(x => x.PermitNo).HasColumnName("PERMIT NO").HasMaxLength(255);
                e.Property(x => x.Applicant).HasColumnName("APPLICANT").HasMaxLength(255);
                e.Property(x => x.Address).HasColumnName("ADDRESS").HasMaxLength(255);
                e.Property(x => x.DateProcessed).HasColumnName("Date Processed");
                e.Property(x => x.Model).HasColumnName("Model").HasMaxLength(255);
                e.Property(x => x.NoOfUnits).HasColumnName("No Of Units").HasMaxLength(255);
                e.Property(x => x.FrequencyRange).HasColumnName("Frequency Range").HasMaxLength(255);
                e.Property(x => x.RfPowerOutput).HasColumnName("RF Power Output").HasMaxLength(255);
                e.Property(x => x.OfficialReceipt).HasColumnName("Official Receipt").HasColumnType("decimal(18,0)");
                e.Property(x => x.Amount).HasColumnName("Amount").HasColumnType("money");
                e.Property(x => x.Date).HasColumnName("Date");
                e.Property(x => x.Encoded).HasColumnName("Encoded").HasMaxLength(255);
                e.Property(x => x.Released).HasColumnName("Released");
                e.Property(x => x.ApprovingOfficer).HasColumnName("Approving Officer").HasMaxLength(255);
                e.Property(x => x.FrequencyAssignment).HasColumnName("Frequency Assignment").HasMaxLength(255);
                e.Property(x => x.ForNew).HasColumnName("For new").HasMaxLength(255);
                e.Property(x => x.Additional).HasColumnName("Additional").HasMaxLength(255);
                e.Property(x => x.Others).HasColumnName("Others").HasMaxLength(255);
                e.Property(x => x.Validity).HasColumnName("Validity");
                e.Property(x => x.Extension).HasColumnName("Extension");
                e.Property(x => x.Position).HasColumnName("Position").HasMaxLength(255);
                e.Property(x => x.NewRadio).HasColumnName("New Radio").HasMaxLength(255);
                e.Property(x => x.AdditionalRadio).HasColumnName("Additional Radio").HasMaxLength(255);
                e.Property(x => x.UnitCount).HasColumnName("UnitCount");
            });

            // ============================
            // MARINE SL - NEWLY ADDED
            // ============================

            modelBuilder.Entity<LicensingAPI.Entities.AccessMarineSL>(e =>
            {
                e.ToTable("accessMarineSL", "dbo");
                e.HasKey(x => x.ID);

                e.Property(x => x.ID).HasColumnName("ID").ValueGeneratedNever();

                e.Property(x => x.Serial).HasColumnName("Serial");
                e.Property(x => x.Issued).HasColumnName("Issued");
                e.Property(x => x.EncodedBy).HasColumnName("Encoded by").HasMaxLength(255);
                e.Property(x => x.ReleaseDate).HasColumnName("Release Date");
                e.Property(x => x.OldLicenseNo).HasColumnName("Old License No").HasMaxLength(255);
                e.Property(x => x.NewLicenceNo).HasColumnName("New Licence No").HasMaxLength(255);
                e.Property(x => x.ValidityFrom).HasColumnName("Validity From");
                e.Property(x => x.ValidityTo).HasColumnName("Validity To");
                e.Property(x => x.NameOfShip).HasColumnName("Name of Ship").HasMaxLength(255);
                e.Property(x => x.CallSign).HasColumnName("Call Sign").HasMaxLength(255);
                e.Property(x => x.Owner).HasColumnName("Owner").HasMaxLength(255);
                e.Property(x => x.PublicCorrespondence).HasColumnName("Public Correspondence").HasMaxLength(255);

                e.Property(x => x.MtxFreqBand).HasColumnName("MTX Freq Band").HasMaxLength(255);
                e.Property(x => x.MtxTypeMakeModel).HasColumnName("MTX type make model").HasMaxLength(255);
                e.Property(x => x.MtxSerialNumber).HasColumnName("MTX Serial Number").HasMaxLength(255);
                e.Property(x => x.MtxRange).HasColumnName("MTX Range").HasMaxLength(255);
                e.Property(x => x.MtxPower).HasColumnName("MTX Power");
                e.Property(x => x.MtxClassOfEmission).HasColumnName("MTX Class of Emission").HasMaxLength(255);
                e.Property(x => x.MtxAssignedFreq).HasColumnName("MTX Assigned Freq").HasMaxLength(255);

                e.Property(x => x.EtxFreqBand).HasColumnName("ETX Freq Band").HasMaxLength(255);
                e.Property(x => x.EtxTypeMakeModel).HasColumnName("ETX type make model").HasMaxLength(255);
                e.Property(x => x.EtxSerialNumber).HasColumnName("ETX Serial Number").HasMaxLength(255);
                e.Property(x => x.EtxRange).HasColumnName("ETX Range").HasMaxLength(255);
                e.Property(x => x.EtxPower).HasColumnName("ETX Power");
                e.Property(x => x.EtxClassOfEmission).HasColumnName("ETX Class of Emission").HasMaxLength(255);
                e.Property(x => x.EtxAssignedFreq).HasColumnName("ETX Assigned Freq").HasMaxLength(255);

                e.Property(x => x.SctxFreqBand).HasColumnName("SCTX Freq Band").HasMaxLength(255);
                e.Property(x => x.SctxTypeMakeModel).HasColumnName("SCTX type make model").HasMaxLength(255);
                e.Property(x => x.SctxSerialNo).HasColumnName("SCTX  Serial No").HasMaxLength(255);

                e.Property(x => x.Tranceiver).HasColumnName("Tranceiver").HasMaxLength(255);
                e.Property(x => x.Receivers).HasColumnName("Receivers").HasMaxLength(255);
                e.Property(x => x.AutoAlarm).HasColumnName("Auto Alarm").HasMaxLength(255);
                e.Property(x => x.Rdf).HasColumnName("RDF").HasMaxLength(255);
                e.Property(x => x.Radar).HasColumnName("Radar").HasMaxLength(255);

                e.Property(x => x.OfficialReciept).HasColumnName("Official Reciept");
                e.Property(x => x.RegionalDirector).HasColumnName("Regional Director").HasMaxLength(255);
                e.Property(x => x.RadioOperator).HasColumnName("Radio Operator").HasMaxLength(255);
                e.Property(x => x.OperatorLicense).HasColumnName("Operator License").HasMaxLength(255);
                e.Property(x => x.OperatorExpiryDate).HasColumnName("Operator Expiry Date");
                e.Property(x => x.DateReceived).HasColumnName("Date Received");

                e.Property(x => x.Remarks).HasColumnName("Remarks").HasMaxLength(255);
                e.Property(x => x.Class).HasColumnName("Class").HasMaxLength(255);
                e.Property(x => x.Type).HasColumnName("Type").HasMaxLength(255);
                e.Property(x => x.Aaic).HasColumnName("AAIC").HasMaxLength(255);
                e.Property(x => x.PortRegistry).HasColumnName("Port Registry").HasMaxLength(255);
                e.Property(x => x.Gross).HasColumnName("Gross").HasColumnType("numeric(18,2)");
                e.Property(x => x.Keel).HasColumnName("Keel");
                e.Property(x => x.MarineReg).HasColumnName("Marine Reg").HasMaxLength(255);
                e.Property(x => x.Amount).HasColumnName("Amount");
                e.Property(x => x.DatePaid).HasColumnName("Date paid");

                e.Property(x => x.ControlNumber).HasColumnName("Control Number").HasMaxLength(255);
                e.Property(x => x.Service).HasColumnName("Service").HasMaxLength(255);
                e.Property(x => x.Homeport).HasColumnName("Homeport").HasMaxLength(255);
                e.Property(x => x.CallingFrequencySsb).HasColumnName("Calling Frequency SSB").HasMaxLength(255);
                e.Property(x => x.CallingFrequencyVhf).HasColumnName("Calling Frequency VHF").HasMaxLength(255);
                e.Property(x => x.MmsiNo).HasColumnName("MMSI NO").HasMaxLength(255);
                e.Property(x => x.Encoder).HasColumnName("Encoder").HasMaxLength(255);
                e.Property(x => x.OldControlNumber).HasColumnName("OLD CONTROL NUMBER").HasMaxLength(255);
                e.Property(x => x.OldIssued).HasColumnName("OLD ISSUED");
                e.Property(x => x.ModificationRemarks).HasColumnName("MODIFICATION REMARKS").HasMaxLength(255);
                e.Property(x => x.Remarks2).HasColumnName("Remarks2").HasMaxLength(255);
                e.Property(x => x.Source).HasColumnName("Source").HasMaxLength(255);
                e.Property(x => x.OurceAddress).HasColumnName("OurceAddress").HasMaxLength(255);
                e.Property(x => x.PermitToPurchase).HasColumnName("PermitToPurchase").HasMaxLength(255);
                e.Property(x => x.DateOfPPR).HasColumnName("DateOfPPR");
                e.Property(x => x.FormerName).HasColumnName("Former Name").HasMaxLength(255);

                e.Property(x => x.RowVer).HasColumnName("RowVer").IsRowVersion();
            });

            // ============================
            // OTHER EXISTING TABLES
            // ============================

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
            // ADDRESS TABLES
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

            modelBuilder.Entity<AddrProvince>()
                .HasMany(p => p.Municipalities)
                .WithOne(m => m.Province)
                .HasForeignKey(m => m.ProvinceId)
                .HasPrincipalKey(p => p.ProvinceId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AddrMunicipality>()
                .HasMany(m => m.Barangays)
                .WithOne(b => b.Municipality)
                .HasForeignKey(b => b.MunicipalityId)
                .HasPrincipalKey(m => m.MunicipalityId)
                .OnDelete(DeleteBehavior.Restrict);

            // ============================
            // KEYLESS MODELS
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