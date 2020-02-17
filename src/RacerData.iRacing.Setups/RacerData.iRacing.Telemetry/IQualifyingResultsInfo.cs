namespace RacerData.iRacing.Telemetry
{
    public interface IQualifyingResultsInfo
    {
        int CarIdx { get; set; }
        int ClassPosition { get; set; }
        int FastestLap { get; set; }
        float FastestTime { get; set; }
        int Position { get; set; }
    }
}