using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicensingAPI.Entities
{
    [Table("accessPermitPurchase", Schema = "dbo")]
    public class AccessPermitPurchase
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

        [Column("Frequency Range")]
        public string? FrequencyRange { get; set; }

        [Column("RF Power Output")]
        public string? RfPowerOutput { get; set; }

        [Column("Official Receipt", TypeName = "decimal(18,0)")]
        public decimal? OfficialReceipt { get; set; }

        [Column("Amount", TypeName = "money")]
        public decimal? Amount { get; set; }

        [Column("Date")]
        public DateTime? Date { get; set; }

        [Column("Encoded")]
        public string? Encoded { get; set; }

        [Column("Released")]
        public DateTime? Released { get; set; }

        [Column("Approving Officer")]
        public string? ApprovingOfficer { get; set; }

        [Column("Frequency Assignment")]
        public string? FrequencyAssignment { get; set; }

        [Column("For new")]
        public string? ForNew { get; set; }

        [Column("Additional")]
        public string? Additional { get; set; }

        [Column("Others")]
        public string? Others { get; set; }

        [Column("Validity")]
        public DateTime? Validity { get; set; }

        [Column("Extension")]
        public DateTime? Extension { get; set; }

        [Column("Position")]
        public string? Position { get; set; }

        [Column("New Radio")]
        public string? NewRadio { get; set; }

        [Column("Additional Radio")]
        public string? AdditionalRadio { get; set; }

        [Column("UnitCount")]
        public int? UnitCount { get; set; }
    }
}