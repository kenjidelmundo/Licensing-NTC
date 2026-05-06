using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicensingAPI.Entities
{
    [Table("accessGROC", Schema = "dbo")]
    public class AccessGROC
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("LICENSEE")]
        public string? Licensee { get; set; }

        [Column("ADDRESS")]
        public string? Address { get; set; }

        [Column("PROVINCE")]
        public string? Province { get; set; }

        [Column("LICENSE NO")]
        public string? LicenseNo { get; set; }

        [Column("BIRTHDAY")]
        public DateTime? Birthday { get; set; }

        [Column("CITIZENSHIP")]
        public string? Citizenship { get; set; }

        [Column("SEX")]
        public string? Sex { get; set; }

        [Column("HEIGHT")]
        public int? Height { get; set; }

        [Column("WEIGHT")]
        public int? Weight { get; set; }

        [Column("OFFICIAL RECEIPT")]
        public int? OfficialReceipt { get; set; }

        [Column("DATE PAID")]
        public DateTime? DatePaid { get; set; }

        [Column("AMOUNT", TypeName = "money")]
        public decimal? Amount { get; set; }

        [Column("DATE ISSUED")]
        public DateTime? DateIssued { get; set; }

        [Column("EXPIRY DATE")]
        public DateTime? ExpiryDate { get; set; }

        [Column("RECOMMENDING APPROVAL")]
        public string? RecommendingApproval { get; set; }

        [Column("REGIONAL DIRECTOR")]
        public string? RegionalDirector { get; set; }

        [Column("POSITION")]
        public string? Position { get; set; }

        [Column("TYPE/CLASS")]
        public string? TypeClass { get; set; }

        [Column("DATE TAKEN")]
        public DateTime? DateTaken { get; set; }

        [Column("PLACE OF EXAM")]
        public string? PlaceOfExam { get; set; }

        [Column("RATING")]
        public string? Rating { get; set; }

        [Column("REMARKS")]
        public string? Remarks { get; set; }

        [Column("ENCODER")]
        public string? Encoder { get; set; }

        [Column("NOTE")]
        public string? Note { get; set; }

        [Column("Userlog")]
        public string? Userlog { get; set; }

        [Column("InsertDate")]
        public DateTime? InsertDate { get; set; }

        [Column("LastUpdateUser")]
        public string? LastUpdateUser { get; set; }

        [Column("LastUpdateDate")]
        public DateTime? LastUpdateDate { get; set; }

        [Column("AccountableFormNumber")]
        public int? AccountableFormNumber { get; set; }

        [Column("OFFICIAL RECEIPT2")]
        public int? OfficialReceipt2 { get; set; }

        [Column("DATE PAID2")]
        public DateTime? DatePaid2 { get; set; }

        [Column("AMOUNT2", TypeName = "money")]
        public decimal? Amount2 { get; set; }

        [Column("SERIES")]
        public int? Series { get; set; }

        [Column("AdminCaseRemark", TypeName = "ntext")]
        public string? AdminCaseRemark { get; set; }

        [Column("DateInspected")]
        public string? DateInspected { get; set; }

        [Column("InspectionMO")]
        public string? InspectionMO { get; set; }

        [Column("isOpen")]
        public bool? IsOpen { get; set; }

        [Column("isPrinted")]
        public bool? IsPrinted { get; set; }

        [Column("RoutingRefNo")]
        public string? RoutingRefNo { get; set; }

        [Column("CertOfCompletionSerialGROC", TypeName = "varchar(255)")]
        public string? CertOfCompletionSerialGROC { get; set; }

        [Timestamp]
        [Column("RowVer")]
        public byte[] RowVer { get; set; } = Array.Empty<byte>();
    }
}