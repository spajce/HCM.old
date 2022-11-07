using HCM.Models.Base;

namespace HCM.Common.Models.Payrolls
{
    public class PayrollScheduleModel : BaseModel
    {
        public bool? AllowOverlapDate { get; set; }
        public bool? Default { get; set; }
    }
}