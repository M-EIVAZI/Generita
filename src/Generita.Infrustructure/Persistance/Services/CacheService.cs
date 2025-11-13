using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

using Generita.Application.Common.Services;

using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;

namespace Generita.Infrustructure.Persistance.Repositories
{
    internal class CacheService : ICachedService
    {
        private static ConcurrentDictionary<string, bool> _cache = new ConcurrentDictionary<string, bool>();
        private readonly IDistributedCache _distributedCache;

        public CacheService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }
        public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default)
            where T : class
        {
            string? value = await _distributedCache.GetStringAsync(key,cancellationToken );
            if (value is null)
                return null;
            var res=JsonSerializer.Deserialize<T>(value);
            return res;
        }

        public async Task<T> GetOrCreateAsync<T>(string key, Func<CancellationToken, Task<T>> factory, TimeSpan? expitration = null, CancellationToken cancellationToken = default)
            where T : class
        {
            var res=await GetAsync<T>(key, cancellationToken);
            if (res is not null)
                return res;
            var value = await factory(cancellationToken);
            await SetAsync(key, value, expitration, cancellationToken);
            return value;

        }


        public async Task RemoveAsync(string key, CancellationToken cancellationToken = default)
        {
            await  _distributedCache.RemoveAsync(key, cancellationToken);
            _cache.TryRemove(key, out _);
        }

        public async  Task RemoveByPrefixAsync(string prefixKey, CancellationToken cancellationToken = default)
        {

            var res=_cache.Keys.Where(x => x.StartsWith(prefixKey))
                .Select(x => RemoveAsync(x, cancellationToken));
            await Task.WhenAll(res);

        }

        public async Task SetAsync<T>(string key, T value, TimeSpan? expitration = null, CancellationToken cancellationToken = default)
             where T : class
        {
            var cachevalue=JsonSerializer.Serialize(value);
            var option =new DistributedCacheEntryOptions();
            if (expitration.HasValue)
                option.SlidingExpiration = expitration;
            await _distributedCache.SetStringAsync(key, cachevalue, cancellationToken);
            _cache.TryAdd(key, true);
        }
    }
}
