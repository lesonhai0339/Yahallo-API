using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace YAHALLO.Infrastructure.Redis
{
    public sealed class RedisCacheService : IRedisCacheService
    {
        private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web);

        private readonly RedisOptions _options;
        private readonly ILogger<RedisCacheService> _logger;
        private readonly IConnectionMultiplexer? _connection;

        public RedisCacheService(
            IOptions<RedisOptions> options,
            ILogger<RedisCacheService> logger,
            IConnectionMultiplexer? connection = null)
        {
            _options = options.Value;
            _logger = logger;
            _connection = connection;
        }

        public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default)
        {
            if (_connection == null)
            {
                _logger.LogDebug("Redis is disabled. Skipped cache get for {CacheKey}.", key);
                return default;
            }

            cancellationToken.ThrowIfCancellationRequested();
            var value = await _connection.GetDatabase().StringGetAsync(BuildKey(key));
            return value.HasValue ? JsonSerializer.Deserialize<T>(value!, JsonOptions) : default;
        }

        public async Task SetAsync<T>(
            string key,
            T value,
            TimeSpan? expiration = null,
            CancellationToken cancellationToken = default)
        {
            if (_connection == null)
            {
                _logger.LogDebug("Redis is disabled. Skipped cache set for {CacheKey}.", key);
                return;
            }

            cancellationToken.ThrowIfCancellationRequested();
            var payload = JsonSerializer.Serialize(value, JsonOptions);
            var ttl = expiration ?? TimeSpan.FromMinutes(_options.DefaultExpirationMinutes);
            await _connection.GetDatabase().StringSetAsync(BuildKey(key), payload, ttl);
        }

        public async Task RemoveAsync(string key, CancellationToken cancellationToken = default)
        {
            if (_connection == null)
            {
                _logger.LogDebug("Redis is disabled. Skipped cache remove for {CacheKey}.", key);
                return;
            }

            cancellationToken.ThrowIfCancellationRequested();
            await _connection.GetDatabase().KeyDeleteAsync(BuildKey(key));
        }

        public async Task RemoveByPrefixAsync(string prefix, CancellationToken cancellationToken = default)
        {
            if (_connection == null)
            {
                _logger.LogDebug("Redis is disabled. Skipped cache prefix remove for {CachePrefix}.", prefix);
                return;
            }

            cancellationToken.ThrowIfCancellationRequested();
            var database = _connection.GetDatabase();
            var redisPrefix = BuildKey(prefix);

            foreach (var endpoint in _connection.GetEndPoints())
            {
                var server = _connection.GetServer(endpoint);
                foreach (var key in server.Keys(pattern: $"{redisPrefix}*"))
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    await database.KeyDeleteAsync(key);
                }
            }
        }

        private string BuildKey(string key)
        {
            return $"{_options.InstanceName}{key}";
        }
    }
}
