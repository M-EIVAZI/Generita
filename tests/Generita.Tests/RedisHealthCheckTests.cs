using Generita.Api.HealthChecks;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;

namespace Generita.Tests;

public sealed class RedisHealthCheckTests
{
    [Fact]
    public async Task CheckHealth_ReturnsHealthyWhenReadWriteDeleteSucceeds()
    {
        var cache = new MemoryDistributedCache(
            Options.Create(new MemoryDistributedCacheOptions()));
        var healthCheck = new RedisHealthCheck(cache);

        var result = await healthCheck.CheckHealthAsync(new HealthCheckContext());

        Assert.Equal(HealthStatus.Healthy, result.Status);
    }

    [Fact]
    public async Task CheckHealth_ReturnsUnhealthyWhenCacheThrows()
    {
        var healthCheck = new RedisHealthCheck(new ThrowingDistributedCache());

        var result = await healthCheck.CheckHealthAsync(new HealthCheckContext());

        Assert.Equal(HealthStatus.Unhealthy, result.Status);
        Assert.IsType<InvalidOperationException>(result.Exception);
    }

    private sealed class ThrowingDistributedCache : IDistributedCache
    {
        private static InvalidOperationException Failure() =>
            new("Redis is unavailable for this test.");

        public byte[]? Get(string key) => throw Failure();

        public Task<byte[]?> GetAsync(
            string key,
            CancellationToken token = default) => throw Failure();

        public void Refresh(string key) => throw Failure();

        public Task RefreshAsync(
            string key,
            CancellationToken token = default) => throw Failure();

        public void Remove(string key) => throw Failure();

        public Task RemoveAsync(
            string key,
            CancellationToken token = default) => throw Failure();

        public void Set(
            string key,
            byte[] value,
            DistributedCacheEntryOptions options) => throw Failure();

        public Task SetAsync(
            string key,
            byte[] value,
            DistributedCacheEntryOptions options,
            CancellationToken token = default) => throw Failure();
    }
}
