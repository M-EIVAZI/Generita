using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Interfaces;
using Generita.Application.Common.Interfaces.Repository;
using Generita.Domain.Common.Interfaces;
using Generita.Infrustructure.Authentication;
using Generita.Infrustructure.Authentication.TokenGenerator;
using Generita.Infrustructure.Persistance;
using Generita.Infrustructure.Persistance.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddScoped<IAuthorRepository,AuthorRepository>();
            services.AddScoped<IRefreshTokenRepository,RefreshTokenRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddSingleton<ITokenGenerator, TokenGenerator>();
            return services;
        }

    }
}
