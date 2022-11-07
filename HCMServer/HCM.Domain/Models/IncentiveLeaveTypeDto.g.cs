using System.Collections.Generic;
using HCM.Domain.DTOs;

namespace HCM.Domain.DTOs
{
    public partial class IncentiveLeaveTypeDto
    {
        public int IdIncentiveLeaveType { get; set; }
        public string? IncentiveLeaveTypeName { get; set; }
        public double? Days { get; set; }
        public int? MonthToAvail { get; set; }
        public string? Description { get; set; }
        public ICollection<EmployeeIncentiveLeaveDto> EmployeeIncentiveLeaves { get; set; }
    }
}