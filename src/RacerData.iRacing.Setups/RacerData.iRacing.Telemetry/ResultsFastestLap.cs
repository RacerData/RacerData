namespace RacerData.iRacing.Telemetry
{
    public interface IResultsFastestLap
    {
        int CarIdx { get; set; }
        int FastestLap { get; set; }
        float FastestTime { get; set; }
    }
}
