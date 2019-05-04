namespace RacerData.NascarApi.Client.Models.LivePit
{
    public class LivePitData
    {
        public string CarNumber { get; set; }
        public string FullName { get; set; }
        public string VehicleManufacturer { get; set; }
        public int LeaderLap { get; set; }
        public int LapCount { get; set; }
        public TrackState PitInFlagStatus { get; set; }
        public TrackState PitOutFlagStatus { get; set; }
        public double PitInRaceTime { get; set; }
        public double PitOutRaceTime { get; set; }
        public double TotalDuration { get; set; }
        public double BoxStopRaceTime { get; set; }
        public double BoxLeaveRaceTime { get; set; }
        public double PitStopDuration { get; set; }
        public double InTravelDuration { get; set; }
        public double OutTravelDuration { get; set; }
        public string PitStopType { get; set; }
        public bool LFTireChanged { get; set; }
        public bool LRTireChanged { get; set; }
        public bool RFTireChanged { get; set; }
        public bool RRTireChanged { get; set; }
        public int PreviousLapTime { get; set; }
        public int NextLapTime { get; set; }
    }
}
