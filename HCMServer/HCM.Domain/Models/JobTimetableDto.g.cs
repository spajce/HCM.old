using System;
using HCM.Domain.DTOs;

namespace HCM.Domain.DTOs
{
    public partial class JobTimetableDto
    {
        public int IdJobTimetable { get; set; }
        public DateOnly? DateStart { get; set; }
        public DateOnly? DateEnd { get; set; }
        public DateTime? CreateAt { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string? UpdateBy { get; set; }
        public int? IdTimetable { get; set; }
        public int? IdJobTimetableGroup { get; set; }
        public JobTimetableGroupDto? IdJobTimetableGroupNavigation { get; set; }
        public TimetableDto? IdTimetableNavigation { get; set; }
    }
}