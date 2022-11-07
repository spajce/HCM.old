using System;
using HCM.Domain.DTOs;

namespace HCM.Domain.DTOs
{
    public partial class JobLeaveDetailDto
    {
        public int IdJobLeaveDetail { get; set; }
        public int? IdJobLeave { get; set; }
        public DateOnly? LeaveDate { get; set; }
        public string? LeaveDayType { get; set; }
        public bool? Incentive { get; set; }
        public int? DayValue { get; set; }
        public double? WorkingHour { get; set; }
        public Guid? IdAttendanceLog { get; set; }
        public int? IdJobTimetable { get; set; }
        public DateTime? CreateAt { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string? UpdateBy { get; set; }
        public JobLeaveDto? IdJobLeaveNavigation { get; set; }
    }
}