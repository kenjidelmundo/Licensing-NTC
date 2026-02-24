#nullable disable
using System.Collections.Generic;

namespace LicensingAPI.DTOs
{
    public class AddressProvinceDto
    {
        public string Province { get; set; }
        public List<AddressTownDto> Towns { get; set; } = new();
    }

    public class AddressTownDto
    {
        public string TownCity { get; set; }
        public List<string> Barangays { get; set; } = new();
    }
}