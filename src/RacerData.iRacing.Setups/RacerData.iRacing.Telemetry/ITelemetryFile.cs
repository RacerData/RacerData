using System.Collections.Generic;

namespace RacerData.iRacing.Telemetry
{
    public interface ITelemetryFile
    {
        string FileName { get; set; }
        ISessionInfo SessionInfo { get; }
        IEnumerable<ILapInfo> Laps { get; }
        IEnumerable<ITelemetryFrame> Frames { get; }
        ITireSheet TireSheet { get; set; }
        ITireSheet TireSheetFromSetup { get; set; }
    }
}
