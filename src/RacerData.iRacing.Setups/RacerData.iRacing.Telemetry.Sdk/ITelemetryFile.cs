using System.Collections.Generic;

namespace RacerData.iRacing.TelemetrySdk
{
    public interface ITelemetryFile
    {
        IList<ITelemetryField> Fields { get; }
        IList<ITelemetryFrame> Frames { get; }
    }
}
