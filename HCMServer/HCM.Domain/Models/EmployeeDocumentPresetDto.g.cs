using System.Collections.Generic;
using HCM.Domain.DTOs;

namespace HCM.Domain.DTOs
{
    public partial class EmployeeDocumentPresetDto
    {
        public int IdDocument { get; set; }
        public string? DocumentName { get; set; }
        public string? Description { get; set; }
        public ICollection<EmployeeDocumentDto> EmployeeDocuments { get; set; }
    }
}