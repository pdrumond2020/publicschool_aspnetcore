using Microsoft.Extensions.DependencyInjection;
using PublicSchool.Application.Implementation;
using PublicSchool.Application.Interface;
using PublicSchool.Domain.Interface.Services;
using PublicSchool.Domain.Interface.UnitOfWork;
using PublicSchool.Domain.Services;
using PublicSchool.Infra.Data.UnitOfWork;

namespace PublicSchool.Infra.CrossCutting.IoC.Resolvers
{
    public static class SevicesResolver
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddSingleton<IUnitOfWork, UnitOfWork>();

            services.AddTransient<ISchoolService, SchoolService>();
            services.AddTransient<ISchoolAppService, SchoolAppService>();
            services.AddTransient<IGradeService, GradeService>();
            services.AddTransient<IGradeAppService, GradeAppService>();
            return services;
        }
    }
}