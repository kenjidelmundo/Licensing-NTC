using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Licensing.Entities
{
    [Table("tblCitizenCharterStages", Schema = "dbo")]
    public class TechCCStages
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("StagesID")]
        public int StagesID { get; set; }

        [Column("StagesName")]
        public string? StagesName { get; set; }
    }
}
