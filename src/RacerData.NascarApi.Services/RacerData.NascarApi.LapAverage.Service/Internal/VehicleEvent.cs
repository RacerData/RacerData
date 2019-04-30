namespace RacerData.NascarApi.LapAverage.Service.Internal
{
    class VehicleEvent
    {
        #region properties

        public string VehicleId { get; set; }
        public double Elapsed { get; set; }

        #endregion

        #region public

        public VehicleEvent(string vehicleId, double elapsed)
        {
            Elapsed = elapsed;
        }

        #endregion
    }
}
