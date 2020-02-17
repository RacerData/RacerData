using AutoMapper;
using RacerData.iRacing.Service.Sessions.Data.Models;
using RacerData.iRacing.Sessions.Models;

namespace RacerData.iRacing.Service.Sessions.Mapping
{
    internal class TelemetryFileInfoMappingProfile : Profile
    {
        public TelemetryFileInfoMappingProfile()
        {
            CreateMap<TelemetryFileInfoModel, TelemetryFileInfo>()
                .ReverseMap();
        }
    }
}
