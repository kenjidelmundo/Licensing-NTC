#nullable disable
using LicensingAPI.Data;
using Licensing.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicensingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechFeesController : ControllerBase
    {
        private readonly LicensingDbContext _context;

        public TechFeesController(LicensingDbContext context)
        {
            _context = context;
        }

        // =========================
        // ASKING DATA (GET)
        // =========================

        // GET: api/TechFees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TechFees>>> GetAllFees()
        {
            var list = await _context.tblFees
                .AsNoTracking()
                .ToListAsync();

            return Ok(list);
        }

        // GET: api/TechFees/fee/5
        [HttpGet("fee/{id:int}", Name = "GetFee")]
        public async Task<ActionResult<TechFees>> GetFee(int id)
        {
            var techfee = await _context.tblFees
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ID == id);

            if (techfee == null) return NotFound($"Fee ID {id} not found.");

            return Ok(techfee);
        }

        // =========================
        // MAINTENANCE (POST/PUT/DELETE)
        // =========================

        // POST: api/TechFees
        [HttpPost]
        public async Task<ActionResult<TechFees>> CreateFee([FromBody] TechFees fee)
        {
            if (fee == null) return BadRequest("Body is required.");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.tblFees.Add(fee);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetFee", new { id = fee.ID }, fee);
        }

        // PUT: api/TechFees/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateFee(int id, [FromBody] TechFees fee)
        {
            if (fee == null) return BadRequest("Body is required.");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (id != fee.ID) return BadRequest("ID mismatch.");

            var exists = await _context.tblFees.AnyAsync(x => x.ID == id);
            if (!exists) return NotFound($"Fee ID {id} not found.");

            _context.Entry(fee).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(fee);
        }

        // DELETE: api/TechFees/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteFee(int id)
        {
            var fee = await _context.tblFees.FirstOrDefaultAsync(x => x.ID == id);
            if (fee == null) return NotFound($"Fee ID {id} not found.");

            _context.tblFees.Remove(fee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // =========================
        // ASKING DATA (CALCULATORS) - keep as GET
        // =========================

        [HttpGet("calculate/new/{feecode}", Name = "CalculateTotalFeesNew")]
        public ActionResult<TechFeesNew> CalculateTotalFeesNew(
            string feecode,
            string category = "HIGH",
            string mode = "SIMPLEX",
            int unitchannel = 1,
            int unit = 1,
            int yearcount = 1)
        {
            var unitParam = new SqlParameter("@unit", unit);
            var categoryParam = new SqlParameter("@category", category);
            var yearcountParam = new SqlParameter("@year", yearcount);
            var unitchannelParam = new SqlParameter("@unitchannel", unitchannel);
            var feecodeParam = new SqlParameter("@feecode", feecode);
            var modeParam = new SqlParameter("@mode", mode);

            try
            {
                var row = _context.TechFeesNew
                    .FromSqlRaw(
                        "SELECT dbo.udf_GetTotalFeesNew(@unit, @category, @year, @unitchannel, @feecode, @mode) AS newfees",
                        unitParam, categoryParam, yearcountParam, unitchannelParam, feecodeParam, modeParam)
                    .AsEnumerable()
                    .FirstOrDefault();

                return row ?? new TechFeesNew { newfees = 0 };
            }
            catch (Exception ex)
            {
                return BadRequest($"Error calculating new fees: {ex.Message}");
            }
        }

        [HttpGet("calculate/newmod/{feecode}", Name = "CalculateTotalFeesNewMod")]
        public ActionResult<TechFeesNewMod> CalculateTotalFeesNewMod(string feecode, int unit = 1)
        {
            var unitParam = new SqlParameter("@unit", unit);
            var feecodeParam = new SqlParameter("@feecode", feecode);

            try
            {
                var row = _context.TechFeesNewMod
                    .FromSqlRaw(
                        "SELECT dbo.udf_GetTotalFeesNewMod(@unit, @feecode) AS newfeesmod",
                        unitParam, feecodeParam)
                    .AsEnumerable()
                    .FirstOrDefault();

                return row ?? new TechFeesNewMod { newfeesmod = 0 };
            }
            catch (Exception ex)
            {
                return BadRequest($"Error calculating new/mod fees: {ex.Message}");
            }
        }

        [HttpGet("calculate/ren/{feecode}", Name = "CalculateTotalFeesRen")]
        public ActionResult<TechFeesRen> CalculateTotalFeesRen(
            string feecodersl,
            decimal bw,
            string feecode,
            string locationrate,
            int numberofmonthsdelay,
            string feetype,
            string category = "HIGH",
            string mode = "SIMPLEX",
            int unitchannel = 1,
            int unit = 1,
            int yearcount = 1,
            bool isfullcharge = false,
            bool withsurcharge = false)
        {
            var bwParam = new SqlParameter("@bw", bw);
            var locationrateParam = new SqlParameter("@locationrate", locationrate);
            var feecoderslParam = new SqlParameter("@feecodersl", feecodersl);
            var numberofmonthsdelayParam = new SqlParameter("@numberofmonthsdelay", numberofmonthsdelay);
            var unitParam = new SqlParameter("@unit", unit);
            var yearcountParam = new SqlParameter("@year", yearcount);
            var feecodeParam = new SqlParameter("@feecode", feecode);
            var modeParam = new SqlParameter("@mode", mode);
            var feetypeParam = new SqlParameter("@feetype", feetype);
            var categoryParam = new SqlParameter("@category", category);
            var unitchannelParam = new SqlParameter("@unitchannel", unitchannel);
            var isfullchargeParam = new SqlParameter("@isfullcharge", isfullcharge);
            var withsurchargeParam = new SqlParameter("@withsurcharge", withsurcharge);

            try
            {
                var row = _context.TechFeesRen
                    .FromSqlRaw(
                        "SELECT dbo.udf_GetTotalFeesRen(@unit, @category, @year, @unitchannel, @feecodersl, @mode, @bw, @locationrate, @feecode, @numberofmonthsdelay, @feetype, @isfullcharge, @withsurcharge) AS renfees",
                        unitParam, categoryParam, yearcountParam, unitchannelParam, feecoderslParam, modeParam,
                        bwParam, locationrateParam, feecodeParam, numberofmonthsdelayParam, feetypeParam,
                        isfullchargeParam, withsurchargeParam)
                    .AsEnumerable()
                    .FirstOrDefault();

                return row ?? new TechFeesRen { renfees = 0 };
            }
            catch (Exception ex)
            {
                return BadRequest($"Error calculating renewal fees: {ex.Message}");
            }
        }
    }
}
