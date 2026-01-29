using LicensingAPI.Data;
using LicensingAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LicensingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SOADetailsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public SOADetailsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/SOADetails
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.SOA_Details.ToList());
        }

        // GET: api/SOADetails/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var detail = _context.SOA_Details.Find(id);
            if (detail == null) return NotFound();
            return Ok(detail);
        }

        // GET: api/SOADetails/by-soa/3
        [HttpGet("by-soa/{soaId}")]
        public IActionResult GetBySOA(int soaId)
        {
            var details = _context.SOA_Details
                .Where(d => d.SOAId == soaId)
                .ToList();

            return Ok(details);
        }

        // POST: api/SOADetails
        [HttpPost]
        public IActionResult Create(SOA_Details model)
        {
            // FK validation
            if (!_context.SOAs.Any(s => s.SOAId == model.SOAId))
                return BadRequest("Invalid SOAId");

            _context.SOA_Details.Add(model);
            _context.SaveChanges();

            return Ok(model);
        }

        // PUT: api/SOADetails/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, SOA_Details model)
        {
            var existing = _context.SOA_Details.Find(id);
            if (existing == null) return NotFound();

            // FK validation
            if (!_context.SOAs.Any(s => s.SOAId == model.SOAId))
                return BadRequest("Invalid SOAId");

            existing.SOAId = model.SOAId;
            existing.Description = model.Description;
            existing.Amount = model.Amount;

            _context.SaveChanges();
            return Ok(existing);
        }

        // DELETE: api/SOADetails/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _context.SOA_Details.Find(id);
            if (existing == null) return NotFound();

            _context.SOA_Details.Remove(existing);
            _context.SaveChanges();

            return Ok();
        }
    }
}
