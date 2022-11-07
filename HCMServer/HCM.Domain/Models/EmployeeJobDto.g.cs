using System;
using HCM.Domain.DTOs;

namespace HCM.Domain.DTOs
{
    public partial class EmployeeJobDto
    {
        public int IdEmployeeJob { get; set; }
        public DateOnly? EffectiveDate { get; set; }
        public decimal? BasePay { get; set; }
        public string? BasePayType { get; set; }
        public int? TotalWorkingDays { get; set; }
        public int? IdEmployee { get; set; }
        public int? IdJobPosition { get; set; }
        public int? IdJobCompensationLevel { get; set; }
        public DateTime? CreateAt { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string? UpdateBy { get; set; }
        public JobCompensationLevelDto? IdJobCompensationLevelNavigation { get; set; }
    }
}