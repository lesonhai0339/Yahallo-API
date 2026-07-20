//AI generated
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.SignalR;
using Serilog;
using YAHALLO.Application;
using YAHALLO.Application.Common.Caching;
using YAHALLO.Application.Services.MailService;
using YAHALLO.Common;
using YAHALLO.Configuration;
using YAHALLO.Filters;
using YAHALLO.Infrastructure;
using YAHALLO.Infrastructure.Realtime;
using YAHALLO.Services;

namespace YAHALLO
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.Configure<CacheSettings>(Configuration.GetSection(nameof(CacheSettings)));
            services.Configure<AuthCookieOptions>(Configuration.GetSection("AuthCookie"));

            services.AddControllers(
                opt =>
                {
                    opt.ModelBinderProviders.Insert(0, new StrictDateTimeOffsetBinderProvider());
                    opt.Filters.Add<ExceptionFilter>();
                })
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new StrictDateTimeOffsetConverter());
                });
            services.AddApplication(Configuration);
            services.ConfigureApplicationSecurity(Configuration);
            services.ConfigureProblemDetails();
            services.ConfigureApiVersioning();
            services.Infrastructure(Configuration);
            services.ConfigureSwagger(Configuration);
            services.AddEmailService(Configuration);
            services.ConfigurationServiceDI(Configuration);
            services.ConfigureRateLimiting();
            services.AddSignalR(o => o.AddFilter<HubRateLimitFilter>());

            //var hangfireConn = Environment.GetEnvironmentVariable("Cloud_Server");
            var hangfireConn = Environment.GetEnvironmentVariable("Server");

            Log.Information("Hangfire connection env var [Server] is {Status}",
          string.IsNullOrEmpty(hangfireConn) ? "NULL" : "SET");

            if (string.IsNullOrEmpty(hangfireConn))
                throw new InvalidOperationException(
                    "Environment variable 'Server' is not set. Check ECS task definition.");

            services.AddHangfire(config => config
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(hangfireConn, new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    DisableGlobalLocks = true
                }));
            services.AddHangfireServer();
            services.AddCors(options =>
            {
                var origins = Configuration.GetSection("CORS:Origins").Get<string[]>()
                                ?? Array.Empty<string>();


                options.AddPolicy("CorsPolicy",
                builder => builder
                    .WithOrigins(origins)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                );
            });
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            services.ConfigureHealthChecks(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwashbuckle(Configuration);
                app.UseDeveloperExceptionPage();
            }
            app.UseExceptionHandler();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseSerilogRequestLogging();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseRateLimiter();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultHealthChecks();
                endpoints.MapControllers();
                endpoints.MapHub<NotificationHub>("/hubs/notification");
            });
            app.UseHangfireJobs();
        }
    }
}
