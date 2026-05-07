using LicensingAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarineSLEntity = LicensingAPI.Entities.AccessMarineSL;

namespace LicensingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessMarineSLController : ControllerBase
    {
        private readonly LicensingDbContext _context;

        public AccessMarineSLController(LicensingDbContext context)
        {
            _context = context;
        }

        // GET: api/AccessMarineSL
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarineSLEntity>>> GetAll()
        {
            var records = await _context.accessMarineSL
                .AsNoTracking()
                .ToListAsync();

            return Ok(records);
        }

        // GET: api/AccessMarineSL/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MarineSLEntity>> GetById(int id)
        {
            var record = await _context.accessMarineSL
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ID == id);

            if (record == null)
                return NotFound();

            return Ok(record);
        }

        // GET: api/AccessMarineSL/search?keyword=test
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<MarineSLEntity>>> Search([FromQuery] string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return BadRequest("Keyword is required.");

            keyword = keyword.Trim();

            var records = await _context.accessMarineSL
                .AsNoTracking()
                .Where(x =>
                    (x.OldLicenseNo != null && x.OldLicenseNo.Contains(keyword)) ||
                    (x.NewLicenceNo != null && x.NewLicenceNo.Contains(keyword)) ||
                    (x.NameOfShip != null && x.NameOfShip.Contains(keyword)) ||
                    (x.CallSign != null && x.CallSign.Contains(keyword)) ||
                    (x.Owner != null && x.Owner.Contains(keyword)) ||
                    (x.MtxSerialNumber != null && x.MtxSerialNumber.Contains(keyword)) ||
                    (x.EtxSerialNumber != null && x.EtxSerialNumber.Contains(keyword)) ||
                    (x.SctxSerialNo != null && x.SctxSerialNo.Contains(keyword)) ||
                    (x.RadioOperator != null && x.RadioOperator.Contains(keyword)) ||
                    (x.OperatorLicense != null && x.OperatorLicense.Contains(keyword)) ||
                    (x.ControlNumber != null && x.ControlNumber.Contains(keyword)) ||
                    (x.MmsiNo != null && x.MmsiNo.Contains(keyword)) ||
                    (x.OldControlNumber != null && x.OldControlNumber.Contains(keyword)) ||
                    (x.PermitToPurchase != null && x.PermitToPurchase.Contains(keyword)) ||
                    (x.FormerName != null && x.FormerName.Contains(keyword))
                )
                .ToListAsync();

            return Ok(records);
        }

        // POST: api/AccessMarineSL
        [HttpPost]
        public async Task<ActionResult<MarineSLEntity>> Create([FromBody] MarineSLEntity model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.accessMarineSL.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = model.ID }, model);
        }

        // PUT: api/AccessMarineSL/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MarineSLEntity model)
        {
            if (id != model.ID)
                return BadRequest("ID mismatch.");

            var existing = await _context.accessMarineSL.FindAsync(id);

            if (existing == null)
                return NotFound();

            _context.Entry(existing).CurrentValues.SetValues(model);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/AccessMarineSL/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var record = await _context.accessMarineSL.FindAsync(id);

            if (record == null)
                return NotFound();

            _context.accessMarineSL.Remove(record);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}