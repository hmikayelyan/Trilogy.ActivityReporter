namespace Trilogy.ActivityReporter.DAL.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        List<TEntity>? Get(string key);
        bool Add(string key, TEntity entity);
    }
}