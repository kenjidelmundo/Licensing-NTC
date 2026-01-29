using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicensingAPI.Entities
{
    public class SOA_Details
    {
        [Key]
        public int SOADetailId { get; set; }

        [Required]
        public int SOAId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Amount { get; set; }

        // Optional navigation
        [ForeignKey("SOAId")]
        public SOA SOA { get; set; }
    }
}
