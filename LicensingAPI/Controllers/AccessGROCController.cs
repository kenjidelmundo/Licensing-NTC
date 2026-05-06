using LicensingAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GROCEntity = LicensingAPI.Entities.AccessGROC;

namespace LicensingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessGROCController : ControllerBase
    {
        private readonly LicensingDbContext _context;

        public AccessGROCController(LicensingDbContext context)
        {
            _context = context;
        }

        // GET: api/AccessGROC
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GROCEntity>>> GetAll()
        {
            var records = await _context.accessGROC
                .AsNoTracking()
                .ToListAsync();

            return Ok(records);
        }

        // GET: api/AccessGROC/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GROCEntity>> GetById(int id)
        {
            var record = await _context.accessGROC
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ID == id);

            if (record == null)
                return NotFound();

            return Ok(record);
        }

        // GET: api/AccessGROC/search?keyword=test
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<GROCEntity>>> Search([FromQuery] string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return BadRequest("Keyword is required.");

            keyword = keyword.Trim();

            var records = await _context.accessGROC
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
                    (x.CertOfCompletionSerialGROC != null && x.CertOfCompletionSerialGROC.Contains(keyword))
                )
                .ToListAsync();

            return Ok(records);
        }

        // POST: api/AccessGROC
        [HttpPost]
        public async Task<ActionResult<GROCEntity>> Create([FromBody] GROCEntity model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.accessGROC.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = model.ID }, model);
        }

        // PUT: api/AccessGROC/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] GROCEntity model)
        {
            if (id != model.ID)
                return BadRequest("ID mismatch.");

            var existing = await _context.accessGROC.FindAsync(id);

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
            existing.AdminCaseRemark = model.AdminCaseRemark;
            existing.DateInspected = model.DateInspected;
            existing.InspectionMO = model.InspectionMO;
            existing.IsOpen = model.IsOpen;
            existing.IsPrinted = model.IsPrinted;
            existing.RoutingRefNo = model.RoutingRefNo;
            existing.CertOfCompletionSerialGROC = model.CertOfCompletionSerialGROC;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/AccessGROC/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var record = await _context.accessGROC.FindAsync(id);

            if (record == null)
                return NotFound();

            _context.accessGROC.Remove(record);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}