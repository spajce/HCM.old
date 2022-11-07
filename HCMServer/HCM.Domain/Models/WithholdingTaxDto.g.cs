using System.Collections.Generic;
using HCM.Domain.DTOs;

namespace HCM.Domain.DTOs
{
    public partial class WithholdingTaxDto
    {
        public int IdWithholdingTax { get; set; }
        public string? WithholdingTaxName { get; set; }
        public bool? Active { get; set; }
        public ICollection<WithholdingTaxDetailDto> WithholdingTaxDetails { get; set; }
    }
}