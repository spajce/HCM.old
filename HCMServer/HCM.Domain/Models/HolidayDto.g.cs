using System;
using HCM.Domain.DTOs;

namespace HCM.Domain.DTOs
{
    public partial class HolidayDto
    {
        public int IdHoliday { get; set; }
        public DateOnly? HolidayDate { get; set; }
        public int? IdHolidayPreset { get; set; }
        public int? IdHolidayType { get; set; }
        public HolidayPresetDto? IdHolidayPresetNavigation { get; set; }
        public HolidayTypeDto? IdHolidayTypeNavigation { get; set; }
    }
}