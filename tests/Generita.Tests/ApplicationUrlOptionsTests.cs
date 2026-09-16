using Generita.Application.Common.Options;

namespace Generita.Tests;

public sealed class ApplicationUrlOptionsTests
{
    [Fact]
    public void Defaults_UseLocalFrontendAndHostedBackends()
    {
        var options = new ApplicationUrlOptions();

        Assert.Equal("https://eivazi.qzz.io", options.PublicBaseUrl);
        Assert.Equal("http://localhost:5173", options.ClientBaseUrl);
        Assert.Equal("https://arsemi.qzz.io", options.BookProcessorBaseUrl);
    }
}
