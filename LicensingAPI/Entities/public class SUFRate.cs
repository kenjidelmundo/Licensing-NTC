using System;
using System.ComponentModel.DataAnnotations;

namespace LicensingAPI.Entities
{
    public class SUFRate
    {
        [Key]
        public int SUFRateId { get; set; }

        public decimal Rate { get; set; }
        public DateTime? EffectiveDate { get; set; }
    }
}
