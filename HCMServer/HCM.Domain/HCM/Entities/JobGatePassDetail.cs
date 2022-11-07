using System;
using System.Collections.Generic;

namespace HCM.Domain.Entities
{
    public partial class JobGatePassDetail
    {
        public int IdJobGatePassDetail { get; set; }
        public string? Particulars { get; set; }
        /// <summary>
        /// Time Out
        /// </summary>
        public DateTime? StartTime { get; set; }
        /// <summary>
        /// Time Return
        /// </summary>
        public DateTime? EndTime { get; set; }
        public Guid? IdAttendanceLogStart { get; set; }
        public Guid? IdAttendanceLogEnd { get; set; }
        public DateTime? CreateAt { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string? UpdateBy { get; set; }
        public int? IdJobGatePass { get; set; }

        public virtual JobGatePass? IdJobGatePassNavigation { get; set; }
    }
}
