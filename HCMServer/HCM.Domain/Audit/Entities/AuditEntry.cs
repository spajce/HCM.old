using System;
using System.Collections.Generic;

#nullable disable

namespace Audit.Domain.Entities
{
    public partial class AuditEntry
    {
        public AuditEntry()
        {
            AuditentryProperties = new HashSet<AuditEntryProperty>();
        }

        public int AuditEntryId { get; set; }
        public string EntitySetName { get; set; }
        public string EntityTypeName { get; set; }
        public int? State { get; set; }
        public string StateName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<AuditEntryProperty> AuditentryProperties { get; set; }
    }
}
