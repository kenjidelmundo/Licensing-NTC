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
    public class TechCCFormulaController : ControllerBase
    {
        private readonly LicensingDbContext _context;

        public TechCCFormulaController(LicensingDbContext context)
        {
            _context = context;
        }

        // =========================
        // GET: api/TechCCFormula
        // =========================
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TechCCFormula>>> GetAllCCFormula()
        {
            var list = await _context.CitizenCharterFormula
                .AsNoTracking()
                .ToListAsync();

            return Ok(list);
        }

        // =========================
        // GET: api/TechCCFormula/{id}
        // =========================
        [HttpGet("{id:int}", Name = "GetCCFormula")]
        public async Task<ActionResult<TechCCFormula>> GetCCFormula(int id)
        {
            var qry = await _context.CitizenCharterFormula
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.CitizenCharterComputeFeeID == id);

            if (qry == null) return NotFound($"CitizenCharterComputeFeeID {id} not found.");

            return Ok(qry);
        }

        // =========================
        // GET: api/TechCCFormula/byCCGroup/{id}
        // =========================
        [HttpGet("byCCGroup/{id:int}", Name = "GetByCCGroup")]
        public async Task<IActionResult> GetByCCGroup(int id)
        {
            var qry = await _context.CitizenCharterFormula
                .AsNoTracking()
                .Include(t => t.CitizenCharterGroup)
                .Where(g => g.CitizenCharterGroupID == id)
                .Select(g => new
                {
                    g.CitizenCharterComputeFeeID,
                    g.CitizenCharterGroupID,
                    g.Title,
                    g.Formula,
                    g.Legend,
                    g.Notes,
                    CitizenCharterGroup = g.CitizenCharterGroup == null ? null : new
                    {
                        g.CitizenCharterGroup.CitizenCharterGroupID,
                        g.CitizenCharterGroup.Name
                    }
                })
                .ToListAsync();

            return Ok(qry);
        }

        // =========================
        // POST: api/TechCCFormula
        // =========================
        [HttpPost]
        public async Task<ActionResult<TechCCFormula>> CreateCCFormula([FromBody] TechCCFormula model)
        {
            if (model == null) return BadRequest("Body is required.");

            // FIX: prevent EF from trying to insert/update the navigation object
            model.CitizenCharterGroup = null;

            _context.CitizenCharterFormula.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtRoute(
                "GetCCFormula",
                new { id = model.CitizenCharterComputeFeeID },
                model
            );
        }

        // =========================
        // PUT: api/TechCCFormula/{id}
        // =========================
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCCFormula(int id, [FromBody] TechCCFormula model)
        {
            if (model == null) return BadRequest("Body is required.");

            if (id != model.CitizenCharterComputeFeeID)
                return BadRequest("ID mismatch.");

            var exists = await _context.CitizenCharterFormula
                .AnyAsync(x => x.CitizenCharterComputeFeeID == id);

            if (!exists) return NotFound($"CitizenCharterComputeFeeID {id} not found.");

            // FIX: prevent EF from trying to insert/update the navigation object
            model.CitizenCharterGroup = null;

            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(model);
        }

        // =========================
        // DELETE: api/TechCCFormula/{id}
        // =========================
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCCFormula(int id)
        {
            var rec = await _context.CitizenCharterFormula
                .FirstOrDefaultAsync(x => x.CitizenCharterComputeFeeID == id);

            if (rec == null) return NotFound($"CitizenCharterComputeFeeID {id} not found.");

            _context.CitizenCharterFormula.Remove(rec);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
