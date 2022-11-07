using System;
using System.Collections.Generic;

namespace HCM.Domain.Entities
{
    public partial class JobCompensationLevel
    {
        public JobCompensationLevel()
        {
            EmployeeJobs = new HashSet<EmployeeJob>();
        }

        public int IdJobCompensationLevel { get; set; }
        public string? LevelName { get; set; }
        public decimal? BasePay { get; set; }
        /// <summary>
        /// Monthly, Daily / Weekly and Hourly still on research
        /// </summary>
        public string? BasePayType { get; set; }
        /// <summary>
        /// Works from Mondays to Saturdays: 313 days / Works from Mondays to Friday: 261 days
        /// </summary>
        public int? TotalWorkingDays { get; set; }
        public int? IdJobPosition { get; set; }

        public virtual JobPosition? IdJobPositionNavigation { get; set; }
        public virtual ICollection<EmployeeJob> EmployeeJobs { get; set; }
    }
}
