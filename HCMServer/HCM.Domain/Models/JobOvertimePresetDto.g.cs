using System.Collections.Generic;
using HCM.Domain.DTOs;

namespace HCM.Domain.DTOs
{
    public partial class JobOvertimePresetDto
    {
        public int IdJobOvertimePreset { get; set; }
        public string? JobOvertimePresetName { get; set; }
        public bool? Default { get; set; }
        public ICollection<JobOvertimeRateDetailDto> JobOvertimeRateDetails { get; set; }
    }
}