using LicensingAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PermitPossessEntity = LicensingAPI.Entities.AccessPermitPossess;

namespace LicensingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessPermitPossessController : ControllerBase
    {
        private readonly LicensingDbContext _context;

        public AccessPermitPossessController(LicensingDbContext context)
        {
            _context = context;
        }

        // GET: api/AccessPermitPossess
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PermitPossessEntity>>> GetAll()
        {
            var records = await _context.accessPermitPossess
                .AsNoTracking()
                .ToListAsync();

            return Ok(records);
        }

        // GET: api/AccessPermitPossess/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PermitPossessEntity>> GetById(int id)
        {
            var record = await _context.accessPermitPossess
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ID == id);

            if (record == null)
                return NotFound();

            return Ok(record);
        }

        // GET: api/AccessPermitPossess/search?keyword=test
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<PermitPossessEntity>>> Search([FromQuery] string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return BadRequest("Keyword is required.");

            keyword = keyword.Trim();

            var records = await _context.accessPermitPossess
                .AsNoTracking()
                .Where(x =>
                    (x.PermitNo != null && x.PermitNo.Contains(keyword)) ||
                    (x.Applicant != null && x.Applicant.Contains(keyword)) ||
                    (x.Address != null && x.Address.Contains(keyword)) ||
                    (x.MakeModelType1 != null && x.MakeModelType1.Contains(keyword)) ||
                    (x.MakeModelType2 != null && x.MakeModelType2.Contains(keyword)) ||
                    (x.MakeModelType3 != null && x.MakeModelType3.Contains(keyword)) ||
                    (x.MakeModelType4 != null && x.MakeModelType4.Contains(keyword)) ||
                    (x.MakeModelType5 != null && x.MakeModelType5.Contains(keyword)) ||
                    (x.MakeModelType6 != null && x.MakeModelType6.Contains(keyword)) ||
                    (x.MakeModelType7 != null && x.MakeModelType7.Contains(keyword)) ||
                    (x.MakeModelType8 != null && x.MakeModelType8.Contains(keyword)) ||
                    (x.MakeModelType9 != null && x.MakeModelType9.Contains(keyword)) ||
                    (x.MakeModelType10 != null && x.MakeModelType10.Contains(keyword)) ||
                    (x.Serial1 != null && x.Serial1.Contains(keyword)) ||
                    (x.Serial2 != null && x.Serial2.Contains(keyword)) ||
                    (x.Serial3 != null && x.Serial3.Contains(keyword)) ||
                    (x.Serial4 != null && x.Serial4.Contains(keyword)) ||
                    (x.Serial5 != null && x.Serial5.Contains(keyword)) ||
                    (x.Serial6 != null && x.Serial6.Contains(keyword)) ||
                    (x.Serial7 != null && x.Serial7.Contains(keyword)) ||
                    (x.Serial8 != null && x.Serial8.Contains(keyword)) ||
                    (x.Serial9 != null && x.Serial9.Contains(keyword)) ||
                    (x.Serial10 != null && x.Serial10.Contains(keyword)) ||
                    (x.FrequencyRange != null && x.FrequencyRange.Contains(keyword)) ||
                    (x.SourceOfEquipment != null && x.SourceOfEquipment.Contains(keyword)) ||
                    (x.PlaceOfStorage != null && x.PlaceOfStorage.Contains(keyword)) ||
                    (x.CityMunicipality != null && x.CityMunicipality.Contains(keyword)) ||
                    (x.Province != null && x.Province.Contains(keyword)) ||
                    (x.CallSign != null && x.CallSign.Contains(keyword))
                )
                .ToListAsync();

            return Ok(records);
        }

        // POST: api/AccessPermitPossess
        [HttpPost]
        public async Task<ActionResult<PermitPossessEntity>> Create([FromBody] PermitPossessEntity model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.accessPermitPossess.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = model.ID }, model);
        }

        // PUT: api/AccessPermitPossess/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PermitPossessEntity model)
        {
            if (id != model.ID)
                return BadRequest("ID mismatch.");

            var existing = await _context.accessPermitPossess.FindAsync(id);

            if (existing == null)
                return NotFound();

            _context.Entry(existing).CurrentValues.SetValues(model);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/AccessPermitPossess/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var record = await _context.accessPermitPossess.FindAsync(id);

            if (record == null)
                return NotFound();

            _context.accessPermitPossess.Remove(record);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}