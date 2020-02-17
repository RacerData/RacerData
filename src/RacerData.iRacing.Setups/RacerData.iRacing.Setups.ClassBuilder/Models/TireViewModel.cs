using System;

namespace RacerData.iRacing.Setups.ClassBuilder.Models
{
    public class TireViewModel
    {
        #region properties

        public TirePosition Position { get; set; }
        public TireTemperatures Temperatures { get; set; }
        public TireWear Wear { get; set; }
        public double EffectiveTemperature
        {
            get
            {
                double effectiveValue = 0;

                switch (Position)
                {
                    case TirePosition.LF:
                    case TirePosition.LR:
                        {
                            effectiveValue = (Temperatures.Outside + Temperatures.Middle) / 2;
                            break;
                        }
                    case TirePosition.RF:
                    case TirePosition.RR:
                        {
                            effectiveValue = (Temperatures.Inside + Temperatures.Middle) / 2;
                            break;
                        }
                }

                return Math.Round(effectiveValue, 3);
            }
        }
        public double EffectiveWear
        {
            get
            {
                double effectiveValue = 0;

                switch (Position)
                {
                    case TirePosition.LF:
                    case TirePosition.LR:
                        {
                            effectiveValue = (Wear.Outside + Wear.Middle) / 2;
                            break;
                        }
                    case TirePosition.RF:
                    case TirePosition.RR:
                        {
                            effectiveValue = (Wear.Inside + Wear.Middle) / 2;
                            break;
                        }
                }

                return Math.Round(effectiveValue, 3);
            }
        }
        public double ColdPsi { get; set; }
        public double HotPsi { get; set; }
        public double DeltaPsi
        {
            get
            {
                return HotPsi - ColdPsi;
            }
        }

        #endregion

        #region ctor

        public TireViewModel(TirePosition position)
        {
            Position = position;
            Temperatures = new TireTemperatures();
            Wear = new TireWear();
        }

        #endregion
    }
}
