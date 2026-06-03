//AI generated
using Amazon.S3;
using dotenv.net;
using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.Serialization;
using Elastic.Transport;
using Hangfire.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Org.BouncyCastle.Asn1.X509.Qualified;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
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
using YAHALLO.Infrastructure.Persistence.Data;
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
            DotEnv.Load();

            services.Configure<AwsS3Options>(configuration.GetSection(nameof(AwsS3Options)));

            var sqlConnection = Environment.GetEnvironmentVariable("Cloud_Server");
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
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IUserRoleRepository, UserRoleRepository>();
            services.AddTransient<IMangaRepository, MangaRepository>();
            services.AddTransient<IChapterRepository, ChapterRepository>();
            services.AddTransient<IImageRepository, ImageRepository>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IArtistRepository, ArtistRepository>();
            services.AddTransient<IMangaArtistRepository, MangaArtistRepository>();
            services.AddTransient<IMangaAuthorRepository, MangaAuthorRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<IFollowRepository, FollowRepository>();
            services.AddTransient<IMangaAssociateNameRepository, MangaAssociateNameRepository>();
            services.AddTransient<IMangaRatingRepository, MangaRatingRepository>(); 
            services.AddTransient<IMangaSeasonRepository, MangaSeasonRepository>();
            services.AddTransient<IMangaViewRepository, MangaViewRepository>();
            services.AddTransient<IUserTokenRepository, UserTokenRepository>();
            services.AddTransient<IAttechmentRepository, AttechmentRepository>();
            services.AddTransient<IBlogRepository, BlogRepository>();
            services.AddTransient<IUserOldPasswordRepository, UserOldPasswordRepository>();
            services.AddTransient<IThreadRepository, ThreadRepository>();
            services.AddTransient<IThreadOfBlogRepository, ThreadOfBlogRepository>();
            services.AddTransient<IReactionRepository, ReactionRepository>();
            services.AddTransient<ICountingRepository, CountingRepository>();
            services.AddTransient<IReportRepository, ReportRepository>();
            services.AddTransient<IEnums, Enums>();
            services.AddTransient(typeof(IFiles<>), typeof(Files<>));
            services.AddTransient<IFilters, Filters>();
            services.AddTransient<IMangaSearchRepository, MangaSearchRepository>();

            // AI generated — new repositories
            services.AddTransient<ITagRepository, TagRepository>();
            services.AddTransient<IMangaTagRepository, MangaTagRepository>();
            services.AddTransient<IReadingProgressRepository, ReadingProgressRepository>();
            services.AddTransient<INotificationRepository, NotificationRepository>();
            services.AddTransient<IUserMangaViewRepository, UserMangaViewRepository>();
            services.AddTransient<ISubscriptionRepository, SubscriptionRepository>();

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
