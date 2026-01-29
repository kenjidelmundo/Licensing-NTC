using System.ComponentModel.DataAnnotations;

namespace LicensingAPI.Entities
{
    public class CitizenCharterGroup
    {
        [Key]
        public int GroupId { get; set; }

        [Required]
        public string GroupName { get; set; }

        public string Description { get; set; }
    }
}
