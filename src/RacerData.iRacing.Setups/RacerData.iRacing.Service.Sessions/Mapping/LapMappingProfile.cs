using AutoMapper;
using RacerData.iRacing.Service.Sessions.Data.Models;
using RacerData.iRacing.Sessions.Models;

namespace RacerData.iRacing.Service.Sessions.Mapping
{
    class LapMappingProfile : Profile
    {
        public LapMappingProfile()
        {
            CreateMap<LapModel, Lap>()
                  .ForMember(m => m.Id, opts => opts.MapFrom(src => src.Id))
                  .ForMember(m => m.LapNumber, opts => opts.MapFrom(src => src.LapNumber))
                  .ForMember(m => m.OverallLapNumber, opts => opts.MapFrom(src => src.OverallLapNumber))
                  .ForMember(m => m.LapTime, opts => opts.MapFrom(src => src.LapTime))
                  .ForMember(m => m.LapSpeed, opts => opts.MapFrom(src => src.LapSpeed))
                  .ForMember(m => m.IsValid, opts => opts.MapFrom(src => src.IsValid))
                  .ReverseMap();
        }
    }
}
