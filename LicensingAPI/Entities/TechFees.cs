using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Licensing.Entities
{
    [Table("tblFees", Schema = "dbo")]
    public class TechFees
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [MaxLength(50)]
        public string? FeeType { get; set; }

        [MaxLength(50)]
        public string? Category { get; set; }

        [MaxLength(100)]
        public string? FeeName { get; set; }

        [MaxLength(50)]
        public string? FeeCode { get; set; }

        [Column(TypeName = "decimal(12, 2)")]
        public decimal? FilingFee { get; set; }

        [Column(TypeName = "decimal(12, 2)")]
        public decimal? PurchaseFee { get; set; }

        [Column(TypeName = "decimal(12, 2)")]
        public decimal? PossessFee { get; set; }

        [Column(TypeName = "decimal(12, 2)")]
        public decimal? ConstructionPermitFee { get; set; }

        [Column(TypeName = "decimal(12, 2)")]
        public decimal? ModificationFee { get; set; }

        [Column(TypeName = "decimal(12, 2)")]
        public decimal? LicenseeFee { get; set; }

        [Column(TypeName = "decimal(12, 2)")]
        public decimal? InspectionFee { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal? DocStampTax { get; set; }

        [Column(TypeName = "decimal(12, 2)")]
        public decimal? TransportFee { get; set; }

        [Column(TypeName = "decimal(12, 2)")]
        public decimal? SellTransferFee { get; set; }

        [Column(TypeName = "decimal(12, 2)")]
        public decimal? DemoPropagateFee { get; set; }

        [MaxLength(50)]
        public string? Mode { get; set; }
    }

    public class TechFeesNew { public decimal? newfees { get; set; } }
    public class TechFeesNewMod { public decimal? newfeesmod { get; set; } }
    public class TechFeesRen { public decimal? renfees { get; set; } }
}
