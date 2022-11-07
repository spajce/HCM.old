using System.Collections.Generic;
using HCM.Domain.DTOs;

namespace HCM.Domain.DTOs
{
    public partial class PaymentParticularDto
    {
        public int IdPaymentParticular { get; set; }
        public string? ParticularName { get; set; }
        public string? Description { get; set; }
        public string? AccountType { get; set; }
        public string? AccountCode { get; set; }
        public int? Position { get; set; }
        public ICollection<EmployeePaymentDto> EmployeePayments { get; set; }
    }
}