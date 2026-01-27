using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LicensingAPI.Data;

namespace LicensingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SOAController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public SOAController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetSOA()
        {
            var data = await _context.SOAs
                                     .Include(s => s.SOA_Details)
                                     .ToListAsync();
            return Ok(data);
        }
    }
}
