using Trilogy.ActivityReporter.DataModels.ConfigurationModels;

namespace Trilogy.ActivityReporter.DataModels.Configurations.Interfaces
{
    public interface IAppConfiguration
    {
        AppCfgModel GetAppConfiguration();
    }
}