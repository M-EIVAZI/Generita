using ErrorOr;
using Generita.Application.Authors.GetAllAuthorBooks;
using Generita.Application.Books.Queries.GetAllBookCategories;
using Generita.Application.Books.Queries.GetBookById;
using Generita.Application.Books.Queries.GetBookContent;
using Generita.Application.Common.Behaviors;
using Generita.Application.Dtos;
using Generita.Application.Home.Query;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Generita.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            configuration.AddOpenBehavior(typeof(LoggingPipelineBehavior<,>));
            configuration.AddOpenBehavior(typeof(CacheInvalidationPipelineBehavior<,>));
        });

        AddCachedQueryBehavior<HomeQuery, HomeResponse>(services);
        AddCachedQueryBehavior<GetAllAuthorBooksQuery, IEnumerable<GetAllBooksResponse>>(services);
        AddCachedQueryBehavior<GetAllBookCategoriesQuery, ICollection<GetAllBookCategoriesResponse>>(services);
        AddCachedQueryBehavior<GetBookByIdQuery, GetBookDto>(services);
        AddCachedQueryBehavior<GetBookByContentQuery, BookConentResponse>(services);

        return services;
    }

    private static void AddCachedQueryBehavior<TRequest, TResponse>(IServiceCollection services)
        where TRequest : Common.Messaging.ICachedQuery<TResponse>
        where TResponse : class
    {
        services.AddTransient<
            IPipelineBehavior<TRequest, ErrorOr<TResponse>>,
            QueryCachingPipelineBehavior<TRequest, TResponse>>();
    }
}
