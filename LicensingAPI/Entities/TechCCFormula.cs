using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Licensing.Entities
{
    [Table("tblCitizenCharterFormula", Schema = "dbo")]
    public class TechCCFormula
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("CitizenCharterComputeFeeID")]
        public int CitizenCharterComputeFeeID { get; set; }

        [Column("CitizenCharterGroupID")]
        public int CitizenCharterGroupID { get; set; }

        [Column("Title")]
        [MaxLength(200)]
        public string? Title { get; set; }

        [Column("Formula")]
        [MaxLength(200)]
        public string? Formula { get; set; }

        [Column("Legend")]
        [MaxLength(200)]
        public string? Legend { get; set; }

        [Column("Notes")]
        public string? Notes { get; set; }

        // This navigation works ONLY if TechCCGroup has a [Key]
        public virtual TechCCGroup? CitizenCharterGroup { get; set; }
    }
}
