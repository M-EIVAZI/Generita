using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Generita.Api.HealthChecks;

public sealed class RedisHealthCheck : IHealthCheck
{
    private readonly IDistributedCache _distributedCache;

    public RedisHealthCheck(IDistributedCache distributedCache)
    {
        _distributedCache = distributedCache;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        var key = $"health:redis:{Guid.NewGuid():N}";
        const string expectedValue = "ok";

        try
        {
            await _distributedCache.SetStringAsync(
                key,
                expectedValue,
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
                },
                cancellationToken);

            var actualValue = await _distributedCache.GetStringAsync(key, cancellationToken);
            if (!string.Equals(actualValue, expectedValue, StringComparison.Ordinal))
            {
                return HealthCheckResult.Unhealthy(
                    "Redis write succeeded, but the value could not be read back.");
            }

            await _distributedCache.RemoveAsync(key, cancellationToken);
            return HealthCheckResult.Healthy("Redis read, write, and delete operations succeeded.");
        }
        catch (Exception exception) when (exception is not OperationCanceledException)
        {
            return HealthCheckResult.Unhealthy(
                "Redis read/write/delete probe failed.",
                exception);
        }
    }
}
