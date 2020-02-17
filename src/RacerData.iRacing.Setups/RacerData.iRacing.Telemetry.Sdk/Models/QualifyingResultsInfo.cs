namespace RacerData.iRacing.Telemetry.Sdk.Models
{
    internal class QualifyingResultsInfo : IQualifyingResultsInfo
    {
        #region properties

        public int Position { get; set; }
        public int ClassPosition { get; set; }
        public int CarIdx { get; set; }
        public int FastestLap { get; set; }
        public float FastestTime { get; set; }

        #endregion
    }
}
