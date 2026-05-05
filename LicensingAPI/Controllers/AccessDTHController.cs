using LicensingAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DTHEntity = LicensingAPI.Entities.AccessDTH;

namespace LicensingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessDTHController : ControllerBase
    {
        private readonly LicensingDbContext _context;

        public AccessDTHController(LicensingDbContext context)
        {
            _context = context;
        }

        // GET: api/AccessDTH
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTHEntity>>> GetAll()
        {
            var records = await _context.accessDTH
                .AsNoTracking()
                .ToListAsync();

            return Ok(records);
        }

        // GET: api/AccessDTH/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DTHEntity>> GetById(int id)
        {
            var record = await _context.accessDTH
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ID == id);

            if (record == null)
                return NotFound();

            return Ok(record);
        }

        // GET: api/AccessDTH/search?keyword=test
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<DTHEntity>>> Search([FromQuery] string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return BadRequest("Keyword is required.");

            keyword = keyword.Trim();

            var records = await _context.accessDTH
                .AsNoTracking()
                .Where(x =>
                    (x.NameOfCompany != null && x.NameOfCompany.Contains(keyword)) ||
                    (x.PermitNo != null && x.PermitNo.Contains(keyword)) ||
                    (x.PermitPre != null && x.PermitPre.Contains(keyword)) ||
                    (x.PermitYear != null && x.PermitYear.Contains(keyword)) ||
                    (x.LicenseStatus != null && x.LicenseStatus.Contains(keyword)) ||
                    (x.Address != null && x.Address.Contains(keyword)) ||
                    (x.OrNo != null && x.OrNo.Contains(keyword)) ||
                    (x.TypeOfService != null && x.TypeOfService.Contains(keyword)) ||
                    (x.Ece != null && x.Ece.Contains(keyword)) ||
                    (x.Contact != null && x.Contact.Contains(keyword)) ||
                    (x.RoutingRefNo != null && x.RoutingRefNo.Contains(keyword))
                )
                .ToListAsync();

            return Ok(records);
        }

        // POST: api/AccessDTH
        [HttpPost]
        public async Task<ActionResult<DTHEntity>> Create([FromBody] DTHEntity model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.accessDTH.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = model.ID }, model);
        }

        // PUT: api/AccessDTH/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DTHEntity model)
        {
            if (id != model.ID)
                return BadRequest("ID mismatch.");

            var existing = await _context.accessDTH.FindAsync(id);

            if (existing == null)
                return NotFound();

            existing.Issued = model.Issued;
            existing.PermitPre = model.PermitPre;
            existing.PermitNo = model.PermitNo;
            existing.PermitYear = model.PermitYear;
            existing.LicenseStatus = model.LicenseStatus;
            existing.NameOfCompany = model.NameOfCompany;
            existing.Address = model.Address;
            existing.Validity = model.Validity;
            existing.Ece = model.Ece;
            existing.OrNo = model.OrNo;
            existing.Date = model.Date;
            existing.Amount = model.Amount;
            existing.ScanLicense = model.ScanLicense;
            existing.TypeOfService = model.TypeOfService;
            existing.IssuanceAddress = model.IssuanceAddress;
            existing.EngrAssigned = model.EngrAssigned;
            existing.EngrLicense = model.EngrLicense;
            existing.EngrLicenseValidity = model.EngrLicenseValidity;
            existing.NameOfTechnician = model.NameOfTechnician;
            existing.Remarks = model.Remarks;
            existing.ValidFrom = model.ValidFrom;
            existing.OldPermitNo = model.OldPermitNo;
            existing.Contact = model.Contact;
            existing.Encoded = model.Encoded;
            existing.AccountableForm = model.AccountableForm;
            existing.DateInspected = model.DateInspected;
            existing.InspectionMO = model.InspectionMO;
            existing.AdminCase = model.AdminCase;
            existing.AdminCaseRemark = model.AdminCaseRemark;
            existing.IsOpen = model.IsOpen;
            existing.IsPrinted = model.IsPrinted;
            existing.RoutingRefNo = model.RoutingRefNo;
            existing.OrNo2 = model.OrNo2;
            existing.Amount2 = model.Amount2;
            existing.Date2 = model.Date2;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/AccessDTH/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var record = await _context.accessDTH.FindAsync(id);

            if (record == null)
                return NotFound();

            _context.accessDTH.Remove(record);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}