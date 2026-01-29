namespace LicensingAPI.DTOs
{
    public class AccessSOAHeaderCreateDto
    {
        public DateTime? DateIssued { get; set; }
        public string? Licensee { get; set; }
        public string? Address { get; set; }
        public string? Particulars { get; set; }
        public string? PeriodCovered { get; set; }

        public string? SOASeries { get; set; }
        public string? ORNumber { get; set; }
        public DateTime? DatePaid { get; set; }
        public string? RemarksNote { get; set; }
    }
}
