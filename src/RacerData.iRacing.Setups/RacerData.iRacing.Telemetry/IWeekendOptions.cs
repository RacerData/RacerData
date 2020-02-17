namespace RacerData.iRacing.Telemetry
{
    public interface IWeekendOptions
    {
        int NumStarters { get; set; }
        string StartingGrid { get; set; }
        string QualifyScoring { get; set; }
        string CourseCautions { get; set; }
        bool StandingStart { get; set; }
        string Restarts { get; set; }
        string WeatherType { get; set; }
        string Skies { get; set; }
        string WindDirection { get; set; }
        string WindSpeed { get; set; }
        string WeatherTemp { get; set; }
        string RelativeHumidity { get; set; }
        string FogLevel { get; set; }
        string TimeOfDay { get; set; }
        string Date { get; set; }
        int EarthRotationSpeedupFactor { get; set; }
        bool Unofficial { get; set; }
        bool CommercialMode { get; set; }
        bool NightMode { get; set; }
        bool IsFixedSetup { get; set; }
        string StrictLapsChecking { get; set; }
        bool HasOpenRegistration { get; set; }
        int HardcoreLevel { get; set; }
        int NumJokerLaps { get; set; }
        string IncidentLimit { get; set; }
    }
}