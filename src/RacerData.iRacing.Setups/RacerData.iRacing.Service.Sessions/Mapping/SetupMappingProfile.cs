using AutoMapper;
using RacerData.iRacing.Service.Sessions.Data.Models;
using RacerData.iRacing.Sessions.Models;

namespace RacerData.iRacing.Service.Sessions.Mapping
{
    internal class SetupMappingProfile : Profile
    {
        public SetupMappingProfile()
        {
            CreateMap<SetupModel, Setup>()
                   .ForMember(m => m.Id, opts => opts.MapFrom(src => src.Id))
                   .ForMember(m => m.Name, opts => opts.MapFrom(src => src.Name))
                   .ForMember(m => m.Season, opts => opts.MapFrom(src => src.Season))
                   .ForMember(m => m.Year, opts => opts.MapFrom(src => src.Year))
                   .ForMember(m => m.UpdateCount, opts => opts.MapFrom(src => src.UpdateCount))
                   .ForMember(m => m.ExportHtml, opts => opts.MapFrom(src => src.ExportHtml))
                   .ForMember(m => m.SetupData, opts => opts.MapFrom(src => src.SetupData))
                   .ForMember(m => m.VehicleId, opts => opts.MapFrom(src => src.VehicleId))
                   .ForMember(m => m.Vehicle, opts => opts.MapFrom(src => src.Vehicle))
                   .ReverseMap();
        }
    }
}
