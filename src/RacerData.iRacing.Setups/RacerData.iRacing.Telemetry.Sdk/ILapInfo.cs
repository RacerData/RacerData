namespace RacerData.iRacing.TelemetrySdk
{
    public interface ILapInfo
    {
        int LapNumber { get; }
        float LapTime { get; }
        float LapSpeed { get; }
        bool IsValid { get; }
    }
}
