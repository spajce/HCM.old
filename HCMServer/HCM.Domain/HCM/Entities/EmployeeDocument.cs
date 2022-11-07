using System;
using System.Collections.Generic;

namespace HCM.Domain.Entities
{
    public partial class EmployeeDocument
    {
        public int IdEmployeeDocument { get; set; }
        public int? IdEmployeeDocumentPreset { get; set; }
        public int? IdEmployee { get; set; }
        public string? Remarks { get; set; }
        public bool? Received { get; set; }
        public DateOnly? ReceivedDate { get; set; }
        public bool? Required { get; set; }

        public virtual EmployeeDocumentPreset? IdEmployeeDocumentPresetNavigation { get; set; }
    }
}
