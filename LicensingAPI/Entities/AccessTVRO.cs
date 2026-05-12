using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicensingAPI.Entities
{
    [Table("accessTVRO", Schema = "dbo")]
    public class AccessTVRO
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("BSD NO")]
        public string? BsdNo { get; set; }

        [Column("RELEASED DATE")]
        public DateTime? ReleasedDate { get; set; }

        [Column("DATE ISSUED")]
        public DateTime? DateIssued { get; set; }

        [Column("LICENSE NO")]
        public string? LicenseNo { get; set; }

        [Column("LICENSEE")]
        public string? Licensee { get; set; }

        [Column("LOCATION")]
        public string? Location { get; set; }

        [Column("Valid from")]
        public DateTime? ValidFrom { get; set; }

        [Column("Valid Until")]
        public DateTime? ValidUntil { get; set; }

        [Column("Model LNA")]
        public string? ModelLna { get; set; }

        [Column("Model Receiver")]
        public string? ModelReceiver { get; set; }

        [Column("Range LNA")]
        public string? RangeLna { get; set; }

        [Column("Range Receiver")]
        public string? RangeReceiver { get; set; }

        [Column("Serial LNA")]
        public string? SerialLna { get; set; }

        [Column("Serial Receiver")]
        public string? SerialReceiver { get; set; }

        [Column("Satellite")]
        public string? Satellite { get; set; }

        [Column("Receive Freq")]
        public string? ReceiveFreq { get; set; }

        [Column("Remarks")]
        public string? Remarks { get; set; }

        [Column("Other Equipment")]
        public string? OtherEquipment { get; set; }

        [Column("Date Processed")]
        public DateTime? DateProcessed { get; set; }

        [Column("Official Receipt")]
        public int? OfficialReceipt { get; set; }

        [Column("OR Date")]
        public DateTime? OrDate { get; set; }

        [Column("Amount", TypeName = "numeric(18,2)")]
        public decimal? Amount { get; set; }

        [Column("TVRO Registration")]
        public string? TvroRegistration { get; set; }

        [Column("TVRO Reg Date")]
        public DateTime? TvroRegDate { get; set; }

        [Column("ISSUED BY")]
        public string? IssuedBy { get; set; }

        [Column("FORM SERIAL")]
        public int? FormSerial { get; set; }

        [Column("CONTROL NUMBER")]
        [StringLength(10)]
        public string? ControlNumber { get; set; }

        [Column("PROVISIONAL AUTHORITY")]
        public string? ProvisionalAuthority { get; set; }

        [Column("CERTIFICATE OF AUTHORITY")]
        public string? CertificateOfAuthority { get; set; }

        [Column("ECE")]
        public string? Ece { get; set; }

        [Column("ECE LICENSE NO")]
        public string? EceLicenseNo { get; set; }

        [Column("TECHNICIAN")]
        public string? Technician { get; set; }

        [Column("MTRCB PERMIT NO")]
        public string? MtrcbPermitNo { get; set; }

        [Column("MAYOR'S PERMIT NO")]
        public string? MayorsPermitNo { get; set; }

        [Column("ATTACHMENT")]
        public string? Attachment { get; set; }

        [Column("STATUS")]
        public string? Status { get; set; }

        [Column("CONTACT NUMBER")]
        public string? ContactNumber { get; set; }

        [Column("REMARKS for MODIFICATION")]
        public string? RemarksForModification { get; set; }

        [Column("Encoder")]
        public string? Encoder { get; set; }

        [Column("Modification")]
        public string? Modification { get; set; }

        [Column("ReceiverModel")]
        public string? ReceiverModel { get; set; }

        [Column("ReceiverSerial")]
        public string? ReceiverSerial { get; set; }

        [Column("SatelliteOther")]
        public string? SatelliteOther { get; set; }

        [Column("ReceivedFreqOthers")]
        public string? ReceivedFreqOthers { get; set; }

        [Column("ReceiverSerial2")]
        public string? ReceiverSerial2 { get; set; }

        [Column("ReceivedFreqOthers2")]
        public string? ReceivedFreqOthers2 { get; set; }

        [Column("ReceivedFreqOthers3")]
        public string? ReceivedFreqOthers3 { get; set; }

        [Column("ReceiverSerial3")]
        public string? ReceiverSerial3 { get; set; }

        [Column("LNASerial")]
        public string? LnaSerial { get; set; }

        [Column("LNA Serial 2")]
        public string? LnaSerial2 { get; set; }

        [Column("ReceiverModel 2")]
        public string? ReceiverModel2 { get; set; }

        [Column("LNA MODEL2")]
        public string? LnaModel2 { get; set; }

        [Column("OR")]
        public int? Or { get; set; }

        [Column("OR DATE2")]
        public DateTime? OrDate2 { get; set; }

        [Column("Amount2", TypeName = "numeric(18,2)")]
        public decimal? Amount2 { get; set; }

        [Column("isOpen")]
        public byte? IsOpen { get; set; }

        [Column("isPrinted")]
        public byte? IsPrinted { get; set; }

        [Column("RoutingRefNo")]
        public string? RoutingRefNo { get; set; }

        [Timestamp]
        [Column("RowVer")]
        public byte[] RowVer { get; set; } = Array.Empty<byte>();
    }
}