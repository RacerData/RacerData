using AutoMapper;
using RacerData.NascarApi.Client.Models.LiveQualifying;
using NascarApiLiveFeed = RacerData.NascarApi.Models.LiveQualifyingData;

namespace RacerData.NascarApi.Client.Mapping.LiveQualifying
{
    class LiveQualitfyingMappingProfile : Profile
    {
        public LiveQualitfyingMappingProfile()
        {
            CreateMap<NascarApiLiveFeed.RootObject, LiveQualifyingData>()
              .ForMember(m => m.DriverId, opts => opts.MapFrom(src => src.driver_id))
              .ForMember(m => m.SeriesId, opts => opts.MapFrom(src => src.series_id))
              .ForMember(m => m.RunId, opts => opts.MapFrom(src => src.run_id))
              .ForMember(m => m.CarNumber, opts => opts.MapFrom(src => src.vehicle_number))
              .ForMember(m => m.Position, opts => opts.MapFrom(src => src.position))
              .ForMember(m => m.FullName, opts => opts.MapFrom(src => src.full_name))
              .ForMember(m => m.QualifyingRound, opts => opts.MapFrom(src => src.qualifying_round))
              .ForMember(m => m.TimeLimit, opts => opts.MapFrom(src => src.time_limit))
              .ForMember(m => m.BestLap, opts => opts.MapFrom(src => src.best_lap))
              .ForMember(m => m.BestLapSpeed, opts => opts.MapFrom(src => src.best_lap_speed))
              .ForMember(m => m.BestLapTime, opts => opts.MapFrom(src => src.best_lap_time))
              .ForMember(m => m.Comment, opts => opts.MapFrom(src => src.comment))
              .ForMember(m => m.IsOnTrack, opts => opts.MapFrom(src => src.is_on_track))
              .ForMember(m => m.IsCurrentRound, opts => opts.MapFrom(src => src.is_current_round))
              .ForMember(m => m.LapsCompleted, opts => opts.MapFrom(src => src.laps_completed))
              .ForMember(m => m.LastLapTime, opts => opts.MapFrom(src => src.last_lap_time));
        }
    }
}
