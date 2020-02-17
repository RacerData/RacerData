using System.Collections.Generic;
using System.Threading.Tasks;

namespace RacerData.iRacing.Telemetry
{
    public interface ITelemetryFileReader
    {
        byte[] TelemetryFileBytes { get; }
        Task<ITelemetryFile> ReadTelemetryFileAsync();
        ITelemetryFile ReadTelemetrySession();
    }
}
