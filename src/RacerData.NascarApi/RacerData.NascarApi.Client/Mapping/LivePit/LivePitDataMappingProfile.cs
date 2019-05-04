using AutoMapper;
using RacerData.NascarApi.Client.Models;
using RacerData.NascarApi.Client.Models.LivePit;
using NascarApiLiveFeed = RacerData.NascarApi.Models.LivePitData;

namespace RacerData.NascarApi.Client.Mapping.LivePit
{
    public class LivePitDataMappingProfile : Profile
    {
        public LivePitDataMappingProfile()
        {
            CreateMap<NascarApiLiveFeed.RootObject, LivePitData>()
               .ForMember(m => m.CarNumber, opts => opts.MapFrom(src => src.vehicle_number))
               .ForMember(m => m.FullName, opts => opts.MapFrom(src => src.driver_name))
               .ForMember(m => m.VehicleManufacturer, opts => opts.MapFrom(src => src.vehicle_manufacturer))
               .ForMember(m => m.LeaderLap, opts => opts.MapFrom(src => src.leader_lap))
               .ForMember(m => m.LapCount, opts => opts.MapFrom(src => src.lap_count))
               .ForMember(m => m.PitInFlagStatus, opts => opts.MapFrom(src => (TrackState)src.pit_in_flag_status))
               .ForMember(m => m.PitOutFlagStatus, opts => opts.MapFrom(src => (TrackState)src.pit_out_flag_status))
               .ForMember(m => m.PitInRaceTime, opts => opts.MapFrom(src => src.pit_in_race_time))
               .ForMember(m => m.PitOutRaceTime, opts => opts.MapFrom(src => src.pit_out_race_time))
               .ForMember(m => m.TotalDuration, opts => opts.MapFrom(src => src.total_duration))
               .ForMember(m => m.BoxStopRaceTime, opts => opts.MapFrom(src => src.box_stop_race_time))
               .ForMember(m => m.BoxLeaveRaceTime, opts => opts.MapFrom(src => src.box_leave_race_time))
               .ForMember(m => m.PitStopDuration, opts => opts.MapFrom(src => src.pit_stop_duration))
               .ForMember(m => m.InTravelDuration, opts => opts.MapFrom(src => src.in_travel_duration))
               .ForMember(m => m.OutTravelDuration, opts => opts.MapFrom(src => src.out_travel_duration))
               .ForMember(m => m.PitStopType, opts => opts.MapFrom(src => src.pit_stop_type))
               .ForMember(m => m.LFTireChanged, opts => opts.MapFrom(src => src.left_front_tire_changed))
               .ForMember(m => m.LRTireChanged, opts => opts.MapFrom(src => src.left_rear_tire_changed))
               .ForMember(m => m.RFTireChanged, opts => opts.MapFrom(src => src.right_front_tire_changed))
               .ForMember(m => m.RRTireChanged, opts => opts.MapFrom(src => src.right_rear_tire_changed))
               .ForMember(m => m.PreviousLapTime, opts => opts.MapFrom(src => src.previous_lap_time))
               .ForMember(m => m.NextLapTime, opts => opts.MapFrom(src => src.next_lap_time));
        }
    }
}