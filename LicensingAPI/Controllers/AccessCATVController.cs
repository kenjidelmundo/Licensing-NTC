using LicensingAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CATVEntity = LicensingAPI.Entities.AccessCATV;

namespace LicensingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessCATVController : ControllerBase
    {
        private readonly LicensingDbContext _context;

        public AccessCATVController(LicensingDbContext context)
        {
            _context = context;
        }

        // GET: api/AccessCATV
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CATVEntity>>> GetAll()
        {
            var records = await _context.accessCATV
                .AsNoTracking()
                .OrderByDescending(x => x.ID)
                .ToListAsync();

            return Ok(records);
        }

        // GET: api/AccessCATV/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CATVEntity>> GetById(int id)
        {
            var record = await _context.accessCATV
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ID == id);

            if (record == null)
                return NotFound(new { message = $"CATV record with ID {id} was not found." });

            return Ok(record);
        }

        // GET: api/AccessCATV/search?keyword=test
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<CATVEntity>>> Search([FromQuery] string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return BadRequest(new { message = "Keyword is required." });

            keyword = keyword.Trim();
            var pattern = $"%{keyword}%";

            var records = await _context.accessCATV
                .AsNoTracking()
                .Where(x =>
                    EF.Functions.Like(x.BmcCaseNo ?? "", pattern) ||
                    EF.Functions.Like(x.Period ?? "", pattern) ||
                    EF.Functions.Like(x.LicenseNo ?? "", pattern) ||
                    EF.Functions.Like(x.Licensee ?? "", pattern) ||
                    EF.Functions.Like(x.Location ?? "", pattern) ||
                    EF.Functions.Like(x.ServiceArea ?? "", pattern) ||
                    EF.Functions.Like(x.ModulatorModel ?? "", pattern) ||
                    EF.Functions.Like(x.ModulatorSerial ?? "", pattern) ||
                    EF.Functions.Like(x.CombinerModel ?? "", pattern) ||
                    EF.Functions.Like(x.CombinerSerial ?? "", pattern) ||
                    EF.Functions.Like(x.OtherEquipment ?? "", pattern) ||
                    EF.Functions.Like(x.ControlNumber ?? "", pattern) ||
                    EF.Functions.Like(x.CertificateOfAuthority ?? "", pattern) ||
                    EF.Functions.Like(x.MtrcbPermitNo ?? "", pattern) ||
                    EF.Functions.Like(x.MayorsPermitNo ?? "", pattern) ||
                    EF.Functions.Like(x.Status ?? "", pattern) ||
                    EF.Functions.Like(x.ContactNumber ?? "", pattern) ||
                    EF.Functions.Like(x.RemarksForModification ?? "", pattern) ||
                    EF.Functions.Like(x.Encoder ?? "", pattern) ||
                    EF.Functions.Like(x.Modification ?? "", pattern) ||
                    EF.Functions.Like(x.ReceiverModel ?? "", pattern) ||
                    EF.Functions.Like(x.ReceiverSerial ?? "", pattern) ||
                    EF.Functions.Like(x.RoutingRefNo ?? "", pattern)
                )
                .OrderByDescending(x => x.ID)
                .ToListAsync();

            return Ok(records);
        }

        // POST: api/AccessCATV
        [HttpPost]
        public async Task<ActionResult<CATVEntity>> Create([FromBody] CATVEntity model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // RowVer is controlled by SQL Server.
            model.RowVer = Array.Empty<byte>();

            _context.accessCATV.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = model.ID }, model);
        }

        // PUT: api/AccessCATV/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] CATVEntity model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != model.ID)
                return BadRequest(new { message = "ID mismatch." });

            var existing = await _context.accessCATV
                .FirstOrDefaultAsync(x => x.ID == id);

            if (existing == null)
                return NotFound(new { message = $"CATV record with ID {id} was not found." });

            var existingRowVer = existing.RowVer;

            _context.Entry(existing).CurrentValues.SetValues(model);

            // Prevent update of SQL timestamp/RowVer.
            existing.RowVer = existingRowVer;
            _context.Entry(existing).Property(x => x.RowVer).IsModified = false;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/AccessCATV/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var record = await _context.accessCATV
                .FirstOrDefaultAsync(x => x.ID == id);

            if (record == null)
                return NotFound(new { message = $"CATV record with ID {id} was not found." });

            _context.accessCATV.Remove(record);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}