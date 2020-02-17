using System.Collections.Generic;

namespace RacerData.iRacing.Telemetry.Sdk.Models
{
    internal class DriverInfo : IDriverInfo
    {
        #region properties

        public int DriverCarIdx { get; set; }
        public int DriverUserID { get; set; }
        public int PaceCarIdx { get; set; }
        public float DriverHeadPosX { get; set; }
        public float DriverHeadPosY { get; set; }
        public float DriverHeadPosZ { get; set; }
        public float DriverCarIdleRPM { get; set; }
        public float DriverCarRedLine { get; set; }
        public int DriverCarEngCylinderCount { get; set; }
        public float DriverCarFuelKgPerLtr { get; set; }
        public float DriverCarFuelMaxLtr { get; set; }
        public float DriverCarMaxFuelPct { get; set; }
        public float DriverCarSLFirstRPM { get; set; }
        public float DriverCarSLShiftRPM { get; set; }
        public float DriverCarSLLastRPM { get; set; }
        public float DriverCarSLBlinkRPM { get; set; }
        public float DriverPitTrkPct { get; set; }
        public float DriverCarEstLapTime { get; set; }
        public string DriverSetupName { get; set; }
        public bool DriverSetupIsModified { get; set; }
        public string DriverSetupLoadTypeName { get; set; }
        public bool DriverSetupPassedTech { get; set; }
        public int DriverIncidentCount { get; set; }
        public IList<IDriver> Drivers { get; set; }
        public IDriver DriversCar
        {
            get
            {
                return Drivers[DriverCarIdx];
            }
        }

        #endregion

        #region ctor

        public DriverInfo()
        {
            Drivers = new List<IDriver>();
        }

        #endregion
    }
}
