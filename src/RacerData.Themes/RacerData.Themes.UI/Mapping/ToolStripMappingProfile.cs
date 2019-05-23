using AutoMapper;
using RacerData.Themes.UI.ColorTables;
using RacerData.Themes.UI.Models;

namespace RacerData.Themes.UI.Mapping
{
    public class ToolStripMappingProfile : Profile
    {
        public ToolStripMappingProfile()
        {
            CreateMap<ToolStripMap, CustomColorTable>()
             .ForMember(m => m.ToolStripBorder, opts => opts.MapFrom(src => src.ToolStripBorder))

             .ForMember(m => m.ToolStripGradientBegin, opts => opts.MapFrom(src => src.ToolStripGradientBegin))
             .ForMember(m => m.ToolStripGradientMiddle, opts => opts.MapFrom(src => src.ToolStripGradientMiddle))
             .ForMember(m => m.ToolStripGradientEnd, opts => opts.MapFrom(src => src.ToolStripGradientEnd))

             .ForMember(m => m.ToolStripPanelGradientBegin, opts => opts.MapFrom(src => src.ToolStripPanelGradientBegin))
             .ForMember(m => m.ToolStripPanelGradientEnd, opts => opts.MapFrom(src => src.ToolStripPanelGradientEnd))

             .ForMember(m => m.ToolStripDropDownBackground, opts => opts.MapFrom(src => src.ToolStripDropDownBackground))

             .ForMember(m => m.ToolStripContentPanelGradientBegin, opts => opts.MapFrom(src => src.ToolStripContentPanelGradientBegin))
             .ForMember(m => m.ToolStripContentPanelGradientEnd, opts => opts.MapFrom(src => src.ToolStripContentPanelGradientEnd))

             .ForMember(m => m.CheckBackground, opts => opts.MapFrom(src => src.CheckBackground))
             .ForMember(m => m.CheckSelectedBackground, opts => opts.MapFrom(src => src.CheckSelectedBackground))
             .ForMember(m => m.CheckPressedBackground, opts => opts.MapFrom(src => src.CheckPressedBackground))

             .ForMember(m => m.ButtonCheckedHighlight, opts => opts.MapFrom(src => src.ButtonCheckedHighlight))
             .ForMember(m => m.ButtonCheckedHighlightBorder, opts => opts.MapFrom(src => src.ButtonCheckedHighlightBorder))

             .ForMember(m => m.ButtonSelectedGradientBegin, opts => opts.MapFrom(src => src.ButtonSelectedGradientBegin))
             .ForMember(m => m.ButtonSelectedGradientMiddle, opts => opts.MapFrom(src => src.ButtonSelectedGradientMiddle))
             .ForMember(m => m.ButtonSelectedGradientEnd, opts => opts.MapFrom(src => src.ButtonSelectedGradientEnd))

             .ForMember(m => m.ButtonSelectedBorder, opts => opts.MapFrom(src => src.ButtonSelectedBorder))
             .ForMember(m => m.ButtonSelectedHighlightBorder, opts => opts.MapFrom(src => src.ButtonSelectedHighlightBorder))

             .ForMember(m => m.ButtonCheckedGradientBegin, opts => opts.MapFrom(src => src.ButtonCheckedGradientBegin))
             .ForMember(m => m.ButtonCheckedGradientMiddle, opts => opts.MapFrom(src => src.ButtonCheckedGradientMiddle))
             .ForMember(m => m.ButtonCheckedGradientEnd, opts => opts.MapFrom(src => src.ButtonCheckedGradientEnd))

             .ForMember(m => m.ButtonPressedHighlight, opts => opts.MapFrom(src => src.ButtonPressedHighlight))
             .ForMember(m => m.ButtonPressedHighlightBorder, opts => opts.MapFrom(src => src.ButtonPressedHighlightBorder))
             .ForMember(m => m.ButtonPressedBorder, opts => opts.MapFrom(src => src.ButtonPressedBorder))

             .ForMember(m => m.ButtonPressedGradientBegin, opts => opts.MapFrom(src => src.ButtonPressedGradientBegin))
             .ForMember(m => m.ButtonPressedGradientMiddle, opts => opts.MapFrom(src => src.ButtonPressedGradientMiddle))
             .ForMember(m => m.ButtonPressedGradientEnd, opts => opts.MapFrom(src => src.ButtonPressedGradientEnd))
             .ReverseMap();
        }
    }
}
