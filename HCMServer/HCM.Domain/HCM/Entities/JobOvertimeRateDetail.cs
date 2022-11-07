using System;
using System.Collections.Generic;

namespace HCM.Domain.Entities
{
    public partial class JobOvertimeRateDetail
    {
        public int IdJobOvertimeRateDetail { get; set; }
        public string? Code { get; set; }
        public string? OvertimeRateName { get; set; }
        public double? Rate { get; set; }
        public int? IdJobOvertimePreset { get; set; }

        public virtual JobOvertimePreset? IdJobOvertimePresetNavigation { get; set; }
    }
}
