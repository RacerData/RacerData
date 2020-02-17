using System.Collections.Generic;
using System.Threading.Tasks;

namespace RacerData.iRacing.TelemetrySdk
{
    public interface ITelemetryFileReader
    {
        Task<ITelemetryFile> ReadTelemetryDataAsync();
        Task<IEnumerable<ILapInfo>> ReadLapDataAsync();
        ISessionInfo GetSessionInfo();
        IVehicleSetup GetVehicleSetup();
    }
}
