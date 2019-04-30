using AutoMapper;
using RacerData.NascarApi.Client.Models.LiveFeed;
using NascarApiLiveFeed = RacerData.NascarApi.Models.LiveFeed;

namespace RacerData.NascarApi.Client.Mapping.LiveFeed
{
    public class StageMappingProfile : Profile
    {
        public StageMappingProfile()
        {
            CreateMap<NascarApiLiveFeed.Stage, Stage>()
              .ForMember(m => m.StageNumber, opts => opts.MapFrom(src => src.stage_num))
              .ForMember(m => m.LapsInStage, opts => opts.MapFrom(src => src.laps_in_stage))
              .ForMember(m => m.FinishAtLap, opts => opts.MapFrom(src => src.finish_at_lap));
        }
    }
}
