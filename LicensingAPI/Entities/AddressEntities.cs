#nullable disable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Licensing.Entities
{
    // ✅ dbo.dbo_addr_province  -> schema dbo, table dbo_addr_province
    [Table("dbo_addr_province", Schema = "dbo")]
    public class AddrProvince
    {
        [Key]
        [Column("province_id")]
        public int ProvinceId { get; set; }

        [Column("region_id")]
        public int? RegionId { get; set; }

        [Column("province_name")]
        public string ProvinceName { get; set; }

        public ICollection<AddrMunicipality> Municipalities { get; set; }
    }

    // ✅ dbo.dbo_addr_municipality -> table dbo_addr_municipality
    [Table("dbo_addr_municipality", Schema = "dbo")]
    public class AddrMunicipality
    {
        [Key]
        [Column("municipality_id")]
        public int MunicipalityId { get; set; }

        [Column("province_id")]
        public int? ProvinceId { get; set; }

        [Column("municipality_name")]
        public string MunicipalityName { get; set; }

        public AddrProvince Province { get; set; }
        public ICollection<AddrBarangay> Barangays { get; set; }
    }

    // ✅ dbo.dbo_addr_barangay -> table dbo_addr_barangay
    [Table("dbo_addr_barangay", Schema = "dbo")]
    public class AddrBarangay
    {
        [Key]
        [Column("barangay_id")]
        public int BarangayId { get; set; }

        [Column("municipality_id")]
        public int? MunicipalityId { get; set; }

        [Column("barangay_name")]
        public string BarangayName { get; set; }

        [Column("remark")]
        public string Remark { get; set; }

        public AddrMunicipality Municipality { get; set; }
    }

    // ✅ dbo.dbo_addr_region -> table dbo_addr_region
    [Table("dbo_addr_region", Schema = "dbo")]
    public class AddrRegion
    {
        [Key]
        [Column("region_id")]
        public int RegionId { get; set; }

        [Column("region_name")]
        public string RegionName { get; set; }

        [Column("region_description")]
        public string RegionDescription { get; set; }
    }
}