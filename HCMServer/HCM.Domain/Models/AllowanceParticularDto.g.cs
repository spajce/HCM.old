using System.Collections.Generic;
using HCM.Domain.DTOs;

namespace HCM.Domain.DTOs
{
    public partial class AllowanceParticularDto
    {
        public int IdAllowanceParticular { get; set; }
        public string? ParticularName { get; set; }
        public string? Description { get; set; }
        public string? AccountType { get; set; }
        public string? AccountCode { get; set; }
        public int? Position { get; set; }
        public ICollection<EmployeeAllowanceDto> EmployeeAllowances { get; set; }
    }
}