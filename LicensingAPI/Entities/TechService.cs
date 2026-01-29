using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LicensingAPI.Entities
{
    [Table("tblTechService", Schema = "dbo")]
    public class TechService
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int TechServiceId { get; set; }

        public string ServiceName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
