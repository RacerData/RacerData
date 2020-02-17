using System;
using System.Linq;
using RacerData.iRacing.Sessions.Models;

namespace RacerData.iRacing.Sessions.Ports
{
    public interface ISessionRepository
    {
        IQueryable<SessionListView> GetSessionsQuery();
        SessionTrackState GetSessionTrackState(string trackState);
        SessionTime GetSessionTimeOfDay(TimeSpan timeOfDay);
        SessionTime GetVariableSessionTimeOfDay();
    }
}
