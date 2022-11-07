using HCM.Domain.DTOs;

namespace HCM.Domain.DTOs
{
    public partial class JobOvertimeRateDetailDto
    {
        public int IdJobOvertimeRateDetail { get; set; }
        public string? Code { get; set; }
        public string? OvertimeRateName { get; set; }
        public double? Rate { get; set; }
        public int? IdJobOvertimePreset { get; set; }
        public JobOvertimePresetDto? IdJobOvertimePresetNavigation { get; set; }
    }
}