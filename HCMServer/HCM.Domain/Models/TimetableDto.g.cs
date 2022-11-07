using System.Collections.Generic;
using HCM.Domain.DTOs;

namespace HCM.Domain.DTOs
{
    public partial class TimetableDto
    {
        public int IdTimetable { get; set; }
        public string? TimetableName { get; set; }
        public int? LateDeductionStart { get; set; }
        public bool? LateDeductionActive { get; set; }
        public string? ShiftType { get; set; }
        public ICollection<JobTimetableDto> JobTimetables { get; set; }
        public ICollection<TimetableDetailDto> TimetableDetails { get; set; }
        public ICollection<TimetableHolidayDto> TimetableHolidays { get; set; }
    }
}