using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicensingAPI.Entities
{
    [Table("accessMPSC", Schema = "dbo")]
    public class AccessMPSC
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("Permit No")]
        public string? PermitNo { get; set; }

        [Column("Applicant")]
        public string? Applicant { get; set; }

        [Column("Telephone")]
        public string? Telephone { get; set; }

        [Column("SEC/DTI")]
        public string? SecDti { get; set; }

        [Column("Validity Until")]
        public DateTime? ValidityUntil { get; set; }

        [Column("Official Receipt", TypeName = "numeric(18,2)")]
        public decimal? OfficialReceipt { get; set; }

        [Column("Amount", TypeName = "numeric(18,2)")]
        public decimal? Amount { get; set; }

        [Column("Issued")]
        public DateTime? Issued { get; set; }

        [Column("Fax No")]
        public string? FaxNo { get; set; }

        [Column("Address")]
        public string? Address { get; set; }

        [Column("Field1")]
        public string? Field1 { get; set; }

        [Column("Date Paid")]
        public DateTime? DatePaid { get; set; }

        [Column("Approving Officer")]
        public string? ApprovingOfficer { get; set; }

        [Column("Remark")]
        public string? Remark { get; set; }

        [Column("Encoded")]
        public string? Encoded { get; set; }

        [Column("Region")]
        public string? Region { get; set; }

        [Column("Issued At")]
        public string? IssuedAt { get; set; }

        [Column("Company Avatar/ Billboard Picture")]
        public string? CompanyAvatarBillboardPicture { get; set; }

        [Column("Date Received")]
        public DateTime? DateReceived { get; set; }

        [Column("Contact")]
        public string? Contact { get; set; }

        [Column("E-mail")]
        public string? Email { get; set; }

        [Column("Technician")]
        public string? Technician { get; set; }

        [Column("Cond")]
        public string? Cond { get; set; }

        [Column("Release")]
        public string? Release { get; set; }

        [Column("CityMunicipality")]
        public string? CityMunicipality { get; set; }

        [Column("Province")]
        public string? Province { get; set; }

        [Column("Field27")]
        public string? Field27 { get; set; }

        [Column("Scan license")]
        public string? ScanLicense { get; set; }

        [Column("Remarks for Modification")]
        public string? RemarksForModification { get; set; }

        [Column("Modification")]
        public string? Modification { get; set; }

        [Column("DateInspected")]
        [StringLength(10)]
        public string? DateInspected { get; set; }

        [Column("InspectionMO")]
        [StringLength(50)]
        public string? InspectionMO { get; set; }

        [Column("AdminCase")]
        [StringLength(50)]
        public string? AdminCase { get; set; }

        [Column("AdminCaseRemark", TypeName = "nvarchar(max)")]
        public string? AdminCaseRemark { get; set; }

        [Column("isOpen")]
        public byte? IsOpen { get; set; }

        [Column("isPrinted")]
        public byte? IsPrinted { get; set; }

        [Column("RoutingRefNo")]
        public string? RoutingRefNo { get; set; }

        [Column("Official Receipt2")]
        public int? OfficialReceipt2 { get; set; }

        [Column("Amount2", TypeName = "numeric(18,2)")]
        public decimal? Amount2 { get; set; }

        [Column("Date Paid2")]
        public DateTime? DatePaid2 { get; set; }

        [Timestamp]
        [Column("RowVer")]
        public byte[] RowVer { get; set; } = Array.Empty<byte>();
    }
}