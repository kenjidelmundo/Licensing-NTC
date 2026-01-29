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
        [HttpGet("BySOA/{id}")]
        public async Task<ActionResult<IEnumerable<TechSOADetails>>> GetSOADetailLists(int id)
        {
            var soadList = await _context.tblSOADetails
                .AsNoTracking()
                .Include(t => t.StatementOfAccount)
                .Where(g => g.SOAID == id)
                .Select(g => new
                {
                    g.ID,
                    g.SOAID,
                    g.FeeType,
                    g.Category,
                    g.FeeName,
                    g.FilingFee,
                    g.PurchaseFee,
                    g.PossessFee,
                    g.ConstructionPermitFee,
                    g.ModificationFee,
                    g.LicenseFee,
                    g.InspectionFee,
                    g.DocStampTax,
                    g.TransportFee,
                    g.SellTransferFee,
                    g.DemoPropagateFee,
                    g.Mode,
                    g.SUF,
                    g.SurChargeSUF,
                    g.SurChargeRSL,
                    g.StorageFee,
                    g.AccessByID,
                    g.ModifiedByID,
                    StatementOfAccount = g.StatementOfAccount == null ? null : new
                    {
                        g.StatementOfAccount.SOAID,
                        g.StatementOfAccount.LicenseID,
                        g.StatementOfAccount.PreparedByID,
                        g.StatementOfAccount.ApprovedByID,
                        g.StatementOfAccount.PeriodCoveredFrom,
                        g.StatementOfAccount.PeriodCoveredTo,
                        g.StatementOfAccount.Particulars,
                        g.StatementOfAccount.ModifiedByID,
                        g.StatementOfAccount.DateIssued
                    },
                    techSOADetails = (object)null
                })
                .ToListAsync();

            if (soadList == null || soadList.Count == 0)
            {
                return Ok(new List<TechSOADetails>());
            }

            return Ok(soadList);
        }

        // GET: api/TechSOADetails/BySOADetails/5
        [HttpGet("BySOADetails/{id}")]
        public async Task<ActionResult<IEnumerable<TechSOADetails>>> GetSOADetails(int id)
        {
            var soad = await _context.tblSOADetails
                .AsNoTracking()
                .Where(g => g.ID == id)
                .Select(g => new
                {
                    g.ID,
                    g.SOAID,
                    g.FeeType,
                    g.Category,
                    g.FeeName,
                    g.FilingFee,
                    g.PurchaseFee,
                    g.PossessFee,
                    g.ConstructionPermitFee,
                    g.ModificationFee,
                    g.LicenseFee,
                    g.InspectionFee,
                    g.DocStampTax,
                    g.TransportFee,
                    g.SellTransferFee,
                    g.DemoPropagateFee,
                    g.Mode,
                    g.SUF,
                    g.SurChargeSUF,
                    g.SurChargeRSL,
                    g.StorageFee,
                    g.AccessByID,
                    g.ModifiedByID,
                    StatementOfAccount = g.StatementOfAccount == null ? null : new
                    {
                        g.StatementOfAccount.SOAID,
                        g.StatementOfAccount.LicenseID,
                        g.StatementOfAccount.PreparedByID,
                        g.StatementOfAccount.ApprovedByID,
                        g.StatementOfAccount.PeriodCoveredFrom,
                        g.StatementOfAccount.PeriodCoveredTo,
                        g.StatementOfAccount.Particulars,
                        g.StatementOfAccount.ModifiedByID,
                        g.StatementOfAccount.DateIssued
                    },
                    techSOADetails = (object)null
                })
                .ToListAsync();

            if (soad == null || soad.Count == 0)
            {
                return Ok(new List<TechSOADetails>());
            }

            return Ok(soad);
        }

        // PUT: api/TechSOADetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcctDefaultTax(int id, [FromBody] TechSOADetails soad)
        {
            if (soad == null) return BadRequest("Body is required.");

            if (id != soad.ID)
            {
                return BadRequest("ID mismatch.");
            }

            // IMPORTANT: prevent EF from updating SOA header via navigation if client sends it
            soad.StatementOfAccount = null;

            _context.Entry(soad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TechSOADetailsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            var rec = await _context.tblSOADetails.AsNoTracking().FirstOrDefaultAsync(x => x.ID == id);
            return Ok(rec);
        }

        // DELETE: api/TechSOADetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTechSOADetails(int id)
        {
            var soad = await _context.tblSOADetails.FindAsync(id);
            if (soad == null)
            {
                return NotFound();
            }

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
