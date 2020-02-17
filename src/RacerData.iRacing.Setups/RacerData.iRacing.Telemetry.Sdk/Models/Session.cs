using System.Collections.Generic;

namespace RacerData.iRacing.Telemetry.Sdk.Models
{
    internal class Session : ISession
    {
        #region properties

        public int SessionNum { get; set; }
        public string SessionLaps { get; set; }
        public string SessionTime { get; set; }
        public int SessionNumLapsToAvg { get; set; }
        public string SessionType { get; set; }
        public string SessionTrackRubberState { get; set; }
        public string SessionName { get; set; }
        public string SessionSubType { get; set; }
        public bool SessionSkipped { get; set; }
        public int SessionRunGroupsUsed { get; set; }
        public IList<IResultsPosition> ResultsPositions { get; set; }
        public IResultsFastestLap ResultsFastestLap { get; set; }
        public float ResultsAverageLapTime { get; set; }
        public int ResultsNumCautionFlags { get; set; }
        public int ResultsNumCautionLaps { get; set; }
        public int ResultsNumLeadChanges { get; set; }
        public int ResultsLapsComplete { get; set; }
        public bool ResultsOfficial { get; set; }

        #endregion

        #region ctor

        public Session()
        {
            ResultsFastestLap = new ResultsFastestLap();
            ResultsPositions = new List<IResultsPosition>();
        }

        #endregion
    }
}
