namespace RacerData.iRacing.Telemetry
{
    public enum irsdk_EngineWarnings
    {
        irsdk_waterTempWarning = 0x01,
        irsdk_fuelPressureWarning = 0x02,
        irsdk_oilPressureWarning = 0x04,
        irsdk_engineStalled = 0x08,
        irsdk_pitSpeedLimiter = 0x10,
        irsdk_revLimiterActive = 0x20,
    }
}
