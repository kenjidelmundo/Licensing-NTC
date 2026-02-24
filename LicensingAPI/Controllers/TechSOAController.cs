#nullable disable
using LicensingAPI.Data;
using LicensingAPI.DTOs;
using Licensing.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LicensingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechSOAController : ControllerBase
    {
        private readonly LicensingDbContext _context;

        public TechSOAController(LicensingDbContext context)
        {
            _context = context;
        }

        // ✅ DEBUG: confirm what DB your API is using at runtime
        [HttpGet("dbinfo")]
        public IActionResult DbInfo()
        {
            var conn = _context.Database.GetDbConnection();
            return Ok(new { DataSource = conn.DataSource, Database = conn.Database });
        }

        // ✅ Period Covered = FULL DATE RANGE (example: 20/02/2026-20/06/2026)
        private static string BuildPeriodCoveredFullDateRange(DateTime? from, DateTime? to)
        {
            if (!from.HasValue || !to.HasValue) return null;
            if (to.Value.Date < from.Value.Date) return null;

            var text = $"{from.Value:dd/MM/yyyy}-{to.Value:dd/MM/yyyy}";
            return text.Length > 255 ? text.Substring(0, 255) : text;
        }

        // ==========================================================
        // ✅ CITIZEN CHARTER LOOKUP HELPERS
        // IMPORTANT: Adjust these 2 methods to your table columns
        // ==========================================================
        private static string GetCode(TechCCFormula row)
        {
            // TODO: CHANGE THIS to your actual "code/name" column
            // Examples:
            // return row.Code;
            // return row.FormulaCode;
            // return row.FormulaName;
            return row.Code; // <-- adjust if not existing
        }

        private static decimal GetAmount(TechCCFormula row)
        {
            // TODO: CHANGE THIS to your actual "amount/value" column
            // Examples:
            // return row.Amount;
            // return row.Value;
            // return row.Rate;
            return Convert.ToDecimal(row.Amount); // <-- adjust if not existing
        }

        private async Task<decimal> CC(string code)
        {
            // pull from DB each call (ok for now; later you can cache)
            var rows = await _context.CitizenCharterFormula.AsNoTracking().ToListAsync();
            var r = rows.FirstOrDefault(x => (GetCode(x) ?? "").Trim().ToUpper() == code.Trim().ToUpper());
            return r == null ? 0m : GetAmount(r);
        }

        // ✅ GET: api/TechSOA/cc/roc?mode=NEW|RENEWAL|MODIFICATION
        [HttpGet("cc/roc")]
        public async Task<IActionResult> GetRocCitizenCharter([FromQuery] string mode = "NEW")
        {
            try
            {
                // You store these codes in CitizenCharterFormula table:
                var result = new
                {
                    mode = (mode ?? "NEW").ToUpper(),

                    rocPerYear = await CC("ROC_YR"),
                    rocOperator = await CC("ROC_OPERATOR"),
                    rocApplication = await CC("ROC_APPLICATION"),
                    rocFiling = await CC("ROC_FILING"),
                    rocSeminar = await CC("ROC_SEMINAR"),
                    rocSurcharge = await CC("ROC_SUR"),
                    rocModification = await CC("ROC_MOD"),
                    dst = await CC("DST"),
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        // ✅ GET: api/TechSOA/cc/amateur
        [HttpGet("cc/amateur")]
        public async Task<IActionResult> GetAmateurCitizenCharter()
        {
            try
            {
                var result = new
                {
                    posPerUnit = await CC("AM_POS_UNIT"),
                    dst = await CC("DST"),
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        // ==========================================================
        // ✅ APPLY DTO
        // ==========================================================
        private static void ApplyDtoToEntity(TechSOA entity, TechSOAUpsertDto dto)
        {
            // BASIC
            entity.DateIssued = dto.DateIssued;
            entity.Licensee = dto.Licensee;
            entity.Address = dto.Address;
            entity.YourCounterField = dto.YourCounterField;
            entity.YearMonth = dto.YearMonth;
            entity.SOASeries = dto.SOASeries;

            // RSL
            entity.rslPurchase = dto.rslPurchase;
            entity.rslFillingFee = dto.rslFillingFee;
            entity.rslPossess = dto.rslPossess;
            entity.rslConstruction = dto.rslConstruction;
            entity.rslRadioStation = dto.rslRadioStation;
            entity.rslInspection = dto.rslInspection;
            entity.rslSUF = dto.rslSUF;
            entity.AmnestyFine = dto.AmnestyFine;
            entity.rslSurcharge = dto.rslSurcharge;

            // PERMIT
            entity.permitPermitFees = dto.permitPermitFees;
            entity.permitInspection = dto.permitInspection;
            entity.permitFillingFee = dto.permitFillingFee;
            entity.permitSurcharge = dto.permitSurcharge;

            // ROC
            entity.rocRadioStation = dto.rocRadioStation;
            entity.rocOperatorFee = dto.rocOperatorFee;
            entity.rocFillingFee = dto.rocFillingFee;
            entity.rocSeminarFee = dto.rocSeminarFee;
            entity.rocSurcharge = dto.rocSurcharge;
            entity.rocApplicationFee = dto.rocApplicationFee;

            // OTHERS
            entity.otherRegistration = dto.otherRegistration;
            entity.otherSRF = dto.otherSRF;
            entity.otherVerification = dto.otherVerification;
            entity.otherExam = dto.otherExam;
            entity.otherClearanceandCertFee = dto.otherClearanceandCertFee;
            entity.otherModification = dto.otherModification;
            entity.otherMiscIncome = dto.otherMiscIncome;
            entity.DST = dto.DST;
            entity.otherOTHERS = dto.otherOTHERS;

            // TEXT
            entity.Particulars = dto.Particulars;

            // ✅ PERIOD COVERED (FULL DATE RANGE)
            var fullRange = BuildPeriodCoveredFullDateRange(dto.PeriodFrom, dto.PeriodTo);
            entity.PeriodCovered = fullRange ?? dto.PeriodCovered;

            // CHECKBOX FLAGS
            entity.chkNEW = dto.chkNEW;
            entity.chkREN = dto.chkREN;
            entity.chkMOD = dto.chkMOD;
            entity.chkDUP = dto.chkDUP;
            entity.chkCO = dto.chkCO;
            entity.chkCV = dto.chkCV;
            entity.chkMS = dto.chkMS;
            entity.chkMA = dto.chkMA;
            entity.chkROC = dto.chkROC;
            entity.chkOthers = dto.chkOthers;

            // NOTES
            entity.chkOtherComment = dto.chkOtherComment;
            entity.rslSurchargeNote = dto.rslSurchargeNote;
            entity.permitSurchargeNote = dto.permitSurchargeNote;
            entity.othersNote = dto.othersNote;
            entity.rocSurchargeNote = dto.rocSurchargeNote;

            // TOTALS
            entity.TotalAmount2 = dto.TotalAmount2;
            entity.TotalAmount = dto.TotalAmount;

            // SIGNATORIES / STATUS
            entity.PreparedBy = dto.PreparedBy;
            entity.ApprovedBy = dto.ApprovedBy;
            entity.chkAssesment = dto.chkAssesment;
            entity.chkPayment = dto.chkPayment;

            // PAYMENT / OR
            entity.NoteTobePayed = dto.NoteTobePayed;
            entity.ORNUMBER = dto.ORNUMBER;
            entity.ORNUMBER2 = dto.ORNUMBER2;
            entity.DatePaid = dto.DatePaid;
            entity.DatePaid2 = dto.DatePaid2;
            entity.OPSeries = dto.OPSeries;
            entity.SRFYEAR = dto.SRFYEAR;
            entity.REMARKSNOTE = dto.REMARKSNOTE;
            entity.PaymentMode = dto.PaymentMode;
            entity.CheckNo = dto.CheckNo;
            entity.PaymentAfter = dto.PaymentAfter;
            entity.DateOfCheck = dto.DateOfCheck;

            // ACCOUNTING
            entity.Accounting = dto.Accounting;
            entity.AccountingPosition = dto.AccountingPosition;
            entity.ReferenceNo = dto.ReferenceNo;

            // FLAGS
            entity.isOpenforSOA = dto.isOpenforSOA;
            entity.isPrintedforSOA = dto.isPrintedforSOA;
            entity.isOpenforOP = dto.isOpenforOP;
            entity.isPrintedforOP = dto.isPrintedforOP;
            entity.isOpenforPayment = dto.isOpenforPayment;
            entity.isPrintedforPayment = dto.isPrintedforPayment;

            // ROUTING / BRANCH
            entity.RoutingSlipRefNo = dto.RoutingSlipRefNo;
            entity.ResponsibilityCenter = dto.ResponsibilityCenter;
            entity.NameofBranch = dto.NameofBranch;
        }

        // ✅ GET: api/TechSOA
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var rows = await _context.accessSOA
                    .AsNoTracking()
                    .OrderByDescending(x => x.ID)
                    .ToListAsync();

                return Ok(rows);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        // ✅ GET: api/TechSOA/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var row = await _context.accessSOA
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.ID == id);

                if (row == null) return NotFound($"ID {id} not found.");
                return Ok(row);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        // ✅ POST: api/TechSOA
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TechSOAUpsertDto dto)
        {
            if (dto == null) return BadRequest("Body is required.");

            try
            {
                var entity = new TechSOA();
                ApplyDtoToEntity(entity, dto);

                _context.accessSOA.Add(entity);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetById), new { id = entity.ID }, entity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        // ✅ PUT: api/TechSOA/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] TechSOAUpsertDto dto)
        {
            if (dto == null) return BadRequest("Body is required.");

            try
            {
                var entity = await _context.accessSOA.FirstOrDefaultAsync(x => x.ID == id);
                if (entity == null) return NotFound($"ID {id} not found.");

                ApplyDtoToEntity(entity, dto);

                await _context.SaveChangesAsync();
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        // ✅ DELETE: api/TechSOA/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var entity = await _context.accessSOA.FirstOrDefaultAsync(x => x.ID == id);
                if (entity == null) return NotFound($"ID {id} not found.");

                _context.accessSOA.Remove(entity);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }
    }
}