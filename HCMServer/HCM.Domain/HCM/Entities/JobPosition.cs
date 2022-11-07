using System;
using System.Collections.Generic;

namespace HCM.Domain.Entities
{
    public partial class JobPosition
    {
        public JobPosition()
        {
            JobCompensationLevels = new HashSet<JobCompensationLevel>();
            JobPositionParents = new HashSet<JobPositionParent>();
        }

        public int IdJobPosition { get; set; }
        public string? JobPositionName { get; set; }
        public bool? AllowNonJobTimetable { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<JobCompensationLevel> JobCompensationLevels { get; set; }
        public virtual ICollection<JobPositionParent> JobPositionParents { get; set; }
    }
}
