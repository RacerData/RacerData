namespace RacerData.iRacing.Telemetry.Sdk.Models
{
    internal class LapInfo : ILapInfo
    {
        #region properties

        public int LapNumber { get; internal set; }
        public float LapTime { get; internal set; }
        public float LapSpeed { get; internal set; }

        #endregion
    }
}
