namespace HCM.Application.Common.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Convert the DateOnly to DateTime
        /// Workaround for DateOnly: Missing type map configuration or unsupported mapping of AutoMapper
        /// </summary>
        /// <param name="dateOnly"></param>
        /// <returns></returns>
        public static DateTime? ToDateTime(this DateOnly? dateOnly)
        {
            return dateOnly?.ToDateTime(TimeOnly.MinValue);
        }

        public static DateOnly? ToDateOnly(this DateTime? dateTime)
        {
            if (dateTime == null)
                return null;
            return DateOnly.FromDateTime(dateTime.Value);
        }

        public static DateOnly ToDateOnly(this DateTime dateTime)
        {
            return DateOnly.FromDateTime(dateTime);
        }

        /// <summary>
        /// Convert the DateOnly to DateTime
        /// Workaround for DateOnly: Missing type map configuration or unsupported mapping of AutoMapper
        /// </summary>
        /// <param name="dateOnly"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this DateOnly dateOnly)
        {
            return dateOnly.ToDateTime(TimeOnly.MinValue);
        }

        public static TimeSpan? ToTimeSpan(this TimeOnly? timeOnly)
        {
            return timeOnly?.ToTimeSpan();
        }
    }
}
