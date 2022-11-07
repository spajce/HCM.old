using System;
using HCM.Domain.DTOs;

namespace HCM.Domain.DTOs
{
    public partial class PayrollScheduleDetailDto
    {
        public int IdPayrollScheduleDetail { get; set; }
        public DateOnly? DateStart { get; set; }
        public DateOnly? DateEnd { get; set; }
        public string? PayrollSchedule { get; set; }
        public int? IdPayrollSchedule { get; set; }
        public PayrollScheduleDto? IdPayrollScheduleNavigation { get; set; }
    }
}