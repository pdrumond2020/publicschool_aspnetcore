using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace PublicSchool.Infra.CrossCutting.IoC.Resolvers
{
    public static class ContextAccessorResolver
    {
        public static IServiceCollection ConfigureContextAccessor(this IServiceCollection services)
        {
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            return services;
        }
    }
}