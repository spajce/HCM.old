using System;
using System.Collections.Generic;

namespace HCM.Domain.Entities
{
    public partial class JobPositionParent
    {
        public int IdJobPositionParent { get; set; }
        public int? IdJobPosition { get; set; }
        public string? Description { get; set; }

        public virtual JobPosition? IdJobPositionNavigation { get; set; }
    }
}
