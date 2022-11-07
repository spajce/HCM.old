using System;
using System.Collections.Generic;

namespace HCM.Domain.Entities
{
    public partial class PagibigDetail
    {
        public int IdPagibigDetail { get; set; }
        public int? IdPagibig { get; set; }

        public virtual Pagibig? IdPagibigNavigation { get; set; }
    }
}
