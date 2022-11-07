using HCM.Domain.DTOs;

namespace HCM.Domain.DTOs
{
    public partial class EmployeeIncentiveLeaveDto
    {
        public int IdEmployeeIncentiveLeave { get; set; }
        public int? IdEmployee { get; set; }
        public int? IdIncentiveLeaveType { get; set; }
        public double? Days { get; set; }
        public double? Used { get; set; }
        public double? PreviousUsed { get; set; }
        public double? PreviousRemaining { get; set; }
        public IncentiveLeaveTypeDto? IdIncentiveLeaveTypeNavigation { get; set; }
    }
}