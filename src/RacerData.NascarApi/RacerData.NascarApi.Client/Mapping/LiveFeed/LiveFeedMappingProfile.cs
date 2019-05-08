using System;
using AutoMapper;
using RacerData.NascarApi.Client.Models;
using RacerData.NascarApi.Client.Models.LiveFeed;

namespace RacerData.NascarApi.Client.Mapping.LiveFeed
{
    public class LiveFeedMappingProfile : Profile
    {
        public LiveFeedMappingProfile()
        {
            CreateMap<RacerData.NascarApi.Models.LiveFeed.RootObject, LiveFeedData>()
                .ForMember(m => m.Elapsed, opts => opts.MapFrom(src => src.elapsed_time))
                .ForMember(m => m.TimeOfDay, opts => opts.MapFrom(src => DateTime.FromBinary(src.time_of_day)))
                .ForMember(m => m.FlagState, opts => opts.MapFrom(src => (TrackState)src.flag_state))
                .ForMember(m => m.LapNumber, opts => opts.MapFrom(src => src.lap_number))
                .ForMember(m => m.LapsInRace, opts => opts.MapFrom(src => src.laps_in_race))
                .ForMember(m => m.LapsToGo, opts => opts.MapFrom(src => src.laps_to_go))
                .ForMember(m => m.RaceId, opts => opts.MapFrom(src => src.race_id))
                .ForMember(m => m.SeriesType, opts => opts.MapFrom(src => (SeriesType)src.series_id))
                .ForMember(m => m.TrackId, opts => opts.MapFrom(src => src.track_id))
                .ForMember(m => m.TrackLength, opts => opts.MapFrom(src => src.track_length))
                .ForMember(m => m.TrackName, opts => opts.MapFrom(src => src.track_name))
                .ForMember(m => m.RunId, opts => opts.MapFrom(src => src.run_id))
                .ForMember(m => m.RunName, opts => opts.MapFrom(src => src.run_name))
                .ForMember(m => m.RunType, opts => opts.MapFrom(src => (RunType)src.run_type))
                .ForMember(m => m.NumberOfCautions, opts => opts.MapFrom(src => src.number_of_caution_segments))
                .ForMember(m => m.NumberOfCautionLaps, opts => opts.MapFrom(src => src.number_of_caution_laps))
                .ForMember(m => m.Stage, opts => opts.MapFrom(src => src.stage))
                .ForMember(m => m.Vehicles, opts => opts.MapFrom(src => src.vehicles));
        }
    }
}
