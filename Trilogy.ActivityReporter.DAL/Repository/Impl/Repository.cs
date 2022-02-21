using Trilogy.ActivityReporter.DAL.Context;
using Trilogy.ActivityReporter.DAL.Context.Entities;
using Trilogy.ActivityReporter.DataModels.Configurations.Interfaces;

namespace Trilogy.ActivityReporter.DAL.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntityClass
    {
        private readonly IUnitOwner _unitOwner;
        private readonly IAppConfiguration _configuration;

        public Repository(IUnitOwner unitOwner, IAppConfiguration configuration)
        {
            _unitOwner = unitOwner;
            _configuration = configuration;
        }

        public virtual bool Add(string key, TEntity entity)
        {
            entity.CreatedAt = _unitOwner.UtcNow;
            return InMemoryContext<TEntity>.Add(key, entity);
        }

        public virtual List<TEntity>? Get(string key)
        {
            return InMemoryContext<TEntity>.GetAll(key, _unitOwner.UtcNow, _configuration.GetAppConfiguration().ActivityExpireTimeInHours);
        }
    }
}