using ErrorOr;
using Generita.Application.Common.Options;
using Generita.Infrustructure.Persistance.Repositories;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace Generita.Tests;

public sealed class CacheServiceTests
{
    [Fact]
    public async Task SetAndGet_RoundTripsSerializedValue()
    {
        var (service, _) = CreateService();
        var expected = new CacheValue("value", 42);

        await service.SetAsync("round-trip", expected, TimeSpan.FromMinutes(1));
        var actual = await service.GetAsync<CacheValue>("round-trip");

        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task GetOrCreate_CachesSuccessfulResult()
    {
        var (service, _) = CreateService();
        var factoryCalls = 0;

        Task<ErrorOr<CacheValue>> Factory(CancellationToken _)
        {
            factoryCalls++;
            return Task.FromResult<ErrorOr<CacheValue>>(new CacheValue("cached", 1));
        }

        var first = await service.GetOrCreateAsync("success", Factory);
        var second = await service.GetOrCreateAsync("success", Factory);

        Assert.False(first.IsError);
        Assert.False(second.IsError);
        Assert.Equal(first.Value, second.Value);
        Assert.Equal(1, factoryCalls);
    }

    [Fact]
    public async Task GetOrCreate_DoesNotCacheErrorResult()
    {
        var (service, _) = CreateService();
        var factoryCalls = 0;

        Task<ErrorOr<CacheValue>> Factory(CancellationToken _)
        {
            factoryCalls++;
            return Task.FromResult<ErrorOr<CacheValue>>(
                Error.Failure("test.failure", "Expected test failure"));
        }

        var first = await service.GetOrCreateAsync("error", Factory);
        var second = await service.GetOrCreateAsync("error", Factory);

        Assert.True(first.IsError);
        Assert.True(second.IsError);
        Assert.Equal(2, factoryCalls);
    }

    [Fact]
    public async Task GetOrCreate_CoalescesConcurrentRequestsForSameKey()
    {
        var (service, _) = CreateService();
        var factoryCalls = 0;

        async Task<ErrorOr<CacheValue>> Factory(CancellationToken cancellationToken)
        {
            Interlocked.Increment(ref factoryCalls);
            await Task.Delay(50, cancellationToken);
            return new CacheValue("shared", 7);
        }

        var requests = Enumerable.Range(0, 10)
            .Select(_ => service.GetOrCreateAsync("concurrent", Factory))
            .ToArray();

        var results = await Task.WhenAll(requests);

        Assert.Equal(1, factoryCalls);
        Assert.All(results, result =>
        {
            Assert.False(result.IsError);
            Assert.Equal(new CacheValue("shared", 7), result.Value);
        });
    }

    [Fact]
    public async Task Get_RemovesInvalidSerializedValue()
    {
        var (service, distributedCache) = CreateService();
        await distributedCache.SetStringAsync("invalid", "not-json");

        var result = await service.GetAsync<CacheValue>("invalid");

        Assert.Null(result);
        Assert.Null(await distributedCache.GetStringAsync("invalid"));
    }

    private static (CacheService Service, IDistributedCache Cache) CreateService()
    {
        var distributedCache = new MemoryDistributedCache(
            Options.Create(new MemoryDistributedCacheOptions()));
        var options = Options.Create(new DistributedCacheOptions
        {
            DefaultExpirationMinutes = 30
        });
        var service = new CacheService(
            distributedCache,
            options,
            NullLogger<CacheService>.Instance);

        return (service, distributedCache);
    }

    public sealed record CacheValue(string Name, int Number);
}
