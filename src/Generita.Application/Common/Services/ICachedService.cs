namespace Generita.Application.Common.Services
{
    public interface ICachedService
    {
        Task<T> GetOrCreateAsync<T>
            (string key,
            Func<CancellationToken, Task<T>> factory,
            TimeSpan? expitration = null,
            CancellationToken cancellationToken = default
            )
            where T: class;
        Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default)
            where T : class;

        Task RemoveAsync(string key, CancellationToken cancellationToken = default);
        Task SetAsync<T>(string key, T value, TimeSpan? expitration = null, CancellationToken cancellationToken = default)
                        where T : class;
        Task RemoveByPrefixAsync(string prefixKey, CancellationToken cancellationToken = default);
    }
}
