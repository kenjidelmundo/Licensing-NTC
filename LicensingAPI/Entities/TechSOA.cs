using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Licensing.Entities
{
    [Table("accessSOA", Schema = "dbo")]
    public class TechSOA
    {
        // =========================
        // KEYS / BASIC INFO
        // =========================

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int ID { get; set; }

        [Column("Date Issued")]
        public DateTime? DateIssued { get; set; }

        [Column("LICENSEE")]
        [MaxLength(255)]
        public string? Licensee { get; set; }

        [Column("Address")]
        [MaxLength(255)]
        public string? Address { get; set; }

        [Column("YourCounterField")]
        public int? YourCounterField { get; set; }

        [Column("YearMonth")]
        [MaxLength(255)]
        public string? YearMonth { get; set; }

        [Column("SOASeries")]
        [MaxLength(243)]
        public string? SOASeries { get; set; }

        // =========================
        // RSL FEES
        // =========================

        [Column("rslPurchase", TypeName = "money")]
        public decimal? rslPurchase { get; set; }

        [Column("rslFillingFee", TypeName = "money")]
        public decimal? rslFillingFee { get; set; }

        [Column("rslPossess", TypeName = "money")]
        public decimal? rslPossess { get; set; }

        [Column("rslConstruction", TypeName = "money")]
        public decimal? rslConstruction { get; set; }

        [Column("rslRadioStation", TypeName = "money")]
        public decimal? rslRadioStation { get; set; }

        [Column("rslInspection", TypeName = "money")]
        public decimal? rslInspection { get; set; }

        [Column("rslSUF", TypeName = "money")]
        public decimal? rslSUF { get; set; }

        [Column("AmnestyFine", TypeName = "money")]
        public decimal? AmnestyFine { get; set; }

        [Column("rslSurcharge", TypeName = "money")]
        public decimal? rslSurcharge { get; set; }

        // =========================
        // PERMIT FEES
        // =========================

        [Column("permitPermitFees", TypeName = "money")]
        public decimal? permitPermitFees { get; set; }

        [Column("permitInspection", TypeName = "money")]
        public decimal? permitInspection { get; set; }

        [Column("permitFillingFee", TypeName = "money")]
        public decimal? permitFillingFee { get; set; }

        [Column("permitSurcharge", TypeName = "money")]
        public decimal? permitSurcharge { get; set; }

        // =========================
        // ROC FEES
        // =========================

        [Column("rocRadioStation", TypeName = "money")]
        public decimal? rocRadioStation { get; set; }

        [Column("rocOperatorFee", TypeName = "money")]
        public decimal? rocOperatorFee { get; set; }

        [Column("rocFillingFee", TypeName = "money")]
        public decimal? rocFillingFee { get; set; }

        [Column("rocSeminarFee", TypeName = "money")]
        public decimal? rocSeminarFee { get; set; }

        [Column("rocSurcharge", TypeName = "money")]
        public decimal? rocSurcharge { get; set; }

        [Column("rocApplicationFee", TypeName = "money")]
        public decimal? rocApplicationFee { get; set; }

        // =========================
        // OTHER FEES
        // =========================

        [Column("otherRegistration", TypeName = "money")]
        public decimal? otherRegistration { get; set; }

        [Column("otherSRF", TypeName = "money")]
        public decimal? otherSRF { get; set; }

        [Column("otherVerification", TypeName = "money")]
        public decimal? otherVerification { get; set; }

        [Column("otherExam", TypeName = "money")]
        public decimal? otherExam { get; set; }

        [Column("otherClearanceand CertFee", TypeName = "money")]
        public decimal? otherClearanceandCertFee { get; set; }

        [Column("otherModification", TypeName = "money")]
        public decimal? otherModification { get; set; }

        [Column("otherMiscIncome", TypeName = "money")]
        public decimal? otherMiscIncome { get; set; }

        [Column("DST", TypeName = "money")]
        public decimal? DST { get; set; }

        [Column("otherOTHERS", TypeName = "money")]
        public decimal? otherOTHERS { get; set; }

        // =========================
        // TEXT FIELDS
        // =========================

        [Column("Particulars")]
        [MaxLength(255)]
        public string? Particulars { get; set; }

        [Column("Period Covered")]
        [MaxLength(255)]
        public string? PeriodCovered { get; set; }

        // =========================
        // CHECKBOX FLAGS
        // =========================

        [Column("chkNEW")]
        public bool? chkNEW { get; set; }

        [Column("chkREN")]
        public bool? chkREN { get; set; }

        [Column("chkMOD")]
        public bool? chkMOD { get; set; }

        [Column("chkDUP")]
        public bool? chkDUP { get; set; }

        [Column("chkCO")]
        public bool? chkCO { get; set; }

        [Column("chkCV")]
        public bool? chkCV { get; set; }

        [Column("chkMS")]
        public bool? chkMS { get; set; }

        [Column("chkMA")]
        public bool? chkMA { get; set; }

        [Column("chkROC")]
        public bool? chkROC { get; set; }

        [Column("chkOthers")]
        public bool? chkOthers { get; set; }

        // =========================
        // NOTES / COMMENTS
        // =========================

        [Column("chkOtherComment")]
        [MaxLength(255)]
        public string? chkOtherComment { get; set; }

        [Column("rslSurchargeNote")]
        [MaxLength(255)]
        public string? rslSurchargeNote { get; set; }

        [Column("permitSurchargeNote")]
        [MaxLength(255)]
        public string? permitSurchargeNote { get; set; }

        [Column("othersNote")]
        [MaxLength(255)]
        public string? othersNote { get; set; }

        [Column("rocSurchargeNote")]
        [MaxLength(255)]
        public string? rocSurchargeNote { get; set; }

        // =========================
        // TOTALS
        // =========================

        [Column("TotalAmount2", TypeName = "money")]
        public decimal? TotalAmount2 { get; set; }

        [Column("TotalAmount", TypeName = "money")]
        public decimal? TotalAmount { get; set; }

        // =========================
        // SIGNATORIES / STATUS
        // =========================

        [Column("PreparedBy")]
        [MaxLength(255)]
        public string? PreparedBy { get; set; }

        [Column("ApprovedBy")]
        [MaxLength(255)]
        public string? ApprovedBy { get; set; }

        [Column("chkAssesment")]
        public bool? chkAssesment { get; set; }

        [Column("chkPayment")]
        public bool? chkPayment { get; set; }

        // =========================
        // PAYMENT / OR DETAILS
        // =========================

        [Column("NoteTobePayed")]
        public DateTime? NoteTobePayed { get; set; }

        [Column("OR NUMBER")]
        public int? ORNUMBER { get; set; }

        [Column("OR NUMBER2")]
        public int? ORNUMBER2 { get; set; }

        [Column("DatePaid")]
        public DateTime? DatePaid { get; set; }

        [Column("DatePaid2")]
        public DateTime? DatePaid2 { get; set; }

        [Column("OP Series")]
        [MaxLength(255)]
        public string? OPSeries { get; set; }

        [Column("SRFYEAR")]
        [MaxLength(255)]
        public string? SRFYEAR { get; set; }

        [Column("REMARKS/NOTE")]
        [MaxLength(255)]
        public string? REMARKSNOTE { get; set; }

        [Column("PaymentMode")]
        [MaxLength(255)]
        public string? PaymentMode { get; set; }

        [Column("Check No")]
        [MaxLength(255)]
        public string? CheckNo { get; set; }

        [Column("PaymentAfter", TypeName = "money")]
        public decimal? PaymentAfter { get; set; }

        [Column("DateOfCheck")]
        public DateTime? DateOfCheck { get; set; }

        // =========================
        // ACCOUNTING
        // =========================

        [Column("Accounting", TypeName = "varchar(max)")]
        public string? Accounting { get; set; }

        [Column("AccountingPosition", TypeName = "varchar(max)")]
        public string? AccountingPosition { get; set; }

        [Column("ReferenceNo")]
        [MaxLength(50)]
        public string? ReferenceNo { get; set; }

        // =========================
        // CONCURRENCY
        // =========================

        [Timestamp]
        [Column("RowVersionColumn")]
        public byte[] RowVersionColumn { get; set; } = Array.Empty<byte>();

        // =========================
        // PRINT / OPEN FLAGS
        // =========================

        [Column("isOpenforSOA")]
        public bool? isOpenforSOA { get; set; }

        [Column("isPrintedforSOA")]
        public bool? isPrintedforSOA { get; set; }

        [Column("isOpenforOP")]
        public bool? isOpenforOP { get; set; }

        [Column("isPrintedforOP")]
        public bool? isPrintedforOP { get; set; }

        [Column("isOpenforPayment")]
        public bool? isOpenforPayment { get; set; }

        [Column("isPrintedforPayment")]
        public bool? isPrintedforPayment { get; set; }

        // =========================
        // ROUTING / BRANCH
        // =========================

        [Column("RoutingSlipRefNo", TypeName = "varchar(max)")]
        public string? RoutingSlipRefNo { get; set; }

        [Column("ResponsibilityCenter")]
        [MaxLength(100)]
        public string? ResponsibilityCenter { get; set; }

        [Column("NameofBranch")]
        [MaxLength(100)]
        public string? NameofBranch { get; set; }
    }
}
