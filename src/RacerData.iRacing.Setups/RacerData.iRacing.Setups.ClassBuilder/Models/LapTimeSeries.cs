using System.Collections.Generic;
using System.Drawing;
using RacerData.iRacing.Telemetry;

namespace RacerData.iRacing.Setups.ClassBuilder.Models
{
    public class LapTimeSeries
    {
        public string Title { get; set; }
        public IList<ILapInfo> Laps { get; set; } = new List<ILapInfo>();
        public Color SeriesLineColor { get; set; } = Color.White;
        public float SeriesLineWidth { get; set; } = .5F;
    }
}
