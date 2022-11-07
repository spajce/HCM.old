using System.Collections.Generic;
using HCM.Domain.DTOs;

namespace HCM.Domain.DTOs
{
    public partial class JobTimetableGroupDto
    {
        public int IdJobTimetableGroup { get; set; }
        public string? JobTimetableGroupName { get; set; }
        public bool? Default { get; set; }
        public ICollection<JobTimetableEmployeeDto> JobTimetableEmployees { get; set; }
        public ICollection<JobTimetableDto> JobTimetables { get; set; }
    }
}