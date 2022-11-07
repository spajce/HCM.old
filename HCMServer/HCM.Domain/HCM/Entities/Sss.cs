using System;
using System.Collections.Generic;

namespace HCM.Domain.Entities
{
    public partial class Sss
    {
        public Sss()
        {
            SssDetails = new HashSet<SssDetail>();
        }

        public int IdSss { get; set; }
        public string? SssName { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<SssDetail> SssDetails { get; set; }
    }
}
