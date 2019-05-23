using System.ComponentModel;
using System.Drawing;

namespace RacerData.Themes.UI.Models
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class ToolStripMap
    {
        public virtual Color ToolStripBorder { get; set; }

        public virtual Color ToolStripGradientBegin { get; set; }
        public virtual Color ToolStripGradientMiddle { get; set; }
        public virtual Color ToolStripGradientEnd { get; set; }

        public virtual Color ToolStripPanelGradientBegin { get; set; }
        public virtual Color ToolStripPanelGradientEnd { get; set; }

        public virtual Color ToolStripDropDownBackground { get; set; }

        public virtual Color ToolStripContentPanelGradientBegin { get; set; }
        public virtual Color ToolStripContentPanelGradientEnd { get; set; }

        public virtual Color CheckBackground { get; set; }
        public virtual Color CheckSelectedBackground { get; set; }
        public virtual Color CheckPressedBackground { get; set; }

        public virtual Color ButtonSelectedGradientBegin { get; set; }
        public virtual Color ButtonSelectedGradientMiddle { get; set; }
        public virtual Color ButtonSelectedGradientEnd { get; set; }

        public virtual Color ButtonSelectedBorder { get; set; }
        public virtual Color ButtonSelectedHighlightBorder { get; set; }

        public virtual Color ButtonCheckedGradientBegin { get; set; }
        public virtual Color ButtonCheckedGradientMiddle { get; set; }
        public virtual Color ButtonCheckedGradientEnd { get; set; }

        public virtual Color ButtonCheckedHighlight { get; set; }
        public virtual Color ButtonCheckedHighlightBorder { get; set; }

        public virtual Color ButtonPressedHighlight { get; set; }
        public virtual Color ButtonPressedHighlightBorder { get; set; }
        public virtual Color ButtonPressedBorder { get; set; }

        public virtual Color ButtonPressedGradientBegin { get; set; }
        public virtual Color ButtonPressedGradientMiddle { get; set; }
        public virtual Color ButtonPressedGradientEnd { get; set; }
    }
}
