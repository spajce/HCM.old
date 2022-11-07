using System;
using System.Collections.Generic;

namespace HCM.Domain.Entities
{
    public partial class HolidayPreset
    {
        public HolidayPreset()
        {
            Holidays = new HashSet<Holiday>();
            TimetableHolidays = new HashSet<TimetableHoliday>();
        }

        public int IdHolidayPreset { get; set; }
        public string? HolidayPresetName { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Holiday> Holidays { get; set; }
        public virtual ICollection<TimetableHoliday> TimetableHolidays { get; set; }
    }
}
