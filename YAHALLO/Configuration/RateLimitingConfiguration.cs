//AI generated
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

namespace YAHALLO.Configuration
{
    public static class RateLimitingConfiguration
    {
        public const string AuthPolicy = "auth";
        public const string GlobalPolicy = "global";

        public static IServiceCollection ConfigureRateLimiting(this IServiceCollection services)
        {
            services.AddRateLimiter(options =>
            {
                // Auth endpoints: max 10 requests per minute per IP
                options.AddFixedWindowLimiter(AuthPolicy, opt =>
                {
                    opt.PermitLimit = 10;
                    opt.Window = TimeSpan.FromMinutes(1);
                    opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                    opt.QueueLimit = 2;
                });

                // Global sliding window: 100 req/min per IP
                options.AddSlidingWindowLimiter(GlobalPolicy, opt =>
                {
                    opt.PermitLimit = 100;
                    opt.Window = TimeSpan.FromMinutes(1);
                    opt.SegmentsPerWindow = 6;
                    opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                    opt.QueueLimit = 10;
                });

                options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
            });

            return services;
        }
    }
}
