using AutoMapper;

namespace RacerData.iRacing.Setups.ClassBuilder
{
    public class TelemetryFileInfoMappingProfile : Profile
    {
        public TelemetryFileInfoMappingProfile()
        {
            CreateMap<Telemetry.Sdk.Models.TelemetryFileInfo, Sessions.Models.TelemetryFileInfo>()
                .ForMember(m => m.Id, opts => opts.Ignore())
                .ForMember(m => m.Name, opts => opts.MapFrom(src => src.Name))
                .ForMember(m => m.FullPath, opts => opts.MapFrom(src => src.FullPath))
                .ForMember(m => m.Size, opts => opts.MapFrom(src => src.Size))
                .ForMember(m => m.Year, opts => opts.MapFrom(src => src.Year))
                .ForMember(m => m.Season, opts => opts.MapFrom(src => src.Season))
                .ForMember(m => m.Week, opts => opts.MapFrom(src => src.Week))
                .ForMember(m => m.TimeOfDay, opts => opts.MapFrom(src => src.TimeOfDay))
                .ForMember(m => m.Date, opts => opts.MapFrom(src => src.Date))
                .ForMember(m => m.ActiveSessionIndex, opts => opts.MapFrom(src => src.ActiveSessionIndex))
                .ForMember(m => m.SeasonId, opts => opts.MapFrom(src => src.SeasonId))
                .ForMember(m => m.SeriesId, opts => opts.MapFrom(src => src.SeriesId))
                .ForMember(m => m.SessionId, opts => opts.MapFrom(src => src.SessionId))
                .ForMember(m => m.LapsCompleted, opts => opts.MapFrom(src => src.LapsCompleted))
                .ForMember(m => m.SubSessionId, opts => opts.MapFrom(src => src.SubSessionId))
                .ForMember(m => m.EventType, opts => opts.MapFrom(src => src.EventType))
                .ForMember(m => m.SessionType, opts => opts.MapFrom(src => src.SessionType))
                .ForMember(m => m.Timestamp, opts => opts.MapFrom(src => src.Timestamp))
                .ForMember(m => m.TrackId, opts => opts.MapFrom(src => src.TrackId))
                .ForMember(m => m.VehicleId, opts => opts.MapFrom(src => src.VehicleId))
                .ForMember(m => m.Track, opts => opts.MapFrom(src => src.Track))
                .ForMember(m => m.Vehicle, opts => opts.MapFrom(src => src.Vehicle))
                .ForMember(m => m.Comments, opts => opts.MapFrom(src => src.Comments))
                .ForMember(m => m.HasError, opts => opts.MapFrom(src => src.HasError))
                .ForMember(m => m.Error, opts => opts.MapFrom(src => src.Error))
                .ForMember(m => m.IsProcessed, opts => opts.Ignore());

            CreateMap<Sessions.Models.TelemetryFileInfo, Telemetry.Sdk.Models.TelemetryFileInfo>()
                .ForMember(m => m.Name, opts => opts.MapFrom(src => src.Name))
                .ForMember(m => m.FullPath, opts => opts.MapFrom(src => src.FullPath))
                .ForMember(m => m.Size, opts => opts.MapFrom(src => src.Size))
                .ForMember(m => m.Year, opts => opts.MapFrom(src => src.Year))
                .ForMember(m => m.Season, opts => opts.MapFrom(src => src.Season))
                .ForMember(m => m.Week, opts => opts.MapFrom(src => src.Week))
                .ForMember(m => m.TimeOfDay, opts => opts.MapFrom(src => src.TimeOfDay))
                .ForMember(m => m.Date, opts => opts.MapFrom(src => src.Date))
                .ForMember(m => m.ActiveSessionIndex, opts => opts.MapFrom(src => src.ActiveSessionIndex))
                .ForMember(m => m.SeasonId, opts => opts.MapFrom(src => src.SeasonId))
                .ForMember(m => m.SeriesId, opts => opts.MapFrom(src => src.SeriesId))
                .ForMember(m => m.SessionId, opts => opts.MapFrom(src => src.SessionId))
                .ForMember(m => m.LapsCompleted, opts => opts.MapFrom(src => src.LapsCompleted))
                .ForMember(m => m.SubSessionId, opts => opts.MapFrom(src => src.SubSessionId))
                .ForMember(m => m.EventType, opts => opts.MapFrom(src => src.EventType))
                .ForMember(m => m.SessionType, opts => opts.MapFrom(src => src.SessionType))
                .ForMember(m => m.Timestamp, opts => opts.MapFrom(src => src.Timestamp))
                .ForMember(m => m.TrackId, opts => opts.MapFrom(src => src.TrackId))
                .ForMember(m => m.VehicleId, opts => opts.MapFrom(src => src.VehicleId))
                .ForMember(m => m.Track, opts => opts.MapFrom(src => src.Track))
                .ForMember(m => m.Vehicle, opts => opts.MapFrom(src => src.Vehicle))
                .ForMember(m => m.Comments, opts => opts.MapFrom(src => src.Comments))
                .ForMember(m => m.HasError, opts => opts.MapFrom(src => src.HasError))
                .ForMember(m => m.Error, opts => opts.MapFrom(src => src.Error));
        }
    }
}
