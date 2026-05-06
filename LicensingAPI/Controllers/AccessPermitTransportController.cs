using LicensingAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PermitTransportEntity = LicensingAPI.Entities.AccessPermitTransport;

namespace LicensingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessPermitTransportController : ControllerBase
    {
        private readonly LicensingDbContext _context;

        public AccessPermitTransportController(LicensingDbContext context)
        {
            _context = context;
        }

        // GET: api/AccessPermitTransport
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PermitTransportEntity>>> GetAll()
        {
            var records = await _context.accessPermitTransport
                .AsNoTracking()
                .ToListAsync();

            return Ok(records);
        }

        // GET: api/AccessPermitTransport/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PermitTransportEntity>> GetById(int id)
        {
            var record = await _context.accessPermitTransport
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ID == id);

            if (record == null)
                return NotFound();

            return Ok(record);
        }

        // GET: api/AccessPermitTransport/search?keyword=test
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<PermitTransportEntity>>> Search([FromQuery] string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return BadRequest("Keyword is required.");

            keyword = keyword.Trim();

            var records = await _context.accessPermitTransport
                .AsNoTracking()
                .Where(x =>
                    (x.ReferenceNo != null && x.ReferenceNo.Contains(keyword)) ||
                    (x.Applicant != null && x.Applicant.Contains(keyword)) ||
                    (x.Address != null && x.Address.Contains(keyword)) ||
                    (x.TelNo != null && x.TelNo.Contains(keyword)) ||
                    (x.NameAuthorizedRep != null && x.NameAuthorizedRep.Contains(keyword)) ||
                    (x.PlaceOfOrigin != null && x.PlaceOfOrigin.Contains(keyword)) ||
                    (x.Destination != null && x.Destination.Contains(keyword)) ||
                    (x.Purpose != null && x.Purpose.Contains(keyword)) ||
                    (x.Model != null && x.Model.Contains(keyword)) ||
                    (x.SerialNumbers != null && x.SerialNumbers.Contains(keyword)) ||
                    (x.Model1 != null && x.Model1.Contains(keyword)) ||
                    (x.SerialNumbers1 != null && x.SerialNumbers1.Contains(keyword)) ||
                    (x.ApplicantName != null && x.ApplicantName.Contains(keyword)) ||
                    (x.PermitNo != null && x.PermitNo.Contains(keyword)) ||
                    (x.ApprovingOfficer != null && x.ApprovingOfficer.Contains(keyword))
                )
                .ToListAsync();

            return Ok(records);
        }

        // POST: api/AccessPermitTransport
        [HttpPost]
        public async Task<ActionResult<PermitTransportEntity>> Create([FromBody] PermitTransportEntity model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.accessPermitTransport.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = model.ID }, model);
        }

        // PUT: api/AccessPermitTransport/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PermitTransportEntity model)
        {
            if (id != model.ID)
                return BadRequest("ID mismatch.");

            var existing = await _context.accessPermitTransport.FindAsync(id);

            if (existing == null)
                return NotFound();

            existing.ReferenceNo = model.ReferenceNo;
            existing.Applicant = model.Applicant;
            existing.Address = model.Address;
            existing.DateProcessed = model.DateProcessed;
            existing.TelNo = model.TelNo;
            existing.NameAuthorizedRep = model.NameAuthorizedRep;
            existing.DateTransport = model.DateTransport;
            existing.PlaceOfOrigin = model.PlaceOfOrigin;
            existing.Destination = model.Destination;
            existing.Purpose = model.Purpose;
            existing.IsCopyPermitToPossess = model.IsCopyPermitToPossess;
            existing.IsCopyRLS = model.IsCopyRLS;
            existing.IsCopyDealersPermit = model.IsCopyDealersPermit;
            existing.OtherAttachment = model.OtherAttachment;
            existing.Model = model.Model;
            existing.SerialNumbers = model.SerialNumbers;
            existing.Model1 = model.Model1;
            existing.SerialNumbers1 = model.SerialNumbers1;
            existing.OfficialReceipt = model.OfficialReceipt;
            existing.Amount = model.Amount;
            existing.Date = model.Date;
            existing.Encoded = model.Encoded;
            existing.ApplicantName = model.ApplicantName;
            existing.PermitNo = model.PermitNo;
            existing.DateIssued = model.DateIssued;
            existing.ApprovingOfficer = model.ApprovingOfficer;
            existing.Position = model.Position;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/AccessPermitTransport/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var record = await _context.accessPermitTransport.FindAsync(id);

            if (record == null)
                return NotFound();

            _context.accessPermitTransport.Remove(record);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}