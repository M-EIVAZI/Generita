namespace Generita.Application.Common.Options;

public sealed class ApplicationUrlOptions
{
    public const string SectionName = "ApplicationUrls";

    public string PublicBaseUrl { get; set; } = "https://eivazi.qzz.io";

    public string ClientBaseUrl { get; set; } = "http://localhost:5173";

    public string BookProcessorBaseUrl { get; set; } = "https://arsemi.qzz.io";
}
