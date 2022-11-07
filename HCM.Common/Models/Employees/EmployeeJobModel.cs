using System;
using HCM.Models.Base;

namespace HCM.Common.Models.Employees
{
    public class EmployeeJobModel : BaseModel
    {
        public DateTime? EffectiveDate { get; set; }
        public decimal? BasePay { get; set; }
        public string BasePayType { get; set; }
        public int? TotalWorkingDays { get; set; }
        public int? IdEmployee { get; set; }
        public int? IdJobPosition { get; set; }
        public int? IdJobCompensationLevel { get; set; }
    }
}