using System.Collections.Concurrent;
using Trilogy.ActivityReporter.DAL.Context.Entities;

namespace Trilogy.ActivityReporter.DAL.Context
{
    public class InMemoryContext<TEntity> where TEntity : BaseEntityClass
    {
        private static readonly ConcurrentDictionary<string, List<TEntity>> _activityValues = new ConcurrentDictionary<string, List<TEntity>>();

        public static bool Add(string key, TEntity activity)
        {
            if (_activityValues.TryGetValue(key, out var activityValues))
            {
                activityValues.Add(activity);
                return true;
            }
            return _activityValues.TryAdd(key, new List<TEntity> { activity });
        }

        public static List<TEntity>? GetAll(string key, DateTime utcNow, int expirationHours)
        {
            if (_activityValues.TryGetValue(key, out var activityValues))
            {
                activityValues.RemoveAll(x => x.CreatedAt.AddHours(expirationHours) < utcNow);
                if (!activityValues.Any())
                {
                    _activityValues.TryRemove(key, out var activity);
                    return null;
                }
                return activityValues;
            }
            return null;
        }
    }
}