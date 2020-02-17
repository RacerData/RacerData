namespace RacerData.iRacing.Telemetry.Sdk.Models
{
    internal class ResultsFastestLap : IResultsFastestLap
    {
        #region properties

        public int CarIdx { get; set; }
        public int FastestLap { get; set; }
        public float FastestTime { get; set; }

        #endregion
    }
}
