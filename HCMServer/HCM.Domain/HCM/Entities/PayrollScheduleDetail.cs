using System;
using System.Collections.Generic;

namespace HCM.Domain.Entities
{
    public partial class PayrollScheduleDetail
    {
        public int IdPayrollScheduleDetail { get; set; }
        public DateOnly? DateStart { get; set; }
        public DateOnly? DateEnd { get; set; }
        /// <summary>
        /// 1st Half / 2nd Half and so on
        /// </summary>
        public string? PayrollSchedule { get; set; }
        public int? IdPayrollSchedule { get; set; }

        public virtual PayrollSchedule? IdPayrollScheduleNavigation { get; set; }
    }
}
