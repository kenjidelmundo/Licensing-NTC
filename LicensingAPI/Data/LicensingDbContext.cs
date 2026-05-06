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

        // ✅ WDN table
        public DbSet<LicensingAPI.Entities.AccessWDN> accessWDN { get; set; }

        // ✅ DTH table
        public DbSet<LicensingAPI.Entities.AccessDTH> accessDTH { get; set; }

        // ✅ MPSC table
        public DbSet<LicensingAPI.Entities.AccessMPSC> accessMPSC { get; set; }

        // ✅ MPDP table
        public DbSet<LicensingAPI.Entities.AccessMPDP> accessMPDP { get; set; }

        // ✅ Permit Transport table
        public DbSet<LicensingAPI.Entities.AccessPermitTransport> accessPermitTransport { get; set; }

        // ✅ Permit Sell Transfer table
        public DbSet<LicensingAPI.Entities.AccessPermitSellTransfer> accessPermitSellTransfer { get; set; }

        // ✅ GROC table
        public DbSet<LicensingAPI.Entities.AccessGROC> accessGROC { get; set; }

        // ✅ RLM table
        public DbSet<LicensingAPI.Entities.AccessRLM> accessRLM { get; set; }

        // ✅ ROC table
        public DbSet<LicensingAPI.Entities.AccessROC> accessROC { get; set; }

        // ✅ SROP table - ADDED ONLY
        public DbSet<LicensingAPI.Entities.AccessSROP> accessSROP { get; set; }

        // ✅ KEEP all your other entities below unchanged
        public DbSet<TechSOADetails> tblSOADetails { get; set; }

        public DbSet<TechCCFormula> CitizenCharterFormula { get; set; }
        public DbSet<TechCCGroup> CitizenCharterGroup { get; set; }
        public DbSet<TechCCStages> CitizenCharterStages { get; set; }

        public DbSet<LicensingAPI.Entities.TechEODService> TechEODService { get; set; }

        public DbSet<TechFees> tblFees { get; set; }
        public DbSet<TechSUFRate> SUFRate { get; set; }
        public DbSet<TechService> TechService { get; set; }

        // keyless
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

            // ✅ SOA
            modelBuilder.Entity<TechSOA>(e =>
            {
                e.ToTable("accessSOA", "dbo");
                e.HasKey(x => x.ID);
            });

            // ✅ WDN table mapping
            modelBuilder.Entity<LicensingAPI.Entities.AccessWDN>(e =>
            {
                e.ToTable("accessWDN", "dbo");
                e.HasKey(x => x.ID);

                e.Property(x => x.ID).HasColumnName("ID").ValueGeneratedNever();
                e.Property(x => x.Issued).HasColumnName("ISSUED");
                e.Property(x => x.PermitPre).HasColumnName("PERMIT_PRE").HasMaxLength(255);
                e.Property(x => x.PermitNo).HasColumnName("PERMIT_NO").HasMaxLength(255);
                e.Property(x => x.PermitYear).HasColumnName("PERMIT_YEAR").HasMaxLength(255);
                e.Property(x => x.LicenseStatus).HasColumnName("LICENSE_STATUS").HasMaxLength(255);
                e.Property(x => x.NameOfCompany).HasColumnName("NAME OF COMPANY").HasMaxLength(255);
                e.Property(x => x.Address).HasColumnName("ADDRESS").HasMaxLength(255);
                e.Property(x => x.Validity).HasColumnName("VALIDITY");
                e.Property(x => x.Ece).HasColumnName("ECE").HasMaxLength(255);
                e.Property(x => x.OrNo).HasColumnName("O R NO").HasMaxLength(255);
                e.Property(x => x.Date).HasColumnName("DATE");
                e.Property(x => x.Amount).HasColumnName("AMOUNT").HasColumnType("money");
                e.Property(x => x.ScanLicense).HasColumnName("Scan License").HasColumnType("ntext");
                e.Property(x => x.TypeOfService).HasColumnName("TYPE_OF_SERVICE").HasMaxLength(255);
                e.Property(x => x.IssuanceAddress).HasColumnName("ISSUANCE_ADDRESS").HasMaxLength(255);
                e.Property(x => x.EngrAssigned).HasColumnName("ENGR_ASSIGNED").HasMaxLength(255);
                e.Property(x => x.EngrLicense).HasColumnName("ENGR_LICENSE").HasMaxLength(255);
                e.Property(x => x.EngrLicenseValidity).HasColumnName("ENGR_LICENSE_VALIDITY");
                e.Property(x => x.NameOfTechnician).HasColumnName("NAME_OF_TECHNICIAN").HasMaxLength(255);
                e.Property(x => x.Remarks).HasColumnName("REMARKS").HasMaxLength(255);
                e.Property(x => x.ValidFrom).HasColumnName("Valid From");
                e.Property(x => x.OldPermitNo).HasColumnName("OLD PERMIT NO").HasMaxLength(255);
                e.Property(x => x.Contact).HasColumnName("Contact").HasMaxLength(255);
                e.Property(x => x.Encoded).HasColumnName("Encoded").HasMaxLength(255);
                e.Property(x => x.AccountableForm).HasColumnName("AccountableForm").HasMaxLength(255);
                e.Property(x => x.DateInspected).HasColumnName("DateInspected").HasMaxLength(10);
                e.Property(x => x.InspectionMO).HasColumnName("InspectionMO").HasMaxLength(50);
                e.Property(x => x.AdminCase).HasColumnName("AdminCase").HasColumnType("ntext");
                e.Property(x => x.AdminCaseRemark).HasColumnName("AdminCaseRemark").HasColumnType("ntext");
            });

            // ✅ DTH table mapping
            modelBuilder.Entity<LicensingAPI.Entities.AccessDTH>(e =>
            {
                e.ToTable("accessDTH", "dbo");
                e.HasKey(x => x.ID);

                e.Property(x => x.ID).HasColumnName("ID").ValueGeneratedNever();
                e.Property(x => x.Issued).HasColumnName("ISSUED");
                e.Property(x => x.PermitPre).HasColumnName("PERMIT_PRE").HasMaxLength(255);
                e.Property(x => x.PermitNo).HasColumnName("PERMIT_NO").HasMaxLength(255);
                e.Property(x => x.PermitYear).HasColumnName("PERMIT_YEAR").HasMaxLength(255);
                e.Property(x => x.LicenseStatus).HasColumnName("LICENSE_STATUS").HasMaxLength(255);
                e.Property(x => x.NameOfCompany).HasColumnName("NAME OF COMPANY").HasMaxLength(255);
                e.Property(x => x.Address).HasColumnName("ADDRESS").HasMaxLength(255);
                e.Property(x => x.Validity).HasColumnName("VALIDITY");
                e.Property(x => x.Ece).HasColumnName("ECE").HasMaxLength(255);
                e.Property(x => x.OrNo).HasColumnName("O R NO").HasMaxLength(255);
                e.Property(x => x.Date).HasColumnName("DATE");
                e.Property(x => x.Amount).HasColumnName("AMOUNT").HasColumnType("numeric(18,2)");
                e.Property(x => x.ScanLicense).HasColumnName("Scan License").HasColumnType("nvarchar(max)");
                e.Property(x => x.TypeOfService).HasColumnName("TYPE_OF_SERVICE").HasMaxLength(255);
                e.Property(x => x.IssuanceAddress).HasColumnName("ISSUANCE_ADDRESS").HasMaxLength(255);
                e.Property(x => x.EngrAssigned).HasColumnName("ENGR_ASSIGNED").HasMaxLength(255);
                e.Property(x => x.EngrLicense).HasColumnName("ENGR_LICENSE").HasMaxLength(255);
                e.Property(x => x.EngrLicenseValidity).HasColumnName("ENGR_LICENSE_VALIDITY");
                e.Property(x => x.NameOfTechnician).HasColumnName("NAME_OF_TECHNICIAN").HasMaxLength(255);
                e.Property(x => x.Remarks).HasColumnName("REMARKS").HasMaxLength(255);
                e.Property(x => x.ValidFrom).HasColumnName("Valid From");
                e.Property(x => x.OldPermitNo).HasColumnName("OLD PERMIT NO").HasMaxLength(255);
                e.Property(x => x.Contact).HasColumnName("Contact").HasMaxLength(255);
                e.Property(x => x.Encoded).HasColumnName("Encoded").HasMaxLength(255);
                e.Property(x => x.AccountableForm).HasColumnName("AccountableForm").HasMaxLength(255);
                e.Property(x => x.DateInspected).HasColumnName("DateInspected").HasMaxLength(10);
                e.Property(x => x.InspectionMO).HasColumnName("InspectionMO").HasMaxLength(50);
                e.Property(x => x.AdminCase).HasColumnName("AdminCase").HasMaxLength(50);
                e.Property(x => x.AdminCaseRemark).HasColumnName("AdminCaseRemark").HasColumnType("nvarchar(max)");
                e.Property(x => x.IsOpen).HasColumnName("isOpen");
                e.Property(x => x.IsPrinted).HasColumnName("isPrinted");
                e.Property(x => x.RoutingRefNo).HasColumnName("RoutingRefNo").HasMaxLength(255);
                e.Property(x => x.OrNo2).HasColumnName("O R NO2");
                e.Property(x => x.Amount2).HasColumnName("AMOUNT2").HasColumnType("numeric(18,2)");
                e.Property(x => x.Date2).HasColumnName("DATE2");
                e.Property(x => x.RowVer).HasColumnName("RowVer").IsRowVersion();
            });

            // ✅ MPSC table mapping
            modelBuilder.Entity<LicensingAPI.Entities.AccessMPSC>(e =>
            {
                e.ToTable("accessMPSC", "dbo");
                e.HasKey(x => x.ID);

                e.Property(x => x.ID).HasColumnName("ID").ValueGeneratedNever();
                e.Property(x => x.PermitNo).HasColumnName("Permit No").HasMaxLength(255);
                e.Property(x => x.Applicant).HasColumnName("Applicant").HasMaxLength(255);
                e.Property(x => x.Telephone).HasColumnName("Telephone").HasMaxLength(255);
                e.Property(x => x.SecDti).HasColumnName("SEC/DTI").HasMaxLength(255);
                e.Property(x => x.ValidityUntil).HasColumnName("Validity Until");
                e.Property(x => x.OfficialReceipt).HasColumnName("Official Receipt").HasColumnType("numeric(18,2)");
                e.Property(x => x.Amount).HasColumnName("Amount").HasColumnType("numeric(18,2)");
                e.Property(x => x.Issued).HasColumnName("Issued");
                e.Property(x => x.FaxNo).HasColumnName("Fax No").HasMaxLength(255);
                e.Property(x => x.Address).HasColumnName("Address").HasMaxLength(255);
                e.Property(x => x.Field1).HasColumnName("Field1").HasMaxLength(255);
                e.Property(x => x.DatePaid).HasColumnName("Date Paid");
                e.Property(x => x.ApprovingOfficer).HasColumnName("Approving Officer").HasMaxLength(255);
                e.Property(x => x.Remark).HasColumnName("Remark").HasMaxLength(255);
                e.Property(x => x.Encoded).HasColumnName("Encoded").HasMaxLength(255);
                e.Property(x => x.Region).HasColumnName("Region").HasMaxLength(255);
                e.Property(x => x.IssuedAt).HasColumnName("Issued At").HasMaxLength(255);
                e.Property(x => x.CompanyAvatarBillboardPicture).HasColumnName("Company Avatar/ Billboard Picture").HasMaxLength(255);
                e.Property(x => x.DateReceived).HasColumnName("Date Received");
                e.Property(x => x.Contact).HasColumnName("Contact").HasMaxLength(255);
                e.Property(x => x.Email).HasColumnName("E-mail").HasMaxLength(255);
                e.Property(x => x.Technician).HasColumnName("Technician").HasMaxLength(255);
                e.Property(x => x.Cond).HasColumnName("Cond").HasMaxLength(255);
                e.Property(x => x.Release).HasColumnName("Release").HasMaxLength(255);
                e.Property(x => x.CityMunicipality).HasColumnName("CityMunicipality").HasMaxLength(255);
                e.Property(x => x.Province).HasColumnName("Province").HasMaxLength(255);
                e.Property(x => x.Field27).HasColumnName("Field27").HasMaxLength(255);
                e.Property(x => x.ScanLicense).HasColumnName("Scan license").HasMaxLength(255);
                e.Property(x => x.RemarksForModification).HasColumnName("Remarks for Modification").HasMaxLength(255);
                e.Property(x => x.Modification).HasColumnName("Modification").HasMaxLength(255);
                e.Property(x => x.DateInspected).HasColumnName("DateInspected").HasMaxLength(10);
                e.Property(x => x.InspectionMO).HasColumnName("InspectionMO").HasMaxLength(50);
                e.Property(x => x.AdminCase).HasColumnName("AdminCase").HasMaxLength(50);
                e.Property(x => x.AdminCaseRemark).HasColumnName("AdminCaseRemark").HasColumnType("nvarchar(max)");
                e.Property(x => x.IsOpen).HasColumnName("isOpen");
                e.Property(x => x.IsPrinted).HasColumnName("isPrinted");
                e.Property(x => x.RoutingRefNo).HasColumnName("RoutingRefNo").HasMaxLength(255);
                e.Property(x => x.OfficialReceipt2).HasColumnName("Official Receipt2");
                e.Property(x => x.Amount2).HasColumnName("Amount2").HasColumnType("numeric(18,2)");
                e.Property(x => x.DatePaid2).HasColumnName("Date Paid2");
                e.Property(x => x.RowVer).HasColumnName("RowVer").IsRowVersion();
            });

            // ✅ MPDP table mapping
            modelBuilder.Entity<LicensingAPI.Entities.AccessMPDP>(e =>
            {
                e.ToTable("accessMPDP", "dbo");
                e.HasKey(x => x.ID);

                e.Property(x => x.ID).HasColumnName("ID").ValueGeneratedNever();
                e.Property(x => x.PermitNo).HasColumnName("PERMIT NO").HasMaxLength(255);
                e.Property(x => x.Applicant).HasColumnName("APPLICANT").HasMaxLength(255);
                e.Property(x => x.Address).HasColumnName("ADDRESS").HasMaxLength(255);
                e.Property(x => x.CityMunicipality).HasColumnName("CityMunicipality").HasMaxLength(255);
                e.Property(x => x.Province).HasColumnName("Province").HasMaxLength(255);
                e.Property(x => x.Telephone).HasColumnName("Telephone").HasMaxLength(255);
                e.Property(x => x.SecDti).HasColumnName("SEC/DTI").HasMaxLength(255);
                e.Property(x => x.Issued).HasColumnName("ISSUED");
                e.Property(x => x.ValidityUntil).HasColumnName("VALIDITY UNTIL");
                e.Property(x => x.OfficialReceipt).HasColumnName("OFFICIAL RECEIPT").HasColumnType("numeric(18,2)");
                e.Property(x => x.DatePaid).HasColumnName("Date Paid");
                e.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(255);
                e.Property(x => x.DateReceived).HasColumnName("Date Received");
                e.Property(x => x.Contact).HasColumnName("CONTACT").HasMaxLength(255);
                e.Property(x => x.Technician).HasColumnName("TECHNICIAN").HasMaxLength(255);
                e.Property(x => x.Region).HasColumnName("REGION").HasMaxLength(255);
                e.Property(x => x.Encoded).HasColumnName("Encoded").HasMaxLength(255);
                e.Property(x => x.IssuedAt).HasColumnName("ISSUED AT").HasMaxLength(255);
                e.Property(x => x.Cond).HasColumnName("COND").HasMaxLength(255);
                e.Property(x => x.Email).HasColumnName("e-MAIL").HasMaxLength(255);
                e.Property(x => x.Dlr1st).HasColumnName("DLR1ST").HasMaxLength(255);
                e.Property(x => x.Ece).HasColumnName("ECE").HasMaxLength(255);
                e.Property(x => x.ApprovingOfficer).HasColumnName("Approving Officer").HasMaxLength(255);
                e.Property(x => x.Release).HasColumnName("Release").HasMaxLength(255);
                e.Property(x => x.FaxNo).HasColumnName("Fax No").HasMaxLength(255);
                e.Property(x => x.Amount).HasColumnName("Amount");
                e.Property(x => x.CompanyAvatarBillboardPicture).HasColumnName("Company Avatar/ Billboard Picture").HasMaxLength(255);
                e.Property(x => x.Type).HasColumnName("Type").HasMaxLength(255);
                e.Property(x => x.ScanLicense).HasColumnName("Scan license").HasMaxLength(255);
                e.Property(x => x.Modification).HasColumnName("Modification").HasMaxLength(255);
                e.Property(x => x.RemarksForModification).HasColumnName("Remarks for Modification").HasMaxLength(255);
                e.Property(x => x.DealerType).HasColumnName("DEALER TYPE").HasMaxLength(255);
                e.Property(x => x.DateInspected).HasColumnName("DateInspected").HasMaxLength(10);
                e.Property(x => x.InspectionMO).HasColumnName("InspectionMO").HasMaxLength(50);
                e.Property(x => x.AdminCase).HasColumnName("AdminCase").HasMaxLength(50);
                e.Property(x => x.AdminCaseRemark).HasColumnName("AdminCaseRemark").HasColumnType("nvarchar(max)");
                e.Property(x => x.IsOpen).HasColumnName("isOpen");
                e.Property(x => x.IsPrinted).HasColumnName("isPrinted");
                e.Property(x => x.RoutingRefNo).HasColumnName("RoutingRefNo").HasMaxLength(255);
                e.Property(x => x.OfficialReceipt2).HasColumnName("OFFICIAL RECEIPT2");
                e.Property(x => x.DatePaid2).HasColumnName("Date Paid2");
                e.Property(x => x.Amount2).HasColumnName("Amount2").HasColumnType("numeric(18,2)");
                e.Property(x => x.RowVer).HasColumnName("RowVer").IsRowVersion();
            });

            // ✅ Permit Transport table mapping
            modelBuilder.Entity<LicensingAPI.Entities.AccessPermitTransport>(e =>
            {
                e.ToTable("accessPermitTransport", "dbo");
                e.HasKey(x => x.ID);

                e.Property(x => x.ID).HasColumnName("ID").ValueGeneratedNever();
                e.Property(x => x.ReferenceNo).HasColumnName("REFERENCE NO").HasMaxLength(255);
                e.Property(x => x.Applicant).HasColumnName("APPLICANT").HasMaxLength(255);
                e.Property(x => x.Address).HasColumnName("ADDRESS").HasMaxLength(255);
                e.Property(x => x.DateProcessed).HasColumnName("Date Processed");
                e.Property(x => x.TelNo).HasColumnName("TEL NO").HasMaxLength(50);
                e.Property(x => x.NameAuthorizedRep).HasColumnName("NAME AUTHORIZED REP").HasMaxLength(255);
                e.Property(x => x.DateTransport).HasColumnName("Date Transport").HasMaxLength(255);
                e.Property(x => x.PlaceOfOrigin).HasColumnName("PLACE OF ORIGIN").HasMaxLength(255);
                e.Property(x => x.Destination).HasColumnName("DESTINATION").HasMaxLength(255);
                e.Property(x => x.Purpose).HasColumnName("PURPOSE").HasMaxLength(255);
                e.Property(x => x.IsCopyPermitToPossess).HasColumnName("IsCopyPermittoPossess");
                e.Property(x => x.IsCopyRLS).HasColumnName("IsCopyRLS");
                e.Property(x => x.IsCopyDealersPermit).HasColumnName("IsCopyDealersPermit");
                e.Property(x => x.OtherAttachment).HasColumnName("Other Attachment").HasMaxLength(255);
                e.Property(x => x.Model).HasColumnName("Model").HasMaxLength(255);
                e.Property(x => x.SerialNumbers).HasColumnName("Serial Numbers").HasMaxLength(255);
                e.Property(x => x.Model1).HasColumnName("Model1").HasMaxLength(255);
                e.Property(x => x.SerialNumbers1).HasColumnName("Serial Numbers1").HasMaxLength(255);
                e.Property(x => x.OfficialReceipt).HasColumnName("Official Receipt").HasColumnType("decimal(18,0)");
                e.Property(x => x.Amount).HasColumnName("Amount").HasColumnType("money");
                e.Property(x => x.Date).HasColumnName("Date");
                e.Property(x => x.Encoded).HasColumnName("Encoded").HasMaxLength(255);
                e.Property(x => x.ApplicantName).HasColumnName("Applicant Name").HasMaxLength(255);
                e.Property(x => x.PermitNo).HasColumnName("Permit No").HasMaxLength(255);
                e.Property(x => x.DateIssued).HasColumnName("Date Issued");
                e.Property(x => x.ApprovingOfficer).HasColumnName("Approving Officer").HasMaxLength(255);
                e.Property(x => x.Position).HasColumnName("Position").HasMaxLength(255);
            });

            // ✅ Permit Sell Transfer table mapping
            modelBuilder.Entity<LicensingAPI.Entities.AccessPermitSellTransfer>(e =>
            {
                e.ToTable("accessPermitSellTransfer", "dbo");
                e.HasKey(x => x.ID);

                e.Property(x => x.ID).HasColumnName("ID").ValueGeneratedNever();
                e.Property(x => x.PermitNo).HasColumnName("PERMIT NO").HasMaxLength(255);
                e.Property(x => x.Applicant).HasColumnName("APPLICANT").HasMaxLength(255);
                e.Property(x => x.Address).HasColumnName("ADDRESS").HasMaxLength(255);
                e.Property(x => x.DateProcessed).HasColumnName("Date Processed");
                e.Property(x => x.Model).HasColumnName("Model").HasMaxLength(255);
                e.Property(x => x.NoOfUnits).HasColumnName("No Of Units").HasMaxLength(255);
                e.Property(x => x.SerialNumbers).HasColumnName("Serial Numbers").HasMaxLength(255);
                e.Property(x => x.OfficialReceipt).HasColumnName("Official Receipt").HasColumnType("decimal(18,0)");
                e.Property(x => x.Amount).HasColumnName("Amount").HasColumnType("money");
                e.Property(x => x.Date).HasColumnName("Date");
                e.Property(x => x.Encoded).HasColumnName("Encoded").HasMaxLength(255);
                e.Property(x => x.Buyer).HasColumnName("Buyer").HasMaxLength(255);
                e.Property(x => x.BuyerAddress).HasColumnName("Buyer Address").HasMaxLength(255);
                e.Property(x => x.PPurchaseNo).HasColumnName("PPurchase No").HasMaxLength(255);
                e.Property(x => x.PPurchaseDateIssue).HasColumnName("PPurchase Date Issue").HasMaxLength(255);
                e.Property(x => x.IntendedUse).HasColumnName("Intended Use").HasMaxLength(255);
                e.Property(x => x.ApprovingOfficer).HasColumnName("Approving Officer").HasMaxLength(255);
                e.Property(x => x.Position).HasColumnName("Position").HasMaxLength(255);
                e.Property(x => x.UnitCount).HasColumnName("UnitCount");
            });

            // ✅ GROC table mapping
            modelBuilder.Entity<LicensingAPI.Entities.AccessGROC>(e =>
            {
                e.ToTable("accessGROC", "dbo");
                e.HasKey(x => x.ID);

                e.Property(x => x.ID).HasColumnName("ID").ValueGeneratedNever();
                e.Property(x => x.Licensee).HasColumnName("LICENSEE").HasMaxLength(255);
                e.Property(x => x.Address).HasColumnName("ADDRESS").HasMaxLength(255);
                e.Property(x => x.Province).HasColumnName("PROVINCE").HasMaxLength(255);
                e.Property(x => x.LicenseNo).HasColumnName("LICENSE NO").HasMaxLength(255);
                e.Property(x => x.Birthday).HasColumnName("BIRTHDAY");
                e.Property(x => x.Citizenship).HasColumnName("CITIZENSHIP").HasMaxLength(255);
                e.Property(x => x.Sex).HasColumnName("SEX").HasMaxLength(255);
                e.Property(x => x.Height).HasColumnName("HEIGHT");
                e.Property(x => x.Weight).HasColumnName("WEIGHT");
                e.Property(x => x.OfficialReceipt).HasColumnName("OFFICIAL RECEIPT");
                e.Property(x => x.DatePaid).HasColumnName("DATE PAID");
                e.Property(x => x.Amount).HasColumnName("AMOUNT").HasColumnType("money");
                e.Property(x => x.DateIssued).HasColumnName("DATE ISSUED");
                e.Property(x => x.ExpiryDate).HasColumnName("EXPIRY DATE");
                e.Property(x => x.RecommendingApproval).HasColumnName("RECOMMENDING APPROVAL").HasMaxLength(255);
                e.Property(x => x.RegionalDirector).HasColumnName("REGIONAL DIRECTOR").HasMaxLength(255);
                e.Property(x => x.Position).HasColumnName("POSITION").HasMaxLength(255);
                e.Property(x => x.TypeClass).HasColumnName("TYPE/CLASS").HasMaxLength(255);
                e.Property(x => x.DateTaken).HasColumnName("DATE TAKEN").HasColumnType("date");
                e.Property(x => x.PlaceOfExam).HasColumnName("PLACE OF EXAM").HasMaxLength(255);
                e.Property(x => x.Rating).HasColumnName("RATING").HasMaxLength(255);
                e.Property(x => x.Remarks).HasColumnName("REMARKS").HasMaxLength(255);
                e.Property(x => x.Encoder).HasColumnName("ENCODER").HasMaxLength(255);
                e.Property(x => x.Note).HasColumnName("NOTE").HasMaxLength(255);
                e.Property(x => x.Userlog).HasColumnName("Userlog").HasMaxLength(255);
                e.Property(x => x.InsertDate).HasColumnName("InsertDate");
                e.Property(x => x.LastUpdateUser).HasColumnName("LastUpdateUser").HasMaxLength(255);
                e.Property(x => x.LastUpdateDate).HasColumnName("LastUpdateDate");
                e.Property(x => x.AccountableFormNumber).HasColumnName("AccountableFormNumber");
                e.Property(x => x.OfficialReceipt2).HasColumnName("OFFICIAL RECEIPT2");
                e.Property(x => x.DatePaid2).HasColumnName("DATE PAID2");
                e.Property(x => x.Amount2).HasColumnName("AMOUNT2").HasColumnType("money");
                e.Property(x => x.Series).HasColumnName("SERIES");
                e.Property(x => x.AdminCaseRemark).HasColumnName("AdminCaseRemark").HasColumnType("ntext");
                e.Property(x => x.DateInspected).HasColumnName("DateInspected").HasMaxLength(255);
                e.Property(x => x.InspectionMO).HasColumnName("InspectionMO").HasMaxLength(255);
                e.Property(x => x.IsOpen).HasColumnName("isOpen");
                e.Property(x => x.IsPrinted).HasColumnName("isPrinted");
                e.Property(x => x.RoutingRefNo).HasColumnName("RoutingRefNo").HasMaxLength(255);
                e.Property(x => x.CertOfCompletionSerialGROC)
                    .HasColumnName("CertOfCompletionSerialGROC")
                    .HasColumnType("varchar(255)");

                e.Property(x => x.RowVer).HasColumnName("RowVer").IsRowVersion();
            });

            // ✅ RLM table mapping
            modelBuilder.Entity<LicensingAPI.Entities.AccessRLM>(e =>
            {
                e.ToTable("accessRLM", "dbo");
                e.HasKey(x => x.ID);

                e.Property(x => x.ID)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                e.Property(x => x.Name).HasColumnName("NAME").HasMaxLength(255);
                e.Property(x => x.LicenseNo).HasColumnName("LICENSE NO").HasMaxLength(255);
                e.Property(x => x.Series).HasColumnName("SERIES").HasMaxLength(255);
                e.Property(x => x.Remark).HasColumnName("REMARK").HasMaxLength(255);
                e.Property(x => x.Issued).HasColumnName("ISSUED");
                e.Property(x => x.ValidUntil).HasColumnName("VALID UNTIL");
                e.Property(x => x.OperatorFee).HasColumnName("OPERATOR FEE").HasMaxLength(255);
                e.Property(x => x.Address).HasColumnName("ADDRESS").HasMaxLength(255);
                e.Property(x => x.Birthdate).HasColumnName("BIRTHDATE");
                e.Property(x => x.Height).HasColumnName("HEIGHT").HasMaxLength(255);
                e.Property(x => x.Weight).HasColumnName("WEIGHT").HasMaxLength(255);
                e.Property(x => x.Citizenship).HasColumnName("CITIZENSHIP").HasMaxLength(255);
                e.Property(x => x.Sex).HasColumnName("SEX").HasMaxLength(255);
                e.Property(x => x.Company).HasColumnName("COMPANY").HasMaxLength(255);
                e.Property(x => x.DateOfSem).HasColumnName("DATE OF SEM").HasMaxLength(255);
                e.Property(x => x.PlaceOfSem).HasColumnName("PLACE OF SEM").HasMaxLength(255);
                e.Property(x => x.OfficialReceipt).HasColumnName("Official Receipt").HasMaxLength(255);
                e.Property(x => x.Amount).HasColumnName("Amount").HasColumnType("money");
                e.Property(x => x.DatePaid).HasColumnName("DATE PAID");
                e.Property(x => x.ForTheCommission).HasColumnName("FOR THE COMMISSION").HasMaxLength(255);
                e.Property(x => x.Position).HasColumnName("POSITION").HasMaxLength(255);
                e.Property(x => x.Encoded).HasColumnName("Encoded").HasMaxLength(255);
                e.Property(x => x.LastName).HasColumnName("LAST NAME").HasMaxLength(255);
                e.Property(x => x.FirstName).HasColumnName("FIRST NAME").HasMaxLength(255);
                e.Property(x => x.MiddleName).HasColumnName("MIDDLE NAME").HasMaxLength(255);
                e.Property(x => x.OperatorFees).HasColumnName("OPERATOR FEES").HasMaxLength(255);
                e.Property(x => x.DocStamp).HasColumnName("DOC STAMP").HasMaxLength(255);
                e.Property(x => x.ReleasedDate).HasColumnName("RELEASED DATE").HasMaxLength(255);
                e.Property(x => x.AccountableForm).HasColumnName("AccountableForm").HasMaxLength(255);
                e.Property(x => x.OfficialReceipt2).HasColumnName("Official Receipt2").HasMaxLength(255);
                e.Property(x => x.Amount2).HasColumnName("Amount2").HasColumnType("money");
                e.Property(x => x.DatePaid2).HasColumnName("Date Paid2");
                e.Property(x => x.OperatorFees2).HasColumnName("OPERATOR FEES2").HasMaxLength(255);
                e.Property(x => x.Status).HasColumnName("Status").HasMaxLength(10);
                e.Property(x => x.MobileNote).HasColumnName("Mobile Note").HasMaxLength(255);
                e.Property(x => x.IsOpen).HasColumnName("isOpen");
                e.Property(x => x.IsPrinted).HasColumnName("isPrinted");
                e.Property(x => x.RoutingRefNo).HasColumnName("RoutingRefNo").HasMaxLength(255);
            });

            // ✅ ROC table mapping
            modelBuilder.Entity<LicensingAPI.Entities.AccessROC>(e =>
            {
                e.ToTable("accessROC", "dbo");
                e.HasKey(x => x.ID);

                e.Property(x => x.ID).HasColumnName("ID").ValueGeneratedNever();
                e.Property(x => x.Licensee).HasColumnName("LICENSEE").HasMaxLength(255);
                e.Property(x => x.Address).HasColumnName("ADDRESS").HasMaxLength(255);
                e.Property(x => x.Province).HasColumnName("PROVINCE").HasMaxLength(255);
                e.Property(x => x.LicenseNo).HasColumnName("LICENSE NO").HasMaxLength(255);
                e.Property(x => x.Birthday).HasColumnName("BIRTHDAY");
                e.Property(x => x.Citizenship).HasColumnName("CITIZENSHIP").HasMaxLength(255);
                e.Property(x => x.Sex).HasColumnName("SEX").HasMaxLength(255);
                e.Property(x => x.Height).HasColumnName("HEIGHT");
                e.Property(x => x.Weight).HasColumnName("WEIGHT");
                e.Property(x => x.OfficialReceipt).HasColumnName("OFFICIAL RECEIPT");
                e.Property(x => x.DatePaid).HasColumnName("DATE PAID");
                e.Property(x => x.Amount).HasColumnName("AMOUNT").HasColumnType("money");
                e.Property(x => x.DateIssued).HasColumnName("DATE ISSUED");
                e.Property(x => x.ExpiryDate).HasColumnName("EXPIRY DATE");
                e.Property(x => x.RecommendingApproval).HasColumnName("RECOMMENDING APPROVAL").HasMaxLength(255);
                e.Property(x => x.RegionalDirector).HasColumnName("REGIONAL DIRECTOR").HasMaxLength(255);
                e.Property(x => x.Position).HasColumnName("POSITION").HasMaxLength(255);
                e.Property(x => x.TypeClass).HasColumnName("TYPE/CLASS").HasMaxLength(255);
                e.Property(x => x.DateTaken).HasColumnName("DATE TAKEN").HasMaxLength(255);
                e.Property(x => x.PlaceOfExam).HasColumnName("PLACE OF EXAM").HasMaxLength(255);
                e.Property(x => x.Rating).HasColumnName("RATING").HasMaxLength(255);
                e.Property(x => x.Remarks).HasColumnName("REMARKS").HasMaxLength(255);
                e.Property(x => x.Encoder).HasColumnName("ENCODER").HasMaxLength(255);
                e.Property(x => x.Note).HasColumnName("NOTE").HasMaxLength(255);
                e.Property(x => x.Userlog).HasColumnName("Userlog").HasMaxLength(255);
                e.Property(x => x.InsertDate).HasColumnName("InsertDate");
                e.Property(x => x.LastUpdateUser).HasColumnName("LastUpdateUser").HasMaxLength(255);
                e.Property(x => x.LastUpdateDate).HasColumnName("LastUpdateDate");
                e.Property(x => x.AccountableFormNumber).HasColumnName("AccountableFormNumber");
                e.Property(x => x.OfficialReceipt2).HasColumnName("OFFICIAL RECEIPT2");
                e.Property(x => x.DatePaid2).HasColumnName("DATE PAID2");
                e.Property(x => x.Amount2).HasColumnName("AMOUNT2").HasColumnType("money");
                e.Property(x => x.AdminCase).HasColumnName("AdminCase").HasColumnType("ntext");
                e.Property(x => x.AdminCaseRemark).HasColumnName("AdminCaseRemark").HasColumnType("ntext");
                e.Property(x => x.DateInspected).HasColumnName("DateInspected").HasMaxLength(10);
                e.Property(x => x.InspectionMO).HasColumnName("InspectionMO").HasMaxLength(50);
                e.Property(x => x.IsOpen).HasColumnName("isOpen");
                e.Property(x => x.IsPrinted).HasColumnName("isPrinted");
                e.Property(x => x.RoutingRefNo).HasColumnName("RoutingRefNo").HasMaxLength(255);
                e.Property(x => x.RowVer).HasColumnName("RowVer").IsRowVersion();
            });

            // ✅ SROP table mapping - ADDED ONLY
            modelBuilder.Entity<LicensingAPI.Entities.AccessSROP>(e =>
            {
                e.ToTable("accessSROP", "dbo");
                e.HasKey(x => x.ID);

                e.Property(x => x.ID).HasColumnName("ID").ValueGeneratedNever();
                e.Property(x => x.Licensee).HasColumnName("LICENSEE").HasMaxLength(255);
                e.Property(x => x.Address).HasColumnName("ADDRESS").HasMaxLength(255);
                e.Property(x => x.Province).HasColumnName("PROVINCE").HasMaxLength(255);
                e.Property(x => x.LicenseNo).HasColumnName("LICENSE NO").HasMaxLength(255);
                e.Property(x => x.Birthday).HasColumnName("BIRTHDAY");
                e.Property(x => x.Citizenship).HasColumnName("CITIZENSHIP").HasMaxLength(255);
                e.Property(x => x.Sex).HasColumnName("SEX").HasMaxLength(255);
                e.Property(x => x.Height).HasColumnName("HEIGHT");
                e.Property(x => x.Weight).HasColumnName("WEIGHT");
                e.Property(x => x.OfficialReceipt).HasColumnName("OFFICIAL RECEIPT");
                e.Property(x => x.DatePaid).HasColumnName("DATE PAID");
                e.Property(x => x.Amount).HasColumnName("AMOUNT").HasColumnType("money");
                e.Property(x => x.DateIssued).HasColumnName("DATE ISSUED");
                e.Property(x => x.ExpiryDate).HasColumnName("EXPIRY DATE");
                e.Property(x => x.RecommendingApproval).HasColumnName("RECOMMENDING APPROVAL").HasMaxLength(255);
                e.Property(x => x.RegionalDirector).HasColumnName("REGIONAL DIRECTOR").HasMaxLength(255);
                e.Property(x => x.Position).HasColumnName("POSITION").HasMaxLength(255);
                e.Property(x => x.TypeClass).HasColumnName("TYPE/CLASS").HasMaxLength(255);
                e.Property(x => x.DateTaken).HasColumnName("DATE TAKEN");
                e.Property(x => x.PlaceOfExam).HasColumnName("PLACE OF EXAM").HasMaxLength(255);
                e.Property(x => x.Rating).HasColumnName("RATING").HasMaxLength(255);
                e.Property(x => x.Remarks).HasColumnName("REMARKS").HasMaxLength(255);
                e.Property(x => x.Encoder).HasColumnName("ENCODER").HasMaxLength(255);
                e.Property(x => x.Note).HasColumnName("NOTE").HasMaxLength(255);
                e.Property(x => x.Userlog).HasColumnName("Userlog").HasMaxLength(255);
                e.Property(x => x.InsertDate).HasColumnName("InsertDate");
                e.Property(x => x.LastUpdateUser).HasColumnName("LastUpdateUser").HasMaxLength(255);
                e.Property(x => x.LastUpdateDate).HasColumnName("LastUpdateDate");
                e.Property(x => x.AccountableFormNumber).HasColumnName("AccountableFormNumber");
                e.Property(x => x.OfficialReceipt2).HasColumnName("OFFICIAL RECEIPT2");
                e.Property(x => x.DatePaid2).HasColumnName("DATE PAID2");
                e.Property(x => x.Amount2).HasColumnName("AMOUNT2").HasColumnType("money");
                e.Property(x => x.Series).HasColumnName("SERIES");
                e.Property(x => x.IsOpen).HasColumnName("isOpen");
                e.Property(x => x.IsPrinted).HasColumnName("isPrinted");
                e.Property(x => x.RoutingRefNo).HasColumnName("RoutingRefNo").HasMaxLength(255);

                e.Property(x => x.CertOfCompletionSerialSROP)
                    .HasColumnName("CertOfCompletionSerialSROP")
                    .HasColumnType("varchar(255)");

                e.Property(x => x.RowVer).HasColumnName("RowVer").IsRowVersion();
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
            // ✅ ADDRESS ONLY
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
            // ✅ keyless
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