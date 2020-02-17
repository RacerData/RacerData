namespace RacerData.iRacing.Sessions.Models
{
    public class SessionView
    {
        public int SessionIndex { get; set; }
        public int RunIndex { get; set; }
        public long RunId { get; set; }
        public int FirstSessionRun { get; set; }

        public virtual Run Run { get; set; }
    }
}
