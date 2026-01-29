using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Licensing.Entities
{
    [Table("tblCitizenCharterGroup", Schema = "dbo")]
    public class TechCCGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("CitizenCharterGroupID")]
        public int CitizenCharterGroupID { get; set; }

        [Column("Name")]
        public string? Name { get; set; }

        [Column("ShortName")]
        public string? ShortName { get; set; }

        // FIX: make DB mapping explicit (no new fields added)
        [Column("New")]
        public bool? New { get; set; }

        [Column("Renewal")]
        public bool? Renewal { get; set; }

        [Column("Modification")]
        public bool? Modification { get; set; }

        [Column("Duplicate")]
        public bool? Duplicate { get; set; }

        [Column("Authenticate")]
        public bool? Authenticate { get; set; }

        public ICollection<TechCCFormula> TechCCFormula { get; set; } = new List<TechCCFormula>();
    }
}
