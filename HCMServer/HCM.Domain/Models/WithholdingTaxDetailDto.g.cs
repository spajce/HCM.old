using HCM.Domain.DTOs;

namespace HCM.Domain.DTOs
{
    public partial class WithholdingTaxDetailDto
    {
        public int IdWithholdingTaxDetail { get; set; }
        public int? IdWithholdingTax { get; set; }
        public WithholdingTaxDto? IdWithholdingTaxNavigation { get; set; }
    }
}