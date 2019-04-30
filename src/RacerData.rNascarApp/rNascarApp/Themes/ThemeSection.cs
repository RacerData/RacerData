using System.Collections.Generic;
using System.Windows.Forms;

namespace RacerData.rNascarApp.Themes
{
    public class ThemeSection
    {
        public string Name { get; set; }
        public IList<Control> Controls { get; set; } = new List<Control>();
    }
}
