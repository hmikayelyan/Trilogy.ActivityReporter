using AutoMapper;
using Trilogy.ActivityReporter.DAL.Context.Entities;
using Trilogy.ActivityReporter.DataModels.Models;

namespace Trilogy.ActivityReporter.BLL.Common
{
    public class ActivityMapper : Profile
    {
        public ActivityMapper()
        {
            CreateMap<ValueModel, Activity>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => Math.Round(src.Value, 0)));
            CreateMap<int, ValueModel>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src));
        }
    }
}