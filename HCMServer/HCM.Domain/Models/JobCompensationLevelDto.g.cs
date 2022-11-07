using System.Collections.Generic;
using HCM.Domain.DTOs;

namespace HCM.Domain.DTOs
{
    public partial class JobCompensationLevelDto
    {
        public int IdJobCompensationLevel { get; set; }
        public string? LevelName { get; set; }
        public decimal? BasePay { get; set; }
        public string? BasePayType { get; set; }
        public int? TotalWorkingDays { get; set; }
        public int? IdJobPosition { get; set; }
        public JobPositionDto? IdJobPositionNavigation { get; set; }
        public ICollection<EmployeeJobDto> EmployeeJobs { get; set; }
    }
}