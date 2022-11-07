using System;
using System.Collections.Generic;

namespace HCM.Domain.Entities
{
    public partial class Timetable
    {
        public Timetable()
        {
            JobTimetables = new HashSet<JobTimetable>();
            TimetableDetails = new HashSet<TimetableDetail>();
            TimetableHolidays = new HashSet<TimetableHoliday>();
        }

        public int IdTimetable { get; set; }
        public string? TimetableName { get; set; }
        public int? LateDeductionStart { get; set; }
        public bool? LateDeductionActive { get; set; }
        /// <summary>
        /// Day Shift or Night Shift and so on
        /// </summary>
        public string? ShiftType { get; set; }

        public virtual ICollection<JobTimetable> JobTimetables { get; set; }
        public virtual ICollection<TimetableDetail> TimetableDetails { get; set; }
        public virtual ICollection<TimetableHoliday> TimetableHolidays { get; set; }
    }
}
