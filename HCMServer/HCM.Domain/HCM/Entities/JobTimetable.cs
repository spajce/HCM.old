using System;
using System.Collections.Generic;

namespace HCM.Domain.Entities
{
    public partial class JobTimetable
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

        public virtual JobTimetableGroup? IdJobTimetableGroupNavigation { get; set; }
        public virtual Timetable? IdTimetableNavigation { get; set; }
    }
}
