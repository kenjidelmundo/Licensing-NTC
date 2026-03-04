#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LicensingAPI.Data;
using LicensingAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LicensingAPI.Controllers
{
    [ApiController]
    [Route("api/Address")]
    public class AddressController : ControllerBase
    {
        private readonly LicensingDbContext _context;

        public AddressController(LicensingDbContext context)
        {
            _context = context;
        }

        // GET https://localhost:7172/api/Address/ping
        [HttpGet("ping")]
        public IActionResult Ping() => Ok("Address controller is OK");

        // GET https://localhost:7172/api/Address/provinces
        [HttpGet("provinces")]
        public async Task<ActionResult<List<AddressProvinceDto>>> GetProvinces()
        {
            try
            {
                // 1) Provinces
                var provinces = await _context.AddrProvinces
                    .AsNoTracking()
                    .Where(p => p.ProvinceName != null && p.ProvinceName.Trim() != "")
                    .Select(p => new
                    {
                        p.ProvinceId,
                        Province = p.ProvinceName.Trim()
                    })
                    .OrderBy(p => p.Province)
                    .ToListAsync();

                var provinceIds = provinces.Select(p => p.ProvinceId).ToList();

                // 2) Municipalities (Town/City)
                var municipalities = await _context.AddrMunicipalities
                    .AsNoTracking()
                    .Where(m => m.ProvinceId != null && provinceIds.Contains(m.ProvinceId.Value))
                    .Where(m => m.MunicipalityName != null && m.MunicipalityName.Trim() != "")
                    .Select(m => new
                    {
                        m.MunicipalityId,
                        ProvinceId = m.ProvinceId.Value,
                        TownCity = m.MunicipalityName.Trim()
                    })
                    .ToListAsync();

                var municipalityIds = municipalities.Select(m => m.MunicipalityId).ToList();

                // 3) Barangays
                var barangays = await _context.AddrBarangays
                    .AsNoTracking()
                    .Where(b => b.MunicipalityId != null && municipalityIds.Contains(b.MunicipalityId.Value))
                    .Where(b => b.BarangayName != null && b.BarangayName.Trim() != "")
                    .Select(b => new
                    {
                        MunicipalityId = b.MunicipalityId.Value,
                        Brgy = b.BarangayName.Trim()
                    })
                    .ToListAsync();

                // Group barangays by municipality_id
                var brgyByMunicipality = barangays
                    .GroupBy(b => b.MunicipalityId)
                    .ToDictionary(
                        g => g.Key,
                        g => g.Select(x => x.Brgy)
                              .Distinct()
                              .OrderBy(x => x)
                              .ToList()
                    );

                // Group municipalities by province_id and attach barangays
                var townsByProvince = municipalities
                    .GroupBy(m => m.ProvinceId)
                    .ToDictionary(
                        g => g.Key,
                        g => g.OrderBy(x => x.TownCity)
                              .Select(m => new AddressTownDto
                              {
                                  TownCity = m.TownCity,
                                  Barangays = brgyByMunicipality.TryGetValue(m.MunicipalityId, out var list)
                                      ? list
                                      : new List<string>()
                              })
                              .ToList()
                    );

                // Final DTO list (what Angular dialog expects)
                var result = provinces
                    .Select(p => new AddressProvinceDto
                    {
                        Province = p.Province,
                        Towns = townsByProvince.TryGetValue(p.ProvinceId, out var towns)
                            ? towns
                            : new List<AddressTownDto>()
                    })
                    .ToList();

                return Ok(result);
            }
            catch (Exception ex)
            {
                // ✅ so you can see the real reason in Swagger/Network
                return StatusCode(500, ex.ToString());
            }
        }
    }
}