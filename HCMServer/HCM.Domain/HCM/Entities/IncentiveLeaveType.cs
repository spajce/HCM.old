using System;
using System.Collections.Generic;

namespace HCM.Domain.Entities
{
    public partial class IncentiveLeaveType
    {
        public IncentiveLeaveType()
        {
            EmployeeIncentiveLeaves = new HashSet<EmployeeIncentiveLeave>();
        }

        public int IdIncentiveLeaveType { get; set; }
        public string? IncentiveLeaveTypeName { get; set; }
        /// <summary>
        /// Default Alloted Days
        /// </summary>
        public double? Days { get; set; }
        public int? MonthToAvail { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<EmployeeIncentiveLeave> EmployeeIncentiveLeaves { get; set; }
    }
}
