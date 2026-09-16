using Generita.Api;
using Generita.Api.HealthChecks;
using Generita.Application;
using Generita.Application.Common.Options;
using Generita.Infrustructure;
using Generita.Infrustructure.Persistance;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Context;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    Log.Information("Starting Generita API");

    var builder = WebApplication.CreateBuilder(args);

    if (builder.Environment.IsDevelopment())
    {
        Serilog.Debugging.SelfLog.Enable(message =>
            Console.Error.WriteLine($"[Serilog SelfLog] {message}"));
    }

    // A checked-in JWT signing key would expose a credential. For local
    // development, create one for this process when no user-secret/environment
    // variable was supplied. Tokens are intentionally invalid after a restart.
    if (string.IsNullOrWhiteSpace(builder.Configuration["JwtSettings:Secret"]))
    {
        if (!builder.Environment.IsDevelopment())
        {
            throw new InvalidOperationException(
                "JwtSettings:Secret is required outside Development. " +
                "Set it through an environment variable or secret store.");
        }

        var developmentJwtSecret = Convert.ToBase64String(
            System.Security.Cryptography.RandomNumberGenerator.GetBytes(64));

        builder.Configuration.AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["JwtSettings:Secret"] = developmentJwtSecret
        });

        Log.Warning(
            "JwtSettings:Secret was not configured. Using an ephemeral " +
            "development key; issued tokens will be invalid after restart");
    }

    builder.Services.AddSerilog((services, loggerConfiguration) => loggerConfiguration
        .ReadFrom.Configuration(builder.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext());

    builder.Services.Configure<ApplicationUrlOptions>(
        builder.Configuration.GetSection(ApplicationUrlOptions.SectionName));

    builder.Services.AddApplication();
    builder.Services.AddInfrustructure(builder.Configuration);
    builder.Services.AddHealthChecks()
        .AddCheck<PostgreSqlHealthCheck>(
            "postgresql",
            failureStatus: HealthStatus.Unhealthy,
            tags: ["database", "ready"])
        .AddCheck<RedisHealthCheck>(
            "redis",
            failureStatus: HealthStatus.Unhealthy,
            tags: ["cache", "ready"]);

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(options =>
    {
        options.MapType<DateOnly>(() => new OpenApiSchema
        {
            Type = "string",
            Format = "date"
        });

        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "Please enter JWT token like: Bearer {your token here}"
        });

        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }
        });
    });

    var allowedOrigins = builder.Configuration
        .GetSection("Cors:AllowedOrigins")
        .Get<string[]>() ?? ["http://localhost:5173"];

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowedClients", policy =>
        {
            policy.WithOrigins(allowedOrigins)
                .AllowAnyMethod()
                .AllowCredentials()
                .AllowAnyHeader();
        });
    });

    var app = builder.Build();

    Log.Information(
        "Generita API configured in {EnvironmentName}; Seq endpoint is {SeqEndpoint}",
        app.Environment.EnvironmentName,
        builder.Configuration["Serilog:WriteTo:1:Args:serverUrl"]);

    // Keep a correlation identifier on every log emitted while handling a request,
    // including EF Core SQL command logs and MediatR command/query logs.
    app.Use(async (httpContext, next) =>
    {
        using (LogContext.PushProperty("CorrelationId", httpContext.TraceIdentifier))
        using (LogContext.PushProperty("RequestMethod", httpContext.Request.Method))
        using (LogContext.PushProperty("RequestPath", httpContext.Request.Path.Value ?? "/"))
        {
            await next();
        }
    });

    app.UseStaticFiles();
    app.UseSerilogRequestLogging(options =>
    {
        options.EnrichDiagnosticContext = (diagnosticContext, httpContext) =>
        {
            diagnosticContext.Set("RequestHost", httpContext.Request.Host.Value);
            diagnosticContext.Set("RequestScheme", httpContext.Request.Scheme);
        };
    });

    app.UseCors("AllowedClients");

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    if (builder.Configuration.GetValue<bool>("HttpsRedirection:Enabled"))
    {
        app.UseHttpsRedirection();
    }

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();
    app.MapHealthChecks("/health", new HealthCheckOptions
    {
        ResponseWriter = HealthCheckResponseWriter.WriteAsync
    });

    if (builder.Configuration.GetValue<bool>("Database:ApplyMigrationsOnStartup"))
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<GeneritaDbContext>();
        dbContext.Database.Migrate();
    }

    app.Run();
}
catch (Exception exception)
{
    Log.Fatal(exception, "Generita API terminated unexpectedly");
    throw;
}
finally
{
    Log.CloseAndFlush();
}
