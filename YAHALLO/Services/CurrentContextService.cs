using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using YAHALLO.Application.Common.Interfaces;

namespace YAHALLO.Services
{
    public class CurrentContextService: ICurrentContextService
    {
        private readonly IHttpContextAccessor _httpContext;
        public CurrentContextService(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
        public string? CurrentHttpContext => _httpContext.HttpContext?.Request?.GetDisplayUrl();
        public string? HttpContext
        {
            get
            {
                var currentHttpContext = _httpContext.HttpContext;
                if (currentHttpContext != null)
                {
                    var scheme = currentHttpContext.Request.Scheme;
                    var host = currentHttpContext.Request.Host;
                    var port = host.Port.HasValue ? ":" + host.Port : "";
                    return $"{scheme}://{host.Host}{port}/";
                }
                return null;
            }
        }
    }
}
