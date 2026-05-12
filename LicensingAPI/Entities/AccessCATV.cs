using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicensingAPI.Entities
{
    [Table("accessCATV", Schema = "dbo")]
    public class AccessCATV
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("BMC Case No")]
        public string? BmcCaseNo { get; set; }

        [Column("Period")]
        public string? Period { get; set; }

        [Column("LICENSE No")]
        public string? LicenseNo { get; set; }

        [Column("LICENSEE")]
        public string? Licensee { get; set; }

        [Column("LOCATION")]
        public string? Location { get; set; }

        [Column("Service Area")]
        public string? ServiceArea { get; set; }

        [Column("Valid from")]
        public DateTime? ValidFrom { get; set; }

        [Column("Valid until")]
        public DateTime? ValidUntil { get; set; }

        [Column("Modulator Model")]
        public string? ModulatorModel { get; set; }

        [Column("Modulator Serial")]
        public string? ModulatorSerial { get; set; }

        [Column("Modulator Remarks")]
        public string? ModulatorRemarks { get; set; }

        [Column("Combiner Model")]
        public string? CombinerModel { get; set; }

        [Column("Combiner Serial")]
        public string? CombinerSerial { get; set; }

        [Column("Combiner Remarks")]
        public string? CombinerRemarks { get; set; }

        [Column("Other Equipment")]
        public string? OtherEquipment { get; set; }

        [Column("OR No")]
        public int? OrNo { get; set; }

        [Column("OR Date")]
        public DateTime? OrDate { get; set; }

        [Column("Amount", TypeName = "numeric(18,2)")]
        public decimal? Amount { get; set; }

        [Column("ISSUED")]
        public DateTime? Issued { get; set; }

        [Column("Encoded")]
        public string? Encoded { get; set; }

        [Column("CA ISSUED ON")]
        public DateTime? CaIssuedOn { get; set; }

        [Column("Released Date")]
        public DateTime? ReleasedDate { get; set; }

        [Column("Form Serial")]
        public int? FormSerial { get; set; }

        [Column("Control Number")]
        public string? ControlNumber { get; set; }

        [Column("Certificate of Authority")]
        public string? CertificateOfAuthority { get; set; }

        [Column("ATTACHMENT", TypeName = "ntext")]
        public string? Attachment { get; set; }

        [Column("ModulatorModelcont2")]
        public string? ModulatorModelCont2 { get; set; }

        [Column("ModukatorSerioal2")]
        public string? ModukatorSerioal2 { get; set; }

        [Column("CombinerModel2")]
        public string? CombinerModel2 { get; set; }

        [Column("CombinerSerial2")]
        public string? CombinerSerial2 { get; set; }

        [Column("ModulatorSerial3")]
        public string? ModulatorSerial3 { get; set; }

        [Column("Field1")]
        public string? Field1 { get; set; }

        [Column("MTRCB PERMIT NO")]
        public string? MtrcbPermitNo { get; set; }

        [Column("MAYOR'S PERMIT NO")]
        public string? MayorsPermitNo { get; set; }

        [Column("ATTACHMENT1")]
        public string? Attachment1 { get; set; }

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

        [Column("ReceiverSerial2")]
        public string? ReceiverSerial2 { get; set; }

        [Column("SatelliteOther")]
        public string? SatelliteOther { get; set; }

        [Column("ReceivedFreqOthers")]
        public string? ReceivedFreqOthers { get; set; }

        [Column("ReceivedFreqOthers2")]
        public string? ReceivedFreqOthers2 { get; set; }

        [Column("ReceivedFreqOthers3")]
        public string? ReceivedFreqOthers3 { get; set; }

        [Column("ReceiverSerial3")]
        public string? ReceiverSerial3 { get; set; }

        [Column("LNASerial")]
        public string? LnaSerial { get; set; }

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