using System;
using Backend_ApiNetCore3_1.Infra.CrossCutting.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Backend_ApiNetCore3_1.Services.Api.Configurations
{
    public static class DependencyInjectionSetup
    {
        public static void AddDependencyInjectionSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}