using Trilogy.ActivityReporter.DAL.Context.Entities;

namespace Trilogy.ActivityReporter.DAL
{
    public interface IUnitOfWork
    {
        Repository.IRepository<Activity> ActivityRepository { get; }
        IUnitOwner Owner { get; }
    }
}