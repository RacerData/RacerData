namespace RacerData.NascarApi.Client.Models.LapAverages
{
    public class VehicleLap
    {
        #region properties

        public string VehicleId { get; set; }
        public int LapNumber { get; set; }
        public double LapTime { get; set; }

        #endregion

        #region public

        public override string ToString()
        {
            return $"[{VehicleId}] {LapNumber} {LapTime}";
        }

        #endregion
    }
}
