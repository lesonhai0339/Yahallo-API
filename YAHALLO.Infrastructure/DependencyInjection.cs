//AI generated
using Amazon.S3;
using dotenv.net;
using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.Serialization;
using Elastic.Transport;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using System.Text.Json.Serialization;
using YAHALLO.Application.Common.Interfaces;
using YAHALLO.Domain;
using YAHALLO.Domain.Functions;
using YAHALLO.Domain.Repositories;
using YAHALLO.Domain.Repositories.Cache;
using YAHALLO.Domain.Repositories.Elastic;
using YAHALLO.Domain.Repositories.Security;
using YAHALLO.Domain.Repositories.Storage;
using YAHALLO.Infrastructure.Data;
using YAHALLO.Infrastructure.Elastic.Repositories;
using YAHALLO.Infrastructure.Elastic1.Options;
using YAHALLO.Infrastructure.Elastic1.Repositories;
using YAHALLO.Infrastructure.Files.Functions;
using YAHALLO.Infrastructure.Jobs;
using YAHALLO.Infrastructure.Persistence.Repositories;
using YAHALLO.Infrastructure.Realtime;
using YAHALLO.Infrastructure.Redis;
using YAHALLO.Infrastructure.S3;
using YAHALLO.Infrastructure.Security;

namespace YAHALLO.Infrastructure
{
    public static class DependencyInjection
    {
        static void ConfigureOptions(JsonSerializerOptions o)
        {
            o.PropertyNamingPolicy = null;
            o.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
            o.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        }
        public static IServiceCollection Infrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            DotEnv.Load(new DotEnvOptions(ignoreExceptions: true, overwriteExistingVars: false));

            services.Configure<AwsS3Options>(configuration.GetSection(nameof(AwsS3Options)));

