using System;
using System.Collections.Generic;

namespace HCM.Domain.Entities
{
    public partial class EmployeePayment
    {
        public int IdEmployeePayment { get; set; }
        public int? DocNum { get; set; }
        public DateOnly? DocDate { get; set; }
        public DateOnly? ReleasedDate { get; set; }
        public DateOnly? EffectiveDate { get; set; }
        /// <summary>
        /// 1st Half / 2nd Half / Every Payroll (devide principal amount in to 2)
        /// </summary>
        public string? PayrollSchedule { get; set; }
        public decimal? PrincipalAmount { get; set; }
        public decimal? PaymentAmount { get; set; }
        /// <summary>
        /// Wouldbe as Payment Term (for information only)
        /// </summary>
        public string? PaymentTerm { get; set; }
        public string? Purpose { get; set; }
        public string? Remarks { get; set; }
        public int? IdEmployee { get; set; }
        public string? AuthStatus { get; set; }
        public bool? AuthUpdated { get; set; }
        public int? AuthSignatureIdApproval { get; set; }
        public bool? AuthSubmitted { get; set; }
        public DateTime? CreateAt { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string? UpdateBy { get; set; }
        public int? IdPaymentParticular { get; set; }
        /// <summary>
        /// mostly for Adjustment or Adjustment Salary
        /// </summary>
        public bool? IncludeToYearEndPay { get; set; }

        public virtual PaymentParticular? IdPaymentParticularNavigation { get; set; }
    }
}
