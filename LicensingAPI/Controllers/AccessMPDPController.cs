using LicensingAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MPDPEntity = LicensingAPI.Entities.AccessMPDP;

namespace LicensingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessMPDPController : ControllerBase
    {
        private readonly LicensingDbContext _context;

        public AccessMPDPController(LicensingDbContext context)
        {
            _context = context;
        }

        // GET: api/AccessMPDP
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MPDPEntity>>> GetAll()
        {
            var records = await _context.accessMPDP
                .AsNoTracking()
                .ToListAsync();

            return Ok(records);
        }

        // GET: api/AccessMPDP/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MPDPEntity>> GetById(int id)
        {
            var record = await _context.accessMPDP
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ID == id);

            if (record == null)
                return NotFound();

            return Ok(record);
        }

        // GET: api/AccessMPDP/search?keyword=test
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<MPDPEntity>>> Search([FromQuery] string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return BadRequest("Keyword is required.");

            keyword = keyword.Trim();

            var records = await _context.accessMPDP
                .AsNoTracking()
                .Where(x =>
                    (x.PermitNo != null && x.PermitNo.Contains(keyword)) ||
                    (x.Applicant != null && x.Applicant.Contains(keyword)) ||
                    (x.Address != null && x.Address.Contains(keyword)) ||
                    (x.CityMunicipality != null && x.CityMunicipality.Contains(keyword)) ||
                    (x.Province != null && x.Province.Contains(keyword)) ||
                    (x.Telephone != null && x.Telephone.Contains(keyword)) ||
                    (x.SecDti != null && x.SecDti.Contains(keyword)) ||
                    (x.Contact != null && x.Contact.Contains(keyword)) ||
                    (x.Technician != null && x.Technician.Contains(keyword)) ||
                    (x.Region != null && x.Region.Contains(keyword)) ||
                    (x.Email != null && x.Email.Contains(keyword)) ||
                    (x.Ece != null && x.Ece.Contains(keyword)) ||
                    (x.DealerType != null && x.DealerType.Contains(keyword)) ||
                    (x.RoutingRefNo != null && x.RoutingRefNo.Contains(keyword))
                )
                .ToListAsync();

            return Ok(records);
        }

        // POST: api/AccessMPDP
        [HttpPost]
        public async Task<ActionResult<MPDPEntity>> Create([FromBody] MPDPEntity model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.accessMPDP.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = model.ID }, model);
        }

        // PUT: api/AccessMPDP/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MPDPEntity model)
        {
            if (id != model.ID)
                return BadRequest("ID mismatch.");

            var existing = await _context.accessMPDP.FindAsync(id);

            if (existing == null)
                return NotFound();

            existing.PermitNo = model.PermitNo;
            existing.Applicant = model.Applicant;
            existing.Address = model.Address;
            existing.CityMunicipality = model.CityMunicipality;
            existing.Province = model.Province;
            existing.Telephone = model.Telephone;
            existing.SecDti = model.SecDti;
            existing.Issued = model.Issued;
            existing.ValidityUntil = model.ValidityUntil;
            existing.OfficialReceipt = model.OfficialReceipt;
            existing.DatePaid = model.DatePaid;
            existing.Remark = model.Remark;
            existing.DateReceived = model.DateReceived;
            existing.Contact = model.Contact;
            existing.Technician = model.Technician;
            existing.Region = model.Region;
            existing.Encoded = model.Encoded;
            existing.IssuedAt = model.IssuedAt;
            existing.Cond = model.Cond;
            existing.Email = model.Email;
            existing.Dlr1st = model.Dlr1st;
            existing.Ece = model.Ece;
            existing.ApprovingOfficer = model.ApprovingOfficer;
            existing.Release = model.Release;
            existing.FaxNo = model.FaxNo;
            existing.Amount = model.Amount;
            existing.CompanyAvatarBillboardPicture = model.CompanyAvatarBillboardPicture;
            existing.Type = model.Type;
            existing.ScanLicense = model.ScanLicense;
            existing.Modification = model.Modification;
            existing.RemarksForModification = model.RemarksForModification;
            existing.DealerType = model.DealerType;
            existing.DateInspected = model.DateInspected;
            existing.InspectionMO = model.InspectionMO;
            existing.AdminCase = model.AdminCase;
            existing.AdminCaseRemark = model.AdminCaseRemark;
            existing.IsOpen = model.IsOpen;
            existing.IsPrinted = model.IsPrinted;
            existing.RoutingRefNo = model.RoutingRefNo;
            existing.OfficialReceipt2 = model.OfficialReceipt2;
            existing.DatePaid2 = model.DatePaid2;
            existing.Amount2 = model.Amount2;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/AccessMPDP/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var record = await _context.accessMPDP.FindAsync(id);

            if (record == null)
                return NotFound();

            _context.accessMPDP.Remove(record);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}