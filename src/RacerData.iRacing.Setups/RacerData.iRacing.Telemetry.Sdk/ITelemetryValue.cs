namespace RacerData.iRacing.TelemetrySdk
{
    public interface ITelemetryValue
    {
        ITelemetryField Field { get; }
        byte[] Bytes { get; }
        object Value { get; }
    }
}