namespace RacerData.NascarApi.LapAverage.Service.Internal
{
    class VehicleLapEvent : VehicleEvent
    {
        #region properties

        public int LapNumber { get; set; }
        public double LapTime { get; set; }

        #endregion

        #region ctor

        public VehicleLapEvent(string vehicleId, double elapsed, int lapNumber, double lapTime)
            : base(vehicleId, elapsed)
        {
            VehicleId = vehicleId;
            LapNumber = lapNumber;
            LapTime = lapTime;
        }

        #endregion

        #region public

        public override string ToString()
        {
            return $"{Elapsed} LAP: {LapNumber} {LapTime}";
        }

        #endregion
    }
}
