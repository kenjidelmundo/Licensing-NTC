using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Licensing.Entities
{
    [Table("tblTechService", Schema = "dbo")]
    public class TechService
    {
        [Key]
        [Column("TechServiceID")]
        public int TechServiceID { get; set; }

        [Column("TechServiceName")]
        public string? TechServiceName { get; set; }
    }
}
