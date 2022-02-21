using AutoMapper;
using Trilogy.ActivityReporter.BLL.Interfaces;
using Trilogy.ActivityReporter.DAL;
using Trilogy.ActivityReporter.DAL.Context.Entities;
using Trilogy.ActivityReporter.DataModels.Models;

namespace Trilogy.ActivityReporter.BLL.Impl
{
    public class ActivityService : BaseService, IActivityService
    {
        public ActivityService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            ConfigureUnitOwner();
        }

        public ValueModel? GetActivities(string key)
        {
            var activitiesSum = _unitOfWork.ActivityRepository.Get(key)?.Select(x => x.Value).Sum();
            return activitiesSum is null ? null : _mapper.Map<ValueModel>(activitiesSum);
        }

        public bool AddActivity(string key, ValueModel value)
        {
            return _unitOfWork.ActivityRepository.Add(key, _mapper.Map<Activity>(value));
        }
    }
}