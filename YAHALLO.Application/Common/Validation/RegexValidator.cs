using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace YAHALLO.Application.Common.Validation
{
    public static class RegexValidator
    {
        private static readonly Regex IsoWithOffset = new Regex(
            @"^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}(\.\d{1,7})?(Zz|[+-]\d{2}:?\d{2})$",
            RegexOptions.Compiled);

        public static bool TryParseStrict(string input, out DateTimeOffset result)
        {
            result = default;
            if (string.IsNullOrEmpty(input) || !IsoWithOffset.IsMatch(input))
                return false;

            return DateTimeOffset.TryParse(input, CultureInfo.InvariantCulture, DateTimeStyles.None, out result );
        }
    }
}
