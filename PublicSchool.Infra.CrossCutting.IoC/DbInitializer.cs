using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PublicSchool.Domain.Entities;
using PublicSchool.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicSchool.Infra.CrossCutting.IoC
{
    public static class DbInitializer
    {
        public static void InitializeDb(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<PublicSchoolContext>();
                    InitializeData(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }
        }

        private static void InitializeData(PublicSchoolContext context)
        {
            context.AddAsync(new School { Id = 1, Name = "School 1" });
            context.AddAsync(new School { Id = 2, Name = "School 2" });
            context.AddAsync(new School { Id = 3, Name = "School 3" });

            context.AddAsync(new Grade { Id = 1, Description = "Grade A", SchoolId = 1 });
            context.AddAsync(new Grade { Id = 1, Description = "Grade A", SchoolId = 1 });
            context.AddAsync(new Grade { Id = 1, Description = "Grade A", SchoolId = 1 });

            context.SaveChangesAsync();
        }
    }
}