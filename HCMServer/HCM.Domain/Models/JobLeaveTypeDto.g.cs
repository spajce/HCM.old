using System.Collections.Generic;
using HCM.Domain.DTOs;

namespace HCM.Domain.DTOs
{
    public partial class JobLeaveTypeDto
    {
        public int IdJobLeaveType { get; set; }
        public string? JobLeaveTypeName { get; set; }
        public ICollection<JobLeaveDto> JobLeaves { get; set; }
    }
}