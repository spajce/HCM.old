using HCM.Models.Base;
using System.Collections.Generic;

namespace HCM.Common.Models.Jobs
{
    public class JobPositionModel : BaseModel
    {
        public bool? AllowNonJobTimetable { get; set; }
        public string Description { get; set; }
    }
}