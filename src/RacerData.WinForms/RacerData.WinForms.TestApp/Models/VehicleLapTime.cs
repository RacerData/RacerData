namespace RacerData.WinForms.Models
{
    public class VehicleLapTime
    {
        public string VehicleId { get; set; }
        public int LapNumber { get; set; }
        public float LapTime { get; set; }
        public string TrackState { get; set; }
        public string VehicleStatus { get; set; }
        public int EventElapsed { get; set; }
        public float VehicleElapsed { get; set; }
    }
}
