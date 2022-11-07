using System.Collections.Generic;
using HCM.Domain.DTOs;

namespace HCM.Domain.DTOs
{
    public partial class HolidayPresetDto
    {
        public int IdHolidayPreset { get; set; }
        public string? HolidayPresetName { get; set; }
        public string? Description { get; set; }
        public ICollection<HolidayDto> Holidays { get; set; }
        public ICollection<TimetableHolidayDto> TimetableHolidays { get; set; }
    }
}