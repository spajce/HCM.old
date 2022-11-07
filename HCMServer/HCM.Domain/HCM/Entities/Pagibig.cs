using System;
using System.Collections.Generic;

namespace HCM.Domain.Entities
{
    public partial class Pagibig
    {
        public Pagibig()
        {
            PagibigDetails = new HashSet<PagibigDetail>();
        }

        public int IdPagibig { get; set; }
        public string? PagibigName { get; set; }
        public string? Active { get; set; }

        public virtual ICollection<PagibigDetail> PagibigDetails { get; set; }
    }
}
