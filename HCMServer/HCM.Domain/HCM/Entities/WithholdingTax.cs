using System;
using System.Collections.Generic;

namespace HCM.Domain.Entities
{
    public partial class WithholdingTax
    {
        public WithholdingTax()
        {
            WithholdingTaxDetails = new HashSet<WithholdingTaxDetail>();
        }

        public int IdWithholdingTax { get; set; }
        public string? WithholdingTaxName { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<WithholdingTaxDetail> WithholdingTaxDetails { get; set; }
    }
}
