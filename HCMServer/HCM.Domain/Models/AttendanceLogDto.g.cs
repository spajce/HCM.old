using System;
using HCM.Domain.DTOs;

namespace HCM.Domain.DTOs
{
    public partial class AttendanceLogDto
    {
        public Guid IdAttendanceLog { get; set; }
        public DateOnly? LogDate { get; set; }
        public TimeOnly? LogTime { get; set; }
        public DateTime? LogDateTime { get; set; }
        public string? LogStatus { get; set; }
        public string? LogType { get; set; }
        public int? DeviceIdNum { get; set; }
        public string? DeviceName { get; set; }
        public DateTime? CreateAt { get; set; }
        public string? CreateBy { get; set; }
        public int? IdAttendanceLogSource { get; set; }
        public AttendanceLogSourceDto? IdAttendanceLogSourceNavigation { get; set; }
    }
}