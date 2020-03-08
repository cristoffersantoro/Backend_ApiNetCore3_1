using Backend_ApiNetCore3_1.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Backend_ApiNetCore3_1.Services.Api.Configurations
{
    public static class DatabaseSetup
    {
        public static void AddDatabaseSetup(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));


            services.AddDbContext<Backend_ApiNetCore3_1Context>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")).UseLazyLoadingProxies()
            );

        }
    }
}