using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicensingAPI.Entities
{
    [Table("accessPermitTransport", Schema = "dbo")]
    public class AccessPermitTransport
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("REFERENCE NO")]
        public string? ReferenceNo { get; set; }

        [Column("APPLICANT")]
        public string? Applicant { get; set; }

        [Column("ADDRESS")]
        public string? Address { get; set; }

        [Column("Date Processed")]
        public DateTime? DateProcessed { get; set; }

        [Column("TEL NO")]
        [StringLength(50)]
        public string? TelNo { get; set; }

        [Column("NAME AUTHORIZED REP")]
        public string? NameAuthorizedRep { get; set; }

        [Column("Date Transport")]
        public string? DateTransport { get; set; }

        [Column("PLACE OF ORIGIN")]
        public string? PlaceOfOrigin { get; set; }

        [Column("DESTINATION")]
        public string? Destination { get; set; }

        [Column("PURPOSE")]
        public string? Purpose { get; set; }

        [Column("IsCopyPermittoPossess")]
        public bool? IsCopyPermitToPossess { get; set; }

        [Column("IsCopyRLS")]
        public bool? IsCopyRLS { get; set; }

        [Column("IsCopyDealersPermit")]
        public bool? IsCopyDealersPermit { get; set; }

        [Column("Other Attachment")]
        public string? OtherAttachment { get; set; }

        [Column("Model")]
        public string? Model { get; set; }

        [Column("Serial Numbers")]
        public string? SerialNumbers { get; set; }

        [Column("Model1")]
        public string? Model1 { get; set; }

        [Column("Serial Numbers1")]
        public string? SerialNumbers1 { get; set; }

        [Column("Official Receipt", TypeName = "decimal(18,0)")]
        public decimal? OfficialReceipt { get; set; }

        [Column("Amount", TypeName = "money")]
        public decimal? Amount { get; set; }

        [Column("Date")]
        public DateTime? Date { get; set; }

        [Column("Encoded")]
        public string? Encoded { get; set; }

        [Column("Applicant Name")]
        public string? ApplicantName { get; set; }

        [Column("Permit No")]
        public string? PermitNo { get; set; }

        [Column("Date Issued")]
        public DateTime? DateIssued { get; set; }

        [Column("Approving Officer")]
        public string? ApprovingOfficer { get; set; }

        [Column("Position")]
        public string? Position { get; set; }
    }
}