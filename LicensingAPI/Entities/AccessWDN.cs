using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicensingAPI.Entities
{
    [Table("accessWDN", Schema = "dbo")]
    public class AccessWDN
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("ISSUED")]
        public DateTime? Issued { get; set; }

        [Column("PERMIT_PRE")]
        public string? PermitPre { get; set; }

        [Column("PERMIT_NO")]
        public string? PermitNo { get; set; }

        [Column("PERMIT_YEAR")]
        public string? PermitYear { get; set; }

        [Column("LICENSE_STATUS")]
        public string? LicenseStatus { get; set; }

        [Column("NAME OF COMPANY")]
        public string? NameOfCompany { get; set; }

        [Column("ADDRESS")]
        public string? Address { get; set; }

        [Column("VALIDITY")]
        public DateTime? Validity { get; set; }

        [Column("ECE")]
        public string? Ece { get; set; }

        [Column("O R NO")]
        public string? OrNo { get; set; }

        [Column("DATE")]
        public DateTime? Date { get; set; }

        [Column("AMOUNT", TypeName = "money")]
        public decimal? Amount { get; set; }

        [Column("Scan License")]
        public string? ScanLicense { get; set; }

        [Column("TYPE_OF_SERVICE")]
        public string? TypeOfService { get; set; }

        [Column("ISSUANCE_ADDRESS")]
        public string? IssuanceAddress { get; set; }

        [Column("ENGR_ASSIGNED")]
        public string? EngrAssigned { get; set; }

        [Column("ENGR_LICENSE")]
        public string? EngrLicense { get; set; }

        [Column("ENGR_LICENSE_VALIDITY")]
        public DateTime? EngrLicenseValidity { get; set; }

        [Column("NAME_OF_TECHNICIAN")]
        public string? NameOfTechnician { get; set; }

        [Column("REMARKS")]
        public string? Remarks { get; set; }

        [Column("Valid From")]
        public DateTime? ValidFrom { get; set; }

        [Column("OLD PERMIT NO")]
        public string? OldPermitNo { get; set; }

        [Column("Contact")]
        public string? Contact { get; set; }

        [Column("Encoded")]
        public string? Encoded { get; set; }

        [Column("AccountableForm")]
        public string? AccountableForm { get; set; }

        [Column("DateInspected")]
        [StringLength(10)]
        public string? DateInspected { get; set; }

        [Column("InspectionMO")]
        [StringLength(50)]
        public string? InspectionMO { get; set; }

        [Column("AdminCase")]
        public string? AdminCase { get; set; }

        [Column("AdminCaseRemark")]
        public string? AdminCaseRemark { get; set; }
    }
}