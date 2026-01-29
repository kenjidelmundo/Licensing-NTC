#nullable disable
using LicensingAPI.Data;
using Licensing.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LicensingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechSOAController : ControllerBase
    {
        private readonly LicensingDbContext _context;

        public TechSOAController(LicensingDbContext context)
        {
            _context = context;
        }

        // GET: api/TechSOA
        [HttpGet]
        public async Task<IActionResult> GetAllSOA(
            int pageNumber = 1,
            int pageSize = 10,
            string sortColumn = "DateIssued",
            string sortDirection = "desc",
            string searchKeyword = "",
            int pmonth = 0,
            int pyear = 0,
            long? draw = null
        )
        {
            if (pageNumber <= 0) pageNumber = 1;

            // allow -1 for "all"; otherwise force sane default
            if (pageSize == 0) pageSize = 10;
            if (pageSize < -1) pageSize = 10;

            var baseQuery = _context.tblStatementOfAccount.AsNoTracking().AsQueryable();

            var totalRecords = await baseQuery.CountAsync();

            if (pyear != 0)
                baseQuery = baseQuery.Where(x => x.DateIssued.HasValue && x.DateIssued.Value.Year == pyear);

            if (pmonth != 0 && pmonth != 13)
                baseQuery = baseQuery.Where(x => x.DateIssued.HasValue && x.DateIssued.Value.Month == pmonth);
            else if (pmonth == 0)
            {
                int currentMonth = DateTime.Now.Month;
                baseQuery = baseQuery.Where(x => x.DateIssued.HasValue && x.DateIssued.Value.Month == currentMonth);
            }

            if (!string.IsNullOrWhiteSpace(searchKeyword))
                baseQuery = baseQuery.Where(x => x.Particulars != null && x.Particulars.Contains(searchKeyword));

            var filteredRecords = await baseQuery.CountAsync();

            bool asc = (sortDirection ?? "").ToLower() == "asc";

            baseQuery = (sortColumn ?? "").ToLower() switch
            {
                "soaid" => asc ? baseQuery.OrderBy(x => x.SOAID) : baseQuery.OrderByDescending(x => x.SOAID),
                "licenseid" => asc ? baseQuery.OrderBy(x => x.LicenseID) : baseQuery.OrderByDescending(x => x.LicenseID),
                "particulars" => asc ? baseQuery.OrderBy(x => x.Particulars) : baseQuery.OrderByDescending(x => x.Particulars),
                "dateissued" => asc ? baseQuery.OrderBy(x => x.DateIssued) : baseQuery.OrderByDescending(x => x.DateIssued),
                "periodcoveredfrom" => asc ? baseQuery.OrderBy(x => x.PeriodCoveredFrom) : baseQuery.OrderByDescending(x => x.PeriodCoveredFrom),
                "periodcoveredto" => asc ? baseQuery.OrderBy(x => x.PeriodCoveredTo) : baseQuery.OrderByDescending(x => x.PeriodCoveredTo),
                _ => baseQuery.OrderByDescending(x => x.DateIssued)
            };

            if (pageSize != -1)
            {
                int skip = (pageNumber - 1) * pageSize;
                baseQuery = baseQuery.Skip(skip).Take(pageSize);
            }

            var data = await baseQuery.ToListAsync();

            return Ok(new
            {
                draw,
                data,
                recordsTotal = totalRecords,
                recordsFiltered = filteredRecords
            });
        }

        // GET: api/TechSOA/5
        [HttpGet("{id:int}", Name = "GetSOA")]
        public async Task<ActionResult<TechSOA>> GetSOA(int id)
        {
            var soa = await _context.tblStatementOfAccount
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.SOAID == id);

            if (soa == null) return NotFound($"SOAID {id} not found.");
            return Ok(soa);
        }

        // PUT: api/TechSOA/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutTechSOA(int id, [FromBody] TechSOA soa)
        {
            if (soa == null) return BadRequest("Body is required.");
            if (id != soa.SOAID) return BadRequest("ID mismatch.");

            // IMPORTANT: avoid EF trying to insert/update details from client payload
            soa.TechSOADetails = null;

            var exists = await _context.tblStatementOfAccount.AnyAsync(x => x.SOAID == id);
            if (!exists) return NotFound($"SOAID {id} not found.");

            _context.Entry(soa).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(soa);
        }

        // POST: api/TechSOA
        [HttpPost]
        public async Task<ActionResult<TechSOA>> PostSOA([FromBody] TechSOA soa)
        {
            if (soa == null) return BadRequest("Body is required.");

            // IMPORTANT: avoid EF trying to insert details from client payload
            soa.TechSOADetails = null;

            _context.tblStatementOfAccount.Add(soa);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetSOA", new { id = soa.SOAID }, soa);
        }

        // DELETE: api/TechSOA/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTechSOA(int id)
        {
            var soa = await _context.tblStatementOfAccount.FindAsync(id);
            if (soa == null) return NotFound($"SOAID {id} not found.");

            _context.tblStatementOfAccount.Remove(soa);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
