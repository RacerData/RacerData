using System.Collections.Generic;

namespace RacerData.iRacing.Setups.ClassBuilder.Models
{
    public class TireSheetValues
    {
        public IDictionary<TirePosition, TireViewModel> Tires { get; set; }
        
        public string Setup { get; set; }
        public string Run { get; set; }
        public int Laps { get; set; }
        public double BestLap { get; set; }
        public double AverageLap { get; set; }

        public string FileName { get; set; }
        public double RightTempDelta
        {
            get
            {
                var effectiveFrontTemp = (Tires[TirePosition.RF].Temperatures.Inside + Tires[TirePosition.RF].Temperatures.Middle) / 2;
                var effectiveRearTemp = Tires[TirePosition.RR].Temperatures.Inside;

                return effectiveRearTemp - effectiveFrontTemp;
            }
        }
        public double LeftTempDelta
        {
            get
            {
                var effectiveFrontTemp = (Tires[TirePosition.LF].Temperatures.Inside + Tires[TirePosition.LF].Temperatures.Middle) / 2;
                var effectiveRearTemp = Tires[TirePosition.LR].Temperatures.Inside;

                return effectiveRearTemp - effectiveFrontTemp;
            }
        }
        public double RightWearDelta
        {
            get
            {
                var effectiveFrontWear = (Tires[TirePosition.RF].Wear.Inside + Tires[TirePosition.RF].Wear.Middle) / 2;
                var effectiveRearWear = Tires[TirePosition.RR].Wear.Inside;

                return effectiveRearWear - effectiveFrontWear;
            }
        }
        public double LeftWearDelta
        {
            get
            {
                var effectiveFrontWear = (Tires[TirePosition.LF].Wear.Inside + Tires[TirePosition.LF].Wear.Middle) / 2;
                var effectiveRearWear = Tires[TirePosition.LR].Wear.Inside;

                return effectiveRearWear - effectiveFrontWear;
            }
        }
        public double RightPsiDelta
        {
            get
            {
                return Tires[TirePosition.RR].HotPsi - Tires[TirePosition.RF].HotPsi;
            }
        }
        public double LeftPsiDelta
        {
            get
            {
                return Tires[TirePosition.LR].HotPsi - Tires[TirePosition.LF].HotPsi;
            }
        }
        public double RightPsiGainDelta
        {
            get
            {
                return Tires[TirePosition.RR].DeltaPsi - Tires[TirePosition.RF].DeltaPsi;
            }
        }
        public double LeftPsiGainDelta
        {
            get
            {
                return Tires[TirePosition.LR].DeltaPsi - Tires[TirePosition.LF].DeltaPsi;
            }
        }

        public TireSheetValues()
        {
            Tires = new Dictionary<TirePosition, TireViewModel>();
            Tires.Add(TirePosition.LF, new TireViewModel(TirePosition.LF));
            Tires.Add(TirePosition.LR, new TireViewModel(TirePosition.LR));
            Tires.Add(TirePosition.RF, new TireViewModel(TirePosition.RF));
            Tires.Add(TirePosition.RR, new TireViewModel(TirePosition.RR));
        }
    }
}
