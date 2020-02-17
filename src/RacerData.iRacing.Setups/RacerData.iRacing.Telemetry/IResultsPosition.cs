namespace RacerData.iRacing.Telemetry
{
    public interface IResultsPosition
    {
        int CarIdx { get; set; }
        int ClassPosition { get; set; }
        int FastestLap { get; set; }
        float FastestTime { get; set; }
        int Incidents { get; set; }
        int JokerLapsComplete { get; set; }
        int Lap { get; set; }
        int LapsComplete { get; set; }
        float LapsDriven { get; set; }
        int LapsLed { get; set; }
        float LastTime { get; set; }
        int Position { get; set; }
        int ReasonOutId { get; set; }
        string ReasonOutStr { get; set; }
        float Time { get; set; }
    }
}