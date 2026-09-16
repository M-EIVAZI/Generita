using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Generita.Api.HealthChecks;

public static class HealthCheckResponseWriter
{
    public static Task WriteAsync(HttpContext context, HealthReport report)
    {
        var response = new
        {
            status = report.Status.ToString(),
            durationMilliseconds = Math.Round(report.TotalDuration.TotalMilliseconds, 2),
            checks = report.Entries.Select(entry => new
            {
                name = entry.Key,
                status = entry.Value.Status.ToString(),
                description = entry.Value.Description,
                durationMilliseconds = Math.Round(entry.Value.Duration.TotalMilliseconds, 2),
                tags = entry.Value.Tags.OrderBy(tag => tag).ToArray()
            })
        };

        return context.Response.WriteAsJsonAsync(response, context.RequestAborted);
    }
}
