using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Licensing.Entities
{
    [Table("accessSOA", Schema = "dbo")]
    public class TechSOA
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int ID { get; set; }

        [Column("Date Issued")]
        public DateTime? DateIssued { get; set; }

        [Column("LICENSEE")]
        [MaxLength(255)]
        public string? Licensee { get; set; }

        [Column("Address")]
        [MaxLength(255)]
        public string? Address { get; set; }

        [Column("Particulars")]
        [MaxLength(255)]
        public string? Particulars { get; set; }

        [Column("Period Covered")]
        [MaxLength(255)]
        public string? PeriodCovered { get; set; }
    }
}
