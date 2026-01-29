using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Licensing.Entities
{
    [Table("tblSUFRate", Schema = "dbo")]
    public class TechSUFRate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [MaxLength(100)]
        public string? RadioType { get; set; }

        [MaxLength(50)]
        public string? Category { get; set; }

        [MaxLength(50)]
        public string? Mode { get; set; }

        [MaxLength(50)]
        public string? FeeCode { get; set; }

        public string? Description { get; set; }

        [Column(TypeName = "decimal(12, 2)")]
        public decimal? MetroManilaRate { get; set; }

        [Column(TypeName = "decimal(12, 2)")]
        public decimal? HighlyUrbanizedCities { get; set; }

        [Column(TypeName = "decimal(12, 2)")]
        public decimal? AllOtherAreas { get; set; }

        [Column(TypeName = "decimal(12, 2)")]
        public decimal? GeneralFee { get; set; }
    }

    // Keyless scalar function output
    public class TechFeesSUFRate
    {
        public decimal? sufratefee { get; set; }
    }
}
