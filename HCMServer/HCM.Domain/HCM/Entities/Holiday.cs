using System;
using System.Collections.Generic;

namespace HCM.Domain.Entities
{
    public partial class Holiday
    {
        public int IdHoliday { get; set; }
        public DateOnly? HolidayDate { get; set; }
        public int? IdHolidayPreset { get; set; }
        public int? IdHolidayType { get; set; }

        public virtual HolidayPreset? IdHolidayPresetNavigation { get; set; }
        public virtual HolidayType? IdHolidayTypeNavigation { get; set; }
    }
}
