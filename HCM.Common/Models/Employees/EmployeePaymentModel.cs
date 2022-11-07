using HCM.Models.Base;
using System;

namespace HCM.Common.Models.Employees
{
    public class EmployeePaymentModel : BaseModel
    {
        public int? DocNum { get; set; }
        public DateTime? DocDate { get; set; }
        public DateTime? ReleasedDate { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public string PayrollSchedule { get; set; }
        public decimal? PrincipalAmount { get; set; }
        public decimal? PaymentAmount { get; set; }
        public string PaymentTerm { get; set; }
        public string Purpose { get; set; }
        public string Remarks { get; set; }
        public int? IdEmployee { get; set; }
        public string AuthStatus { get; set; }
        public bool? AuthUpdated { get; set; }
        public int? AuthSignatureIdApproval { get; set; }
        public bool? AuthSubmitted { get; set; }

        public int? IdPaymentParticular { get; set; }
        public bool? IncludeToYearEndPay { get; set; }
    }
}