using AutoMapper;
using RacerData.iRacing.Service.Sessions.Data.Models;
using RacerData.iRacing.Sessions.Models;

namespace RacerData.iRacing.Service.Sessions.Mapping
{
    internal class TelemetryDataMappingProfile : Profile
    {
        public TelemetryDataMappingProfile()
        {
            CreateMap<TelemetryModel, TelemetryData>()
                   .ForMember(m => m.Id, opts => opts.MapFrom(src => src.Id))
                   .ForMember(m => m.FileName, opts => opts.MapFrom(src => src.FileName))
                   .ForMember(m => m.FullPath, opts => opts.MapFrom(src => src.FullPath))
                   .ForMember(m => m.Timestamp, opts => opts.MapFrom(src => src.Timestamp))
                   //.ForMember(m => m.Data, opts => opts.MapFrom(src => src.Data))
                   .ForMember(m => m.Data, opts => opts.Ignore())
                   .ReverseMap();
        }
    }
}
