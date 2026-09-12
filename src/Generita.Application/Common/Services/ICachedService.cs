namespace Generita.Application.Common.Services
{
    public interface ICachedService
    {
        Task<ErrorOr.ErrorOr<T>> GetOrCreateAsync<T>
            (string key,
            Func<CancellationToken, Task<ErrorOr.ErrorOr<T>>> factory,
            TimeSpan? expiration = null,
            CancellationToken cancellationToken = default
            )
            where T: class;
        Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default)
            where T : class;

        Task RemoveAsync(string key, CancellationToken cancellationToken = default);
        Task SetAsync<T>(string key, T value, TimeSpan? expiration = null, CancellationToken cancellationToken = default)
                        where T : class;
    }
}
