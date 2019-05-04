using System;
using AutoMapper;
using RacerData.NascarApi.Client.Models;
using RacerData.NascarApi.Client.Models.LiveFlag;
using NascarApiLiveFeed = RacerData.NascarApi.Models.LiveFlagData;

namespace RacerData.NascarApi.Client.Mapping.LivePit
{
    public class LiveFlagDataMappingProfile : Profile
    {
        public LiveFlagDataMappingProfile()
        {
            CreateMap<NascarApiLiveFeed.RootObject, LiveFlagData>()
               .ForMember(m => m.LapNumber, opts => opts.MapFrom(src => src.lap_number))
               .ForMember(m => m.FlagState, opts => opts.MapFrom(src => (TrackState)src.flag_state))
               .ForMember(m => m.ElapsedTime, opts => opts.MapFrom(src => src.elapsed_time))
               .ForMember(m => m.Comment, opts => opts.MapFrom(src => src.comment))
               .ForMember(m => m.Beneficiary, opts => opts.MapFrom(src => src.beneficiary))
               .ForMember(m => m.TimeOfDay, opts => opts.MapFrom(src => new TimeSpan((long)src.time_of_day)));
        }
    }
}