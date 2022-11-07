using System;
using System.Collections.Generic;

namespace HCM.Domain.Entities
{
    public partial class WithholdingTaxDetail
    {
        public int IdWithholdingTaxDetail { get; set; }
        public int? IdWithholdingTax { get; set; }

        public virtual WithholdingTax? IdWithholdingTaxNavigation { get; set; }
    }
}
