using System;
using System.Collections.Generic;

#nullable disable

namespace Audit.Domain.Entities
{
    public partial class AuditEntryProperty
    {
        public int AuditEntryPropertyId { get; set; }
        public int? AuditEntryId { get; set; }
        public string RelationName { get; set; }
        public string PropertyName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }

        public virtual AuditEntry AuditEntry { get; set; }
    }
}
