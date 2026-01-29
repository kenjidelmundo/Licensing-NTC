using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LicensingAPI.Entities
{
    [Table("tblFees", Schema = "dbo")]
    public class Fees
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int FeeId { get; set; }

        public string FeeName { get; set; } = string.Empty;
        public decimal Amount { get; set; }

        public int TechServiceId { get; set; }
    }
}
