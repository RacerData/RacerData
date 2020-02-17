namespace RacerData.iRacing.Telemetry.Sdk.Models
{
    internal class WeekendInfo : IWeekendInfo
    {
        #region properties

        public string TrackName { get; set; }
        public int TrackID { get; set; }
        public string TrackLength { get; set; }
        public string TrackDisplayName { get; set; }
        public string TrackDisplayShortName { get; set; }
        public string TrackConfigName { get; set; }
        public string TrackCity { get; set; }
        public string TrackCountry { get; set; }
        public string TrackAltitude { get; set; }
        public string TrackLatitude { get; set; }
        public string TrackLongitude { get; set; }
        public string TrackNorthOffset { get; set; }
        public int TrackNumTurns { get; set; }
        public string TrackPitSpeedLimit { get; set; }
        public string TrackType { get; set; }
        public string TrackDirection { get; set; }
        public string TrackWeatherType { get; set; }
        public string TrackSkies { get; set; }
        public string TrackSurfaceTemp { get; set; }
        public string TrackAirTemp { get; set; }
        public string TrackAirPressure { get; set; }
        public string TrackWindVel { get; set; }
        public string TrackWindDir { get; set; }
        public string TrackRelativeHumidity { get; set; }
        public string TrackFogLevel { get; set; }
        public bool TrackCleanup { get; set; }
        public bool TrackDynamicTrack { get; set; }
        public int SeriesID { get; set; }
        public int SeasonID { get; set; }
        public int SessionID { get; set; }
        public int SubSessionID { get; set; }
        public int LeagueID { get; set; }
        public bool Official { get; set; }
        public int RaceWeek { get; set; }
        public string EventType { get; set; }
        public string Category { get; set; }
        public string SimMode { get; set; }
        public int TeamRacing { get; set; }
        public int MinDrivers { get; set; }
        public int MaxDrivers { get; set; }
        public string DCRuleSet { get; set; }
        public bool QualifierMustStartRace { get; set; }
        public int NumCarClasses { get; set; }
        public int NumCarTypes { get; set; }
        public bool HeatRacing { get; set; }
        public IWeekendOptions WeekendOptions { get; set; }
        public ITelemetryOptions TelemetryOptions { get; set; }

        #endregion

        #region ctor

        public WeekendInfo()
        {
            WeekendOptions = new WeekendOptions();
            TelemetryOptions = new TelemetryOptions();
        }

        #endregion
    }
}
