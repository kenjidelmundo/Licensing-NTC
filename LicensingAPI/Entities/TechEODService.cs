using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicensingAPI.Entities
{
    [Table("tblEODService", Schema = "dbo")]
    public class TechEODService
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("EODservicesID")]
        public int EODservicesID { get; set; }

        [Column("CitizenCharterGroupID")]
        public int? CitizenCharterGroupID { get; set; }

        [Column("ServiceName", TypeName = "varchar(100)")]
        public string? ServiceName { get; set; }

        [Column("ServiceGroup", TypeName = "varchar(100)")]
        public string? ServiceGroup { get; set; }

        [Column("IsEnable")] public bool? IsEnable { get; set; }

        [Column("Purchase")] public bool? Purchase { get; set; }
        [Column("Possess")] public bool? Possess { get; set; }
        [Column("New")] public bool? New { get; set; }
        [Column("Renewal")] public bool? Renewal { get; set; }
        [Column("Modification")] public bool? Modification { get; set; }
        [Column("Duplicate")] public bool? Duplicate { get; set; }
        [Column("Authenticate")] public bool? Authenticate { get; set; }
        [Column("Storage")] public bool? Storage { get; set; }
        [Column("SellTransfer")] public bool? SellTransfer { get; set; }

        [Column("IsPurchaseAllowed")] public bool? IsPurchaseAllowed { get; set; }
        [Column("IsPossessAllowed")] public bool? IsPossessAllowed { get; set; }
        [Column("IsNewAllowed")] public bool? IsNewAllowed { get; set; }
        [Column("IsRenewalAllowed")] public bool? IsRenewalAllowed { get; set; }
        [Column("IsModificationAllowed")] public bool? IsModificationAllowed { get; set; }
        [Column("IsDuplicateAllowed")] public bool? IsDuplicateAllowed { get; set; }
        [Column("IsAuthenticateAllowed")] public bool? IsAuthenticateAllowed { get; set; }
        [Column("IsStorageAllowed")] public bool? IsStorageAllowed { get; set; }
        [Column("IsSellTransferAllowed")] public bool? IsSellTransferAllowed { get; set; }
    }
}
