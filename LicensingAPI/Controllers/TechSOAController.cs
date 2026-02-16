#nullable disable
using LicensingAPI.Data;
using LicensingAPI.DTOs;
using Licensing.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LicensingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechSOAController : ControllerBase
    {
        private readonly LicensingDbContext _context;

        public TechSOAController(LicensingDbContext context)
        {
            _context = context;
        }

        // ✅ GET: api/TechSOA
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var rows = await _context.accessSOA
                .AsNoTracking()
                .OrderByDescending(x => x.ID)
                .ToListAsync();

            return Ok(rows);
        }

        // ✅ GET: api/TechSOA/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var row = await _context.accessSOA
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ID == id);

            if (row == null) return NotFound($"ID {id} not found.");
            return Ok(row);
        }

        // ✅ GET: api/TechSOA/payees
        // For your dropdown (since you have no Payees table)
        [HttpGet("payees")]
        public async Task<IActionResult> GetPayees()
        {
            var payees = await _context.accessSOA
                .AsNoTracking()
                .Select(x => x.Licensee)
                .Where(x => x != null && x.Trim() != "")
                .Select(x => x.Trim())
                .Distinct()
                .OrderBy(x => x)
                .ToListAsync();

            return Ok(payees);
        }

        // ✅ POST: api/TechSOA/header  (kept your route)
        [HttpPost("header")]
        public async Task<IActionResult> CreateHeader([FromBody] TechSOAHeaderCreateDto dto)
        {
            if (dto == null) return BadRequest("Body is required.");

            // Build Period Covered text
            string periodCovered = null;
            if (dto.PeriodFrom.HasValue || dto.PeriodTo.HasValue || dto.PeriodYears.HasValue)
            {
                string from = dto.PeriodFrom?.ToString("yyyy-MM-dd") ?? "";
                string to = dto.PeriodTo?.ToString("yyyy-MM-dd") ?? "";
                string yrs = dto.PeriodYears.HasValue ? $" ({dto.PeriodYears.Value} years)" : "";

                periodCovered = $"{from} to {to}{yrs}".Trim();

                if (!string.IsNullOrEmpty(periodCovered) && periodCovered.Length > 255)
                    periodCovered = periodCovered.Substring(0, 255);
            }

            var entity = new TechSOA
            {
                DateIssued = dto.DateIssued,
                Licensee = dto.Licensee,
                Address = dto.Address,
                Particulars = dto.Particulars,
                PeriodCovered = periodCovered
            };

            _context.accessSOA.Add(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = entity.ID }, entity);
        }

        // ✅ PUT: api/TechSOA/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateHeader(int id, [FromBody] TechSOAHeaderCreateDto dto)
        {
            if (dto == null) return BadRequest("Body is required.");

            var entity = await _context.accessSOA.FirstOrDefaultAsync(x => x.ID == id);
            if (entity == null) return NotFound($"ID {id} not found.");

            string periodCovered = null;
            if (dto.PeriodFrom.HasValue || dto.PeriodTo.HasValue || dto.PeriodYears.HasValue)
            {
                string from = dto.PeriodFrom?.ToString("yyyy-MM-dd") ?? "";
                string to = dto.PeriodTo?.ToString("yyyy-MM-dd") ?? "";
                string yrs = dto.PeriodYears.HasValue ? $" ({dto.PeriodYears.Value} years)" : "";
                periodCovered = $"{from} to {to}{yrs}".Trim();
                if (!string.IsNullOrEmpty(periodCovered) && periodCovered.Length > 255)
                    periodCovered = periodCovered.Substring(0, 255);
            }

            entity.DateIssued = dto.DateIssued;
            entity.Licensee = dto.Licensee;
            entity.Address = dto.Address;
            entity.Particulars = dto.Particulars;
            entity.PeriodCovered = periodCovered;

            await _context.SaveChangesAsync();
            return Ok(entity);
        }

        // ✅ DELETE: api/TechSOA/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteHeader(int id)
        {
            var entity = await _context.accessSOA.FirstOrDefaultAsync(x => x.ID == id);
            if (entity == null) return NotFound($"ID {id} not found.");

            _context.accessSOA.Remove(entity);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
