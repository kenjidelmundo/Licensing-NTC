#nullable disable
using LicensingAPI.Data;
using LicensingAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LicensingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechEODServiceController : ControllerBase
    {
        private readonly LicensingDbContext _context;

        public TechEODServiceController(LicensingDbContext context)
        {
            _context = context;
        }

        // GET: api/TechEODService
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TechEODService>>> GetTechEODServices()
        {
            var list = await _context.TechEODService
                .AsNoTracking()
                .ToListAsync();

            return Ok(list);
        }

        // GET: api/TechEODService/{id}
        [HttpGet("{id:int}", Name = "GetTechEODService")]
        public async Task<ActionResult<TechEODService>> GetTechEODService(int id)
        {
            var rec = await _context.TechEODService
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.EODservicesID == id);

            if (rec == null) return NotFound($"EODservicesID {id} not found.");

            return Ok(rec);
        }

        // POST: api/TechEODService
        [HttpPost]
        public async Task<ActionResult<TechEODService>> PostTechEODService([FromBody] TechEODService model)
        {
            if (model == null) return BadRequest("Body is required.");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.TechEODService.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetTechEODService", new { id = model.EODservicesID }, model);
        }

        // PUT: api/TechEODService/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutTechEODService(int id, [FromBody] TechEODService model)
        {
            if (model == null) return BadRequest("Body is required.");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (id != model.EODservicesID)
                return BadRequest("Route id does not match entity key.");

            var exists = await _context.TechEODService.AnyAsync(x => x.EODservicesID == id);
            if (!exists) return NotFound($"EODservicesID {id} not found.");

            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(model);
        }

        // DELETE: api/TechEODService/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTechEODService(int id)
        {
            var rec = await _context.TechEODService
                .FirstOrDefaultAsync(x => x.EODservicesID == id);

            if (rec == null) return NotFound($"EODservicesID {id} not found.");

            _context.TechEODService.Remove(rec);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
