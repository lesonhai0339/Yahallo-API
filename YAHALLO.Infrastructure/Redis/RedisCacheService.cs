//AI generated
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using YAHALLO.Domain.Repositories.Cache;

namespace YAHALLO.Infrastructure.Redis
{
    public class RedisCacheService : ICacheService
    {
        private readonly IDistributedCache _cache;
        private readonly ILogger<RedisCacheService> _logger;

        private static readonly DistributedCacheEntryOptions DefaultOptions = new()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30)
        };

        public RedisCacheService(IDistributedCache cache, ILogger<RedisCacheService> logger)
        {
            _cache = cache;
            _logger = logger;
        }

        public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default) where T : class
        {
            try
            {
                var bytes = await _cache.GetAsync(key, cancellationToken);
                if (bytes is null) return null;
                return JsonSerializer.Deserialize<T>(bytes);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Cache GET failed for key {Key}", key);
                return null;
            }
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan? expiry = null, CancellationToken cancellationToken = default) where T : class
        {
            try
            {
                var options = expiry.HasValue
                    ? new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = expiry }
                    : DefaultOptions;
                var bytes = JsonSerializer.SerializeToUtf8Bytes(value);
                await _cache.SetAsync(key, bytes, options, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Cache SET failed for key {Key}", key);
            }
        }

        public async Task RemoveAsync(string key, CancellationToken cancellationToken = default)
        {
            try
            {
                await _cache.RemoveAsync(key, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Cache REMOVE failed for key {Key}", key);
            }
        }

        public async Task RemoveByPrefixAsync(string prefix, CancellationToken cancellationToken = default)
        {
            // IDistributedCache does not support pattern-based removal natively.
            // This is a known limitation; with Redis directly, you'd use SCAN + DEL.
            // For now we log a warning so it's visible during development.
            _logger.LogWarning("RemoveByPrefix '{Prefix}' is not supported by IDistributedCache. Use a direct IConnectionMultiplexer for pattern-based eviction.", prefix);
            await Task.CompletedTask;
        }

        public async Task<bool> ExistsAsync(string key, CancellationToken cancellationToken = default)
        {
            try
            {
                var bytes = await _cache.GetAsync(key, cancellationToken);
                return bytes is not null;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Cache EXISTS check failed for key {Key}", key);
                return false;
            }
        }

        public async Task<T> GetOrSetAsync<T>(string key, Func<Task<T>> factory, TimeSpan? expiry = null, CancellationToken cancellationToken = default) where T : class
        {
            var cached = await GetAsync<T>(key, cancellationToken);
            if (cached is not null) return cached;

            var value = await factory();
            await SetAsync(key, value, expiry, cancellationToken);
            return value;
        }
    }
}
