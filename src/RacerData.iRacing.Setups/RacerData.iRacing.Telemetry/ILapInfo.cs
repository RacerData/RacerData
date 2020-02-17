namespace RacerData.iRacing.Telemetry
{
    public interface ILapInfo
    {
        int LapNumber { get; }
        float LapTime { get; }
        float LapSpeed { get; }
    }
}
