#nullable disable
using LicensingAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Licensing.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicensingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechSOADetailsController : ControllerBase
    {
        private readonly LicensingDbContext _context;

        public TechSOADetailsController(LicensingDbContext context)
        {
            _context = context;
        }

        // GET: api/TechSOADetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TechSOADetails>>> GetAllSOADetails()
        {
            var list = await _context.tblSOADetails
                .AsNoTracking()
                .ToListAsync();

            return Ok(list);
        }

        // GET: api/TechSOADetails/BySOA/5
        // NOTE: "id" here is the HEADER ID (dbo.accessSOA.ID)
        // Your details table still uses SOAID as FK column name, so we filter by SOAID == headerId.
        [HttpGet("BySOA/{id:int}")]
        public async Task<IActionResult> GetSOADetailLists(int id)
        {
            // ✅ load header from dbo.accessSOA
            var header = await _context.accessSOA
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ID == id);

            // ✅ load details from dbo.tblSOADetails
            var details = await _context.tblSOADetails
                .AsNoTracking()
                .Where(d => d.SOAID == id)   // FK column name in details table is SOAID (keep this)
                .Select(d => new
                {
                    d.ID,
                    HeaderID = d.SOAID,      // expose it as HeaderID so you stop thinking SOAID
                    d.FeeType,
                    d.Category,
                    d.FeeName,
                    d.FilingFee,
                    d.PurchaseFee,
                    d.PossessFee,
                    d.ConstructionPermitFee,
                    d.ModificationFee,
                    d.LicenseFee,
                    d.InspectionFee,
                    d.DocStampTax,
                    d.TransportFee,
                    d.SellTransferFee,
                    d.DemoPropagateFee,
                    d.Mode,
                    d.SUF,
                    d.SurChargeSUF,
                    d.SurChargeRSL,
                    d.StorageFee,
                    d.AccessByID,
                    d.ModifiedByID
                })
                .ToListAsync();

            return Ok(new
            {
                Header = header,     // returns TechSOA from accessSOA
                Details = details    // returns list from tblSOADetails
            });
        }

        // GET: api/TechSOADetails/BySOADetails/5
        [HttpGet("BySOADetails/{id:int}")]
        public async Task<IActionResult> GetSOADetails(int id)
        {
            var detail = await _context.tblSOADetails
                .AsNoTracking()
                .FirstOrDefaultAsync(d => d.ID == id);

            if (detail == null) return Ok(new List<TechSOADetails>());

            // get header using FK (SOAID)
            var header = await _context.accessSOA
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ID == detail.SOAID);

            // return combined
            return Ok(new
            {
                Header = header,
                Detail = new
                {
                    detail.ID,
                    HeaderID = detail.SOAID,
                    detail.FeeType,
                    detail.Category,
                    detail.FeeName,
                    detail.FilingFee,
                    detail.PurchaseFee,
                    detail.PossessFee,
                    detail.ConstructionPermitFee,
                    detail.ModificationFee,
                    detail.LicenseFee,
                    detail.InspectionFee,
                    detail.DocStampTax,
                    detail.TransportFee,
                    detail.SellTransferFee,
                    detail.DemoPropagateFee,
                    detail.Mode,
                    detail.SUF,
                    detail.SurChargeSUF,
                    detail.SurChargeRSL,
                    detail.StorageFee,
                    detail.AccessByID,
                    detail.ModifiedByID
                }
            });
        }

        // PUT: api/TechSOADetails/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAcctDefaultTax(int id, [FromBody] TechSOADetails soad)
        {
            if (soad == null) return BadRequest("Body is required.");
            if (id != soad.ID) return BadRequest("ID mismatch.");

            // ✅ CRITICAL: Prevent EF from trying to update the old nav (if your model still has it)
            soad.StatementOfAccount = null;

            _context.Entry(soad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TechSOADetailsExists(id)) return NotFound();
                throw;
            }

            var rec = await _context.tblSOADetails.AsNoTracking().FirstOrDefaultAsync(x => x.ID == id);
            return Ok(rec);
        }

        // DELETE: api/TechSOADetails/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTechSOADetails(int id)
        {
            var soad = await _context.tblSOADetails.FindAsync(id);
            if (soad == null) return NotFound();

            // ✅ Prevent EF from touching old nav
            soad.StatementOfAccount = null;

            _context.tblSOADetails.Remove(soad);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool TechSOADetailsExists(int id)
        {
            return _context.tblSOADetails.Any(e => e.ID == id);
        }
    }
}
