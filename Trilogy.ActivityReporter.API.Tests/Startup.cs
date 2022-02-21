using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trilogy.ActivityReporter.BLL.Common;
using Trilogy.ActivityReporter.DataModels.ConfigurationModels;
using Xunit.Abstractions;
using Xunit.DependencyInjection;

namespace Trilogy.ActivityReporter.API.Tests
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            ServiceProvider? provider = services.BuildServiceProvider();
            var configuration = provider.GetRequiredService<IConfiguration>();
            services.Configure<AppCfgModel>(options =>
            {
                configuration.GetSection("AppConfiguration").Bind(options);
            });
            services.AddServices();
        }
    }
}
