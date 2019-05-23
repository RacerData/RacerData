using AutoMapper;
using RacerData.Themes.UI.ColorTables;
using RacerData.Themes.UI.Models;

namespace RacerData.Themes.UI.Mapping
{
    public class ColorMapMappingProfile : Profile
    {
        public ColorMapMappingProfile()
        {
            CreateMap<CustomColorTable, ColorMap>()
                .ForMember(m => m.SeparatorDark, opts => opts.MapFrom(src => src.SeparatorDarkColor))
                .ForMember(m => m.SeparatorLight, opts => opts.MapFrom(src => src.SeparatorLightColor))
                .ForMember(m => m.StatusStripMap, opts => opts.MapFrom(src => src))
                .ForMember(m => m.MenuStripMap, opts => opts.MapFrom(src => src))
                .ForMember(m => m.ToolStripMap, opts => opts.MapFrom(src => src));

            CreateMap<ColorMap, CustomColorTable>()
                .ForMember(m => m.SeparatorDarkColor, opts => opts.MapFrom(src => src.SeparatorDark))
                .ForMember(m => m.SeparatorLightColor, opts => opts.MapFrom(src => src.SeparatorLight))

                .ForMember(m => m.MenuBorderColor, opts => opts.MapFrom(src => src.MenuStripMap.MenuBorder))
                .ForMember(m => m.HoverHighlightColor, opts => opts.MapFrom(src => src.ToolStripMap.ButtonPressedHighlight))
                .ForMember(m => m.HighlightColor, opts => opts.MapFrom(src => src.ToolStripMap.ButtonPressedHighlight))
                .ForMember(m => m.CheckedHighlightColor, opts => opts.MapFrom(src => src.ToolStripMap.ButtonCheckedHighlight))
                .ForMember(m => m.HighlightBorderColor, opts => opts.MapFrom(src => src.ToolStripMap.ButtonPressedHighlightBorder))

                .ForMember(m => m.PressedBackgroundGradientBegin, opts => opts.MapFrom(src => src.ToolStripMap.ButtonPressedGradientBegin))
                .ForMember(m => m.PressedBackgroundGradientMiddle, opts => opts.MapFrom(src => src.ToolStripMap.ButtonPressedGradientMiddle))
                .ForMember(m => m.PressedBackgroundGradientEnd, opts => opts.MapFrom(src => src.ToolStripMap.ButtonPressedGradientEnd))

                .ForMember(m => m.CheckedBackgroundGradientBegin, opts => opts.MapFrom(src => src.ToolStripMap.ButtonCheckedGradientBegin))
                .ForMember(m => m.CheckedBackgroundGradientMiddle, opts => opts.MapFrom(src => src.ToolStripMap.ButtonCheckedGradientMiddle))
                .ForMember(m => m.CheckedBackgroundGradientEnd, opts => opts.MapFrom(src => src.ToolStripMap.ButtonCheckedGradientEnd))

                .ForMember(m => m.StripBackgroundGradientBegin, opts => opts.MapFrom(src => src.ToolStripMap.ToolStripGradientBegin))
                .ForMember(m => m.StripBackgroundGradientMiddle, opts => opts.MapFrom(src => src.ToolStripMap.ToolStripGradientMiddle))
                .ForMember(m => m.StripBackgroundGradientEnd, opts => opts.MapFrom(src => src.ToolStripMap.ToolStripGradientEnd))

                .ForMember(m => m.HoverBackgroundGradientBegin, opts => opts.MapFrom(src => src.MenuStripMap.MenuItemSelectedGradientBegin))
                .ForMember(m => m.HoverBackgroundGradientEnd, opts => opts.MapFrom(src => src.MenuStripMap.MenuItemSelectedGradientEnd));


            CreateMap<SimpleCustomColorTable, ColorMap>()
               .ForMember(m => m.SeparatorDark, opts => opts.MapFrom(src => src.SeparatorDarkColor))
               .ForMember(m => m.SeparatorLight, opts => opts.MapFrom(src => src.SeparatorLightColor))
               .ForMember(m => m.StatusStripMap, opts => opts.MapFrom(src => src))
               .ForMember(m => m.MenuStripMap, opts => opts.MapFrom(src => src))
               .ForMember(m => m.ToolStripMap, opts => opts.MapFrom(src => src));

            CreateMap<ColorMap, SimpleCustomColorTable>()
                .ForMember(m => m.SeparatorDarkColor, opts => opts.MapFrom(src => src.SeparatorDark))
                .ForMember(m => m.SeparatorLightColor, opts => opts.MapFrom(src => src.SeparatorLight))
                .ForMember(m => m.MenuBorderColor, opts => opts.MapFrom(src => src.MenuStripMap.MenuBorder))
                .ForMember(m => m.CheckedButtonBorderColor, opts => opts.MapFrom(src => src.ToolStripMap.ButtonPressedHighlightBorder))
                .ForMember(m => m.OpenMenuBackColor, opts => opts.MapFrom(src => src.ToolStripMap.ButtonPressedGradientBegin))
                .ForMember(m => m.CheckedButtonBackColor, opts => opts.MapFrom(src => src.ToolStripMap.ButtonCheckedGradientBegin))
                .ForMember(m => m.BackColor, opts => opts.MapFrom(src => src.ToolStripMap.ToolStripGradientBegin))
                .ForMember(m => m.MouseOverBackColor, opts => opts.MapFrom(src => src.MenuStripMap.MenuItemSelectedGradientBegin));

        }
    }
}


