using System;
using HCM.Domain.DTOs;

namespace HCM.Domain.DTOs
{
    public partial class JobOvertimeDetailDto
    {
        public int IdJobOvertimeDetail { get; set; }
        public int? IdJobOvertime { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string? Accomplishments { get; set; }
        public Guid? IdAttendanceLogStart { get; set; }
        public Guid? IdAttendanceLogEnd { get; set; }
        public DateTime? CreateAt { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string? UpdateBy { get; set; }
        public JobOvertimeDto? IdJobOvertimeNavigation { get; set; }
    }
}