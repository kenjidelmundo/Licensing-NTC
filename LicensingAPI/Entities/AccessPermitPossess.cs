using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicensingAPI.Entities
{
    [Table("accessPermitPossess", Schema = "dbo")]
    public class AccessPermitPossess
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("PERMIT NO")]
        public string? PermitNo { get; set; }

        [Column("APPLICANT")]
        public string? Applicant { get; set; }

        [Column("ADDRESS")]
        public string? Address { get; set; }

        [Column("MAKE/MODEL/TYPE 1")]
        public string? MakeModelType1 { get; set; }

        [Column("MAKE/MODEL/TYPE 2")]
        public string? MakeModelType2 { get; set; }

        [Column("MAKE/MODEL/TYPE 3")]
        public string? MakeModelType3 { get; set; }

        [Column("MAKE/MODEL/TYPE 4")]
        public string? MakeModelType4 { get; set; }

        [Column("MAKE/MODEL/TYPE 5")]
        public string? MakeModelType5 { get; set; }

        [Column("MAKE/MODEL/TYPE 6")]
        public string? MakeModelType6 { get; set; }

        [Column("MAKE/MODEL/TYPE 7")]
        public string? MakeModelType7 { get; set; }

        [Column("MAKE/MODEL/TYPE 8")]
        public string? MakeModelType8 { get; set; }

        [Column("MAKE/MODEL/TYPE 9")]
        public string? MakeModelType9 { get; set; }

        [Column("MAKE/MODEL/TYPE 10")]
        public string? MakeModelType10 { get; set; }

        [Column("No Of Units")]
        public string? NoOfUnits { get; set; }

        [Column("FX")]
        public int? Fx { get; set; }

        [Column("FB")]
        public int? Fb { get; set; }

        [Column("FX and FB")]
        public int? FxAndFb { get; set; }

        [Column("ML")]
        public int? Ml { get; set; }

        [Column("P")]
        public int? P { get; set; }

        [Column("Repeater")]
        public int? Repeater { get; set; }

        [Column("Serial 1")]
        public string? Serial1 { get; set; }

        [Column("Serial 2")]
        public string? Serial2 { get; set; }

        [Column("Serial 3")]
        public string? Serial3 { get; set; }

        [Column("Serial 4")]
        public string? Serial4 { get; set; }

        [Column("Serial 5")]
        public string? Serial5 { get; set; }

        [Column("Serial 6")]
        public string? Serial6 { get; set; }

        [Column("Serial 7")]
        public string? Serial7 { get; set; }

        [Column("Serial 8")]
        public string? Serial8 { get; set; }

        [Column("Serial 9")]
        public string? Serial9 { get; set; }

        [Column("Serial 10")]
        public string? Serial10 { get; set; }

        [Column("Serial 11")]
        public string? Serial11 { get; set; }

        [Column("Serial 12")]
        public string? Serial12 { get; set; }

        [Column("Serial 13")]
        public string? Serial13 { get; set; }

        [Column("Serial 14")]
        public string? Serial14 { get; set; }

        [Column("Serial 15")]
        public string? Serial15 { get; set; }

        [Column("Serial 16")]
        public string? Serial16 { get; set; }

        [Column("Serial 17")]
        public string? Serial17 { get; set; }

        [Column("Serial 18")]
        public string? Serial18 { get; set; }

        [Column("Serial 19")]
        public string? Serial19 { get; set; }

        [Column("Serial 20")]
        public string? Serial20 { get; set; }

        [Column("Serial 21")]
        public string? Serial21 { get; set; }

        [Column("Serial 22")]
        public string? Serial22 { get; set; }

        [Column("Serial 23")]
        public string? Serial23 { get; set; }

        [Column("Serial 24")]
        public string? Serial24 { get; set; }

        [Column("Frequency Range")]
        public string? FrequencyRange { get; set; }

        [Column("RF Power Output")]
        public string? RfPowerOutput { get; set; }

        [Column("Source of Equipment")]
        public string? SourceOfEquipment { get; set; }

        [Column("Address of Source")]
        public string? AddressOfSource { get; set; }

        [Column("Permit to Purchase/Registration No")]
        public string? PermitToPurchaseRegistrationNo { get; set; }

        [Column("Place of Storage")]
        public string? PlaceOfStorage { get; set; }

        [Column("Intended")]
        public string? Intended { get; set; }

        [Column("Date Processed")]
        public DateTime? DateProcessed { get; set; }

        [Column("PossessFee", TypeName = "money")]
        public decimal? PossessFee { get; set; }

        [Column("Official Receipt", TypeName = "decimal(18,0)")]
        public decimal? OfficialReceipt { get; set; }

        [Column("Date")]
        public DateTime? Date { get; set; }

        [Column("Encoded")]
        public string? Encoded { get; set; }

        [Column("Approving Officer")]
        public string? ApprovingOfficer { get; set; }

        [Column("FillingFee", TypeName = "money")]
        public decimal? FillingFee { get; set; }

        [Column("DocStamp", TypeName = "money")]
        public decimal? DocStamp { get; set; }

        [Column("TotalAmount", TypeName = "money")]
        public decimal? TotalAmount { get; set; }

        [Column("TotalPossessFee", TypeName = "money")]
        public decimal? TotalPossessFee { get; set; }

        [Column("CityMunicipality")]
        public string? CityMunicipality { get; set; }

        [Column("Province")]
        public string? Province { get; set; }

        [Column("CALL-SIGN")]
        public string? CallSign { get; set; }

        [Column("Serial 25")]
        public string? Serial25 { get; set; }

        [Column("UnitCount")]
        public int? UnitCount { get; set; }
    }
}