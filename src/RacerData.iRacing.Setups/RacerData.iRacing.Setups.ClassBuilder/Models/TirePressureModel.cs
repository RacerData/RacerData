using RacerData.iRacing.Telemetry;

namespace RacerData.iRacing.Setups.ClassBuilder.Models
{
    public class TirePressureModel
    {
        public TirePosition Position { get; set; }
        public float ColdPsi { get; set; }
        public float HotPsi { get; set; }
        public float DeltaPsi
        {
            get
            {
                return HotPsi - ColdPsi;
            }
        }
    }
}
