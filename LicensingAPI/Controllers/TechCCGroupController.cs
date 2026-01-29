#nullable disable
using LicensingAPI.Data;
using Licensing.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicensingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechCCGroupController : ControllerBase
    {
        private readonly LicensingDbContext _context;

        public TechCCGroupController(LicensingDbContext context)
        {
            _context = context;
        }

        // GET: api/TechCCGroup
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TechCCGroup>>> GetAllGroups()
        {
            var list = await _context.CitizenCharterGroup
                .AsNoTracking()
                .Include(f => f.TechCCFormula)
                .Where(f => f.ShortName != "CWaP Unit")
                .ToListAsync();

            return Ok(list);
        }

        // GET: api/TechCCGroup/ccgroup/{id}
        [HttpGet("ccgroup/{id:int}", Name = "GetCCGroup")]
        public async Task<ActionResult<TechCCGroup>> GetCCGroup(int id)
        {
            var qry = await _context.CitizenCharterGroup
                .AsNoTracking()
                .Include(f => f.TechCCFormula)
                .FirstOrDefaultAsync(m => m.CitizenCharterGroupID == id);

            if (qry == null) return NotFound($"CitizenCharterGroupID {id} not found.");

            return Ok(qry);
        }

        // POST: api/TechCCGroup
        [HttpPost]
        public async Task<ActionResult<TechCCGroup>> CreateCCGroup([FromBody] TechCCGroup model)
        {
            if (model == null) return BadRequest("Body is required.");

            // FIX: prevent EF from trying to insert formulas if client sends them
            model.TechCCFormula = null;

            _context.CitizenCharterGroup.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetCCGroup", new { id = model.CitizenCharterGroupID }, model);
        }

        // PUT: api/TechCCGroup/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCCGroup(int id, [FromBody] TechCCGroup model)
        {
            if (model == null) return BadRequest("Body is required.");

            if (id != model.CitizenCharterGroupID)
                return BadRequest("ID mismatch.");

            var exists = await _context.CitizenCharterGroup
                .AnyAsync(x => x.CitizenCharterGroupID == id);

            if (!exists) return NotFound($"CitizenCharterGroupID {id} not found.");

            // FIX: update only group row, not child collection
            model.TechCCFormula = null;

            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(model);
        }

        // DELETE: api/TechCCGroup/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCCGroup(int id)
        {
            var rec = await _context.CitizenCharterGroup
                .FirstOrDefaultAsync(x => x.CitizenCharterGroupID == id);

            if (rec == null) return NotFound($"CitizenCharterGroupID {id} not found.");

            _context.CitizenCharterGroup.Remove(rec);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
