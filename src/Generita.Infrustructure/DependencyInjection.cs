using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Interfaces;
using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Common.Options;
using Generita.Application.Common.Services;
using Generita.Domain.Common.Interfaces;
using Generita.Infrustructure.Authentication;
using Generita.Infrustructure.Authentication.TokenGenerator;
using Generita.Infrustructure.Persistance;
using Generita.Infrustructure.Persistance.Repositories;
using Generita.Infrustructure.Persistance.Services;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;

namespace Generita.Infrustructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrustructure(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            var jwtSettings = configuration
                .GetRequiredSection(JwtSettings.SectionName)
                .Get<JwtSettings>()
                ?? throw new InvalidOperationException("JwtSettings configuration is required.");

            if (string.IsNullOrWhiteSpace(jwtSettings.Secret))
            {
                throw new InvalidOperationException(
                    "JwtSettings:Secret is required. Configure it through an " +
                    "environment variable or secret store.");
            }

            if (Encoding.UTF8.GetByteCount(jwtSettings.Secret) < 32)
            {
                throw new InvalidOperationException(
                    "JwtSettings:Secret must contain at least 32 bytes.");
            }

            if (string.IsNullOrWhiteSpace(jwtSettings.Issuer) ||
                string.IsNullOrWhiteSpace(jwtSettings.Audience) ||
                jwtSettings.ExpiryMinutes <= 0)
            {
                throw new InvalidOperationException(
                    "JwtSettings:Issuer, JwtSettings:Audience, and a positive " +
                    "JwtSettings:ExpiryMinutes are required.");
            }

            services.Configure<JwtSettings>(
                configuration.GetRequiredSection(JwtSettings.SectionName));

            services.AddDbContext<GeneritaDbContext>(options =>
            {
                options.UseNpgsql(connectionString);

                // EF Core writes executed SQL through the normal
                // Microsoft.Extensions.Logging pipeline. The Serilog category override in
                // appsettings.json enables these command events at Information level.
                if (configuration.GetValue<bool>("Database:EnableDetailedErrors"))
                {
                    options.EnableDetailedErrors();
                }

                // Do not include parameter values by default. SQL text and execution metadata
                // are useful for diagnostics, while request/user data must stay out of Seq.
                if (configuration.GetValue<bool>("Database:EnableSensitiveDataLogging"))
                {
                    options.EnableSensitiveDataLogging();
                }
            });
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<ISongRepository,SongsRepository>();
            services.AddScoped<IBookRepository,BookRepository>();
            services.AddScoped<IBookCategoryRepository,BookCategoryRepository>();
            services.AddScoped<ITransactionsRepository,TransactionRepository>();
            services.AddScoped<IPlansRepository,PlansRepository>();
            services.AddScoped<IParagraphRepository,ParagraphRepository>();
            services.AddScoped<IEntityRepository,EntityRepository>();
            services.AddScoped<IAuthorRepository,AuthorRepository>();
            services.AddScoped<IRefreshTokenRepository,RefreshTokenRepository>();
            services.AddScoped<IJobRepository, JobsRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICachedService, CacheService>();
            services.Configure<DistributedCacheOptions>(
                configuration.GetSection(DistributedCacheOptions.SectionName));
            services.AddHttpClient<IBookService, BookServices>((serviceProvider, httpClient) =>
            {
                var urlOptions = serviceProvider
                    .GetRequiredService<IOptions<ApplicationUrlOptions>>()
                    .Value;

                httpClient.BaseAddress = new Uri(
                    $"{urlOptions.BookProcessorBaseUrl.TrimEnd('/')}/");
            });
            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddSingleton<ITokenGenerator, TokenGenerator>();
            services.Configure<ZarinPalOptions>(
                configuration.GetSection("ZarinPal"));
            services.AddHttpClient<IPaymentService, PaymentService>();
            services.AddHostedService<JobStatusCheckerService>();

            var redisConnection = configuration.GetConnectionString("Redis")
                ?? throw new InvalidOperationException("ConnectionStrings:Redis is required.");
            var cacheInstanceName = configuration[$"{DistributedCacheOptions.SectionName}:InstanceName"]
                ?? "generita:";

            services.AddStackExchangeRedisCache(options =>
            {
                var redisOptions = ConfigurationOptions.Parse(redisConnection);
                redisOptions.AbortOnConnectFail = false;
                redisOptions.ConnectRetry = 3;
                redisOptions.ConnectTimeout = 5000;
                redisOptions.SyncTimeout = 5000;

                options.ConfigurationOptions = redisOptions;
                options.InstanceName = cacheInstanceName;
            });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o =>
                {
                    o.RequireHttpsMetadata = false;
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = jwtSettings.Issuer,
                        ValidAudience = jwtSettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(jwtSettings.Secret)),

                        ClockSkew = TimeSpan.Zero
                    };
                });

            return services;
        }

    }
}
