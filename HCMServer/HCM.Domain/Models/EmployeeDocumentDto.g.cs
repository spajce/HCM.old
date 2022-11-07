using System;
using HCM.Domain.DTOs;

namespace HCM.Domain.DTOs
{
    public partial class EmployeeDocumentDto
    {
        public int IdEmployeeDocument { get; set; }
        public int? IdEmployeeDocumentPreset { get; set; }
        public int? IdEmployee { get; set; }
        public string? Remarks { get; set; }
        public bool? Received { get; set; }
        public DateOnly? ReceivedDate { get; set; }
        public bool? Required { get; set; }
        public EmployeeDocumentPresetDto? IdEmployeeDocumentPresetNavigation { get; set; }
    }
}