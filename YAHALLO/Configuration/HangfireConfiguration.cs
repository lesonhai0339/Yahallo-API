//AI generated
using Hangfire;
using YAHALLO.Infrastructure.Jobs;

namespace YAHALLO.Configuration
{
    public static class HangfireConfiguration
    {
        public static IApplicationBuilder UseHangfireJobs(this IApplicationBuilder app)
        {
            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                // Restrict dashboard to local requests in production
                Authorization = new[] { new HangfireLocalRequestFilter() }
            });

            // Register recurring jobs
            RecurringJob.AddOrUpdate<IBackgroundJobService>(
                "expire-subscriptions",
                svc => svc.ExpireSubscriptionsAsync(CancellationToken.None),
                Cron.Daily);

            RecurringJob.AddOrUpdate<IBackgroundJobService>(
                "cleanup-soft-deleted",
                svc => svc.CleanupSoftDeletedRecordsAsync(30, CancellationToken.None),
                Cron.Weekly);

            return app;
        }
    }
}
