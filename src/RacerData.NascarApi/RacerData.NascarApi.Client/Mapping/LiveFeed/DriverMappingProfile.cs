using AutoMapper;
using RacerData.NascarApi.Client.Models.LiveFeed;
using NascarApiLiveFeed = RacerData.NascarApi.Models.LiveFeed;

namespace RacerData.NascarApi.Client.Mapping.LiveFeed
{
    public class DriverMappingProfile : Profile
    {
        public DriverMappingProfile()
        {
            CreateMap<NascarApiLiveFeed.Driver, Driver>()
               .ForMember(m => m.Id, opts => opts.MapFrom(src => src.driver_id))
               .ForMember(m => m.FirstName, opts => opts.MapFrom(src => src.first_name))
               .ForMember(m => m.LastName, opts => opts.MapFrom(src => src.last_name))
               .ForMember(m => m.IsInChase, opts => opts.MapFrom(src => src.is_in_chase));
        }
    }
}
