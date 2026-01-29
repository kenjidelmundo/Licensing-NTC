using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Licensing.Entities
{
    [Table("tblStatementOfAccount", Schema = "dbo")]
    public class TechSOA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("SOAID")]
        public int SOAID { get; set; }

        public int? LicenseID { get; set; }
        public int? PreparedByID { get; set; }
        public int? ApprovedByID { get; set; }

        public DateTime? PeriodCoveredFrom { get; set; }
        public DateTime? PeriodCoveredTo { get; set; }

        public string? Particulars { get; set; }
        public string? Address { get; set; }
        public string? RoutingSlip { get; set; }

        public int? ModifiedByID { get; set; }
        public DateTime? DateIssued { get; set; }

        public ICollection<TechSOADetails> TechSOADetails { get; set; } = new List<TechSOADetails>();
    }
}
