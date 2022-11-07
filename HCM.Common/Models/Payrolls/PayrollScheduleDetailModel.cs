using HCM.Models.Base;
using System;

namespace HCM.Common.Models.Payrolls
{
    public class PayrollScheduleDetailModel : BaseModel
    {
        public int IdPayrollScheduleDetail { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public string PayrollSchedule { get; set; }
        public int? IdPayrollSchedule { get; set; }
    }
}