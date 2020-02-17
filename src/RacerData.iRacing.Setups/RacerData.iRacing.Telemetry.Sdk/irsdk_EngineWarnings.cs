using System;

namespace RacerData.iRacing.TelemetrySdk
{
    [Flags()]
    public enum irsdk_EngineWarnings
    {
        irsdk_waterTempWarning = (1 << 0),
        irsdk_fuelPressureWarning = (1 << 1),
        irsdk_oilPressureWarning = (1 << 2),
        irsdk_engineStalled = (1 << 3),
        irsdk_pitSpeedLimiter = (1 << 4),
        irsdk_revLimiterActive = (1 << 5),
    }
}
