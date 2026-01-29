using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Licensing.Entities
{
    public class TechSurcharge
    {
        public decimal? surchargefee { get; set; }
    }

    public class TechFeesSurchargeRSL50
    {
        public decimal? surchargefee { get; set; }
    }

    public class TechFeesSurchargeRSL100
    {
        public decimal? surchargefee { get; set; }
    }
}
