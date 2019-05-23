using System.ComponentModel;
using System.Drawing;

namespace RacerData.Themes.UI.Models
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class StatusStripMap
    {
        public virtual Color StatusStripGradientBegin { get; set; }
        public virtual Color StatusStripGradientEnd { get; set; }

        public virtual Color GripDark { get; set; }
        public virtual Color GripLight { get; set; }
    }
}