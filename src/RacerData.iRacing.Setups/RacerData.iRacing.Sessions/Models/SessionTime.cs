using System;

namespace RacerData.iRacing.Sessions.Models
{
    public class SessionTime
    {
        public int Id { get; set; }
        public string TimeOfDay { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
