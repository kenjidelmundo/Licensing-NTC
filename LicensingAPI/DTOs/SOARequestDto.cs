using Licensing.Entities;
using System.Collections.Generic;

namespace LicensingAPI.DTOs
{
    public class SOARequestDto
    {
        public TechSOA SOA { get; set; } = new TechSOA();
        public List<TechSOADetails> Details { get; set; } = new List<TechSOADetails>();
    }
}
