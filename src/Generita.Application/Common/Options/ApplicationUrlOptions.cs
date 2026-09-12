namespace Generita.Application.Common.Options;

public sealed class ApplicationUrlOptions
{
    public const string SectionName = "ApplicationUrls";

    public string PublicBaseUrl { get; set; } = "http://localhost:7161";

    public string ClientBaseUrl { get; set; } = "http://localhost:3000";

    public string BookProcessorBaseUrl { get; set; } = "http://localhost:8000";
}
