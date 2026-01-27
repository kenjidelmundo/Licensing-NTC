using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicensingAPI.Entities
{
    [Table("SOA")]
    public class SOA
    {
        [Key]
        [Column("SOAId")]
        public int SOAId { get; set; }

        public string? SOANumber { get; set; }

        public DateTime? SOADate { get; set; }

        public ICollection<SOA_Details>? SOA_Details { get; set; }
    }
}
