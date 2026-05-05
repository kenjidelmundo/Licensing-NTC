using LicensingAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MPSCEntity = LicensingAPI.Entities.AccessMPSC;

namespace LicensingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessMPSCController : ControllerBase
    {
        private readonly LicensingDbContext _context;

        public AccessMPSCController(LicensingDbContext context)
        {
            _context = context;
        }

        // GET: api/AccessMPSC
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MPSCEntity>>> GetAll()
        {
            var records = await _context.accessMPSC
                .AsNoTracking()
                .ToListAsync();

            return Ok(records);
        }

        // GET: api/AccessMPSC/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MPSCEntity>> GetById(int id)
        {
            var record = await _context.accessMPSC
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ID == id);

            if (record == null)
                return NotFound();

            return Ok(record);
        }

        // GET: api/AccessMPSC/search?keyword=test
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<MPSCEntity>>> Search([FromQuery] string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return BadRequest("Keyword is required.");

            keyword = keyword.Trim();

            var records = await _context.accessMPSC
                .AsNoTracking()
                .Where(x =>
                    (x.PermitNo != null && x.PermitNo.Contains(keyword)) ||
                    (x.Applicant != null && x.Applicant.Contains(keyword)) ||
                    (x.Telephone != null && x.Telephone.Contains(keyword)) ||
                    (x.SecDti != null && x.SecDti.Contains(keyword)) ||
                    (x.Address != null && x.Address.Contains(keyword)) ||
                    (x.Region != null && x.Region.Contains(keyword)) ||
                    (x.IssuedAt != null && x.IssuedAt.Contains(keyword)) ||
                    (x.Contact != null && x.Contact.Contains(keyword)) ||
                    (x.Email != null && x.Email.Contains(keyword)) ||
                    (x.Technician != null && x.Technician.Contains(keyword)) ||
                    (x.CityMunicipality != null && x.CityMunicipality.Contains(keyword)) ||
                    (x.Province != null && x.Province.Contains(keyword)) ||
                    (x.RoutingRefNo != null && x.RoutingRefNo.Contains(keyword))
                )
                .ToListAsync();

            return Ok(records);
        }

        // POST: api/AccessMPSC
        [HttpPost]
        public async Task<ActionResult<MPSCEntity>> Create([FromBody] MPSCEntity model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.accessMPSC.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = model.ID }, model);
        }

        // PUT: api/AccessMPSC/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MPSCEntity model)
        {
            if (id != model.ID)
                return BadRequest("ID mismatch.");

            var existing = await _context.accessMPSC.FindAsync(id);

            if (existing == null)
                return NotFound();

            existing.PermitNo = model.PermitNo;
            existing.Applicant = model.Applicant;
            existing.Telephone = model.Telephone;
            existing.SecDti = model.SecDti;
            existing.ValidityUntil = model.ValidityUntil;
            existing.OfficialReceipt = model.OfficialReceipt;
            existing.Amount = model.Amount;
            existing.Issued = model.Issued;
            existing.FaxNo = model.FaxNo;
            existing.Address = model.Address;
            existing.Field1 = model.Field1;
            existing.DatePaid = model.DatePaid;
            existing.ApprovingOfficer = model.ApprovingOfficer;
            existing.Remark = model.Remark;
            existing.Encoded = model.Encoded;
            existing.Region = model.Region;
            existing.IssuedAt = model.IssuedAt;
            existing.CompanyAvatarBillboardPicture = model.CompanyAvatarBillboardPicture;
            existing.DateReceived = model.DateReceived;
            existing.Contact = model.Contact;
            existing.Email = model.Email;
            existing.Technician = model.Technician;
            existing.Cond = model.Cond;
            existing.Release = model.Release;
            existing.CityMunicipality = model.CityMunicipality;
            existing.Province = model.Province;
            existing.Field27 = model.Field27;
            existing.ScanLicense = model.ScanLicense;
            existing.RemarksForModification = model.RemarksForModification;
            existing.Modification = model.Modification;
            existing.DateInspected = model.DateInspected;
            existing.InspectionMO = model.InspectionMO;
            existing.AdminCase = model.AdminCase;
            existing.AdminCaseRemark = model.AdminCaseRemark;
            existing.IsOpen = model.IsOpen;
            existing.IsPrinted = model.IsPrinted;
            existing.RoutingRefNo = model.RoutingRefNo;
            existing.OfficialReceipt2 = model.OfficialReceipt2;
            existing.Amount2 = model.Amount2;
            existing.DatePaid2 = model.DatePaid2;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/AccessMPSC/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var record = await _context.accessMPSC.FindAsync(id);

            if (record == null)
                return NotFound();

            _context.accessMPSC.Remove(record);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}