using System;

namespace RacerData.iRacing.Telemetry.Models
{
    [Flags()]
    public enum IbtParseOptions
    {
        Minimum = 0x001,
        WeekendOptions = 0x002,
        SessionInfo = 0x004,
        CameraInfo = 0x008,
        RadioInfo = 0x010,
        DriverInfo = 0x020,
        SplitTimeInfo = 0x040,
        CarSetup = 0x080,
        EventInfo = 0x100,
        TelemetryData = 0x200,
        LapTimes = 0x400,
        SetupOnly = Minimum | CarSetup,
        All = Minimum | WeekendOptions | SessionInfo | CameraInfo | RadioInfo | DriverInfo | SplitTimeInfo | CarSetup | EventInfo | TelemetryData
    }
}
