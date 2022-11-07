using System;
using System.Collections.Generic;

namespace HCM.Domain.Entities
{
    public partial class JobOvertime
    {
        public JobOvertime()
        {
            JobOvertimeDetails = new HashSet<JobOvertimeDetail>();
        }

        public int IdJobOvertime { get; set; }
        public int? DocNum { get; set; }
        public DateOnly? DocDate { get; set; }
        public DateOnly? PostingDate { get; set; }
        /// <summary>
        /// Custom Payment Date: If has date, the date will be follow when to payment of overtime, note: the date must be between of payroll schedule dates
        /// </summary>
        public DateOnly? PaymentDate { get; set; }
        public string? Remarks { get; set; }
        public string? AuthStatus { get; set; }
        public bool? AuthUpdated { get; set; }
        public int? AuthSignatureIdApproval { get; set; }
        public int? AuthSubmitted { get; set; }
        public DateTime? CreateAt { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string? UpdateBy { get; set; }
        public int? IdEmployee { get; set; }

        public virtual ICollection<JobOvertimeDetail> JobOvertimeDetails { get; set; }
    }
}
