using System.Collections.Generic;

namespace RacerData.iRacing.Telemetry
{
    public interface IDriverInfo
    {
        int DriverCarIdx { get; set; }
        int DriverUserID { get; set; }
        int PaceCarIdx { get; set; }
        float DriverHeadPosX { get; set; }
        float DriverHeadPosY { get; set; }
        float DriverHeadPosZ { get; set; }
        float DriverCarIdleRPM { get; set; }
        float DriverCarRedLine { get; set; }
        int DriverCarEngCylinderCount { get; set; }
        float DriverCarFuelKgPerLtr { get; set; }
        float DriverCarFuelMaxLtr { get; set; }
        float DriverCarMaxFuelPct { get; set; }
        float DriverCarSLFirstRPM { get; set; }
        float DriverCarSLShiftRPM { get; set; }
        float DriverCarSLLastRPM { get; set; }
        float DriverCarSLBlinkRPM { get; set; }
        float DriverPitTrkPct { get; set; }
        float DriverCarEstLapTime { get; set; }
        string DriverSetupName { get; set; }
        bool DriverSetupIsModified { get; set; }
        string DriverSetupLoadTypeName { get; set; }
        bool DriverSetupPassedTech { get; set; }
        int DriverIncidentCount { get; set; }
        IList<IDriver> Drivers { get; set; }
        IDriver DriversCar { get; }
    }
}