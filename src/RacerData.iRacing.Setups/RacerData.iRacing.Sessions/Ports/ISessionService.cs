using System.Threading.Tasks;
using RacerData.iRacing.Sessions.Models;

namespace RacerData.iRacing.Sessions.Ports
{
    public interface ISessionService
    {
        Task ImportTelemetry(TelemetryFileInfo telemetryFileInfo);
    }
}
