using System.Threading.Tasks;

namespace RacerData.iRacing.Telemetry
{
    public interface IIbtFileReader
    {
        Task<byte[]> ReadTelemetryDataAsync(string fullPath);
    }
}
