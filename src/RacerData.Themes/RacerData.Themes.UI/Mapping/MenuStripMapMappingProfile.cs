using System.Windows.Forms;
using AutoMapper;
using RacerData.Themes.UI.ColorTables;
using RacerData.Themes.UI.Models;

namespace RacerData.Themes.UI.Mapping
{
    public class MenuStripMapMappingProfile : Profile
    {
        public MenuStripMapMappingProfile()
        {
            CreateMap<MenuStripMap, CustomColorTable>()
             .ForMember(m => m.MenuBorder, opts => opts.MapFrom(src => src.MenuBorder))
             .ForMember(m => m.MenuItemBorder, opts => opts.MapFrom(src => src.MenuItemBorder))

             .ForMember(m => m.MenuItemSelected, opts => opts.MapFrom(src => src.MenuItemSelected))

             .ForMember(m => m.MenuStripGradientBegin, opts => opts.MapFrom(src => src.MenuStripGradientBegin))
             .ForMember(m => m.MenuStripGradientEnd, opts => opts.MapFrom(src => src.MenuStripGradientEnd))

             .ForMember(m => m.MenuItemSelectedGradientBegin, opts => opts.MapFrom(src => src.MenuItemSelectedGradientBegin))
             .ForMember(m => m.MenuItemSelectedGradientEnd, opts => opts.MapFrom(src => src.MenuItemSelectedGradientEnd))

             .ForMember(m => m.MenuItemPressedGradientBegin, opts => opts.MapFrom(src => src.MenuItemPressedGradientBegin))
             .ForMember(m => m.MenuItemPressedGradientMiddle, opts => opts.MapFrom(src => src.MenuItemPressedGradientMiddle))
             .ForMember(m => m.MenuItemPressedGradientEnd, opts => opts.MapFrom(src => src.MenuItemPressedGradientEnd))

             .ForMember(m => m.ImageMarginGradientBegin, opts => opts.MapFrom(src => src.ImageMarginGradientBegin))
             .ForMember(m => m.ImageMarginGradientMiddle, opts => opts.MapFrom(src => src.ImageMarginGradientMiddle))
             .ForMember(m => m.ImageMarginGradientEnd, opts => opts.MapFrom(src => src.ImageMarginGradientEnd))

             .ForMember(m => m.ImageMarginRevealedGradientBegin, opts => opts.MapFrom(src => src.ImageMarginRevealedGradientBegin))
             .ForMember(m => m.ImageMarginRevealedGradientMiddle, opts => opts.MapFrom(src => src.ImageMarginRevealedGradientMiddle))
             .ForMember(m => m.ImageMarginRevealedGradientEnd, opts => opts.MapFrom(src => src.ImageMarginRevealedGradientEnd))
             .ReverseMap();
        }
    }
}
