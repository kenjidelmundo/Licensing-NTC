#nullable disable
using LicensingAPI.Data;
using Licensing.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicensingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechSUFRateController : ControllerBase
    {
        private readonly LicensingDbContext _context;

        public TechSUFRateController(LicensingDbContext context)
        {
            _context = context;
        }

        // GET: api/TechSUFRate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TechSUFRate>>> GetAllSUFRate()
        {
            var list = await _context.SUFRate
                .AsNoTracking()
                .ToListAsync();

            return Ok(list);
        }

        // GET: api/TechSUFRate/sufrate/5
        [HttpGet("sufrate/{id:int}", Name = "GetSUFRate")]
        public async Task<ActionResult<TechSUFRate>> GetSUFRate(int id)
        {
            var techsufrate = await _context.SUFRate
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ID == id);

            if (techsufrate == null) return NotFound($"SUFRate ID {id} not found.");

            return Ok(techsufrate);
        }

        // GET: api/TechSUFRate/calculate/sufrate?feecode=FX&columnrate=HighlyUrbanizedCities
        [HttpGet("calculate/sufrate/", Name = "CalculateSUFRateFee")]
        public ActionResult<TechFeesSUFRate> CalculateSUFRateFee(
            string feecode,
            string columnrate = "HighlyUrbanizedCities")
        {
            var feecodeParam = new SqlParameter("@feecode", feecode);
            var columnrateParam = new SqlParameter("@columnrate", columnrate);

            try
            {
                // ✅ FIX: alias MUST match property name "sufratefee"
                var sufrateFee = _context.TechFeesSUFRate
                   .FromSqlRaw(
                       "SELECT dbo.udf_GetSUFRate (@feecode, @columnrate) AS sufratefee",
                       feecodeParam, columnrateParam)
                   .AsEnumerable()
                   .FirstOrDefault();

                return sufrateFee ?? new TechFeesSUFRate { sufratefee = 0 };
            }
            catch (Exception ex)
            {
                return BadRequest($"Error calculating SUF rate fee: {ex.Message}");
            }
        }

        // GET: api/TechSUFRate/calculate/sufrate/FX?bw=10&feecode=FXMWB10&columnrate=HighlyUrbanizedCities&unitchannel=1
        [HttpGet("calculate/sufrate/{feecode}", Name = "CalculateTotalSUFRate")]
        public ActionResult<TechFeesSUFRate> CalculateTotalSUFRate(
            decimal bw,
            string feecode,
            string columnrate = "HighlyUrbanizedCities",
            int unitchannel = 1)
        {
            var bwParam = new SqlParameter("@bw", bw);
            var columnrateParam = new SqlParameter("@columnrate", columnrate);
            var feecodeParam = new SqlParameter("@feecode", feecode);
            var unitchannelParam = new SqlParameter("@unitchannel", unitchannel);

            try
            {
                // ✅ FIX: alias MUST match property name "sufratefee"
                var sufratefee = _context.TechFeesSUFRate
                   .FromSqlRaw(
                       "SELECT dbo.udf_GetSUF(@bw, @columnrate, @feecode, @unitchannel) AS sufratefee",
                       bwParam, columnrateParam, feecodeParam, unitchannelParam)
                   .AsEnumerable()
                   .FirstOrDefault();

                return sufratefee ?? new TechFeesSUFRate { sufratefee = 0 };
            }
            catch (Exception ex)
            {
                return BadRequest($"Error calculating total SUF rate: {ex.Message}");
            }
        }
    }
}
