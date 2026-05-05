using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicensingAPI.Entities
{
    [Table("accessMPDP", Schema = "dbo")]
    public class AccessMPDP
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("PERMIT NO")]
        public string? PermitNo { get; set; }

        [Column("APPLICANT")]
        public string? Applicant { get; set; }

        [Column("ADDRESS")]
        public string? Address { get; set; }

        [Column("CityMunicipality")]
        public string? CityMunicipality { get; set; }

        [Column("Province")]
        public string? Province { get; set; }

        [Column("Telephone")]
        public string? Telephone { get; set; }

        [Column("SEC/DTI")]
        public string? SecDti { get; set; }

        [Column("ISSUED")]
        public DateTime? Issued { get; set; }

        [Column("VALIDITY UNTIL")]
        public DateTime? ValidityUntil { get; set; }

        [Column("OFFICIAL RECEIPT", TypeName = "numeric(18,2)")]
        public decimal? OfficialReceipt { get; set; }

        [Column("Date Paid")]
        public DateTime? DatePaid { get; set; }

        [Column("REMARK")]
        public string? Remark { get; set; }

        [Column("Date Received")]
        public DateTime? DateReceived { get; set; }

        [Column("CONTACT")]
        public string? Contact { get; set; }

        [Column("TECHNICIAN")]
        public string? Technician { get; set; }

        [Column("REGION")]
        public string? Region { get; set; }

        [Column("Encoded")]
        public string? Encoded { get; set; }

        [Column("ISSUED AT")]
        public string? IssuedAt { get; set; }

        [Column("COND")]
        public string? Cond { get; set; }

        [Column("e-MAIL")]
        public string? Email { get; set; }

        [Column("DLR1ST")]
        public string? Dlr1st { get; set; }

        [Column("ECE")]
        public string? Ece { get; set; }

        [Column("Approving Officer")]
        public string? ApprovingOfficer { get; set; }

        [Column("Release")]
        public string? Release { get; set; }

        [Column("Fax No")]
        public string? FaxNo { get; set; }

        [Column("Amount")]
        public double? Amount { get; set; }

        [Column("Company Avatar/ Billboard Picture")]
        public string? CompanyAvatarBillboardPicture { get; set; }

        [Column("Type")]
        public string? Type { get; set; }

        [Column("Scan license")]
        public string? ScanLicense { get; set; }

        [Column("Modification")]
        public string? Modification { get; set; }

        [Column("Remarks for Modification")]
        public string? RemarksForModification { get; set; }

        [Column("DEALER TYPE")]
        public string? DealerType { get; set; }

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

        [Column("OFFICIAL RECEIPT2")]
        public int? OfficialReceipt2 { get; set; }

        [Column("Date Paid2")]
        public DateTime? DatePaid2 { get; set; }

        [Column("Amount2", TypeName = "numeric(18,2)")]
        public decimal? Amount2 { get; set; }

        [Timestamp]
        [Column("RowVer")]
        public byte[] RowVer { get; set; } = Array.Empty<byte>();
    }
}