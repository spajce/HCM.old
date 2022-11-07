using System;
using System.Collections.Generic;

namespace HCM.Domain.Entities
{
    public partial class JobTimetableGroup
    {
        public JobTimetableGroup()
        {
            JobTimetableEmployees = new HashSet<JobTimetableEmployee>();
            JobTimetables = new HashSet<JobTimetable>();
        }

        public int IdJobTimetableGroup { get; set; }
        public string? JobTimetableGroupName { get; set; }
        public bool? Default { get; set; }

        public virtual ICollection<JobTimetableEmployee> JobTimetableEmployees { get; set; }
        public virtual ICollection<JobTimetable> JobTimetables { get; set; }
    }
}
