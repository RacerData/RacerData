using System;
using System.Collections.Generic;
using System.Text;

namespace RacerData.iRacing.Telemetry.Models
{
    internal class LapInfo : ILapInfo
    {
        public int FrameIndex { get; set; }
        public int LapIndex { get; set; }
        public int LapNumber { get; set; }
        public Single LapTime { get; set; }
        public Single LapSpeed { get; set; }
        public irsdk_SessionState SessionState { get; set; }
        public IList<IFrame> LapFrames { get; set; }
        public string Description
        {
            get
            {
                return $"[{LapNumber}] {Math.Round(LapTime, 3)}";
            }
        }
    }
}
