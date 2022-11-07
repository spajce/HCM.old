using System;
using HCM.Domain.DTOs;

namespace HCM.Domain.DTOs
{
    public partial class JobGatePassDetailDto
    {
        public int IdJobGatePassDetail { get; set; }
        public string? Particulars { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public Guid? IdAttendanceLogStart { get; set; }
        public Guid? IdAttendanceLogEnd { get; set; }
        public DateTime? CreateAt { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string? UpdateBy { get; set; }
        public int? IdJobGatePass { get; set; }
        public JobGatePassDto? IdJobGatePassNavigation { get; set; }
    }
}