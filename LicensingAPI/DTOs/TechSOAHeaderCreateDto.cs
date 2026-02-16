#nullable disable
using System;
using System.Text.Json.Serialization;

namespace LicensingAPI.DTOs
{
    public class TechSOAHeaderCreateDto
    {
        [JsonPropertyName("date")]
        public DateTime? DateIssued { get; set; }

        [JsonPropertyName("payeeName")]
        public string Licensee { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("particulars")]
        public string Particulars { get; set; }

        [JsonPropertyName("periodFrom")]
        public DateTime? PeriodFrom { get; set; }

        [JsonPropertyName("periodTo")]
        public DateTime? PeriodTo { get; set; }

        [JsonPropertyName("periodYears")]
        public int? PeriodYears { get; set; }
    }
}
