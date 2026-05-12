using LicensingAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TVROEntity = LicensingAPI.Entities.AccessTVRO;

namespace LicensingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessTVROController : ControllerBase
    {
        private readonly LicensingDbContext _context;

        public AccessTVROController(LicensingDbContext context)
        {
            _context = context;
        }

        // GET: api/AccessTVRO
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TVROEntity>>> GetAll()
        {
            var records = await _context.accessTVRO
                .AsNoTracking()
                .OrderByDescending(x => x.ID)
                .ToListAsync();

            return Ok(records);
        }

        // GET: api/AccessTVRO/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<TVROEntity>> GetById(int id)
        {
            var record = await _context.accessTVRO
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ID == id);

            if (record == null)
                return NotFound(new { message = $"TVRO record with ID {id} was not found." });

            return Ok(record);
        }

        // GET: api/AccessTVRO/search?keyword=test
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<TVROEntity>>> Search([FromQuery] string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return BadRequest(new { message = "Keyword is required." });

            keyword = keyword.Trim();
            var pattern = $"%{keyword}%";

            var records = await _context.accessTVRO
                .AsNoTracking()
                .Where(x =>
                    EF.Functions.Like(x.BsdNo ?? "", pattern) ||
                    EF.Functions.Like(x.LicenseNo ?? "", pattern) ||
                    EF.Functions.Like(x.Licensee ?? "", pattern) ||
                    EF.Functions.Like(x.Location ?? "", pattern) ||
                    EF.Functions.Like(x.ModelLna ?? "", pattern) ||
                    EF.Functions.Like(x.ModelReceiver ?? "", pattern) ||
                    EF.Functions.Like(x.RangeLna ?? "", pattern) ||
                    EF.Functions.Like(x.RangeReceiver ?? "", pattern) ||
                    EF.Functions.Like(x.SerialLna ?? "", pattern) ||
                    EF.Functions.Like(x.SerialReceiver ?? "", pattern) ||
                    EF.Functions.Like(x.Satellite ?? "", pattern) ||
                    EF.Functions.Like(x.ReceiveFreq ?? "", pattern) ||
                    EF.Functions.Like(x.Remarks ?? "", pattern) ||
                    EF.Functions.Like(x.OtherEquipment ?? "", pattern) ||
                    EF.Functions.Like(x.TvroRegistration ?? "", pattern) ||
                    EF.Functions.Like(x.IssuedBy ?? "", pattern) ||
                    EF.Functions.Like(x.ControlNumber ?? "", pattern) ||
                    EF.Functions.Like(x.ProvisionalAuthority ?? "", pattern) ||
                    EF.Functions.Like(x.CertificateOfAuthority ?? "", pattern) ||
                    EF.Functions.Like(x.Ece ?? "", pattern) ||
                    EF.Functions.Like(x.EceLicenseNo ?? "", pattern) ||
                    EF.Functions.Like(x.Technician ?? "", pattern) ||
                    EF.Functions.Like(x.MtrcbPermitNo ?? "", pattern) ||
                    EF.Functions.Like(x.MayorsPermitNo ?? "", pattern) ||
                    EF.Functions.Like(x.Status ?? "", pattern) ||
                    EF.Functions.Like(x.ContactNumber ?? "", pattern) ||
                    EF.Functions.Like(x.RemarksForModification ?? "", pattern) ||
                    EF.Functions.Like(x.Encoder ?? "", pattern) ||
                    EF.Functions.Like(x.Modification ?? "", pattern) ||
                    EF.Functions.Like(x.ReceiverModel ?? "", pattern) ||
                    EF.Functions.Like(x.ReceiverSerial ?? "", pattern) ||
                    EF.Functions.Like(x.SatelliteOther ?? "", pattern) ||
                    EF.Functions.Like(x.ReceivedFreqOthers ?? "", pattern) ||
                    EF.Functions.Like(x.ReceiverSerial2 ?? "", pattern) ||
                    EF.Functions.Like(x.ReceivedFreqOthers2 ?? "", pattern) ||
                    EF.Functions.Like(x.ReceivedFreqOthers3 ?? "", pattern) ||
                    EF.Functions.Like(x.ReceiverSerial3 ?? "", pattern) ||
                    EF.Functions.Like(x.LnaSerial ?? "", pattern) ||
                    EF.Functions.Like(x.LnaSerial2 ?? "", pattern) ||
                    EF.Functions.Like(x.ReceiverModel2 ?? "", pattern) ||
                    EF.Functions.Like(x.LnaModel2 ?? "", pattern) ||
                    EF.Functions.Like(x.RoutingRefNo ?? "", pattern)
                )
                .OrderByDescending(x => x.ID)
                .ToListAsync();

            return Ok(records);
        }

        // POST: api/AccessTVRO
        [HttpPost]
        public async Task<ActionResult<TVROEntity>> Create([FromBody] TVROEntity model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // RowVer is controlled by SQL Server.
            model.RowVer = Array.Empty<byte>();

            _context.accessTVRO.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = model.ID }, model);
        }

        // PUT: api/AccessTVRO/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] TVROEntity model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != model.ID)
                return BadRequest(new { message = "ID mismatch." });

            var existing = await _context.accessTVRO
                .FirstOrDefaultAsync(x => x.ID == id);

            if (existing == null)
                return NotFound(new { message = $"TVRO record with ID {id} was not found." });

            var existingRowVer = existing.RowVer;

            _context.Entry(existing).CurrentValues.SetValues(model);

            // Prevent update of SQL Server timestamp/RowVer.
            existing.RowVer = existingRowVer;
            _context.Entry(existing).Property(x => x.RowVer).IsModified = false;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/AccessTVRO/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var record = await _context.accessTVRO
                .FirstOrDefaultAsync(x => x.ID == id);

            if (record == null)
                return NotFound(new { message = $"TVRO record with ID {id} was not found." });

            _context.accessTVRO.Remove(record);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}