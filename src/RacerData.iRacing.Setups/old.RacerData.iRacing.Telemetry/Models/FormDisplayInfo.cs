using System.Collections.Generic;
using System.Windows.Forms;

namespace RacerData.iRacing.Telemetry.Models
{
    public class FormDisplayInfo : IFormDisplayInfo
    {
        public DisplayTypes DisplayType { get; set; }

        public IList<FieldDisplayInfo> DisplayFields { get; set; }

        public string Title { get; set; }
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public FormWindowState WindowState { get; set; }
        public string DisplayData { get; set; }

        public FormDisplayInfo()
        {
            DisplayFields = new List<FieldDisplayInfo>();
        }
    }
}
