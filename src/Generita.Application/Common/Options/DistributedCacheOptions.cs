namespace Generita.Application.Common.Options;

public sealed class DistributedCacheOptions
{
    public const string SectionName = "Cache";

    public int DefaultExpirationMinutes { get; init; } = 30;

    public string InstanceName { get; init; } = "generita:";
}
