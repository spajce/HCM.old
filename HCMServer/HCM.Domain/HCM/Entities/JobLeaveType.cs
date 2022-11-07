using System;
using System.Collections.Generic;

namespace HCM.Domain.Entities
{
    public partial class JobLeaveType
    {
        public JobLeaveType()
        {
            JobLeaves = new HashSet<JobLeave>();
        }

        public int IdJobLeaveType { get; set; }
        public string? JobLeaveTypeName { get; set; }

        public virtual ICollection<JobLeave> JobLeaves { get; set; }
    }
}
