#nullable disable
using LicensingAPI.Data;
using Licensing.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LicensingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechCCStagesController : ControllerBase
    {
        private readonly LicensingDbContext _context;

        public TechCCStagesController(LicensingDbContext context)
        {
            _context = context;
        }

        // =========================
        // GET: api/TechCCStages
        // =========================
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TechCCStages>>> GetTechCCStagesList()
        {
            var list = await _context.CitizenCharterStages
                .AsNoTracking()
                .ToListAsync();

            return Ok(list);
        }

        // =========================
        // GET: api/TechCCStages/{id}
        // =========================
        [HttpGet("{id:int}", Name = "GetCCStage")]
        public async Task<ActionResult<TechCCStages>> GetCCStage(int id)
        {
            var rec = await _context.CitizenCharterStages
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.StagesID == id);

            if (rec == null) return NotFound($"StagesID {id} not found.");
            return Ok(rec);
        }

        // =========================
        // POST: api/TechCCStages
        // =========================
        [HttpPost]
        public async Task<ActionResult<TechCCStages>> CreateCCStage([FromBody] TechCCStages model)
        {
            if (model == null) return BadRequest("Body is required.");

            _context.CitizenCharterStages.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetCCStage", new { id = model.StagesID }, model);
        }

        // =========================
        // PUT: api/TechCCStages/{id}
        // =========================
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCCStage(int id, [FromBody] TechCCStages model)
        {
            if (model == null) return BadRequest("Body is required.");

            if (id != model.StagesID)
                return BadRequest("ID mismatch.");

            var exists = await _context.CitizenCharterStages
                .AnyAsync(x => x.StagesID == id);

            if (!exists) return NotFound($"StagesID {id} not found.");

            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(model);
        }

        // =========================
        // DELETE: api/TechCCStages/{id}
        // =========================
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCCStage(int id)
        {
            var rec = await _context.CitizenCharterStages
                .FirstOrDefaultAsync(x => x.StagesID == id);

            if (rec == null) return NotFound($"StagesID {id} not found.");

            _context.CitizenCharterStages.Remove(rec);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
