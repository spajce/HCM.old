using System;
using HCM.Domain.DTOs;

namespace HCM.Domain.DTOs
{
    public partial class EmployeePaymentDto
    {
        public int IdEmployeePayment { get; set; }
        public int? DocNum { get; set; }
        public DateOnly? DocDate { get; set; }
        public DateOnly? ReleasedDate { get; set; }
        public DateOnly? EffectiveDate { get; set; }
        public string? PayrollSchedule { get; set; }
        public decimal? PrincipalAmount { get; set; }
        public decimal? PaymentAmount { get; set; }
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
        public bool? IncludeToYearEndPay { get; set; }
        public PaymentParticularDto? IdPaymentParticularNavigation { get; set; }
    }
}