            //var sqlConnection = Environment.GetEnvironmentVariable("Cloud_Server");
            var sqlConnection = Environment.GetEnvironmentVariable("Server");
            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                options.UseSqlServer(
                    sqlConnection,
                    //configuration.GetConnectionString("Server"),
                    b =>
                    {
                        b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                        b.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                        b.EnableRetryOnFailure(
                            maxRetryCount: 5,
                            maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorNumbersToAdd: null);
                        b.CommandTimeout(30);
                    });
                options.UseLazyLoadingProxies(false);
            });
            //services.AddDbContextFactory<ApplicationDbContext>(options =>
            //{
            //    options.UseSqlServer(
            //       sqlConnection,
            //       b =>
            //       {
            //           b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
            //           b.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
            //           b.EnableRetryOnFailure(
            //               maxRetryCount: 5,
            //               maxRetryDelay: TimeSpan.FromSeconds(30),
            //               errorNumbersToAdd: null);
            //       });
            //    options.UseLazyLoadingProxies(false);
            //});


            services.Configure<IndexNameOptions>(opt =>
            {
                opt.IndexName = Environment.GetEnvironmentVariable("Elastic_DefaultIndex")!;
            });
            services.AddSingleton<ElasticsearchClient>(sp =>
            {
    
                var elasticUri = Environment.GetEnvironmentVariable("Elastic_Url") ?? "";
                var elasticApiKey = Environment.GetEnvironmentVariable("Elastic_Key") ?? "";
                var elasticIndex = Environment.GetEnvironmentVariable("Elastic_DefaultIndex") ?? "";

                var nodePool = new SingleNodePool(new Uri(elasticUri));
                var setting = new ElasticsearchClientSettings(nodePool,
                    sourceSerializer: (defaultSerializer, settings) =>
        new DefaultSourceSerializer(settings, ConfigureOptions))
                .Authentication(new ApiKey(elasticApiKey))
                .DefaultIndex(elasticIndex);
                
                return new ElasticsearchClient(setting);
            });

            //elastic
            services.AddSingleton(typeof(IElasticQueryBuilder<>), typeof(ElasticQueryBuilder<>));

            //security
            services.AddSingleton<IKeypairGenerate, KeypairGenerate>(sp =>
            {
                var ops = Environment.GetEnvironmentVariable("Encrypt_Context")!;
                return new KeypairGenerate(ops);
            });

            // S3 uses a DEDICATED IAM user (yahallo-storage) separate from the
            // ECS/ECR deploy user (ecr_ecs). Presigned URLs are signed with these
            // credentials, so this identity is the one that needs s3:PutObject.
            services.AddSingleton<IAmazonS3>(sp =>
            {
                var accessKey = Environment.GetEnvironmentVariable("S3_AccessKey");
                var secretKey = Environment.GetEnvironmentVariable("S3_SecretKey");
                var region = Environment.GetEnvironmentVariable("S3_Region")
                             ?? "ap-southeast-1";
                var regionEndpoint = Amazon.RegionEndpoint.GetBySystemName(region);

                // If dedicated S3 keys are provided, use them; otherwise fall back
                // to the default credential chain (local profile / task role).
                if (!string.IsNullOrEmpty(accessKey) && !string.IsNullOrEmpty(secretKey))
                {
                    var credentials = new Amazon.Runtime.BasicAWSCredentials(accessKey, secretKey);
                    return new AmazonS3Client(credentials, regionEndpoint);
                }

                return new AmazonS3Client(regionEndpoint);
            });
            services.AddTransient(typeof(IStorageService<>), typeof(AwsS3Service<>));

            services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<ApplicationDbContext>());
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();

            services.AddScoped<IMangaRepository, MangaRepository>();

            services.AddScoped<IChapterRepository, ChapterRepository>();
            services.AddScoped<IRatingRepository, RatingRepository>();

            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IArtistRepository, ArtistRepository>();
            services.AddScoped<IMangaArtistRepository, MangaArtistRepository>();
            services.AddScoped<IMangaAuthorRepository, MangaAuthorRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IFollowRepository, FollowRepository>();
            services.AddScoped<IMangaAssociateNameRepository, MangaAssociateNameRepository>();
            services.AddScoped<IMangaGroupRepository, MangaGroupRepository>();
            services.AddScoped<IUserTokenRepository, UserTokenRepository>();
            services.AddScoped<IAttechmentRepository, AttechmentRepository>();
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<IUserOldPasswordRepository, UserOldPasswordRepository>();
            services.AddScoped<IThreadRepository, ThreadRepository>();
            services.AddScoped<IThreadOfBlogRepository, ThreadOfBlogRepository>();
            services.AddScoped<IReactionRepository, ReactionRepository>();
            services.AddScoped<IViewCountRepository, ViewCountRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IEnums, Enums>();
            services.AddTransient(typeof(IFiles<>), typeof(Files<>));
            services.AddScoped<IFilters, Filters>();
            services.AddScoped<IMangaSearchRepository, MangaSearchRepository>();
            services.AddScoped<IUserBlacklistRepository, UserBlacklistRepository>();
            services.AddScoped<IUnTrustEmailRepository, UnTrustEmailRepository>();
            services.AddScoped<IUnTrustPhoneRepository, UnTrustPhoneRepository>();
            services.AddScoped<IPendingRegistrationRepository, PendingRegistrationRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IBookmarkRepository, BookmarkRepository>();
            services.AddScoped<IMangaDailyAnalyticsRepository, MangaDailyAnalyticsRepository>();
            services.AddScoped<IUserDailyActivityRepository, UserDailyActivityRepository>();
            services.AddScoped<IUserMangaDailyReadRepository, UserMangaDailyReadRepository>();
            services.AddScoped<IChapterImageRepository, ChapterImageRepository>();

            // AI generated — new repositories
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IMangaTagRepository, MangaTagRepository>();
            services.AddScoped<IReadingProgressRepository, ReadingProgressRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<IUserMangaViewRepository, UserMangaViewRepository>();
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
            services.AddScoped<IUserSettingsRepository, UserSettingsRepository>();

            // AI generated — Redis cache
            var redisConnection = Environment.GetEnvironmentVariable("Redis_Connection");
            if (!string.IsNullOrEmpty(redisConnection))
            {
                services.AddStackExchangeRedisCache(opt => opt.Configuration = redisConnection);
            }
            else
            {
                services.AddDistributedMemoryCache();
            }
            services.AddSingleton<ICacheService, RedisCacheService>();
            services.AddSingleton<IUserIdProvider, UserIdProvider>();

            // AI generated — Background job service (Hangfire DI moved to Startup.cs)
            services.AddScoped<IBackgroundJobService, BackgroundJobService>();

            services.AddScoped<IBackgroundTaskQueue, BackgroundTaskQueue>();
            services.AddScoped<IRealtimeNotifier, SignalRNotifier>();

            return services;
        }
    }
}
