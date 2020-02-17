namespace RacerData.iRacing.Sessions.Models
{
    public class Lap
    {
        public long Id { get; set; }
        public long RunId { get; set; }
        public int LapNumber { get; set; }
        public int OverallLapNumber { get; set; }
        public float LapTime { get; set; }
        public float LapSpeed { get; set; }
        public bool IsValid { get; set; }
    }
}
