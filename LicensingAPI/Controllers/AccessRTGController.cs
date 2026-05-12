using LicensingAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RTGEntity = LicensingAPI.Entities.AccessRTG;

namespace LicensingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessRTGController : ControllerBase
    {
        private readonly LicensingDbContext _context;

        public AccessRTGController(LicensingDbContext context)
        {
            _context = context;
        }

        // GET: api/AccessRTG
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RTGEntity>>> GetAll()
        {
            var records = await _context.accessRTG
                .AsNoTracking()
                .OrderByDescending(x => x.ID)
                .ToListAsync();

            return Ok(records);
        }

        // GET: api/AccessRTG/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<RTGEntity>> GetById(int id)
        {
            var record = await _context.accessRTG
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ID == id);

            if (record == null)
                return NotFound(new { message = $"RTG record with ID {id} was not found." });

            return Ok(record);
        }

        // GET: api/AccessRTG/search?keyword=test
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<RTGEntity>>> Search([FromQuery] string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return BadRequest(new { message = "Keyword is required." });

            keyword = keyword.Trim();
            var pattern = $"%{keyword}%";

            var records = await _context.accessRTG
                .AsNoTracking()
                .Where(x =>
                    EF.Functions.Like(x.Licensee ?? "", pattern) ||
                    EF.Functions.Like(x.Address ?? "", pattern) ||
                    EF.Functions.Like(x.Province ?? "", pattern) ||
                    EF.Functions.Like(x.LicenseNo ?? "", pattern) ||
                    EF.Functions.Like(x.Citizenship ?? "", pattern) ||
                    EF.Functions.Like(x.Sex ?? "", pattern) ||
                    EF.Functions.Like(x.RecommendingApproval ?? "", pattern) ||
                    EF.Functions.Like(x.RegionalDirector ?? "", pattern) ||
                    EF.Functions.Like(x.Position ?? "", pattern) ||
                    EF.Functions.Like(x.TypeClass ?? "", pattern) ||
                    EF.Functions.Like(x.PlaceOfExam ?? "", pattern) ||
                    EF.Functions.Like(x.Rating ?? "", pattern) ||
                    EF.Functions.Like(x.Remarks ?? "", pattern) ||
                    EF.Functions.Like(x.Encoder ?? "", pattern) ||
                    EF.Functions.Like(x.Note ?? "", pattern) ||
                    EF.Functions.Like(x.Userlog ?? "", pattern) ||
                    EF.Functions.Like(x.LastUpdateUser ?? "", pattern) ||
                    EF.Functions.Like(x.AdminCase ?? "", pattern) ||
                    EF.Functions.Like(x.AdminCaseRemark ?? "", pattern) ||
                    EF.Functions.Like(x.DateInspected ?? "", pattern) ||
                    EF.Functions.Like(x.InspectionMO ?? "", pattern) ||
                    EF.Functions.Like(x.RoutingRefNo ?? "", pattern)
                )
                .OrderByDescending(x => x.ID)
                .ToListAsync();

            return Ok(records);
        }

        // POST: api/AccessRTG
        [HttpPost]
        public async Task<ActionResult<RTGEntity>> Create([FromBody] RTGEntity model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.accessRTG.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = model.ID }, model);
        }

        // PUT: api/AccessRTG/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] RTGEntity model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != model.ID)
                return BadRequest(new { message = "ID mismatch." });

            var existing = await _context.accessRTG
                .FirstOrDefaultAsync(x => x.ID == id);

            if (existing == null)
                return NotFound(new { message = $"RTG record with ID {id} was not found." });

            var existingRowVer = existing.RowVer;

            _context.Entry(existing).CurrentValues.SetValues(model);

            existing.RowVer = existingRowVer;
            _context.Entry(existing).Property(x => x.RowVer).IsModified = false;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/AccessRTG/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var record = await _context.accessRTG
                .FirstOrDefaultAsync(x => x.ID == id);

            if (record == null)
                return NotFound(new { message = $"RTG record with ID {id} was not found." });

            _context.accessRTG.Remove(record);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}