using Generita.Api;
using Generita.Application;
using Generita.Application.Common.Options;
using Generita.Infrustructure;
using Generita.Infrustructure.Persistance;
using Microsoft.EntityFrameworkCore;
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

    builder.Services.AddSerilog((services, loggerConfiguration) => loggerConfiguration
        .ReadFrom.Configuration(builder.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext());

    builder.Services.Configure<ApplicationUrlOptions>(
        builder.Configuration.GetSection(ApplicationUrlOptions.SectionName));

    builder.Services.AddApplication();
    builder.Services.AddInfrustructure(builder.Configuration);

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
        .Get<string[]>() ?? ["http://localhost:3000", "http://localhost:5173"];

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
