using Trilogy.ActivityReporter.DataModels.Models;

namespace Trilogy.ActivityReporter.BLL.Interfaces
{
    public interface IActivityService : IBaseService
    {
        ValueModel? GetActivities(string key);
        bool AddActivity(string key, ValueModel value);
    }
}