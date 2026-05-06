using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicensingAPI.Entities
{
    [Table("accessRLM", Schema = "dbo")]
    public class AccessRLM
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("NAME")]
        public string? Name { get; set; }

        [Column("LICENSE NO")]
        public string? LicenseNo { get; set; }

        [Column("SERIES")]
        public string? Series { get; set; }

        [Column("REMARK")]
        public string? Remark { get; set; }

        [Column("ISSUED")]
        public DateTime? Issued { get; set; }

        [Column("VALID UNTIL")]
        public DateTime? ValidUntil { get; set; }

        [Column("OPERATOR FEE")]
        public string? OperatorFee { get; set; }

        [Column("ADDRESS")]
        public string? Address { get; set; }

        [Column("BIRTHDATE")]
        public DateTime? Birthdate { get; set; }

        [Column("HEIGHT")]
        public string? Height { get; set; }

        [Column("WEIGHT")]
        public string? Weight { get; set; }

        [Column("CITIZENSHIP")]
        public string? Citizenship { get; set; }

        [Column("SEX")]
        public string? Sex { get; set; }

        [Column("COMPANY")]
        public string? Company { get; set; }

        [Column("DATE OF SEM")]
        public string? DateOfSem { get; set; }

        [Column("PLACE OF SEM")]
        public string? PlaceOfSem { get; set; }

        [Column("Official Receipt")]
        public string? OfficialReceipt { get; set; }

        [Column("Amount", TypeName = "money")]
        public decimal? Amount { get; set; }

        [Column("DATE PAID")]
        public DateTime? DatePaid { get; set; }

        [Column("FOR THE COMMISSION")]
        public string? ForTheCommission { get; set; }

        [Column("POSITION")]
        public string? Position { get; set; }

        [Column("Encoded")]
        public string? Encoded { get; set; }

        [Column("LAST NAME")]
        public string? LastName { get; set; }

        [Column("FIRST NAME")]
        public string? FirstName { get; set; }

        [Column("MIDDLE NAME")]
        public string? MiddleName { get; set; }

        [Column("OPERATOR FEES")]
        public string? OperatorFees { get; set; }

        [Column("DOC STAMP")]
        public string? DocStamp { get; set; }

        [Column("RELEASED DATE")]
        public string? ReleasedDate { get; set; }

        [Column("AccountableForm")]
        public string? AccountableForm { get; set; }

        [Column("Official Receipt2")]
        public string? OfficialReceipt2 { get; set; }

        [Column("Amount2", TypeName = "money")]
        public decimal? Amount2 { get; set; }

        [Column("Date Paid2")]
        public DateTime? DatePaid2 { get; set; }

        [Column("OPERATOR FEES2")]
        public string? OperatorFees2 { get; set; }

        [Column("Status")]
        [StringLength(10)]
        public string? Status { get; set; }

        [Column("Mobile Note")]
        public string? MobileNote { get; set; }

        [Column("isOpen")]
        public bool? IsOpen { get; set; }

        [Column("isPrinted")]
        public bool? IsPrinted { get; set; }

        [Column("RoutingRefNo")]
        public string? RoutingRefNo { get; set; }
    }
}