using LicensingAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SROPEntity = LicensingAPI.Entities.AccessSROP;

namespace LicensingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessSROPController : ControllerBase
    {
        private readonly LicensingDbContext _context;

        public AccessSROPController(LicensingDbContext context)
        {
            _context = context;
        }

        // GET: api/AccessSROP
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SROPEntity>>> GetAll()
        {
            var records = await _context.accessSROP
                .AsNoTracking()
                .ToListAsync();

            return Ok(records);
        }

        // GET: api/AccessSROP/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SROPEntity>> GetById(int id)
        {
            var record = await _context.accessSROP
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ID == id);

            if (record == null)
                return NotFound();

            return Ok(record);
        }

        // GET: api/AccessSROP/search?keyword=test
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<SROPEntity>>> Search([FromQuery] string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return BadRequest("Keyword is required.");

            keyword = keyword.Trim();

            var records = await _context.accessSROP
                .AsNoTracking()
                .Where(x =>
                    (x.Licensee != null && x.Licensee.Contains(keyword)) ||
                    (x.Address != null && x.Address.Contains(keyword)) ||
                    (x.Province != null && x.Province.Contains(keyword)) ||
                    (x.LicenseNo != null && x.LicenseNo.Contains(keyword)) ||
                    (x.Citizenship != null && x.Citizenship.Contains(keyword)) ||
                    (x.TypeClass != null && x.TypeClass.Contains(keyword)) ||
                    (x.PlaceOfExam != null && x.PlaceOfExam.Contains(keyword)) ||
                    (x.Rating != null && x.Rating.Contains(keyword)) ||
                    (x.Remarks != null && x.Remarks.Contains(keyword)) ||
                    (x.RoutingRefNo != null && x.RoutingRefNo.Contains(keyword)) ||
                    (x.CertOfCompletionSerialSROP != null && x.CertOfCompletionSerialSROP.Contains(keyword))
                )
                .ToListAsync();

            return Ok(records);
        }

        // POST: api/AccessSROP
        [HttpPost]
        public async Task<ActionResult<SROPEntity>> Create([FromBody] SROPEntity model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.accessSROP.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = model.ID }, model);
        }

        // PUT: api/AccessSROP/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SROPEntity model)
        {
            if (id != model.ID)
                return BadRequest("ID mismatch.");

            var existing = await _context.accessSROP.FindAsync(id);

            if (existing == null)
                return NotFound();

            existing.Licensee = model.Licensee;
            existing.Address = model.Address;
            existing.Province = model.Province;
            existing.LicenseNo = model.LicenseNo;
            existing.Birthday = model.Birthday;
            existing.Citizenship = model.Citizenship;
            existing.Sex = model.Sex;
            existing.Height = model.Height;
            existing.Weight = model.Weight;
            existing.OfficialReceipt = model.OfficialReceipt;
            existing.DatePaid = model.DatePaid;
            existing.Amount = model.Amount;
            existing.DateIssued = model.DateIssued;
            existing.ExpiryDate = model.ExpiryDate;
            existing.RecommendingApproval = model.RecommendingApproval;
            existing.RegionalDirector = model.RegionalDirector;
            existing.Position = model.Position;
            existing.TypeClass = model.TypeClass;
            existing.DateTaken = model.DateTaken;
            existing.PlaceOfExam = model.PlaceOfExam;
            existing.Rating = model.Rating;
            existing.Remarks = model.Remarks;
            existing.Encoder = model.Encoder;
            existing.Note = model.Note;
            existing.Userlog = model.Userlog;
            existing.InsertDate = model.InsertDate;
            existing.LastUpdateUser = model.LastUpdateUser;
            existing.LastUpdateDate = model.LastUpdateDate;
            existing.AccountableFormNumber = model.AccountableFormNumber;
            existing.OfficialReceipt2 = model.OfficialReceipt2;
            existing.DatePaid2 = model.DatePaid2;
            existing.Amount2 = model.Amount2;
            existing.Series = model.Series;
            existing.IsOpen = model.IsOpen;
            existing.IsPrinted = model.IsPrinted;
            existing.RoutingRefNo = model.RoutingRefNo;
            existing.CertOfCompletionSerialSROP = model.CertOfCompletionSerialSROP;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/AccessSROP/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var record = await _context.accessSROP.FindAsync(id);

            if (record == null)
                return NotFound();

            _context.accessSROP.Remove(record);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}