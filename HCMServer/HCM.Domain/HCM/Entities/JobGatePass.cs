using System;
using System.Collections.Generic;

namespace HCM.Domain.Entities
{
    public partial class JobGatePass
    {
        public JobGatePass()
        {
            JobGatePassDetails = new HashSet<JobGatePassDetail>();
        }

        public int IdJobGatePass { get; set; }
        public int? DocNum { get; set; }
        public DateOnly? DocDate { get; set; }
        public DateOnly? PostingDate { get; set; }
        public bool? GatePassType { get; set; }
        public string? Remarks { get; set; }
        public string? Equipements { get; set; }
        public string? AuthStatus { get; set; }
        public bool? AuthUpdated { get; set; }
        public int? AuthSignatureIdApproval { get; set; }
        public int? AuthSubmitted { get; set; }
        public DateTime? CreateAt { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string? UpdateBy { get; set; }
        public int? IdEmployee { get; set; }

        public virtual ICollection<JobGatePassDetail> JobGatePassDetails { get; set; }
    }
}
