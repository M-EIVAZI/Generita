using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Generita.Application.Common.Behaviors;

using Microsoft.Extensions.DependencyInjection;

namespace Generita.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
                configuration.AddOpenBehavior(typeof(LoggingPipelineBehavior<,>));
                configuration.AddOpenBehavior(typeof(QueryCachingPipelineBehavior<,>));
            });
            return services;
        }

    }
}
