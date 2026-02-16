#nullable disable
using System;

namespace LicensingAPI.DTOs
{
    public class TechSOAUpsertDto
    {
        // UI-only (not DB)
        public DateTime? PeriodFrom { get; set; }
        public DateTime? PeriodTo { get; set; }

        // BASIC
        public DateTime? DateIssued { get; set; }
        public string Licensee { get; set; }
        public string Address { get; set; }
        public int? YourCounterField { get; set; }
        public string YearMonth { get; set; }
        public string SOASeries { get; set; }

        // RSL
        public decimal? rslPurchase { get; set; }
        public decimal? rslFillingFee { get; set; }
        public decimal? rslPossess { get; set; }
        public decimal? rslConstruction { get; set; }
        public decimal? rslRadioStation { get; set; }
        public decimal? rslInspection { get; set; }
        public decimal? rslSUF { get; set; }
        public decimal? AmnestyFine { get; set; }
        public decimal? rslSurcharge { get; set; }

        // PERMIT
        public decimal? permitPermitFees { get; set; }
        public decimal? permitInspection { get; set; }
        public decimal? permitFillingFee { get; set; }
        public decimal? permitSurcharge { get; set; }

        // ROC
        public decimal? rocRadioStation { get; set; }
        public decimal? rocOperatorFee { get; set; }
        public decimal? rocFillingFee { get; set; }
        public decimal? rocSeminarFee { get; set; }
        public decimal? rocSurcharge { get; set; }
        public decimal? rocApplicationFee { get; set; }

        // OTHER
        public decimal? otherRegistration { get; set; }
        public decimal? otherSRF { get; set; }
        public decimal? otherVerification { get; set; }
        public decimal? otherExam { get; set; }
        public decimal? otherClearanceandCertFee { get; set; }
        public decimal? otherModification { get; set; }
        public decimal? otherMiscIncome { get; set; }
        public decimal? DST { get; set; }
        public decimal? otherOTHERS { get; set; }

        // TEXT
        public string Particulars { get; set; }

        // DB column "Period Covered" (we fill as "YYYY-YYYY")
        public string PeriodCovered { get; set; }

        // CHECKBOX FLAGS
        public bool? chkNEW { get; set; }
        public bool? chkREN { get; set; }
        public bool? chkMOD { get; set; }
        public bool? chkDUP { get; set; }
        public bool? chkCO { get; set; }
        public bool? chkCV { get; set; }
        public bool? chkMS { get; set; }
        public bool? chkMA { get; set; }
        public bool? chkROC { get; set; }
        public bool? chkOthers { get; set; }

        // NOTES
        public string chkOtherComment { get; set; }
        public string rslSurchargeNote { get; set; }
        public string permitSurchargeNote { get; set; }
        public string othersNote { get; set; }
        public string rocSurchargeNote { get; set; }

        // TOTALS
        public decimal? TotalAmount2 { get; set; }
        public decimal? TotalAmount { get; set; }

        // SIGNATORIES / STATUS
        public string PreparedBy { get; set; }
        public string ApprovedBy { get; set; }
        public bool? chkAssesment { get; set; }
        public bool? chkPayment { get; set; }

        // PAYMENT / OR
        public DateTime? NoteTobePayed { get; set; }
        public int? ORNUMBER { get; set; }
        public int? ORNUMBER2 { get; set; }
        public DateTime? DatePaid { get; set; }
        public DateTime? DatePaid2 { get; set; }
        public string OPSeries { get; set; }
        public string SRFYEAR { get; set; }
        public string REMARKSNOTE { get; set; }
        public string PaymentMode { get; set; }
        public string CheckNo { get; set; }
        public decimal? PaymentAfter { get; set; }
        public DateTime? DateOfCheck { get; set; }

        // ACCOUNTING
        public string Accounting { get; set; }
        public string AccountingPosition { get; set; }
        public string ReferenceNo { get; set; }

        // FLAGS
        public bool? isOpenforSOA { get; set; }
        public bool? isPrintedforSOA { get; set; }
        public bool? isOpenforOP { get; set; }
        public bool? isPrintedforOP { get; set; }
        public bool? isOpenforPayment { get; set; }
        public bool? isPrintedforPayment { get; set; }

        // ROUTING / BRANCH
        public string RoutingSlipRefNo { get; set; }
        public string ResponsibilityCenter { get; set; }
        public string NameofBranch { get; set; }
    }
}
