using System.Threading.Tasks;
using RacerData.iRacing.Telemetry.Models;

namespace RacerData.iRacing.Telemetry
{
    public interface IIbtSessionParser
    {
        Task<ISessionData> ParseTelemetrySessionAsync(byte[] telemetryBytes);
        Task<ISessionData> ParseTelemetrySessionAsync(byte[] telemetryBytes, IbtParseOptions options);
    }
}
