using System.Collections.Generic;

namespace RacerData.iRacing.Telemetry
{
    public interface ISession
    {
         int SessionNum { get; set; }
         string SessionLaps { get; set; }
         string SessionTime { get; set; }
         int SessionNumLapsToAvg { get; set; }
         string SessionType { get; set; }
         string SessionTrackRubberState { get; set; }
         string SessionName { get; set; }
         string SessionSubType { get; set; }
         bool SessionSkipped { get; set; }
         int SessionRunGroupsUsed { get; set; }
         IList<IResultsPosition> ResultsPositions { get; set; }
         IResultsFastestLap ResultsFastestLap { get; set; }
         float ResultsAverageLapTime { get; set; }
         int ResultsNumCautionFlags { get; set; }
         int ResultsNumCautionLaps { get; set; }
         int ResultsNumLeadChanges { get; set; }
         int ResultsLapsComplete { get; set; }
         bool ResultsOfficial { get; set; }
    }
}