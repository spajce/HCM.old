using HCM.Models.Base;

namespace HCM.Common.Models.Jobs
{
    public partial class JobPositionParentModel : BaseModel
    {
        public int? IdJobPosition { get; set; }
        public string Description { get; set; }
    }
}