using System;
using System.Collections.Generic;
using System.Linq;

namespace RacerData.iRacing.Setups.ClassBuilder.Models
{
    public class EventData
    {
        #region properties

        public EventTypes EventType { get; set; }
        public string TrackName { get; set; }
        public double TrackLength { get; set; }
        public string Vehicle { get; set; }

        public string SessionId { get; set; }
        public string SubSessionId { get; set; }
        public DateTime Timestamp { get; set; }

        public int AirTemperature { get; set; }
        public int TrackTemperature { get; set; }
        public string Skies { get; set; }

        public EventSessionData ActiveSession
        {
            get
            {
                return Sessions.LastOrDefault();
            }
        }

        public IList<EventSessionData> Sessions { get; set; }

        #endregion

        #region ctor

        public EventData()
        {
            Sessions = new List<EventSessionData>();
        }

        #endregion
    }
}
