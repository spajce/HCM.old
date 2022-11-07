using System;
using System.Collections.Generic;

namespace HCM.Domain.Entities
{
    public partial class EmployeeIncentiveLeave
    {
        public int IdEmployeeIncentiveLeave { get; set; }
        public int? IdEmployee { get; set; }
        public int? IdIncentiveLeaveType { get; set; }
        /// <summary>
        /// Alloted Days
        /// </summary>
        public double? Days { get; set; }
        public double? Used { get; set; }
        public double? PreviousUsed { get; set; }
        public double? PreviousRemaining { get; set; }

        public virtual IncentiveLeaveType? IdIncentiveLeaveTypeNavigation { get; set; }
    }
}
