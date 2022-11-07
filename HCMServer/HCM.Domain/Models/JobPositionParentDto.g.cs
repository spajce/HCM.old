using HCM.Domain.DTOs;

namespace HCM.Domain.DTOs
{
    public partial class JobPositionParentDto
    {
        public int IdJobPositionParent { get; set; }
        public int? IdJobPosition { get; set; }
        public string? Description { get; set; }
        public JobPositionDto? IdJobPositionNavigation { get; set; }
    }
}