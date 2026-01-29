using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LicensingAPI.Entities
{
    [Table("SOA", Schema = "dbo")]
    public class SOA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore] // ID not inputtable
        public int SOAId { get; set; }

        public string SOANumber { get; set; } = string.Empty;

        public DateTime? SOADate { get; set; }
    }
}
