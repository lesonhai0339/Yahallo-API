//AI generated
using dotenv.net;
using Hangfire;
using Hangfire.SqlServer;
using Serilog;
using SixLabors.ImageSharp;
using YAHALLO.Application;
using YAHALLO.Application.Common.Caching;
using YAHALLO.Application.Services.MailService;
using YAHALLO.Configuration;
using YAHALLO.Filters;
using YAHALLO.Hubs;
using YAHALLO.Infrastructure;
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
            DotEnv.Load(new DotEnvOptions(ignoreExceptions: true, overwriteExistingVars: false));

            services.Configure<CacheSettings>(Configuration.GetSection(nameof(CacheSettings)));

            services.AddControllers(
                opt =>
                {
                    opt.Filters.Add<ExceptionFilter>();
                });
            services.AddApplication(Configuration);
            services.ConfigureApplicationSecurity(Configuration);
            services.ConfigureProblemDetails();
            services.ConfigureApiVersioning();
            services.Infrastructure(Configuration);
            services.ConfigureSwagger(Configuration);
            services.AddEmailService(Configuration);
            services.ConfigurationServiceDJ(Configuration);
            services.ConfigureRateLimiting();
            services.AddSignalR();

            //var hangfireConn = Environment.GetEnvironmentVariable("Cloud_Server");
            var hangfireConn = Environment.GetEnvironmentVariable("Server");
            Log.Information("Cloud_Server env var is {Status}", hangfireConn != null ? "SET" : "NULL");
            if (string.IsNullOrEmpty(hangfireConn))
                throw new InvalidOperationException("Cloud_Server environment variable is not set. Check ECS task definition.");
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
                options.AddPolicy("CorsPolicy",
                builder => builder.WithOrigins(
                        "https://www.yahallo.online",
                        "https://yahallo.online",
                        "http://localhost:4200",
                        "https://localhost:4200"
                    )
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
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseCors("CorsPolicy");
            app.UseSerilogRequestLogging();
            app.UseExceptionHandler();
            app.UseHttpsRedirection();
            app.UseRouting();
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
            app.UseSwashbuckle(Configuration);
        }
    }
}
