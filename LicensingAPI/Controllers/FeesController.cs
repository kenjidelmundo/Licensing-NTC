using LicensingAPI.Data;
using LicensingAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LicensingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeesController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public FeesController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Fees.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = _context.Fees.Find(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Post(Fees model)
        {
            if (!_context.TechServices.Any(t => t.TechServiceId == model.TechServiceId))
                return BadRequest("Invalid TechServiceId");

            _context.Fees.Add(model);
            _context.SaveChanges();
            return Ok(model);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Fees model)
        {
            var existing = _context.Fees.Find(id);
            if (existing == null) return NotFound();

            existing.FeeName = model.FeeName;
            existing.Amount = model.Amount;
            existing.TechServiceId = model.TechServiceId;

            _context.SaveChanges();
            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = _context.Fees.Find(id);
            if (data == null) return NotFound();

            _context.Fees.Remove(data);
            _context.SaveChanges();
            return Ok();
        }
    }
}
