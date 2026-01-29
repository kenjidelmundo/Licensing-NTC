using LicensingAPI.Data;
using LicensingAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LicensingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SUFRateController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public SUFRateController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/SUFRate
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.SUFRates.ToList());
        }

        // GET: api/SUFRate/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _context.SUFRates.Find(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        // POST: api/SUFRate
        [HttpPost]
        public IActionResult Post(SUFRate model)
        {
            _context.SUFRates.Add(model);
            _context.SaveChanges();
            return Ok(model);
        }

        // PUT: api/SUFRate/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, SUFRate model)
        {
            var existing = _context.SUFRates.Find(id);
            if (existing == null) return NotFound();

            existing.Rate = model.Rate;
            existing.EffectiveDate = model.EffectiveDate;

            _context.SaveChanges();
            return Ok(existing);
        }

        // DELETE: api/SUFRate/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _context.SUFRates.Find(id);
            if (item == null) return NotFound();

            _context.SUFRates.Remove(item);
            _context.SaveChanges();
            return Ok();
        }
    }
}
