using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicensingAPI.Entities
{
    public class CitizenCharterFormula
    {
        [Key]
        public int FormulaId { get; set; }

        [Required]
        public int StageId { get; set; }

        [Required]
        public string FormulaDescription { get; set; }

        [ForeignKey("StageId")]
        public CitizenCharterStages Stage { get; set; }
    }
}
