using System;
using System.Collections.Generic;
using HCM.Domain.DTOs;

namespace HCM.Domain.DTOs
{
    public partial class AttendanceLogSourceDto
    {
        public int IdAttendanceLogSource { get; set; }
        public string? AttendanceLogSourceName { get; set; }
        public DateTime? CreateAt { get; set; }
        public string? CreateBy { get; set; }
        public ICollection<AttendanceLogDto> AttendanceLogs { get; set; }
    }
}