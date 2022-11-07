using System.Collections.Generic;
using HCM.Domain.DTOs;

namespace HCM.Domain.DTOs
{
    public partial class PayrollScheduleDto
    {
        public int IdPayrollSchedule { get; set; }
        public string? PayrollScheduleName { get; set; }
        public bool? AllowOverlapDate { get; set; }
        public bool? Default { get; set; }
        public ICollection<PayrollScheduleDetailDto> PayrollScheduleDetails { get; set; }
    }
}