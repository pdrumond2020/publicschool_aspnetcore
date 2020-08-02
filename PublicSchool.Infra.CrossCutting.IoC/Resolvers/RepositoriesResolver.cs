using Microsoft.Extensions.DependencyInjection;
using PublicSchool.Domain.Interface.Repositories;
using PublicSchool.Domain.Interface.Repositories.Base;
using PublicSchool.Infra.Data.Repositories;
using PublicSchool.Infra.Data.Repositories.Base;

namespace PublicSchool.Infra.CrossCutting.IoC.Resolvers
{
    public static class RepositoriesResolver
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddTransient<ISchoolRepository, SchoolRepository>();
            services.AddTransient<IGradeRepository, GradeRepository>();
            return services;
        }
    }
}