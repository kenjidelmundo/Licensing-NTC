using System.ComponentModel.DataAnnotations;

namespace LicensingAPI.Entities
{
    public class TechEODService
    {
        [Key]
        public int Id { get; set; }

        public string ServiceCode { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
    }
}
