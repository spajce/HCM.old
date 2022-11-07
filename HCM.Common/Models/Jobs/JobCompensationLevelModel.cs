using HCM.Models.Base;
using System.Collections.Generic;

namespace HCM.Common.Models.Jobs
{
    public partial class JobCompensationLevelModel : BaseModel
    {
        public decimal BasePay { get; set; }
        public string BasePayType { get; set; }
        public int? TotalWorkingDays { get; set; }
        public int? IdJobPosition { get; set; }
    }
}