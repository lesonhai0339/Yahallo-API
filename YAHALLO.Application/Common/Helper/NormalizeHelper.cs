using PhoneNumbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using YAHALLO.Application.Common.Exceptions;

namespace YAHALLO.Application.Common.Helper
{
    internal static class NormalizeHelper
    {
        internal static string NormalizeEmail(string email)
        {
            return email.Trim().ToLowerInvariant();
        }
        internal static string NormalizePhoneNumber(string phone, string region = "VN")
        {
            var util = PhoneNumberUtil.GetInstance();
            var parsed = util.Parse(phone, region);

            if (!util.IsValidNumber(parsed))
                throw new ValidationException("Số điện thoại không hợp lệ");

            string e164 = util.Format(parsed, PhoneNumberFormat.E164);
            return e164;
        }
    }
}
