using System;

namespace RacerData.iRacing.Telemetry
{
    [Flags()]
    public enum irsdk_EngineWarnings
    {
        irsdk_waterTempWarning = 0x00000001,
        irsdk_fuelPressureWarning = 0x00000002,
        irsdk_oilPressureWarning = 0x00000004,
        irsdk_engineStalled = 0x00000008,
        irsdk_pitSpeedLimiter = 0x00000010,
        irsdk_revLimiterActive = 0x00000020
    }
}