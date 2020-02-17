using System;

namespace RacerData.iRacing.SessionMonitor.ViewModels
{
    class LapComparison
    {
        public int LapNumber { get; set; }
        public Single? FirstLapTime { get; set; }
        public Single? SecondLapTime { get; set; }
        public Single? LapDelta { get; set; }
        public Single? RunDelta { get; set; }
    }
}
