namespace HCM.Application.Common.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNotNull(this string value)
        {
            if (!string.IsNullOrEmpty(value))
                return true;
            if (!string.IsNullOrWhiteSpace(value))
                return true;
            return false;
        }
    }
}
