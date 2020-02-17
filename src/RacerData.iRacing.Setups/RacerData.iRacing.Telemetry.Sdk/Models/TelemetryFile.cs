using System.Collections.Generic;

namespace RacerData.iRacing.Telemetry.Sdk.Models
{
    internal class TelemetryFile : ITelemetryFile
    {
        #region properties

        public string FileName { get; set; }
        public ISessionInfo SessionInfo { get; internal set; }
        public IEnumerable<ILapInfo> Laps { get; internal set; }
        public IEnumerable<ITelemetryFrame> Frames { get; internal set; }
        public ITireSheet TireSheet { get; set; }
        public ITireSheet TireSheetFromSetup { get; set; }

        #endregion

        #region ctor

        public TelemetryFile()
        {
            Frames = new List<ITelemetryFrame>();
            Laps = new List<ILapInfo>();
            SessionInfo = new SessionInfo();
        }

        #endregion
    }
}