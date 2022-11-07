using System;
using System.Collections.Generic;

namespace HCM.Domain.Entities
{
    public partial class SssDetail
    {
        public int IdSssDetail { get; set; }
        public int? IdSssContribution { get; set; }

        public virtual Sss? IdSssContributionNavigation { get; set; }
    }
}
