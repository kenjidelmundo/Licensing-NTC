using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicensingAPI.Entities
{
    [Table("accessPermitSellTransfer", Schema = "dbo")]
    public class AccessPermitSellTransfer
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

        [Column("Date Processed")]
        public DateTime? DateProcessed { get; set; }

        [Column("Model")]
        public string? Model { get; set; }

        [Column("No Of Units")]
        public string? NoOfUnits { get; set; }

        [Column("Serial Numbers")]
        public string? SerialNumbers { get; set; }

        [Column("Official Receipt", TypeName = "decimal(18,0)")]
        public decimal? OfficialReceipt { get; set; }

        [Column("Amount", TypeName = "money")]
        public decimal? Amount { get; set; }

        [Column("Date")]
        public DateTime? Date { get; set; }

        [Column("Encoded")]
        public string? Encoded { get; set; }

        [Column("Buyer")]
        public string? Buyer { get; set; }

        [Column("Buyer Address")]
        public string? BuyerAddress { get; set; }

        [Column("PPurchase No")]
        public string? PPurchaseNo { get; set; }

        [Column("PPurchase Date Issue")]
        public string? PPurchaseDateIssue { get; set; }

        [Column("Intended Use")]
        public string? IntendedUse { get; set; }

        [Column("Approving Officer")]
        public string? ApprovingOfficer { get; set; }

        [Column("Position")]
        public string? Position { get; set; }

        [Column("UnitCount")]
        public int? UnitCount { get; set; }
    }
}