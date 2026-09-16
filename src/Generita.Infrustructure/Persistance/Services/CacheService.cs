using System.Collections.Concurrent;
using System.Text.Json;
using ErrorOr;
using Generita.Application.Common.Options;
using Generita.Application.Common.Services;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace Generita.Infrustructure.Persistance.Repositories;

internal sealed class CacheService : ICachedService
{
    private static readonly JsonSerializerOptions SerializerOptions = new(JsonSerializerDefaults.Web);

    private readonly IDistributedCache _distributedCache;
    private readonly ILogger<CacheService> _logger;
    private readonly TimeSpan _defaultExpiration;

    public CacheService(
        IDistributedCache distributedCache,
        IOptions<DistributedCacheOptions> options,
        ILogger<CacheService> logger)
    {
        _distributedCache = distributedCache;
        _logger = logger;

        var expirationMinutes = options.Value.DefaultExpirationMinutes;
        _defaultExpiration = expirationMinutes > 0
            ? TimeSpan.FromMinutes(expirationMinutes)
            : TimeSpan.FromMinutes(30);
    }

    public async Task<T?> GetAsync<T>(
        string key,
        CancellationToken cancellationToken = default)
        where T : class
    {
        try
        {
            var value = await _distributedCache.GetStringAsync(key, cancellationToken);
            if (value is null)
            {
                _logger.LogInformation("Cache {CacheOperation} for {CacheKey}", "Miss", key);
                return null;
            }

            var result = JsonSerializer.Deserialize<T>(value, SerializerOptions);
            if (result is null)
            {
                _logger.LogWarning(
                    "Cache {CacheOperation} for {CacheKey}: value could not be deserialized",
                    "Invalid",
                    key);
                await RemoveAsync(key, cancellationToken);
                return null;
            }

            _logger.LogInformation("Cache {CacheOperation} for {CacheKey}", "Hit", key);
            return result;
        }
        catch (Exception exception) when (exception is JsonException or NotSupportedException)
        {
            _logger.LogWarning(
                exception,
                "Cache {CacheOperation} for {CacheKey}: invalid serialized value; removing the entry",
                "Invalid",
                key);
            await RemoveAsync(key, cancellationToken);
            return null;
        }
        catch (RedisException exception)
        {
            _logger.LogWarning(
                exception,
                "Cache {CacheOperation} for {CacheKey}; continuing without cache",
                "ReadFailure",
                key);
            return null;
        }
    }

    public async Task<ErrorOr<T>> GetOrCreateAsync<T>(
        string key,
        Func<CancellationToken, Task<ErrorOr<T>>> factory,
        TimeSpan? expiration = null,
        CancellationToken cancellationToken = default)
        where T : class
    {
        var cachedValue = await GetAsync<T>(key, cancellationToken);
        if (cachedValue is not null)
        {
            return cachedValue;
        }

        var lazyRequest = InflightRequests<T>.Requests.GetOrAdd(
            key,
            _ => new Lazy<Task<ErrorOr<T>>>(
                () => CreateAndCacheAsync(key, factory, expiration, cancellationToken),
                LazyThreadSafetyMode.ExecutionAndPublication));

        try
        {
            return await lazyRequest.Value;
        }
        finally
        {
            ((ICollection<KeyValuePair<string, Lazy<Task<ErrorOr<T>>>>>)InflightRequests<T>.Requests)
                .Remove(new KeyValuePair<string, Lazy<Task<ErrorOr<T>>>>(key, lazyRequest));
        }
    }

    public async Task SetAsync<T>(
        string key,
        T value,
        TimeSpan? expiration = null,
        CancellationToken cancellationToken = default)
        where T : class
    {
        try
        {
            var cacheValue = JsonSerializer.Serialize(value, SerializerOptions);
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expiration ?? _defaultExpiration
            };

            await _distributedCache.SetStringAsync(key, cacheValue, options, cancellationToken);
            _logger.LogInformation(
                "Cache {CacheOperation} for {CacheKey} with TTL {CacheDurationSeconds} seconds",
                "Set",
                key,
                options.AbsoluteExpirationRelativeToNow?.TotalSeconds);
        }
        catch (Exception exception) when (exception is JsonException or NotSupportedException)
        {
            _logger.LogWarning(
                exception,
                "Cache {CacheOperation} for {CacheKey}; value could not be serialized",
                "SerializationFailure",
                key);
        }
        catch (RedisException exception)
        {
            _logger.LogWarning(
                exception,
                "Cache {CacheOperation} for {CacheKey}; response was not cached",
                "WriteFailure",
                key);
        }
    }

    public async Task RemoveAsync(
        string key,
        CancellationToken cancellationToken = default)
    {
        try
        {
            await _distributedCache.RemoveAsync(key, cancellationToken);
            _logger.LogInformation("Cache {CacheOperation} for {CacheKey}", "Remove", key);
        }
        catch (RedisException exception)
        {
            _logger.LogWarning(
                exception,
                "Cache {CacheOperation} for {CacheKey}",
                "RemoveFailure",
                key);
        }
    }

    private async Task<ErrorOr<T>> CreateAndCacheAsync<T>(
        string key,
        Func<CancellationToken, Task<ErrorOr<T>>> factory,
        TimeSpan? expiration,
        CancellationToken cancellationToken)
        where T : class
    {
        // A request may have populated the cache while this request was waiting.
        var cachedValue = await GetAsync<T>(key, cancellationToken);
        if (cachedValue is not null)
        {
            return cachedValue;
        }

        var response = await factory(cancellationToken);
        if (response.IsError)
        {
            _logger.LogInformation(
                "Cache {CacheOperation} for unsuccessful response {CacheKey}",
                "Skip",
                key);
            return response;
        }

        await SetAsync(key, response.Value, expiration, cancellationToken);
        return response;
    }

    private static class InflightRequests<T>
        where T : class
    {
        internal static readonly ConcurrentDictionary<string, Lazy<Task<ErrorOr<T>>>> Requests = new();
    }
}
