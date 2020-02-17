using AutoMapper;
using RacerData.iRacing.Service.Sessions.Data.Models;
using RacerData.iRacing.Sessions.Models;

namespace RacerData.iRacing.Service.Sessions.Mapping
{
    internal class TrackMappingProfile : Profile
    {
        public TrackMappingProfile()
        {
            CreateMap<TrackModel, Track>()
                   .ForMember(m => m.Id, opts => opts.MapFrom(src => src.Id))
                   .ForMember(m => m.Name, opts => opts.MapFrom(src => src.Name))
                   .ForMember(m => m.Length, opts => opts.MapFrom(src => src.Length))
                   .ForMember(m => m.Banking, opts => opts.MapFrom(src => src.Banking))
                   .ReverseMap();
        }
    }
}
