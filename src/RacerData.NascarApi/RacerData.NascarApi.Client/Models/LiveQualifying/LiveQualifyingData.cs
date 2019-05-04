namespace RacerData.NascarApi.Client.Models.LiveQualifying
{
    public class LiveQualifyingData
    {
        public int DriverId { get; set; }
        public int SeriesId { get; set; }
        public int RunId { get; set; }
        public int Position { get; set; }
        public string CarNumber { get; set; }
        public string FullName { get; set; }
        public int QualifyingRound { get; set; }
        public int LapsCompleted { get; set; }
        public int BestLap { get; set; }
        public double BestLapTime { get; set; }
        public double BestLapSpeed { get; set; }
        public string Comment { get; set; }
        public bool IsOnTrack { get; set; }
        public bool IsCurrentRound { get; set; }
        public int TimeLimit { get; set; }
        public double LastLapTime { get; set; }
    }
}
