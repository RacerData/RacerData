using System.Threading.Tasks;
using RacerData.iRacing.Telemetry.Models;

namespace RacerData.iRacing.Telemetry
{
    public interface ITelemetryParser
    {
        Task<ITelemetryData> ParseTelemetrySessionAsync(byte[] telemetryBytes);
        Task<ITelemetryData> ParseTelemetrySessionAsync(byte[] telemetryBytes, IbtParseOptions options);
    }
}
