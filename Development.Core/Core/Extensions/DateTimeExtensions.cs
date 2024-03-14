using System;

namespace Extensions.Web.Core.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool HasValue(this DateTime? dateTime)
        {
            return dateTime.HasValue && dateTime != DateTime.MinValue;
        }

        public static bool HasNoValue(this DateTime? dateTime)
        {
            return !HasValue(dateTime);
        }
    }
}
