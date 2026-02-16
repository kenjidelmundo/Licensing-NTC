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

        // ✅ Period Covered = YEAR-YEAR ONLY (example: 2004-2005)
        private static string BuildPeriodCoveredYearRange(DateTime? from, DateTime? to)
        {
            if (!from.HasValue || !to.HasValue) return null;

            int y1 = from.Value.Year;
            int y2 = to.Value.Year;

            // if to is earlier than from, still return from-to (or return null if you prefer)
            if (to.Value.Date < from.Value.Date)
                return null;

            string text = $"{y1}-{y2}"; // "2004-2005"
            return text.Length > 255 ? text.Substring(0, 255) : text;
        }

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

            // ✅ PERIOD COVERED = YEAR RANGE (2004-2005)
            // computed from dto.PeriodFrom + dto.PeriodTo (UI-only)
            var yearRange = BuildPeriodCoveredYearRange(dto.PeriodFrom, dto.PeriodTo);
            entity.PeriodCovered = yearRange ?? dto.PeriodCovered; // fallback if you send PeriodCovered manually

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
            var rows = await _context.accessSOA
                .AsNoTracking()
                .OrderByDescending(x => x.ID)
                .ToListAsync();

            return Ok(rows);
        }

        // ✅ GET: api/TechSOA/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var row = await _context.accessSOA
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ID == id);

            if (row == null) return NotFound($"ID {id} not found.");
            return Ok(row);
        }

        // ✅ GET: api/TechSOA/payees
        [HttpGet("payees")]
        public async Task<IActionResult> GetPayees()
        {
            var payees = await _context.accessSOA
                .AsNoTracking()
                .Select(x => x.Licensee)
                .Where(x => x != null && x.Trim() != "")
                .Select(x => x.Trim())
                .Distinct()
                .OrderBy(x => x)
                .ToListAsync();

            return Ok(payees);
        }

        // ✅ POST: api/TechSOA  (Create ALL fields)
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TechSOAUpsertDto dto)
        {
            if (dto == null) return BadRequest("Body is required.");

            var entity = new TechSOA();
            ApplyDtoToEntity(entity, dto);

            _context.accessSOA.Add(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = entity.ID }, entity);
        }

        // ✅ PUT: api/TechSOA/5  (Update ALL fields)
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] TechSOAUpsertDto dto)
        {
            if (dto == null) return BadRequest("Body is required.");

            var entity = await _context.accessSOA.FirstOrDefaultAsync(x => x.ID == id);
            if (entity == null) return NotFound($"ID {id} not found.");

            ApplyDtoToEntity(entity, dto);

            await _context.SaveChangesAsync();
            return Ok(entity);
        }

        // ✅ DELETE: api/TechSOA/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _context.accessSOA.FirstOrDefaultAsync(x => x.ID == id);
            if (entity == null) return NotFound($"ID {id} not found.");

            _context.accessSOA.Remove(entity);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
