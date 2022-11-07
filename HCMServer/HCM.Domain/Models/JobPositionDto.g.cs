using System.Collections.Generic;
using HCM.Domain.DTOs;

namespace HCM.Domain.DTOs
{
    public partial class JobPositionDto
    {
        public int IdJobPosition { get; set; }
        public string? JobPositionName { get; set; }
        public bool? AllowNonJobTimetable { get; set; }
        public string? Description { get; set; }
        public ICollection<JobCompensationLevelDto> JobCompensationLevels { get; set; }
        public ICollection<JobPositionParentDto> JobPositionParents { get; set; }
    }
}