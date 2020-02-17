using System.Collections.Generic;
using System.Linq;

namespace RacerData.iRacing.Telemetry.Sdk.Models
{
    internal class SessionInfo : ISessionInfo
    {
        #region properties

        public IWeekendInfo WeekendInfo { get; set; }
        public IList<ISession> Sessions { get; set; }
        public ISession ActiveSession
        {
            get
            {
                return Sessions.FirstOrDefault(s => s.ResultsOfficial == false);
            }
        }
        public IDriverInfo DriverInfo { get; set; }
        public IList<IQualifyingResultsInfo> QualifyingResults { get; set; }
        public ICarSetup CarSetup { get; set; }

        #endregion

        #region ctor

        public SessionInfo()
        {
            Sessions = new List<ISession>();
            WeekendInfo = new WeekendInfo();
            DriverInfo = new DriverInfo();
            QualifyingResults = new List<IQualifyingResultsInfo>();
            CarSetup = new CarSetup();
        }

        #endregion
    }
}
