using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Interfaces;
using Generita.Application.Common.Interfaces.Repository;
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
using Microsoft.IdentityModel.Tokens;

namespace Generita.Infrustructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrustructure(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<GeneritaDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
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
            services.AddHttpClient<IBookService, BookServices>();
            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddSingleton<ITokenGenerator, TokenGenerator>();
            services.AddHostedService<JobStatusCheckerService>();

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

                        ValidIssuer = configuration["JwtSettings:Issuer"],
                        ValidAudience = configuration["JwtSettings:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(configuration["JwtSettings:Secret"])),

                        ClockSkew = TimeSpan.Zero
                    };
                });

            return services;
        }

    }
}
