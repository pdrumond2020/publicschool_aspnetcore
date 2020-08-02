using Microsoft.Extensions.DependencyInjection;
using PublicSchool.Infra.CrossCutting.IoC.Resolvers;

namespace PublicSchool.Infra.CrossCutting.IoC
{
    public static class IoC
    {
        public static IServiceCollection ResolveApi(this IServiceCollection services)
        {
            services.ConfigureContext()
                    .ConfigureContextAccessor()
                    .ConfigureServices()
                    .ConfigureRepositories();

            return services;
        }
    }
}