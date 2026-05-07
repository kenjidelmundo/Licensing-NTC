using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicensingAPI.Entities
{
    [Table("accessMarineSL", Schema = "dbo")]
    public class AccessMarineSL
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("Serial")]
        public int? Serial { get; set; }

        [Column("Issued")]
        public DateTime? Issued { get; set; }

        [Column("Encoded by")]
        public string? EncodedBy { get; set; }

        [Column("Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Column("Old License No")]
        public string? OldLicenseNo { get; set; }

        [Column("New Licence No")]
        public string? NewLicenceNo { get; set; }

        [Column("Validity From")]
        public DateTime? ValidityFrom { get; set; }

        [Column("Validity To")]
        public DateTime? ValidityTo { get; set; }

        [Column("Name of Ship")]
        public string? NameOfShip { get; set; }

        [Column("Call Sign")]
        public string? CallSign { get; set; }

        [Column("Owner")]
        public string? Owner { get; set; }

        [Column("Public Correspondence")]
        public string? PublicCorrespondence { get; set; }

        [Column("MTX Freq Band")]
        public string? MtxFreqBand { get; set; }

        [Column("MTX type make model")]
        public string? MtxTypeMakeModel { get; set; }

        [Column("MTX Serial Number")]
        public string? MtxSerialNumber { get; set; }

        [Column("MTX Range")]
        public string? MtxRange { get; set; }

        [Column("MTX Power")]
        public int? MtxPower { get; set; }

        [Column("MTX Class of Emission")]
        public string? MtxClassOfEmission { get; set; }

        [Column("MTX Assigned Freq")]
        public string? MtxAssignedFreq { get; set; }

        [Column("ETX Freq Band")]
        public string? EtxFreqBand { get; set; }

        [Column("ETX type make model")]
        public string? EtxTypeMakeModel { get; set; }

        [Column("ETX Serial Number")]
        public string? EtxSerialNumber { get; set; }

        [Column("ETX Range")]
        public string? EtxRange { get; set; }

        [Column("ETX Power")]
        public int? EtxPower { get; set; }

        [Column("ETX Class of Emission")]
        public string? EtxClassOfEmission { get; set; }

        [Column("ETX Assigned Freq")]
        public string? EtxAssignedFreq { get; set; }

        [Column("SCTX Freq Band")]
        public string? SctxFreqBand { get; set; }

        [Column("SCTX type make model")]
        public string? SctxTypeMakeModel { get; set; }

        [Column("SCTX  Serial No")]
        public string? SctxSerialNo { get; set; }

        [Column("Tranceiver")]
        public string? Tranceiver { get; set; }

        [Column("Receivers")]
        public string? Receivers { get; set; }

        [Column("Auto Alarm")]
        public string? AutoAlarm { get; set; }

        [Column("RDF")]
        public string? Rdf { get; set; }

        [Column("Radar")]
        public string? Radar { get; set; }

        [Column("Official Reciept")]
        public int? OfficialReciept { get; set; }

        [Column("Regional Director")]
        public string? RegionalDirector { get; set; }

        [Column("Radio Operator")]
        public string? RadioOperator { get; set; }

        [Column("Operator License")]
        public string? OperatorLicense { get; set; }

        [Column("Operator Expiry Date")]
        public DateTime? OperatorExpiryDate { get; set; }

        [Column("Date Received")]
        public DateTime? DateReceived { get; set; }

        [Column("Remarks")]
        public string? Remarks { get; set; }

        [Column("Class")]
        public string? Class { get; set; }

        [Column("Type")]
        public string? Type { get; set; }

        [Column("AAIC")]
        public string? Aaic { get; set; }

        [Column("Port Registry")]
        public string? PortRegistry { get; set; }

        [Column("Gross", TypeName = "numeric(18,2)")]
        public decimal? Gross { get; set; }

        [Column("Keel")]
        public int? Keel { get; set; }

        [Column("Marine Reg")]
        public string? MarineReg { get; set; }

        [Column("Amount")]
        public int? Amount { get; set; }

        [Column("Date paid")]
        public DateTime? DatePaid { get; set; }

        [Column("Control Number")]
        public string? ControlNumber { get; set; }

        [Column("Service")]
        public string? Service { get; set; }

        [Column("Homeport")]
        public string? Homeport { get; set; }

        [Column("Calling Frequency SSB")]
        public string? CallingFrequencySsb { get; set; }

        [Column("Calling Frequency VHF")]
        public string? CallingFrequencyVhf { get; set; }

        [Column("MMSI NO")]
        public string? MmsiNo { get; set; }

        [Column("Encoder")]
        public string? Encoder { get; set; }

        [Column("OLD CONTROL NUMBER")]
        public string? OldControlNumber { get; set; }

        [Column("OLD ISSUED")]
        public DateTime? OldIssued { get; set; }

        [Column("MODIFICATION REMARKS")]
        public string? ModificationRemarks { get; set; }

        [Column("Remarks2")]
        public string? Remarks2 { get; set; }

        [Column("Source")]
        public string? Source { get; set; }

        [Column("OurceAddress")]
        public string? OurceAddress { get; set; }

        [Column("PermitToPurchase")]
        public string? PermitToPurchase { get; set; }

        [Column("DateOfPPR")]
        public DateTime? DateOfPPR { get; set; }

        [Column("Former Name")]
        public string? FormerName { get; set; }

        [Timestamp]
        [Column("RowVer")]
        public byte[] RowVer { get; set; } = Array.Empty<byte>();
    }
}