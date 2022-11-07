using System;
using System.Collections.Generic;

namespace HCM.Domain.Entities
{
    public partial class PhilHealth
    {
        public PhilHealth()
        {
            PhilHealthDetails = new HashSet<PhilHealthDetail>();
        }

        public int IdPhilHealth { get; set; }
        public string? PhilHealthName { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<PhilHealthDetail> PhilHealthDetails { get; set; }
    }
}
