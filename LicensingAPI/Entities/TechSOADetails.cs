using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Licensing.Entities
{
    [Table("tblSOADetails", Schema = "dbo")]
    public class TechSOADetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int? SOAID { get; set; }

        [StringLength(50)]
        public string? FeeType { get; set; }

        [StringLength(50)]
        public string? Category { get; set; }

        [StringLength(100)]
        public string? FeeName { get; set; } // safer (often 100 like tblFees)

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
        public decimal? LicenseFee { get; set; }

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

        [StringLength(50)]
        public string? Mode { get; set; }

        [Column(TypeName = "decimal(12, 2)")]
        public decimal? SUF { get; set; }

        [Column(TypeName = "decimal(12, 2)")]
        public decimal? SurChargeSUF { get; set; }

        [Column(TypeName = "decimal(12, 2)")]
        public decimal? SurChargeRSL { get; set; }

        [Column(TypeName = "decimal(12, 2)")]
        public decimal? StorageFee { get; set; }

        public int? AccessByID { get; set; }
        public int? ModifiedByID { get; set; }

        [ForeignKey(nameof(SOAID))]
        public virtual TechSOA? StatementOfAccount { get; set; }
    }
}
