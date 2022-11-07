using System;
using System.Collections.Generic;

namespace HCM.Domain.Entities
{
    public partial class JobOvertimePreset
    {
        public JobOvertimePreset()
        {
            JobOvertimeRateDetails = new HashSet<JobOvertimeRateDetail>();
        }

        public int IdJobOvertimePreset { get; set; }
        public string? JobOvertimePresetName { get; set; }
        public bool? Default { get; set; }

        public virtual ICollection<JobOvertimeRateDetail> JobOvertimeRateDetails { get; set; }
    }
}
