namespace RacerData.NascarApi.Client.Models.LapAverages
{
    public class VehicleNLapAverage
    {
        #region properties

        public string VehicleId { get; set; }
        public int LapCount { get; set; }
        public int StartLap { get; set; }
        public int EndLap { get; set; }
        public double AverageLapTime { get; set; }

        #endregion

        #region public

        public override string ToString()
        {
            return $"[{VehicleId}] {LapCount} {StartLap}-{EndLap} {AverageLapTime}";
        }

        #endregion
    }

}
