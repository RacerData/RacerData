namespace RacerData.iRacing.Sessions.Ui.TirePressureGraph
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
