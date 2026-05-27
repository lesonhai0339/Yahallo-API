//AI generated
using Hangfire.Dashboard;

namespace YAHALLO.Configuration
{
    public class HangfireLocalRequestFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            var httpContext = context.GetHttpContext();
            var ip = httpContext.Connection.RemoteIpAddress?.ToString();
            var isLocal = ip == "127.0.0.1" || ip == "::1";
            return isLocal || httpContext.User.IsInRole("Admin");
        }
    }
}
