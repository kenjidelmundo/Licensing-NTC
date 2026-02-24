#nullable disable
using LicensingAPI.Data;
using LicensingAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LicensingAPI.Controllers
{
    // ✅ force controller discovery + exact route
    [ApiController]
    [Route("api/Address")]
    public class AddressController : ControllerBase
    {
        private readonly LicensingDbContext _context;

        public AddressController(LicensingDbContext context)
        {
            _context = context;
        }

        // ✅ TEST FIRST (must return 200)
        // GET https://localhost:7172/api/Address/ping
        [HttpGet("ping")]
        public IActionResult Ping() => Ok("Address controller is OK");

        // ✅ REAL ENDPOINT
        // GET https://localhost:7172/api/Address/provinces
        [HttpGet("provinces")]
        public async Task<IActionResult> GetProvinces()
        {
            var provinces = await _context.AddrProvinces
                .AsNoTracking()
                .Include(p => p.Municipalities)
                    .ThenInclude(m => m.Barangays)
                .OrderBy(p => p.ProvinceName)
                .ToListAsync();

            var result = provinces.Select(p => new AddressProvinceDto
            {
                Province = (p.ProvinceName ?? "").Trim(),
                Towns = (p.Municipalities ?? Enumerable.Empty<Licensing.Entities.AddrMunicipality>())
                    .Where(m => !string.IsNullOrWhiteSpace(m.MunicipalityName))
                    .OrderBy(m => m.MunicipalityName)
                    .Select(m => new AddressTownDto
                    {
                        TownCity = m.MunicipalityName.Trim(),
                        Barangays = (m.Barangays ?? Enumerable.Empty<Licensing.Entities.AddrBarangay>())
                            .Where(b => !string.IsNullOrWhiteSpace(b.BarangayName))
                            .Select(b => b.BarangayName.Trim())
                            .Distinct()
                            .OrderBy(x => x)
                            .ToList()
                    })
                    .ToList()
            }).ToList();

            return Ok(result);
        }
    }
}