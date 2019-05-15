namespace RacerData.NascarApi.Client.Models.LiveFeed
{
    public class PitStop
    {
        public int PositionDelta { get; set; }
        public double PitInElapsed { get; set; }
        [Newtonsoft.Json.JsonIgnore()]
        public System.TimeSpan PitInElapsedTimeSpan
        {
            get
            {
                return System.TimeSpan.FromSeconds(PitInElapsed);
            }
        }
        public int PitInLap { get; set; }
        public int PitInLeaderLap { get; set; }
        public double PitOutElapsed { get; set; }
        [Newtonsoft.Json.JsonIgnore()]
        public System.TimeSpan PitOutElapsedTimeSpan
        {
            get
            {
                return System.TimeSpan.FromSeconds(PitOutElapsed);
            }
        }
    }
}
