using System;
using System.Collections.Generic;

namespace HCM.Domain.Entities
{
    public partial class JobOvertimeDetail
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

        public virtual JobOvertime? IdJobOvertimeNavigation { get; set; }
    }
}
