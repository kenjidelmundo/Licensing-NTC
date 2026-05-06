using LicensingAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PermitSellTransferEntity = LicensingAPI.Entities.AccessPermitSellTransfer;

namespace LicensingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessPermitSellTransferController : ControllerBase
    {
        private readonly LicensingDbContext _context;

        public AccessPermitSellTransferController(LicensingDbContext context)
        {
            _context = context;
        }

        // GET: api/AccessPermitSellTransfer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PermitSellTransferEntity>>> GetAll()
        {
            var records = await _context.accessPermitSellTransfer
                .AsNoTracking()
                .ToListAsync();

            return Ok(records);
        }

        // GET: api/AccessPermitSellTransfer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PermitSellTransferEntity>> GetById(int id)
        {
            var record = await _context.accessPermitSellTransfer
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ID == id);

            if (record == null)
                return NotFound();

            return Ok(record);
        }

        // GET: api/AccessPermitSellTransfer/search?keyword=test
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<PermitSellTransferEntity>>> Search([FromQuery] string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return BadRequest("Keyword is required.");

            keyword = keyword.Trim();

            var records = await _context.accessPermitSellTransfer
                .AsNoTracking()
                .Where(x =>
                    (x.PermitNo != null && x.PermitNo.Contains(keyword)) ||
                    (x.Applicant != null && x.Applicant.Contains(keyword)) ||
                    (x.Address != null && x.Address.Contains(keyword)) ||
                    (x.Model != null && x.Model.Contains(keyword)) ||
                    (x.SerialNumbers != null && x.SerialNumbers.Contains(keyword)) ||
                    (x.Buyer != null && x.Buyer.Contains(keyword)) ||
                    (x.BuyerAddress != null && x.BuyerAddress.Contains(keyword)) ||
                    (x.PPurchaseNo != null && x.PPurchaseNo.Contains(keyword)) ||
                    (x.IntendedUse != null && x.IntendedUse.Contains(keyword)) ||
                    (x.ApprovingOfficer != null && x.ApprovingOfficer.Contains(keyword))
                )
                .ToListAsync();

            return Ok(records);
        }

        // POST: api/AccessPermitSellTransfer
        [HttpPost]
        public async Task<ActionResult<PermitSellTransferEntity>> Create([FromBody] PermitSellTransferEntity model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.accessPermitSellTransfer.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = model.ID }, model);
        }

        // PUT: api/AccessPermitSellTransfer/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PermitSellTransferEntity model)
        {
            if (id != model.ID)
                return BadRequest("ID mismatch.");

            var existing = await _context.accessPermitSellTransfer.FindAsync(id);

            if (existing == null)
                return NotFound();

            existing.PermitNo = model.PermitNo;
            existing.Applicant = model.Applicant;
            existing.Address = model.Address;
            existing.DateProcessed = model.DateProcessed;
            existing.Model = model.Model;
            existing.NoOfUnits = model.NoOfUnits;
            existing.SerialNumbers = model.SerialNumbers;
            existing.OfficialReceipt = model.OfficialReceipt;
            existing.Amount = model.Amount;
            existing.Date = model.Date;
            existing.Encoded = model.Encoded;
            existing.Buyer = model.Buyer;
            existing.BuyerAddress = model.BuyerAddress;
            existing.PPurchaseNo = model.PPurchaseNo;
            existing.PPurchaseDateIssue = model.PPurchaseDateIssue;
            existing.IntendedUse = model.IntendedUse;
            existing.ApprovingOfficer = model.ApprovingOfficer;
            existing.Position = model.Position;
            existing.UnitCount = model.UnitCount;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/AccessPermitSellTransfer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var record = await _context.accessPermitSellTransfer.FindAsync(id);

            if (record == null)
                return NotFound();

            _context.accessPermitSellTransfer.Remove(record);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}