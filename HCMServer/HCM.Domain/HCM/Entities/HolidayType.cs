using System;
using System.Collections.Generic;

namespace HCM.Domain.Entities
{
    public partial class HolidayType
    {
        public HolidayType()
        {
            Holidays = new HashSet<Holiday>();
        }

        public int IdHolidayType { get; set; }
        public string? HolidayTypeName { get; set; }

        public virtual ICollection<Holiday> Holidays { get; set; }
    }
}
