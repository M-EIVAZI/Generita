using MediatR;
using Generita.Application.Common.Messaging;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Generita.Application.Common.Behaviors;

public sealed class LoggingPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class
{
    private readonly ILogger<LoggingPipelineBehavior<TRequest, TResponse>> _logger;

    public LoggingPipelineBehavior(ILogger<LoggingPipelineBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var requestType = typeof(TRequest);
        var requestName = requestType.Name;
        var requestKind = GetRequestKind(requestType);
        var stopwatch = Stopwatch.StartNew();

        using (_logger.BeginScope(new Dictionary<string, object>
        {
            ["RequestName"] = requestName,
            ["RequestType"] = requestType.FullName ?? requestName,
            ["RequestKind"] = requestKind
        }))
        {
            _logger.LogInformation(
                "Handling {RequestKind} {RequestName}",
                requestKind,
                requestName);

            try
            {
                var response = await next(cancellationToken);
                stopwatch.Stop();

                _logger.LogInformation(
                    "Handled {RequestKind} {RequestName} in {ElapsedMilliseconds} ms",
                    requestKind,
                    requestName,
                    stopwatch.ElapsedMilliseconds);

                return response;
            }
            catch (Exception exception)
            {
                stopwatch.Stop();

                _logger.LogError(
                    exception,
                    "{RequestKind} {RequestName} failed after {ElapsedMilliseconds} ms",
                    requestKind,
                    requestName,
                    stopwatch.ElapsedMilliseconds);

                throw;
            }
        }
    }

    private static string GetRequestKind(Type requestType)
    {
        if (typeof(ICommand).IsAssignableFrom(requestType) ||
            ImplementsOpenGeneric(requestType, typeof(ICommand<>)))
        {
            return "Command";
        }

        if (ImplementsOpenGeneric(requestType, typeof(IQuery<>)))
        {
            return "Query";
        }

        // Keep logging requests that do not use the project's CQRS marker interfaces.
        return "Request";
    }

    private static bool ImplementsOpenGeneric(Type type, Type openGenericType)
    {
        return (type.IsGenericType && type.GetGenericTypeDefinition() == openGenericType) ||
               type.GetInterfaces().Any(interfaceType =>
                   interfaceType.IsGenericType &&
                   interfaceType.GetGenericTypeDefinition() == openGenericType);
    }
}
