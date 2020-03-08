using System;
using AutoMapper;
using Backend_ApiNetCore3_1.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Backend_ApiNetCore3_1.Services.Api.Configurations
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(AutoMappingProfileRequestService));
        }
    }
}