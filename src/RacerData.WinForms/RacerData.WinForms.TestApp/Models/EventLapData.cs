namespace RacerData.WinForms.Models
{
    public class EventLapData
    {
        public int RaceId { get; set; }
        public int SeriesId { get; set; }
        public int RunId { get; set; }
        public string TrackName { get; set; }
        public string RunName { get; set; }
        public int Elapsed { get; set; }
        public VehicleLapTime[] VehicleLapTimes { get; set; }
    }
}
