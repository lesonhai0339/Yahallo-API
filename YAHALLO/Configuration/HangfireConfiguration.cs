//AI generated
using Hangfire;
using MediatR;
using YAHALLO.Application.Queries.MangaQuery.GetHomepage;
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

            //reload homepage
            RecurringJob.AddOrUpdate<IMediator>(
            "homepage-cache-warmup",
            mediator => mediator.Send(new GetHomepageRequest(), CancellationToken.None),
            "*/1 * * * *");
            //* * * * *
            //│ │ │ │ │
            //│ │ │ │ └── Ngay trong tuan(date in week(0 - 6, 0 = Chu nhat)
            //│ │ │ └──── Thang(month)(1 - 12)
            //│ │ └────── Ngay trong thang(date in month)(1 - 31)
            //│ └──────── gio(hour)(0 - 23)
            //└────────── phut(minute)(0 - 59)



            // Register recurring jobs
            RecurringJob.AddOrUpdate<IBackgroundJobService>(
                "expire-subscriptions",
                svc => svc.ExpireSubscriptionsAsync(CancellationToken.None),
                Cron.Daily);

            RecurringJob.AddOrUpdate<IBackgroundJobService>(
                "cleanup-soft-deleted",
                svc => svc.CleanupSoftDeletedRecordsAsync(30, CancellationToken.None),
                Cron.Weekly);

            RecurringJob.AddOrUpdate<IBackgroundJobService>(
                "cleanup-expired-tokens",
                svc => svc.CleanupExpiredTokensAsync(CancellationToken.None),
                "0 3 * * *" );

            return app;
        }
    }
}
