using LicensingAPI.Entities;
using LicensingAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LicensingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessWDNController : ControllerBase
    {
        private readonly LicensingDbContext _context;

        public AccessWDNController(LicensingDbContext context)
        {
            _context = context;
        }

        // GET: api/AccessWDN
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccessWDN>>> GetAll()
        {
            var records = await _context.accessWDN
                .AsNoTracking()
                .ToListAsync();

            return Ok(records);
        }

        // GET: api/AccessWDN/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccessWDN>> GetById(int id)
        {
            var record = await _context.accessWDN
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ID == id);

            if (record == null)
                return NotFound();

            return Ok(record);
        }

        // GET: api/AccessWDN/search?keyword=test
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<AccessWDN>>> Search([FromQuery] string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return BadRequest("Keyword is required.");

            keyword = keyword.Trim();

            var records = await _context.accessWDN
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
                    (x.Contact != null && x.Contact.Contains(keyword))
                )
                .ToListAsync();

            return Ok(records);
        }

        // POST: api/AccessWDN
        [HttpPost]
        public async Task<ActionResult<AccessWDN>> Create([FromBody] AccessWDN model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.accessWDN.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = model.ID }, model);
        }

        // PUT: api/AccessWDN/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AccessWDN model)
        {
            if (id != model.ID)
                return BadRequest("ID mismatch.");

            var existing = await _context.accessWDN.FindAsync(id);

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

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/AccessWDN/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var record = await _context.accessWDN.FindAsync(id);

            if (record == null)
                return NotFound();

            _context.accessWDN.Remove(record);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}