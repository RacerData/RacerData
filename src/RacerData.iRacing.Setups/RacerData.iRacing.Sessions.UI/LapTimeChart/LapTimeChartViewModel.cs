using System.Collections.Generic;
using System.Drawing;

namespace RacerData.iRacing.Sessions.Ui.LapTimeChart
{
    public class LapTimeChartViewModel
    {
        public string Title { get; set; }
        public int RunId { get; set; }
        public IList<LapInfo> Laps { get; set; } = new List<LapInfo>();
        public Color SeriesLineColor { get; set; } = Color.White;
        public float SeriesLineWidth { get; set; } = .5F;

        public class LapInfo
        {
            public int LapNumber { get; set; }
            public float LapTime { get; set; }
            public float LapSpeed { get; set; }
        }
    }
}
