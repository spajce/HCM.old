using System;
using System.Collections.Generic;

namespace HCM.Domain.Entities
{
    public partial class PaymentParticular
    {
        public PaymentParticular()
        {
            EmployeePayments = new HashSet<EmployeePayment>();
        }

        public int IdPaymentParticular { get; set; }
        /// <summary>
        /// Ex. Adjustment / Advance / Benefit / Bonus / Miscellanos / Vacation Pay / Due Charges / and any Loans and Goverment Loans / Allowance
        /// </summary>
        public string? ParticularName { get; set; }
        public string? Description { get; set; }
        /// <summary>
        /// Debit or Credit
        /// </summary>
        public string? AccountType { get; set; }
        /// <summary>
        /// Related to Accounting
        /// </summary>
        public string? AccountCode { get; set; }
        /// <summary>
        /// Order By
        /// </summary>
        public int? Position { get; set; }

        public virtual ICollection<EmployeePayment> EmployeePayments { get; set; }
    }
}
