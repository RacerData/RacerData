using AutoMapper;
using RacerData.Themes.UI.ColorTables;
using RacerData.Themes.UI.Models;

namespace RacerData.Themes.UI.Mapping
{
    public class ColorMapMappingProfile : Profile
    {
        public ColorMapMappingProfile()
        {
            CreateMap<SimpleColorTable, ColorMap>()
               .ForMember(m => m.SeparatorDark, opts => opts.MapFrom(src => src.SeparatorDarkColor))
               .ForMember(m => m.SeparatorLight, opts => opts.MapFrom(src => src.SeparatorLightColor))
               .ForMember(m => m.StatusStripMap, opts => opts.MapFrom(src => src))
               .ForMember(m => m.MenuStripMap, opts => opts.MapFrom(src => src))
               .ForMember(m => m.ToolStripMap, opts => opts.MapFrom(src => src));

            CreateMap<ColorMap, SimpleColorTable>()
                .ForMember(m => m.SeparatorDarkColor, opts => opts.MapFrom(src => src.SeparatorDark))
                .ForMember(m => m.SeparatorLightColor, opts => opts.MapFrom(src => src.SeparatorLight))
                .ForMember(m => m.MenuStripMouseOverBorderColor, opts => opts.MapFrom(src => src.MenuStripMap.MenuBorder))
                .ForMember(m => m.CheckedBorderColor, opts => opts.MapFrom(src => src.ToolStripMap.ButtonPressedHighlightBorder))
                .ForMember(m => m.OpenMenuBackColor, opts => opts.MapFrom(src => src.ToolStripMap.ButtonPressedGradientBegin))
                .ForMember(m => m.CheckedButtonBackColor, opts => opts.MapFrom(src => src.ToolStripMap.ButtonCheckedGradientBegin))
                .ForMember(m => m.BackColor, opts => opts.MapFrom(src => src.ToolStripMap.ToolStripGradientBegin))
                .ForMember(m => m.MouseOverBackColor, opts => opts.MapFrom(src => src.MenuStripMap.MenuItemSelectedGradientBegin));

        }
    }
}


