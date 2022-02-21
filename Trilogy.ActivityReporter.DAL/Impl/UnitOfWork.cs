using Trilogy.ActivityReporter.DAL.Context.Entities;
using Trilogy.ActivityReporter.DataModels.Configurations.Interfaces;

namespace Trilogy.ActivityReporter.DAL.Impl
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IUnitOwner _unitOwner;
        private readonly IAppConfiguration _appConfiguration;

        IUnitOwner IUnitOfWork.Owner => _unitOwner;

        public UnitOfWork(IUnitOwner unitOwner, IAppConfiguration appConfiguration)
        {
            _unitOwner = unitOwner;
            _appConfiguration = appConfiguration;
        }

        private Repository.IRepository<Activity> _activityRepository;
        public Repository.IRepository<Activity> ActivityRepository
        {
            get
            {
                return _activityRepository ??= new Repository.Repository<Activity>(_unitOwner, _appConfiguration);
            }
        }
    }
}