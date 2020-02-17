using System;

namespace RacerData.iRacing.SessionMonitor.ViewModels
{
    public class TireViewModel
    {
        public TirePosition Position { get; set; }
        public float ColdPsi { get; set; }
        public float HotPsi { get; set; }
        public float PsiGain
        {
            get
            {
                return HotPsi - ColdPsi;
            }
        }
        public float EffectiveTemp
        {
            get
            {
                float value1 = (Position == TirePosition.LF || Position == TirePosition.LR) ?
                    Temperatures[(int)TreadPosition.Outside] :
                    Temperatures[(int)TreadPosition.Inside];

                return (float)Math.Round(((value1 + Temperatures[(int)TreadPosition.Middle]) / 2), 2);
            }
        }
        public float EffectiveWear
        {
            get
            {
                float value1 = (Position == TirePosition.LF || Position == TirePosition.LR) ?
                      Wear[(int)TreadPosition.Outside] :
                      Wear[(int)TreadPosition.Inside];

                return (float)Math.Round(((value1 + Wear[(int)TreadPosition.Middle]) / 2), 2);
            }
        }

        public float[] Wear { get; set; } = new float[3];
        public float[] Temperatures { get; set; } = new float[3];
    }
}
