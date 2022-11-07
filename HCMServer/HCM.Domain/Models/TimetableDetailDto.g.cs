using System;
using HCM.Domain.DTOs;

namespace HCM.Domain.DTOs
{
    public partial class TimetableDetailDto
    {
        public int IdTimetableDetail { get; set; }
        public string? DayOfWeekName { get; set; }
        public int? DayOfWeekNum { get; set; }
        public DateTime? PunchInAmIntervalStart { get; set; }
        public DateTime? PunchInAmIntervalEnd { get; set; }
        public DateTime? PunchInAm { get; set; }
        public DateTime? PunchOutAmIntervalStart { get; set; }
        public DateTime? PunchOutAmIntervalEnd { get; set; }
        public DateTime? PunchOutAm { get; set; }
        public DateTime? PunchInPmIntervalStart { get; set; }
        public DateTime? PunchInPmIntervalEnd { get; set; }
        public DateTime? PunchInPm { get; set; }
        public DateTime? PunchOutPmIntervalStart { get; set; }
        public DateTime? PunchOutPmIntervalEnd { get; set; }
        public DateTime? PunchOutPm { get; set; }
        public DateTime? ShiftIntervalStart { get; set; }
        public DateTime? ShiftIntervalEnd { get; set; }
        public bool? RestDay { get; set; }
        public int? IdTimetable { get; set; }
        public TimetableDto? IdTimetableNavigation { get; set; }
    }
}