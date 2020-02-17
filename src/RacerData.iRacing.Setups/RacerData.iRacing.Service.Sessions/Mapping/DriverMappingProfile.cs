using AutoMapper;
using RacerData.iRacing.Service.Sessions.Data.Models;
using RacerData.iRacing.Sessions.Models;

namespace RacerData.iRacing.Service.Sessions.Mapping
{
    internal class DriverMappingProfile : Profile
    {
        public DriverMappingProfile()
        {
            CreateMap<DriverModel, Driver>()
                   .ForMember(m => m.Id, opts => opts.MapFrom(src => src.Id))
                   .ForMember(m => m.Name, opts => opts.MapFrom(src => src.Name))
                   .ReverseMap();
        }
    }
}
