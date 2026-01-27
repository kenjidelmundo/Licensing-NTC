using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicensingAPI.Entities
{
    [Table("tblEODService")]
    public class TechEODService
    {
        [Key]
        public int Id { get; set; }

        public string? ServiceCode { get; set; }
        public string? ServiceName { get; set; }
        public string? Description { get; set; }
    }
}
