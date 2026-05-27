using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace YAHALLO.Infrastructure.Redis
{
    public static class RedisServiceCollectionExtensions
    {
        public static IServiceCollection AddRedis(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RedisOptions>(configuration.GetSection(RedisOptions.SectionName));

            var options = configuration
                .GetSection(RedisOptions.SectionName)
                .Get<RedisOptions>() ?? new RedisOptions();

            if (options.Enabled)
            {
                services.AddSingleton<IConnectionMultiplexer>(_ =>
                    ConnectionMultiplexer.Connect(options.ConnectionString));
            }

            services.AddSingleton<IRedisCacheService, RedisCacheService>();
            return services;
        }
    }
}

