using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PublicSchool.Infra.Data.Context;
using System;

namespace PublicSchool.Infra.CrossCutting.IoC.Resolvers
{
    public static class ContextResolver
    {
        public static IServiceCollection ConfigureContext(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddScoped<PublicSchoolContext, PublicSchoolContext>();

            return services;
        }
    }
}