#nullable disable
using LicensingAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace LicensingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechSurchargeController : ControllerBase
    {
        private readonly LicensingDbContext _context;

        public TechSurchargeController(LicensingDbContext context)
        {
            _context = context;
        }

        // GET /api/TechSurcharge/suf?bw=10&locationrate=MetroManilaRate&feecode=FX&unitchannel=1&numberofmonthsdelay=2
        [HttpGet("suf")]
        public ActionResult<decimal?> GetSurchargeSUF(
            decimal bw,
            string locationrate,
            string feecode,
            int unitchannel = 1,
            int numberofmonthsdelay = 0)
        {
            try
            {
                var bwParam = new SqlParameter("@bw", bw);
                var locationrateParam = new SqlParameter("@locationrate", locationrate);
                var feecodeParam = new SqlParameter("@feecode", feecode);
                var unitchannelParam = new SqlParameter("@unitchannel", unitchannel);
                var numberofmonthsdelayParam = new SqlParameter("@numberofmonthsdelay", numberofmonthsdelay);

                var row = _context.TechSurcharge
                    .FromSqlRaw(
                        "SELECT dbo.udf_GetSURSUF(@bw, @feecode, @locationrate, @unitchannel, @numberofmonthsdelay) AS surchargefee",
                        bwParam, feecodeParam, locationrateParam, unitchannelParam, numberofmonthsdelayParam)
                    .AsNoTracking()
                    .AsEnumerable()
                    .FirstOrDefault();

                return Ok(row?.surchargefee);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error calculating SUF surcharge: {ex.Message}");
            }
        }

        // GET /api/TechSurcharge/rsl50?unitchannel=1&category=HIGH&feecode=FX&mode=SIMPLEX&feetype=Ren
        [HttpGet("rsl50")]
        public ActionResult<decimal?> GetSurchargeRSL50(
            int unitchannel,
            string category,
            string feecode,
            string mode,
            string feetype)
        {
            try
            {
                var unitchannelParam = new SqlParameter("@unitchannel", unitchannel);
                var categoryParam = new SqlParameter("@category", category);
                var feecodeParam = new SqlParameter("@feecode", feecode);
                var modeParam = new SqlParameter("@mode", mode);
                var feetypeParam = new SqlParameter("@feetype", feetype);

                var row = _context.TechFeesSurchargeRSL50
                    .FromSqlRaw(
                        "SELECT dbo.udf_GetSURSLS50(@unitchannel, @category, @feecode, @mode, @feetype) AS surchargefee",
                        unitchannelParam, categoryParam, feecodeParam, modeParam, feetypeParam)
                    .AsNoTracking()
                    .AsEnumerable()
                    .FirstOrDefault();

                return Ok(row?.surchargefee);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error calculating RSL50 surcharge: {ex.Message}");
            }
        }

        // GET /api/TechSurcharge/rsl100?unitchannel=1&category=HIGH&feecode=FX&mode=SIMPLEX&feetype=Ren
        [HttpGet("rsl100")]
        public ActionResult<decimal?> GetSurchargeRSL100(
            int unitchannel,
            string category,
            string feecode,
            string mode,
            string feetype)
        {
            try
            {
                var unitchannelParam = new SqlParameter("@unitchannel", unitchannel);
                var categoryParam = new SqlParameter("@category", category);
                var feecodeParam = new SqlParameter("@feecode", feecode);
                var modeParam = new SqlParameter("@mode", mode);
                var feetypeParam = new SqlParameter("@feetype", feetype);

                var row = _context.TechFeesSurchargeRSL100
                    .FromSqlRaw(
                        "SELECT dbo.udf_GetSURSLS100(@unitchannel, @category, @feecode, @mode, @feetype) AS surchargefee",
                        unitchannelParam, categoryParam, feecodeParam, modeParam, feetypeParam)
                    .AsNoTracking()
                    .AsEnumerable()
                    .FirstOrDefault();

                return Ok(row?.surchargefee);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error calculating RSL100 surcharge: {ex.Message}");
            }
        }
    }
}
