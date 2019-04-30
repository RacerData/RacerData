namespace RacerData.NascarApi.Client.Models.LiveFeed
{
    public class PitStop
    {
        public int PositionDelta { get; set; }
        public double PitInElapsed { get; set; }
        public int PitInLap { get; set; }
        public int PitInLeaderLap { get; set; }
        public double PitOutElapsed { get; set; }
    }
}
