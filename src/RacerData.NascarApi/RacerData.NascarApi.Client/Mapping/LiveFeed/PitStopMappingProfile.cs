using AutoMapper;
using RacerData.NascarApi.Client.Models.LiveFeed;
using NascarApiLiveFeed = RacerData.NascarApi.Models.LiveFeed;

namespace RacerData.NascarApi.Client.Mapping.LiveFeed
{
    public class PitStopMappingProfile : Profile
    {
        public PitStopMappingProfile()
        {
            CreateMap<NascarApiLiveFeed.PitStop, PitStop>()
              .ForMember(m => m.PositionDelta, opts => opts.MapFrom(src => src.positions_gained_lossed))
              .ForMember(m => m.PitInElapsed , opts => opts.MapFrom(src => src.pit_in_elapsed_time))
              .ForMember(m => m.PitOutElapsed, opts => opts.MapFrom(src => src.pit_out_elapsed_time))
              .ForMember(m => m.PitInLap, opts => opts.MapFrom(src => src.pit_in_lap_count))
              .ForMember(m => m.PitInLeaderLap, opts => opts.MapFrom(src => src.pit_in_leader_lap));
        }
    }
}
