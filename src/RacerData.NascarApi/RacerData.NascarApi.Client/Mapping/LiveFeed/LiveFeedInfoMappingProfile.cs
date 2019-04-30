using AutoMapper;
using RacerData.NascarApi.Client.Models.LiveFeed;
using RacerData.NascarApi.Models;

namespace RacerData.NascarApi.Client.Mapping.LiveFeed
{
    public class LiveFeedInfoMappingProfile : Profile
    {
        public LiveFeedInfoMappingProfile()
        {
            CreateMap<EventSettings, LiveFeedInfo>()
                .ForMember(m => m.RaceId, opts => opts.MapFrom(src => src.race_id))
                .ForMember(m => m.Series, opts => opts.MapFrom(src => src.series_id))
                .ForMember(m => m.TrackId, opts => opts.MapFrom(src => src.track_id))
                .ForMember(m => m.TrackLength, opts => opts.MapFrom(src => src.track_length))
                .ForMember(m => m.RunId, opts => opts.MapFrom(src => src.run_id))
                .ForMember(m => m.RunName, opts => opts.MapFrom(src => src.run_name))
                .ForMember(m => m.RunType, opts => opts.MapFrom(src => src.run_type))
                .ReverseMap();
        }
    }
}
