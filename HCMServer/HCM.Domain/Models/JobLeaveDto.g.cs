using System;
using System.Collections.Generic;
using HCM.Domain.DTOs;

namespace HCM.Domain.DTOs
{
    public partial class JobLeaveDto
    {
        public int IdJobLeave { get; set; }
        public int? DocNum { get; set; }
        public DateOnly? DocDate { get; set; }
        public DateOnly? PostingDate { get; set; }
        public string? Reason { get; set; }
        public string? Remarks { get; set; }
        public string? AuthStatus { get; set; }
        public bool? AuthUpdated { get; set; }
        public int? AuthSignatureIdApproval { get; set; }
        public int? AuthSubmitted { get; set; }
        public DateTime? CreateAt { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string? UpdateBy { get; set; }
        public int? IdEmployee { get; set; }
        public int? IdJobLeaveType { get; set; }
        public int? IdEmployeeIncentiveLeave { get; set; }
        public JobLeaveTypeDto? IdJobLeaveTypeNavigation { get; set; }
        public ICollection<JobLeaveDetailDto> JobLeaveDetails { get; set; }
    }
}