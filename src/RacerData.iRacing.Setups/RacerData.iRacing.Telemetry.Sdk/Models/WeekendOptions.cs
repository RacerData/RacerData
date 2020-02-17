namespace RacerData.iRacing.Telemetry.Sdk.Models
{
    internal class WeekendOptions : IWeekendOptions
    {
        #region properties

        public int NumStarters { get; set; }
        public string StartingGrid { get; set; }
        public string QualifyScoring { get; set; }
        public string CourseCautions { get; set; }
        public bool StandingStart { get; set; }
        public string Restarts { get; set; }
        public string WeatherType { get; set; }
        public string Skies { get; set; }
        public string WindDirection { get; set; }
        public string WindSpeed { get; set; }
        public string WeatherTemp { get; set; }
        public string RelativeHumidity { get; set; }
        public string FogLevel { get; set; }
        public string TimeOfDay { get; set; }
        public string Date { get; set; }
        public int EarthRotationSpeedupFactor { get; set; }
        public bool Unofficial { get; set; }
        public bool CommercialMode { get; set; }
        public bool NightMode { get; set; }
        public bool IsFixedSetup { get; set; }
        public string StrictLapsChecking { get; set; }
        public bool HasOpenRegistration { get; set; }
        public int HardcoreLevel { get; set; }
        public int NumJokerLaps { get; set; }
        public string IncidentLimit { get; set; }

        #endregion
    }
}
