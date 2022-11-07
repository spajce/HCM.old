using HCM.Domain.DTOs;

namespace HCM.Domain.DTOs
{
    public partial class EmployeeAllowanceDto
    {
        public int IdEmployeeAllowance { get; set; }
        public string? Frequency { get; set; }
        public string? VariabilityType { get; set; }
        public bool? IsDoubleHoliday { get; set; }
        public bool? IsRegular { get; set; }
        public bool? IsRegularHoliday { get; set; }
        public bool? IsSpecialHoliday { get; set; }
        public string? Destination { get; set; }
        public int? IdEmployee { get; set; }
        public int? IdAllowanceParticular { get; set; }
        public AllowanceParticularDto? IdAllowanceParticularNavigation { get; set; }
    }
}