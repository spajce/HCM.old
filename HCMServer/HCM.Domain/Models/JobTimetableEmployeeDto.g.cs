using System;
using HCM.Domain.DTOs;

namespace HCM.Domain.DTOs
{
    public partial class JobTimetableEmployeeDto
    {
        public int IdJobTimetableEmployee { get; set; }
        public string? AuthStatus { get; set; }
        public bool? AuthUpdated { get; set; }
        public int? AuthSignatureIdApproval { get; set; }
        public bool? AuthSubmitted { get; set; }
        public int? IdEmployee { get; set; }
        public int? IdJobTimetableGroup { get; set; }
        public DateTime? CreateAt { get; set; }
        public string? CreateBy { get; set; }
        public JobTimetableGroupDto? IdJobTimetableGroupNavigation { get; set; }
    }
}