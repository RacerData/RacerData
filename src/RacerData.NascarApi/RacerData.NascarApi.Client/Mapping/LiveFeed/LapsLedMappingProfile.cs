using AutoMapper;
using RacerData.NascarApi.Client.Models.LiveFeed;
using NascarApiLiveFeed = RacerData.NascarApi.Models.LiveFeed;

namespace RacerData.NascarApi.Client.Mapping.LiveFeed
{
    public class LapsLedMappingProfile : Profile
    {
        public LapsLedMappingProfile()
        {
            CreateMap<NascarApiLiveFeed.LapsLed, LapsLed>()
              .ForMember(m => m.StartLap, opts => opts.MapFrom(src => src.start_lap))
              .ForMember(m => m.EndLap, opts => opts.MapFrom(src => src.end_lap));
        }
    }
}
