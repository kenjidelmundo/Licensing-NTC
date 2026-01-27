using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LicensingAPI.Entities;
using LicensingAPI.Data;

namespace LicensingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TechEODServiceController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public TechEODServiceController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _context.TechEODServices.ToListAsync();
            return Ok(data);
        }
    }
}
