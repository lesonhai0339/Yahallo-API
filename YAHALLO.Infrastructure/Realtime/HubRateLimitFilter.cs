using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.RateLimiting;
using System.Threading.Tasks;

namespace YAHALLO.Infrastructure.Realtime
{
    public class HubRateLimitFilter: IHubFilter
    {
        private static readonly PartitionedRateLimiter<string> _limiter =
       PartitionedRateLimiter.Create<string, string>(userId =>
           RateLimitPartition.GetTokenBucketLimiter(userId, _ => new TokenBucketRateLimiterOptions
           {
               TokenLimit = 5,
               TokensPerPeriod = 1,
               ReplenishmentPeriod = TimeSpan.FromSeconds(30)
           }));

        public async ValueTask<object?> InvokeMethodAsync(
            HubInvocationContext ctx,
            Func<HubInvocationContext, ValueTask<object?>> next)
        {
            var key = ctx.Context.UserIdentifier ?? ctx.Context.ConnectionId;
            using var lease = await _limiter.AcquireAsync(key, 1);
            if (!lease.IsAcquired)
                throw new HubException("Rate limit exceeded");
            return await next(ctx);
        }
    }
}
