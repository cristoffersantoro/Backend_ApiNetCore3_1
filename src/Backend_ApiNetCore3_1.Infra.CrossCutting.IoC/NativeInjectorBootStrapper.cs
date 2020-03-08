using Backend_ApiNetCore3_1.Domain.Interfaces;
using Backend_ApiNetCore3_1.Domain.Notifications;
using Backend_ApiNetCore3_1.Infra.Data.Context;
using Backend_ApiNetCore3_1.Infra.Data.Repository;
using Backend_ApiNetCore3_1.Infra.Data.UoW;
using Microsoft.Extensions.DependencyInjection;

namespace Backend_ApiNetCore3_1.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {


            #region Repositories
            services.AddScoped<IAppUserRepository, AppUserRepository>();
            services.AddScoped<IPositionRepository, PositionRepository>();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();


            // Domain - Notifications

            #endregion


            #region Domain Notification
            services.AddScoped<INotificator, Notificator>();
            #endregion

            #region Infra
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<Backend_ApiNetCore3_1Context>();
            #endregion




        }
    }
}