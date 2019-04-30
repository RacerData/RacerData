namespace RacerData.NascarApi.LapAverage.Service.Internal
{
    class VehiclePitStopEvent : VehicleEvent
    {
        #region properties

        public int PitInLap { get; set; }
        public double PitOutElapsed { get; set; }

        #endregion

        #region ctor

        public VehiclePitStopEvent(string vehicleId, double pitInElapsed, int pitInLap, double pitOutElapsed)
            : base(vehicleId, pitInElapsed)
        {
            PitInLap = pitInLap;
            PitOutElapsed = pitOutElapsed;
        }

        #endregion

        #region public

        public override string ToString()
        {
            return $"{Elapsed} PIT: {PitInLap} {Elapsed} - {PitOutElapsed}";
        }

        #endregion
    }
}
