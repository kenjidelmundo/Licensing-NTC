using System;

namespace LicensingAPI.DTOs
{
    public class TechSOAHeaderCreateDto
    {
        public DateTime? DateIssued { get; set; }
        public string? Licensee { get; set; }
        public string? Address { get; set; }
        public string? Particulars { get; set; }

        public DateTime? PeriodFrom { get; set; }
        public DateTime? PeriodTo { get; set; }
        public int? PeriodYears { get; set; }
    }
}
