#nullable disable
using LicensingAPI.Data;
using Licensing.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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

        // POST: api/TechSOA/header
        [HttpPost("header")]
        public async Task<IActionResult> CreateHeader([FromBody] TechSOAHeaderCreateDto dto)
        {
            if (dto == null) return BadRequest("Body is required.");

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

            return Ok(entity);
        }

        // GET: api/TechSOA/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var row = await _context.accessSOA.AsNoTracking().FirstOrDefaultAsync(x => x.ID == id);
            if (row == null) return NotFound($"ID {id} not found.");
            return Ok(row);
        }
    }
}
