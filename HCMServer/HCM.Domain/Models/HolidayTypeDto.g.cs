using System.Collections.Generic;
using HCM.Domain.DTOs;

namespace HCM.Domain.DTOs
{
    public partial class HolidayTypeDto
    {
        public int IdHolidayType { get; set; }
        public string? HolidayTypeName { get; set; }
        public ICollection<HolidayDto> Holidays { get; set; }
    }
}