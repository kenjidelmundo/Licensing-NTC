using LicensingAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AmateurFullEntity = LicensingAPI.Entities.AccessAmateurFull;

namespace LicensingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessAmateurFullController : ControllerBase
    {
        private readonly LicensingDbContext _context;

        public AccessAmateurFullController(LicensingDbContext context)
        {
            _context = context;
        }

        // GET: api/AccessAmateurFull
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AmateurFullEntity>>> GetAll()
        {
            var records = await _context.accessAmateurFull
                .AsNoTracking()
                .ToListAsync();

            return Ok(records);
        }

        // GET: api/AccessAmateurFull/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AmateurFullEntity>> GetById(int id)
        {
            var record = await _context.accessAmateurFull
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ID == id);

            if (record == null)
                return NotFound();

            return Ok(record);
        }

        // GET: api/AccessAmateurFull/search?keyword=test
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<AmateurFullEntity>>> Search([FromQuery] string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return BadRequest("Keyword is required.");

            keyword = keyword.Trim();

            var records = await _context.accessAmateurFull
                .AsNoTracking()
                .Where(x =>
                    (x.Licensee != null && x.Licensee.Contains(keyword)) ||
                    (x.Registration != null && x.Registration.Contains(keyword)) ||
                    (x.Callsign != null && x.Callsign.Contains(keyword)) ||
                    (x.Address != null && x.Address.Contains(keyword)) ||
                    (x.FirstName != null && x.FirstName.Contains(keyword)) ||
                    (x.MiddleName != null && x.MiddleName.Contains(keyword)) ||
                    (x.LastName != null && x.LastName.Contains(keyword)) ||
                    (x.AddrBrgy != null && x.AddrBrgy.Contains(keyword)) ||
                    (x.AddrTown != null && x.AddrTown.Contains(keyword)) ||
                    (x.AddrProv != null && x.AddrProv.Contains(keyword)) ||
                    (x.StationBrgy != null && x.StationBrgy.Contains(keyword)) ||
                    (x.StationTown != null && x.StationTown.Contains(keyword)) ||
                    (x.StationProv != null && x.StationProv.Contains(keyword)) ||
                    (x.Status != null && x.Status.Contains(keyword)) ||
                    (x.Class != null && x.Class.Contains(keyword)) ||
                    (x.CallsignLetter != null && x.CallsignLetter.Contains(keyword)) ||
                    (x.AmateurClub != null && x.AmateurClub.Contains(keyword)) ||
                    (x.RoutingRefNo != null && x.RoutingRefNo.Contains(keyword))
                )
                .ToListAsync();

            return Ok(records);
        }

        // POST: api/AccessAmateurFull
        [HttpPost]
        public async Task<ActionResult<AmateurFullEntity>> Create([FromBody] AmateurFullEntity model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.accessAmateurFull.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = model.ID }, model);
        }

        // PUT: api/AccessAmateurFull/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AmateurFullEntity model)
        {
            if (id != model.ID)
                return BadRequest("ID mismatch.");

            var existing = await _context.accessAmateurFull.FindAsync(id);

            if (existing == null)
                return NotFound();

            _context.Entry(existing).CurrentValues.SetValues(model);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/AccessAmateurFull/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var record = await _context.accessAmateurFull.FindAsync(id);

            if (record == null)
                return NotFound();

            _context.accessAmateurFull.Remove(record);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}