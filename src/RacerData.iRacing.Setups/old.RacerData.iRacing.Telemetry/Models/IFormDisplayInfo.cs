using System.Collections.Generic;
using System.Windows.Forms;

namespace RacerData.iRacing.Telemetry.Models
{
    public interface IFormDisplayInfo
    {
        DisplayTypes DisplayType { get; set; }

        IList<FieldDisplayInfo> DisplayFields { get; set; }

        string Title { get; set; }
        string Name { get; set; }
        int X { get; set; }
        int Y { get; set; }
        int Height { get; set; }
        int Width { get; set; }
        FormWindowState WindowState { get; set; }
        string DisplayData { get; set; }
    }
}
