using System.Collections.Generic;

namespace RacerData.NascarApi.Client.Models.LiveFeed
{
    public class Vehicle
    {
        public int BestLap { get; set; }
        public double BestLapSpeed { get; set; }
        public double BestLapTime { get; set; }
        public string Manufacturer { get; set; }
        public string CarNumber { get; set; }
        public Driver Driver { get; set; }
        public double VehicleElapsedTime { get; set; }
        public int LapsCompleted { get; set; }
        public List<LapsLed> LapsLed { get; set; }
        public double LastLapSpeed { get; set; }
        public double LastLapTime { get; set; }
        public List<PitStop> PitStops { get; set; }
        public int RunningPosition { get; set; }
        public int Status { get; set; }
        public double Delta { get; set; }
        public string Sponsor { get; set; }
        public int StartingPosition { get; set; }
        public bool IsOnTrack { get; set; }


        public override string ToString()
        {
            return $"[{CarNumber}] {Driver.ToString()}";
        }
    }
}
