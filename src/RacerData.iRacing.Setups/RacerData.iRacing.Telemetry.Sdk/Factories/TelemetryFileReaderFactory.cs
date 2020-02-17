using RacerData.iRacing.Telemetry.Sdk.Adapters;

namespace RacerData.iRacing.Telemetry.Sdk.Factories
{
    public static class TelemetryFileReaderFactory
    {
        public static ITelemetryFileReader GetTelemetryFileReader(string file)
        {
            return new TelemetryFileReader(file);
        }
    }
}
