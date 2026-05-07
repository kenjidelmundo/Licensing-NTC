using LicensingAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PermitPurchaseEntity = LicensingAPI.Entities.AccessPermitPurchase;

namespace LicensingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessPermitPurchaseController : ControllerBase
    {
        private readonly LicensingDbContext _context;

        public AccessPermitPurchaseController(LicensingDbContext context)
        {
            _context = context;
        }

        // GET: api/AccessPermitPurchase
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PermitPurchaseEntity>>> GetAll()
        {
            var records = await _context.accessPermitPurchase
                .AsNoTracking()
                .ToListAsync();

            return Ok(records);
        }

        // GET: api/AccessPermitPurchase/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PermitPurchaseEntity>> GetById(int id)
        {
            var record = await _context.accessPermitPurchase
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ID == id);

            if (record == null)
                return NotFound();

            return Ok(record);
        }

        // GET: api/AccessPermitPurchase/search?keyword=test
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<PermitPurchaseEntity>>> Search([FromQuery] string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return BadRequest("Keyword is required.");

            keyword = keyword.Trim();

            var records = await _context.accessPermitPurchase
                .AsNoTracking()
                .Where(x =>
                    (x.PermitNo != null && x.PermitNo.Contains(keyword)) ||
                    (x.Applicant != null && x.Applicant.Contains(keyword)) ||
                    (x.Address != null && x.Address.Contains(keyword)) ||
                    (x.Model != null && x.Model.Contains(keyword)) ||
                    (x.NoOfUnits != null && x.NoOfUnits.Contains(keyword)) ||
                    (x.FrequencyRange != null && x.FrequencyRange.Contains(keyword)) ||
                    (x.RfPowerOutput != null && x.RfPowerOutput.Contains(keyword)) ||
                    (x.Encoded != null && x.Encoded.Contains(keyword)) ||
                    (x.ApprovingOfficer != null && x.ApprovingOfficer.Contains(keyword)) ||
                    (x.FrequencyAssignment != null && x.FrequencyAssignment.Contains(keyword)) ||
                    (x.ForNew != null && x.ForNew.Contains(keyword)) ||
                    (x.Additional != null && x.Additional.Contains(keyword)) ||
                    (x.Others != null && x.Others.Contains(keyword)) ||
                    (x.Position != null && x.Position.Contains(keyword)) ||
                    (x.NewRadio != null && x.NewRadio.Contains(keyword)) ||
                    (x.AdditionalRadio != null && x.AdditionalRadio.Contains(keyword))
                )
                .ToListAsync();

            return Ok(records);
        }

        // POST: api/AccessPermitPurchase
        [HttpPost]
        public async Task<ActionResult<PermitPurchaseEntity>> Create([FromBody] PermitPurchaseEntity model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.accessPermitPurchase.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = model.ID }, model);
        }

        // PUT: api/AccessPermitPurchase/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PermitPurchaseEntity model)
        {
            if (id != model.ID)
                return BadRequest("ID mismatch.");

            var existing = await _context.accessPermitPurchase.FindAsync(id);

            if (existing == null)
                return NotFound();

            existing.PermitNo = model.PermitNo;
            existing.Applicant = model.Applicant;
            existing.Address = model.Address;
            existing.DateProcessed = model.DateProcessed;
            existing.Model = model.Model;
            existing.NoOfUnits = model.NoOfUnits;
            existing.FrequencyRange = model.FrequencyRange;
            existing.RfPowerOutput = model.RfPowerOutput;
            existing.OfficialReceipt = model.OfficialReceipt;
            existing.Amount = model.Amount;
            existing.Date = model.Date;
            existing.Encoded = model.Encoded;
            existing.Released = model.Released;
            existing.ApprovingOfficer = model.ApprovingOfficer;
            existing.FrequencyAssignment = model.FrequencyAssignment;
            existing.ForNew = model.ForNew;
            existing.Additional = model.Additional;
            existing.Others = model.Others;
            existing.Validity = model.Validity;
            existing.Extension = model.Extension;
            existing.Position = model.Position;
            existing.NewRadio = model.NewRadio;
            existing.AdditionalRadio = model.AdditionalRadio;
            existing.UnitCount = model.UnitCount;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/AccessPermitPurchase/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var record = await _context.accessPermitPurchase.FindAsync(id);

            if (record == null)
                return NotFound();

            _context.accessPermitPurchase.Remove(record);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}