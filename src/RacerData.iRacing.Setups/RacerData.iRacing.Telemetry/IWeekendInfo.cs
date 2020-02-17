namespace RacerData.iRacing.Telemetry
{
    public interface IWeekendInfo
    {
        string TrackName { get; set; }
        int TrackID { get; set; }
        string TrackLength { get; set; }
        string TrackDisplayName { get; set; }
        string TrackDisplayShortName { get; set; }
        string TrackConfigName { get; set; }
        string TrackCity { get; set; }
        string TrackCountry { get; set; }
        string TrackAltitude { get; set; }
        string TrackLatitude { get; set; }
        string TrackLongitude { get; set; }
        string TrackNorthOffset { get; set; }
        int TrackNumTurns { get; set; }
        string TrackPitSpeedLimit { get; set; }
        string TrackType { get; set; }
        string TrackDirection { get; set; }
        string TrackWeatherType { get; set; }
        string TrackSkies { get; set; }
        string TrackSurfaceTemp { get; set; }
        string TrackAirTemp { get; set; }
        string TrackAirPressure { get; set; }
        string TrackWindVel { get; set; }
        string TrackWindDir { get; set; }
        string TrackRelativeHumidity { get; set; }
        string TrackFogLevel { get; set; }
        bool TrackCleanup { get; set; }
        bool TrackDynamicTrack { get; set; }
        int SeriesID { get; set; }
        int SeasonID { get; set; }
        int SessionID { get; set; }
        int SubSessionID { get; set; }
        int LeagueID { get; set; }
        bool Official { get; set; }
        int RaceWeek { get; set; }
        string EventType { get; set; }
        string Category { get; set; }
        string SimMode { get; set; }
        int TeamRacing { get; set; }
        int MinDrivers { get; set; }
        int MaxDrivers { get; set; }
        string DCRuleSet { get; set; }
        bool QualifierMustStartRace { get; set; }
        int NumCarClasses { get; set; }
        int NumCarTypes { get; set; }
        bool HeatRacing { get; set; }
        IWeekendOptions WeekendOptions { get; set; }
        ITelemetryOptions TelemetryOptions { get; set; }
    }
}