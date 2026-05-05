// DTOs/AccessWDNDto.cs

namespace LicensingAPI.DTOs
{
    public class AccessWDNDto
    {
        public int ID { get; set; }
        public DateTime? Issued { get; set; }
        public string? PermitPre { get; set; }
        public string? PermitNo { get; set; }
        public string? PermitYear { get; set; }
        public string? LicenseStatus { get; set; }
        public string? NameOfCompany { get; set; }
        public string? Address { get; set; }
        public DateTime? Validity { get; set; }
        public string? Ece { get; set; }
        public string? OrNo { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Amount { get; set; }
        public string? ScanLicense { get; set; }
        public string? TypeOfService { get; set; }
        public string? IssuanceAddress { get; set; }
        public string? EngrAssigned { get; set; }
        public string? EngrLicense { get; set; }
        public DateTime? EngrLicenseValidity { get; set; }
        public string? NameOfTechnician { get; set; }
        public string? Remarks { get; set; }
        public DateTime? ValidFrom { get; set; }
        public string? OldPermitNo { get; set; }
        public string? Contact { get; set; }
        public string? Encoded { get; set; }
        public string? AccountableForm { get; set; }
        public string? DateInspected { get; set; }
        public string? InspectionMO { get; set; }
        public string? AdminCase { get; set; }
        public string? AdminCaseRemark { get; set; }
    }
}