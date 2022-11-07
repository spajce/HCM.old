using System;
using System.Collections.Generic;

namespace HCM.Domain.Entities
{
    public partial class AttendanceLogSource
    {
        public AttendanceLogSource()
        {
            AttendanceLogs = new HashSet<AttendanceLog>();
        }

        public int IdAttendanceLogSource { get; set; }
        /// <summary>
        /// Generated Name (Device Name) - (Generated Date and Time)
        /// </summary>
        public string? AttendanceLogSourceName { get; set; }
        public DateTime? CreateAt { get; set; }
        public string? CreateBy { get; set; }

        public virtual ICollection<AttendanceLog> AttendanceLogs { get; set; }
    }
}
