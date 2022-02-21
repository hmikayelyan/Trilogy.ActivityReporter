using Microsoft.Extensions.Options;
using Trilogy.ActivityReporter.DataModels.ConfigurationModels;
using Trilogy.ActivityReporter.DataModels.Configurations.Interfaces;

namespace Trilogy.ActivityReporter.DataModels.Configurations.Impl
{
    public class AppConfiguration : IAppConfiguration
    {
        private readonly IOptions<AppCfgModel> _appConfiguration;
        public AppConfiguration()
        {
        }

        public AppConfiguration(IOptions<AppCfgModel> appConfiguration)
        {
            _appConfiguration = appConfiguration;
        }

        public AppCfgModel GetAppConfiguration()
        {
            return _appConfiguration.Value;
        }
    }
}