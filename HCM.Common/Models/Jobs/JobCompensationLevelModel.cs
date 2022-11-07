using HCM.Models.Base;
using System.Collections.Generic;

namespace HCM.Common.Models.Jobs
{
    /// <summary>
    /// Preset of EmployeeJob Table
    /// </summary>
    public class JobCompensationLevelModel : BaseModel
    {
        public decimal BasePay { get; set; }
        public JobBasePayType? JobBasePayType { get; set; }
        public int? TotalWorkingDays { get; set; }
        public int? IdJobPosition { get; set; }
    }
}