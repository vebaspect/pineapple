using Pineapple.Core;
using Pineapple.Core.Storage.Database;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Pineapple.Api
{
    public static class Extensions
    {
        public static IServiceCollection AddCors(this IServiceCollection services, IConfiguration configuration)
        {
            IConfigurationSection corsConfigurationSection = configuration.GetSection("Hosting:Cors");
            string[] origins = corsConfigurationSection.GetSection("Origins").Get<string[]>();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins(origins)
                        .AllowAnyMethod();
                });
            });

            return services;
        }

        public static IServiceCollection AddMediatR(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ICommand));

            return services;
        }

        public static IServiceCollection AddStorage(this IServiceCollection services)
        {
            services.AddSingleton<DatabaseContextFactory>();

            return services;
        }

        public static IApplicationBuilder UseStorage(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            var databaseContextFactory = serviceScope.ServiceProvider.GetService<DatabaseContextFactory>();

            using var databaseContext = databaseContextFactory.CreateDbContext();

            if (!(databaseContext is null) && !(databaseContext.Database is null))
            {
                databaseContext.Database.Migrate();
            }

            return app;
        }
    }
}
