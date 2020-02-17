using System.Drawing;

namespace RacerData.iRacing.SessionMonitor.ViewModels
{
    public class TireSheetViewModel
    {
        public int RunId { get; set; }
        public TireViewModel[] Tires { get; set; }
        public PointF TempBalance
        {
            get
            {
                float x = (Tires[(int)TirePosition.LF].EffectiveTemp + Tires[(int)TirePosition.RF].EffectiveTemp) -
                    (Tires[(int)TirePosition.LR].EffectiveTemp + Tires[(int)TirePosition.RR].EffectiveTemp);

                float y = (Tires[(int)TirePosition.RF].EffectiveTemp + Tires[(int)TirePosition.RR].EffectiveTemp) -
                    (Tires[(int)TirePosition.LF].EffectiveTemp + Tires[(int)TirePosition.LR].EffectiveTemp);

                return new PointF(x, y);
            }
        }
        public PointF WearBalance
        {
            get
            {
                float x = (Tires[(int)TirePosition.LF].EffectiveWear + Tires[(int)TirePosition.RF].EffectiveWear) -
                    (Tires[(int)TirePosition.LR].EffectiveWear + Tires[(int)TirePosition.RR].EffectiveWear);

                float y = (Tires[(int)TirePosition.RF].EffectiveWear + Tires[(int)TirePosition.RR].EffectiveWear) -
                    (Tires[(int)TirePosition.LF].EffectiveWear + Tires[(int)TirePosition.LR].EffectiveWear);

                return new PointF(x, y);
            }
        }
        public PointF PsiGainBalance
        {
            get
            {
                float x = (Tires[(int)TirePosition.LF].PsiGain + Tires[(int)TirePosition.RF].PsiGain) -
                    (Tires[(int)TirePosition.LR].PsiGain + Tires[(int)TirePosition.RR].PsiGain);

                float y = (Tires[(int)TirePosition.RF].PsiGain + Tires[(int)TirePosition.RR].PsiGain) -
                    (Tires[(int)TirePosition.LF].PsiGain + Tires[(int)TirePosition.LR].PsiGain);

                return new PointF(x, y);
            }
        }

        public TireSheetViewModel()
        {
            Tires = new TireViewModel[4]
            {
                new TireViewModel(),
                new TireViewModel(),
                new TireViewModel(),
                new TireViewModel()
            };
        }
    }
}
