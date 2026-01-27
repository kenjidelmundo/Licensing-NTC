using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LicensingAPI.Entities
{
    [Table("SOA_Details")]
    public class SOA_Details
    {
        [Key]
        [Column("SOADetailId")]
        public int SOADetailId { get; set; }

        [Column("SOAId")]
        public int? SOAId { get; set; }

        public string? Description { get; set; }

        public decimal? Amount { get; set; }

        [JsonIgnore]
        public SOA? SOA { get; set; }
    }
}
