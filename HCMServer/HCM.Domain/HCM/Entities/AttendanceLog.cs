using System;
using System.Collections.Generic;

namespace HCM.Domain.Entities
{
    public partial class AttendanceLog
    {
        public Guid IdAttendanceLog { get; set; }
        public DateOnly? LogDate { get; set; }
        public TimeOnly? LogTime { get; set; }
        public DateTime? LogDateTime { get; set; }
        public string? LogStatus { get; set; }
        public string? LogType { get; set; }
        /// <summary>
        /// Biometric Id Num
        /// </summary>
        public int? DeviceIdNum { get; set; }
        public string? DeviceName { get; set; }
        public DateTime? CreateAt { get; set; }
        public string? CreateBy { get; set; }
        public int? IdAttendanceLogSource { get; set; }

        public virtual AttendanceLogSource? IdAttendanceLogSourceNavigation { get; set; }
    }
}
