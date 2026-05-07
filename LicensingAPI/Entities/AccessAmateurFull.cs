using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicensingAPI.Entities
{
    [Table("accessAmateurFull", Schema = "dbo")]
    public class AccessAmateurFull
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("TYPE")]
        public string? Type { get; set; }

        [Column("LICENSEE")]
        public string? Licensee { get; set; }

        [Column("REGISTRATION")]
        public string? Registration { get; set; }

        [Column("CALLSIGN")]
        public string? Callsign { get; set; }

        [Column("ADDRESS")]
        public string? Address { get; set; }

        [Column("FIRSTNAME")]
        public string? FirstName { get; set; }

        [Column("MIDDLENAME")]
        public string? MiddleName { get; set; }

        [Column("LASTNAME")]
        public string? LastName { get; set; }

        [Column("BIRTHDATE")]
        public DateTime? Birthdate { get; set; }

        [Column("HEIGHT")]
        public string? Height { get; set; }

        [Column("WEIGHT")]
        public string? Weight { get; set; }

        [Column("GENDER")]
        public string? Gender { get; set; }

        [Column("CITIZENSHIP")]
        public string? Citizenship { get; set; }

        [Column("EMPLOYER")]
        public string? Employer { get; set; }

        [Column("VALIDFROM")]
        public DateTime? ValidFrom { get; set; }

        [Column("VALIDUNTIL")]
        public DateTime? ValidUntil { get; set; }

        [Column("DATEISSUED")]
        public DateTime? DateIssued { get; set; }

        [Column("OFFICIALRECEIPT")]
        public int? OfficialReceipt { get; set; }

        [Column("AMOUNT", TypeName = "numeric(18,2)")]
        public decimal? Amount { get; set; }

        [Column("DATEPAID")]
        public DateTime? DatePaid { get; set; }

        [Column("ISSUEDBY")]
        public string? IssuedBy { get; set; }

        [Column("OFFICIALRECEIPT2")]
        public int? OfficialReceipt2 { get; set; }

        [Column("AMOUNT2")]
        public int? Amount2 { get; set; }

        [Column("DATEPAID2")]
        public DateTime? DatePaid2 { get; set; }

        [Column("ISSUEDBY2")]
        public int? IssuedBy2 { get; set; }

        [Column("OFFICIALRECEIPT3")]
        public int? OfficialReceipt3 { get; set; }

        [Column("AMOUNT3")]
        public int? Amount3 { get; set; }

        [Column("DATEPAID3")]
        public DateTime? DatePaid3 { get; set; }

        [Column("ISSUEDBY3")]
        public int? IssuedBy3 { get; set; }

        [Column("ADDRBRGY")]
        public string? AddrBrgy { get; set; }

        [Column("ADDRTOWN")]
        public string? AddrTown { get; set; }

        [Column("ADDRPROV")]
        public string? AddrProv { get; set; }

        [Column("STATIONBRGY")]
        public string? StationBrgy { get; set; }

        [Column("STATIONTOWN")]
        public string? StationTown { get; set; }

        [Column("STATIONPROV")]
        public string? StationProv { get; set; }

        [Column("REGIONALDIRECTOR")]
        public string? RegionalDirector { get; set; }

        [Column("STATUS")]
        public string? Status { get; set; }

        [Column("DATERECEIVED")]
        public DateTime? DateReceived { get; set; }

        [Column("RELEASEDATE")]
        public DateTime? ReleaseDate { get; set; }

        [Column("EXAMDATE")]
        public DateTime? ExamDate { get; set; }

        [Column("EXAMTAKEN")]
        public string? ExamTaken { get; set; }

        [Column("EXAMREMARK")]
        public string? ExamRemark { get; set; }

        [Column("ELEM2", TypeName = "numeric(18,2)")]
        public decimal? Elem2 { get; set; }

        [Column("ELEM3", TypeName = "numeric(18,2)")]
        public decimal? Elem3 { get; set; }

        [Column("ELEM4", TypeName = "numeric(18,2)")]
        public decimal? Elem4 { get; set; }

        [Column("ELEM5", TypeName = "numeric(18,2)")]
        public decimal? Elem5 { get; set; }

        [Column("ELEM6", TypeName = "numeric(18,2)")]
        public decimal? Elem6 { get; set; }

        [Column("ELEM7", TypeName = "numeric(18,2)")]
        public decimal? Elem7 { get; set; }

        [Column("AVE")]
        public string? Ave { get; set; }

        [Column("SERIAL", TypeName = "numeric(18,2)")]
        public decimal? Serial { get; set; }

        [Column("ENCODEDBY")]
        public string? EncodedBy { get; set; }

        [Column("CLASS")]
        public string? Class { get; set; }

        [Column("CALLSIGNLETTER")]
        public string? CallsignLetter { get; set; }

        [Column("AMATEURCLUB")]
        public string? AmateurClub { get; set; }

        [Column("MODIFICATION")]
        public string? Modification { get; set; }

        [Column("STATIONLOCATIONDETAILS")]
        public string? StationLocationDetails { get; set; }

        [Column("EQUIP1")]
        public string? Equip1 { get; set; }

        [Column("SERIAL1")]
        public string? Serial1 { get; set; }

        [Column("EQUIP2")]
        public string? Equip2 { get; set; }

        [Column("SERIAL2")]
        public string? Serial2 { get; set; }

        [Column("EQUIP3")]
        public string? Equip3 { get; set; }

        [Column("SERIAL3")]
        public string? Serial3 { get; set; }

        [Column("EQUIP4")]
        public string? Equip4 { get; set; }

        [Column("SERIAL4")]
        public string? Serial4 { get; set; }

        [Column("EQUIP5")]
        public string? Equip5 { get; set; }

        [Column("SERIAL5")]
        public string? Serial5 { get; set; }

        [Column("EQUIP6")]
        public string? Equip6 { get; set; }

        [Column("SERIAL6")]
        public string? Serial6 { get; set; }

        [Column("EQUIP7")]
        public string? Equip7 { get; set; }

        [Column("SERIAL7")]
        public string? Serial7 { get; set; }

        [Column("EQUIP8")]
        public string? Equip8 { get; set; }

        [Column("SERIAL8")]
        public string? Serial8 { get; set; }

        [Column("EQUIP9")]
        public string? Equip9 { get; set; }

        [Column("SERIAL9")]
        public string? Serial9 { get; set; }

        [Column("EQUIP10")]
        public string? Equip10 { get; set; }

        [Column("SERIAL10")]
        public string? Serial10 { get; set; }

        [Column("EQUIP11")]
        public string? Equip11 { get; set; }

        [Column("SERIAL11")]
        public string? Serial11 { get; set; }

        [Column("EQUIP12")]
        public string? Equip12 { get; set; }

        [Column("SERIAL12")]
        public string? Serial12 { get; set; }

        [Column("EQUIP13")]
        public string? Equip13 { get; set; }

        [Column("SERIAL13")]
        public string? Serial13 { get; set; }

        [Column("EQUIP14")]
        public string? Equip14 { get; set; }

        [Column("SERIAL14")]
        public string? Serial14 { get; set; }

        [Column("EQUIP15")]
        public string? Equip15 { get; set; }

        [Column("SERIAL15")]
        public string? Serial15 { get; set; }

        [Column("EQUIP16")]
        public string? Equip16 { get; set; }

        [Column("SERIAL16")]
        public string? Serial16 { get; set; }

        [Column("EQUIP17")]
        public string? Equip17 { get; set; }

        [Column("SERIAL17")]
        public string? Serial17 { get; set; }

        [Column("EQUIP18")]
        public string? Equip18 { get; set; }

        [Column("SERIAL18")]
        public string? Serial18 { get; set; }

        [Column("EQUIP19")]
        public string? Equip19 { get; set; }

        [Column("SERIAL19")]
        public string? Serial19 { get; set; }

        [Column("EQUIP20")]
        public string? Equip20 { get; set; }

        [Column("SERIAL20")]
        public string? Serial20 { get; set; }

        [Column("EQUIP21")]
        public string? Equip21 { get; set; }

        [Column("SERIAL21")]
        public string? Serial21 { get; set; }

        [Column("EQUIP22")]
        public string? Equip22 { get; set; }

        [Column("SERIAL22")]
        public string? Serial22 { get; set; }

        [Column("EQUIP23")]
        public string? Equip23 { get; set; }

        [Column("SERIAL23")]
        public string? Serial23 { get; set; }

        [Column("EQUIP24")]
        public string? Equip24 { get; set; }

        [Column("SERIAL24")]
        public string? Serial24 { get; set; }

        [Column("EQUIP25")]
        public string? Equip25 { get; set; }

        [Column("SERIAL25")]
        public string? Serial25 { get; set; }

        [Column("EQUIP26")]
        public string? Equip26 { get; set; }

        [Column("SERIAL26")]
        public string? Serial26 { get; set; }

        [Column("EQUIP27")]
        public string? Equip27 { get; set; }

        [Column("SERIAL27")]
        public string? Serial27 { get; set; }

        [Column("EQUIP28")]
        public string? Equip28 { get; set; }

        [Column("SERIAL28")]
        public string? Serial28 { get; set; }

        [Column("EQUIP29")]
        public string? Equip29 { get; set; }

        [Column("SERIAL29")]
        public string? Serial29 { get; set; }

        [Column("EQUIP30")]
        public string? Equip30 { get; set; }

        [Column("SERIAL30")]
        public string? Serial30 { get; set; }

        [Column("EQUIP31")]
        public string? Equip31 { get; set; }

        [Column("SERIAL31")]
        public string? Serial31 { get; set; }

        [Column("EQUIP32")]
        public string? Equip32 { get; set; }

        [Column("SERIAL32")]
        public string? Serial32 { get; set; }

        [Column("EQUIP33")]
        public string? Equip33 { get; set; }

        [Column("SERIAL33")]
        public string? Serial33 { get; set; }

        [Column("EQUIP34")]
        public string? Equip34 { get; set; }

        [Column("SERIAL34")]
        public string? Serial34 { get; set; }

        [Column("EQUIP35")]
        public string? Equip35 { get; set; }

        [Column("SERIAL35")]
        public string? Serial35 { get; set; }

        [Column("EQUIP36")]
        public string? Equip36 { get; set; }

        [Column("SERIAL36")]
        public string? Serial36 { get; set; }

        [Column("EQUIP37")]
        public string? Equip37 { get; set; }

        [Column("SERIAL37")]
        public string? Serial37 { get; set; }

        [Column("EQUIP38")]
        public string? Equip38 { get; set; }

        [Column("SERIAL38")]
        public string? Serial38 { get; set; }

        [Column("EQUIP39")]
        public string? Equip39 { get; set; }

        [Column("SERIAL39")]
        public string? Serial39 { get; set; }

        [Column("EQUIP40")]
        public string? Equip40 { get; set; }

        [Column("SERIAL40")]
        public string? Serial40 { get; set; }

        [Column("LAST MODIFIED")]
        [StringLength(10)]
        public string? LastModified { get; set; }

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