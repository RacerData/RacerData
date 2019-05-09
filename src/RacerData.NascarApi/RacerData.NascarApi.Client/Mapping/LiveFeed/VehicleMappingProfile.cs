using AutoMapper;
using RacerData.NascarApi.Client.Models;
using RacerData.NascarApi.Client.Models.LiveFeed;
using NascarApiLiveFeed = RacerData.NascarApi.Models.LiveFeed;

namespace RacerData.NascarApi.Client.Mapping.LiveFeed
{
    public class VehicleMappingProfile : Profile
    {
        public VehicleMappingProfile()
        {
            CreateMap<NascarApiLiveFeed.Vehicle, Vehicle>()
                .ForMember(m => m.BestLap, opts => opts.MapFrom(src => src.best_lap))
                .ForMember(m => m.BestLapSpeed, opts => opts.MapFrom(src => src.best_lap_speed))
                .ForMember(m => m.BestLapTime, opts => opts.MapFrom(src => src.best_lap_time))
                .ForMember(m => m.CarNumber, opts => opts.MapFrom(src => src.vehicle_number))
                .ForMember(m => m.Delta, opts => opts.MapFrom(src => src.delta))
                .ForMember(m => m.Driver, opts => opts.MapFrom(src => src.driver))
                .ForMember(m => m.IsOnTrack, opts => opts.MapFrom(src => src.is_on_track))
                .ForMember(m => m.LapsCompleted, opts => opts.MapFrom(src => src.laps_completed))
                .ForMember(m => m.LapsLed, opts => opts.MapFrom(src => src.laps_led))
                .ForMember(m => m.LastLapSpeed, opts => opts.MapFrom(src => src.last_lap_speed))
                .ForMember(m => m.LastLapTime, opts => opts.MapFrom(src => src.last_lap_time))
                .ForMember(m => m.Manufacturer, opts => opts.MapFrom(src => src.vehicle_manufacturer))
                .ForMember(m => m.PitStops, opts => opts.MapFrom(src => src.pit_stops))
                .ForMember(m => m.RunningPosition, opts => opts.MapFrom(src => src.running_position))
                .ForMember(m => m.Sponsor, opts => opts.MapFrom(src => src.sponsor_name))
                .ForMember(m => m.StartingPosition, opts => opts.MapFrom(src => src.starting_position))
                .ForMember(m => m.Status, opts => opts.MapFrom(src => (VehicleStatus)src.status))
                .ForMember(m => m.VehicleElapsedTime, opts => opts.MapFrom(src => src.vehicle_elapsed_time));
        }
    }
}
