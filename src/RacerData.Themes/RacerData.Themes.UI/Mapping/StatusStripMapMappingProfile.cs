using AutoMapper;
using RacerData.Themes.UI.ColorTables;
using RacerData.Themes.UI.Models;

namespace RacerData.Themes.UI.Mapping
{
    public class StatusStripMapMappingProfile : Profile
    {
        public StatusStripMapMappingProfile()
        {
            CreateMap<StatusStripMap, CustomColorTable>()
                .ForMember(m => m.StatusStripGradientBegin, opts => opts.MapFrom(src => src.StatusStripGradientBegin))
                .ForMember(m => m.StatusStripGradientEnd, opts => opts.MapFrom(src => src.StatusStripGradientEnd))

                .ForMember(m => m.GripDark, opts => opts.MapFrom(src => src.GripDark))
                .ForMember(m => m.GripLight, opts => opts.MapFrom(src => src.GripLight))
                .ReverseMap();
        }
    }
}
