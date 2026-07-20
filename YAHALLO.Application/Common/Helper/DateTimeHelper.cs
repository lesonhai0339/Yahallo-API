using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Application.Common.Helper
{
    public static class DateTimeHelper
    {
        public static double ResolveOffsetHours(string? timeZone, DateTimeOffset time)
        {
            try
            {
                if (!string.IsNullOrEmpty(timeZone) && TimeZoneInfo.TryFindSystemTimeZoneById(timeZone, out var result))
                    return result.GetUtcOffset(time.UtcDateTime).TotalHours;

                if (time.Offset != TimeSpan.Zero)
                    return time.Offset.TotalHours;

                return 0;
            }
            catch { return 0; } 
        }
    }
}
