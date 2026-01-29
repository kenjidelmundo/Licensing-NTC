using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicensingAPI.Entities
{
    public class CitizenCharterStages
    {
        [Key]
        public int StageId { get; set; }

        [Required]
        public int GroupId { get; set; }

        [Required]
        public string StageName { get; set; }

        public string Description { get; set; }

        [ForeignKey("GroupId")]
        public CitizenCharterGroup Group { get; set; }
    }
}
