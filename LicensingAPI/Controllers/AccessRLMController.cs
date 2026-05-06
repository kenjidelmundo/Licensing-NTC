using LicensingAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RLMEntity = LicensingAPI.Entities.AccessRLM;

namespace LicensingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessRLMController : ControllerBase
    {
        private readonly LicensingDbContext _context;

        public AccessRLMController(LicensingDbContext context)
        {
            _context = context;
        }

        // GET: api/AccessRLM
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RLMEntity>>> GetAll()
        {
            var records = await _context.accessRLM
                .AsNoTracking()
                .ToListAsync();

            return Ok(records);
        }

        // GET: api/AccessRLM/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RLMEntity>> GetById(int id)
        {
            var record = await _context.accessRLM
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ID == id);

            if (record == null)
                return NotFound();

            return Ok(record);
        }

        // GET: api/AccessRLM/search?keyword=test
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<RLMEntity>>> Search([FromQuery] string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return BadRequest("Keyword is required.");

            keyword = keyword.Trim();

            var records = await _context.accessRLM
                .AsNoTracking()
                .Where(x =>
                    (x.Name != null && x.Name.Contains(keyword)) ||
                    (x.LicenseNo != null && x.LicenseNo.Contains(keyword)) ||
                    (x.Series != null && x.Series.Contains(keyword)) ||
                    (x.Remark != null && x.Remark.Contains(keyword)) ||
                    (x.Address != null && x.Address.Contains(keyword)) ||
                    (x.Citizenship != null && x.Citizenship.Contains(keyword)) ||
                    (x.Company != null && x.Company.Contains(keyword)) ||
                    (x.PlaceOfSem != null && x.PlaceOfSem.Contains(keyword)) ||
                    (x.LastName != null && x.LastName.Contains(keyword)) ||
                    (x.FirstName != null && x.FirstName.Contains(keyword)) ||
                    (x.MiddleName != null && x.MiddleName.Contains(keyword)) ||
                    (x.RoutingRefNo != null && x.RoutingRefNo.Contains(keyword))
                )
                .ToListAsync();

            return Ok(records);
        }

        // POST: api/AccessRLM
        [HttpPost]
        public async Task<ActionResult<RLMEntity>> Create([FromBody] RLMEntity model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.accessRLM.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = model.ID }, model);
        }

        // PUT: api/AccessRLM/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RLMEntity model)
        {
            if (id != model.ID)
                return BadRequest("ID mismatch.");

            var existing = await _context.accessRLM.FindAsync(id);

            if (existing == null)
                return NotFound();

            existing.Name = model.Name;
            existing.LicenseNo = model.LicenseNo;
            existing.Series = model.Series;
            existing.Remark = model.Remark;
            existing.Issued = model.Issued;
            existing.ValidUntil = model.ValidUntil;
            existing.OperatorFee = model.OperatorFee;
            existing.Address = model.Address;
            existing.Birthdate = model.Birthdate;
            existing.Height = model.Height;
            existing.Weight = model.Weight;
            existing.Citizenship = model.Citizenship;
            existing.Sex = model.Sex;
            existing.Company = model.Company;
            existing.DateOfSem = model.DateOfSem;
            existing.PlaceOfSem = model.PlaceOfSem;
            existing.OfficialReceipt = model.OfficialReceipt;
            existing.Amount = model.Amount;
            existing.DatePaid = model.DatePaid;
            existing.ForTheCommission = model.ForTheCommission;
            existing.Position = model.Position;
            existing.Encoded = model.Encoded;
            existing.LastName = model.LastName;
            existing.FirstName = model.FirstName;
            existing.MiddleName = model.MiddleName;
            existing.OperatorFees = model.OperatorFees;
            existing.DocStamp = model.DocStamp;
            existing.ReleasedDate = model.ReleasedDate;
            existing.AccountableForm = model.AccountableForm;
            existing.OfficialReceipt2 = model.OfficialReceipt2;
            existing.Amount2 = model.Amount2;
            existing.DatePaid2 = model.DatePaid2;
            existing.OperatorFees2 = model.OperatorFees2;
            existing.Status = model.Status;
            existing.MobileNote = model.MobileNote;
            existing.IsOpen = model.IsOpen;
            existing.IsPrinted = model.IsPrinted;
            existing.RoutingRefNo = model.RoutingRefNo;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/AccessRLM/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var record = await _context.accessRLM.FindAsync(id);

            if (record == null)
                return NotFound();

            _context.accessRLM.Remove(record);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}