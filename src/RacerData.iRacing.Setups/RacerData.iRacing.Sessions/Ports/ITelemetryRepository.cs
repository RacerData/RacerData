using System.Collections.Generic;
using System.Threading.Tasks;
using RacerData.iRacing.Sessions.Models;

namespace RacerData.iRacing.Sessions.Ports
{
    public interface ITelemetryRepository
    {
        Task<TelemetryData> GetTelemetryAsync(long id);
        Task<TelemetryData> GetTelemetryAsync(string fileName);
        Task<IList<TelemetryData>> GetTelemetriesAsync();
        Task<TelemetryData> InsertTelemetryAsync(TelemetryData activity);
        Task<TelemetryData> UpdateTelemetryAsync(TelemetryData activity);
    }
}
