using System;
using System.Collections.Generic;

namespace HCM.Domain.Entities
{
    public partial class TimetableHoliday
    {
        public int IdTimetableHoliday { get; set; }
        public int? IdTimetable { get; set; }
        public int? IdHolidayPreset { get; set; }

        public virtual HolidayPreset? IdHolidayPresetNavigation { get; set; }
        public virtual Timetable? IdTimetableNavigation { get; set; }
    }
}
