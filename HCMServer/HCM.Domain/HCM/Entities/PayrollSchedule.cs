using System;
using System.Collections.Generic;

namespace HCM.Domain.Entities
{
    public partial class PayrollSchedule
    {
        public PayrollSchedule()
        {
            PayrollScheduleDetails = new HashSet<PayrollScheduleDetail>();
        }

        public int IdPayrollSchedule { get; set; }
        /// <summary>
        /// Year Name or other names
        /// </summary>
        public string? PayrollScheduleName { get; set; }
        public bool? AllowOverlapDate { get; set; }
        public bool? Default { get; set; }

        public virtual ICollection<PayrollScheduleDetail> PayrollScheduleDetails { get; set; }
    }
}
