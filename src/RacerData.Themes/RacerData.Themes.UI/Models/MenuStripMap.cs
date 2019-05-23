using System.ComponentModel;
using System.Drawing;

namespace RacerData.Themes.UI.Models
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class MenuStripMap
    {
        public virtual Color MenuBorder { get; set; }

        public virtual Color MenuItemSelected { get; set; }
        public virtual Color MenuItemBorder { get; set; }

        public virtual Color MenuStripGradientBegin { get; set; }
        public virtual Color MenuStripGradientEnd { get; set; }

        public virtual Color MenuItemSelectedGradientBegin { get; set; }
        public virtual Color MenuItemSelectedGradientEnd { get; set; }

        public virtual Color MenuItemPressedGradientBegin { get; set; }
        public virtual Color MenuItemPressedGradientMiddle { get; set; }
        public virtual Color MenuItemPressedGradientEnd { get; set; }

        public virtual Color ImageMarginGradientBegin { get; set; }
        public virtual Color ImageMarginGradientMiddle { get; set; }
        public virtual Color ImageMarginGradientEnd { get; set; }

        public virtual Color ImageMarginRevealedGradientBegin { get; set; }
        public virtual Color ImageMarginRevealedGradientMiddle { get; set; }
        public virtual Color ImageMarginRevealedGradientEnd { get; set; }

        public virtual Color OverflowButtonGradientBegin { get; set; }
        public virtual Color OverflowButtonGradientMiddle { get; set; }
        public virtual Color OverflowButtonGradientEnd { get; set; }
    }
}