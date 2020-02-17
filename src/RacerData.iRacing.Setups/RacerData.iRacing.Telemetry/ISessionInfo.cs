using System.Collections.Generic;

namespace RacerData.iRacing.Telemetry
{
    public interface ISessionInfo
    {
        IWeekendInfo WeekendInfo { get; set; }
        IList<ISession> Sessions { get; set; }
        ISession ActiveSession { get; }
        IDriverInfo DriverInfo { get; set; }
        ICarSetup CarSetup { get; set; }
        IList<IQualifyingResultsInfo> QualifyingResults { get; set; }
    }
}
