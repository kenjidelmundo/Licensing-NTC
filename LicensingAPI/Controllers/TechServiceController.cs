using LicensingAPI.Data;
using LicensingAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LicensingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TechServiceController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public TechServiceController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.TechServices.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = _context.TechServices.Find(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Post(TechService model)
        {
            _context.TechServices.Add(model);
            _context.SaveChanges();
            return Ok(model);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TechService model)
        {
            var existing = _context.TechServices.Find(id);
            if (existing == null) return NotFound();

            existing.ServiceName = model.ServiceName;
            existing.Description = model.Description;

            _context.SaveChanges();
            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = _context.TechServices.Find(id);
            if (data == null) return NotFound();

            _context.TechServices.Remove(data);
            _context.SaveChanges();
            return Ok();
        }
    }
}
