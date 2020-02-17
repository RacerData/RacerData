using System;

namespace RacerData.iRacing.SessionMonitor.ViewModels
{
    public class SessionLapViewModel
    {
        public int SessionLapNumber { get; set; }
        public int RunLapNumber { get; set; }
        public Single LapTime { get; set; }
        public SessionLapStatus Status { get; set; }

        public override string ToString()
        {
            return $"{RunLapNumber,-3} {LapTime}";
        }
    }
}
