using AutoMapper;
using RacerData.iRacing.Service.Sessions.Data.Models;
using RacerData.iRacing.Sessions.Models;

namespace RacerData.iRacing.Service.Sessions.Mapping
{
    internal class VehicleMappingProfile : Profile
    {
        public VehicleMappingProfile()
        {
            CreateMap<VehicleModel, Vehicle>()
                   .ForMember(m => m.Id, opts => opts.MapFrom(src => src.Id))
                   .ForMember(m => m.ScreenName, opts => opts.MapFrom(src => src.ScreenName))
                   .ForMember(m => m.ScreenNameShort, opts => opts.MapFrom(src => src.ScreenNameShort))
                   .ForMember(m => m.ClassShortName, opts => opts.MapFrom(src => src.ClassShortName))
                   .ForMember(m => m.Path, opts => opts.MapFrom(src => src.Path))
                   .ReverseMap();
        }
    }
}
