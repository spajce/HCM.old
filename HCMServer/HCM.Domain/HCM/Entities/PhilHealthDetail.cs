using System;
using System.Collections.Generic;

namespace HCM.Domain.Entities
{
    public partial class PhilHealthDetail
    {
        public int IdPhilHealthDetail { get; set; }
        public int? IdPhilHealth { get; set; }

        public virtual PhilHealth? IdPhilHealthNavigation { get; set; }
    }
}
