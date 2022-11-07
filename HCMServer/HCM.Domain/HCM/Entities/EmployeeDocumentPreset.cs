using System;
using System.Collections.Generic;

namespace HCM.Domain.Entities
{
    public partial class EmployeeDocumentPreset
    {
        public EmployeeDocumentPreset()
        {
            EmployeeDocuments = new HashSet<EmployeeDocument>();
        }

        public int IdDocument { get; set; }
        public string? DocumentName { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<EmployeeDocument> EmployeeDocuments { get; set; }
    }
}
