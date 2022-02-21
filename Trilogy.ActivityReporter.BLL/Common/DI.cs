using Microsoft.Extensions.DependencyInjection;
using Trilogy.ActivityReporter.BLL.Impl;
using Trilogy.ActivityReporter.BLL.Interfaces;
using Trilogy.ActivityReporter.DAL;
using Trilogy.ActivityReporter.DAL.Impl;
using Trilogy.ActivityReporter.DataModels.Configurations.Impl;
using Trilogy.ActivityReporter.DataModels.Configurations.Interfaces;

namespace Trilogy.ActivityReporter.BLL.Common
{
    public static class DI
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ActivityMapper));
            services.AddScoped<IUnitOwner, UnitOwner>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IBaseService, BaseService>();
            services.AddTransient<IActivityService, ActivityService>();
            services.AddSingleton<IAppConfiguration, AppConfiguration>();
        }
    }
}