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

        // ✅ ADD THESE TWO (fix CS1061)
        // IMPORTANT: column names must match your DB columns.
        // If your DB column is different, change "Code" / "Amount" below.
        [Column("Code")]
        [MaxLength(50)]
        public string? Code { get; set; }

        [Column("Amount")]
        public decimal? Amount { get; set; }

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

        public virtual TechCCGroup? CitizenCharterGroup { get; set; }
    }
}