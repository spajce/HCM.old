using HCM.Models.Base;

namespace HCM.Common.Models.Payments
{
    public class PaymentParticularModel : BaseModel
    {
        public string Description { get; set; }
        public AccountType? AccountType { get; set; }
        public string AccountCode { get; set; }
        public int? Position { get; set; }
    }
}