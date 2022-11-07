using HCM.Domain.DTOs;

namespace HCM.Domain.DTOs
{
    public partial class TimetableHolidayDto
    {
        public int IdTimetableHoliday { get; set; }
        public int? IdTimetable { get; set; }
        public int? IdHolidayPreset { get; set; }
        public HolidayPresetDto? IdHolidayPresetNavigation { get; set; }
        public TimetableDto? IdTimetableNavigation { get; set; }
    }
}