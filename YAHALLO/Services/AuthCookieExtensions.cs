using System.Runtime.CompilerServices;
using YAHALLO.Common;

namespace YAHALLO.Services
{
    public static class AuthCookieExtensions
    {
        public static void SetAuthCookie(this HttpResponse response, string access, string refresh, AuthCookieOptions cfg)
        {
            var baseOpts = new CookieOptions
            {
                HttpOnly = true,
                Secure = cfg.Secure,
                SameSite = Enum.Parse<SameSiteMode>(cfg.SameSite),
                Domain = cfg.Domain,
                Path = "/"
            };
            response.Cookies.Append("accessToken", access, new CookieOptions
            {
                HttpOnly = baseOpts.HttpOnly,
                Secure = baseOpts.Secure,
                SameSite = baseOpts.SameSite,
                Domain = baseOpts.Domain,
                Path = baseOpts.Path,
                Expires = DateTimeOffset.UtcNow.AddDays(1),
            });
            response.Cookies.Append("refreshToken", access, new CookieOptions
            {
                HttpOnly = baseOpts.HttpOnly,
                Secure = baseOpts.Secure,
                SameSite = baseOpts.SameSite,
                Domain = baseOpts.Domain,
                Path = baseOpts.Path,
                Expires = DateTimeOffset.UtcNow.AddDays(7),
            });
        }
    }
}
