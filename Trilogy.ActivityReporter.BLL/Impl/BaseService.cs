using AutoMapper;
using Trilogy.ActivityReporter.BLL.Interfaces;
using Trilogy.ActivityReporter.DAL;

namespace Trilogy.ActivityReporter.BLL.Impl
{
    public class BaseService : IBaseService
    {
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _unitOfWork;
        public BaseService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public void ConfigureUnitOwner()
        {
            _unitOfWork.Owner.Configure();
        }
    }
}