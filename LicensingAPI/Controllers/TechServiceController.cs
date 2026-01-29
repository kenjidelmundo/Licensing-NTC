#nullable disable
using LicensingAPI.Data;
using Licensing.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LicensingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechServiceController : ControllerBase
    {
        private readonly LicensingDbContext _context;

        public TechServiceController(LicensingDbContext context)
        {
            _context = context;
        }

        // GET: api/TechService
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TechService>>> GetTechServiceList()
        {
            var list = await _context.TechService
                .AsNoTracking()
                .ToListAsync();

            return Ok(list);
        }
    }
}
