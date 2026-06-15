//AI generated
using Amazon.S3;
using dotenv.net;
using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.Serialization;
using Elastic.Transport;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using System.Text.Json.Serialization;
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

            services.AddDefaultAWSOptions(configuration.GetAWSOptions());
            services.AddAWSService<IAmazonS3>();
            services.AddTransient(typeof(IStorageService<>), typeof(AwsS3Service<>));

            services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<ApplicationDbContext>());
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();

            services.AddScoped<IMangaRepository, MangaRepository>();

            services.AddScoped<IChapterRepository, ChapterRepository>();
            services.AddScoped<IRatingRepository, RatingRepository>();

            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IArtistRepository, ArtistRepository>();
            services.AddScoped<IMangaArtistRepository, MangaArtistRepository>();
            services.AddScoped<IMangaAuthorRepository, MangaAuthorRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IFollowRepository, FollowRepository>();
            services.AddScoped<IMangaAssociateNameRepository, MangaAssociateNameRepository>();
            services.AddScoped<IMangaSeasonRepository, MangaSeasonRepository>();
            services.AddScoped<IMangaViewRepository, MangaViewRepository>();
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

            // AI generated — new repositories
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IMangaTagRepository, MangaTagRepository>();
            services.AddScoped<IReadingProgressRepository, ReadingProgressRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<IUserMangaViewRepository, UserMangaViewRepository>();
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();

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

            // AI generated — Background job service (Hangfire DI moved to Startup.cs)
            services.AddScoped<IBackgroundJobService, BackgroundJobService>();

            return services;
        }
    }
}
