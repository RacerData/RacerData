using System.ComponentModel;
using System.Drawing;

namespace RacerData.Themes.UI.Models
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class ColorMap
    {
        public virtual Color SeparatorDark { get; set; } = Color.LimeGreen;
        public virtual Color SeparatorLight { get; set; }

        public virtual Color RaftingContainerGradientBegin { get; set; }
        public virtual Color RaftingContainerGradientEnd { get; set; }

        public StatusStripMap StatusStripMap { get; set; }
        public MenuStripMap MenuStripMap { get; set; }
        public ToolStripMap ToolStripMap { get; set; }

        public ColorMap()
        {
            StatusStripMap = new StatusStripMap();
            MenuStripMap = new MenuStripMap();
            ToolStripMap = new ToolStripMap();
        }
    }
}