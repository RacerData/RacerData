using System;
using System.Collections.Generic;

namespace RacerData.iRacing.Sessions.Ui.TireSheet
{
    public class TireSheetViewModel
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

        public TireSheetViewModel(TirePosition position)
        {
            Position = position;
            Temperatures = new TireTemperatures();
            Wear = new TireWear();
        }

        #endregion

        #region classes

        public class TireSurfaceValues
        {
            #region fields

            private IDictionary<TreadPosition, double> _values = new Dictionary<TreadPosition, double>();

            #endregion

            #region properties

            public double Inside
            {
                get
                {
                    return _values[TreadPosition.Inside];
                }
                set
                {
                    _values[TreadPosition.Inside] = value;
                }
            }
            public double Middle
            {
                get
                {
                    return _values[TreadPosition.Middle];
                }
                set
                {
                    _values[TreadPosition.Middle] = value;
                }
            }
            public double Outside
            {
                get
                {
                    return _values[TreadPosition.Outside];
                }
                set
                {
                    _values[TreadPosition.Outside] = value;
                }
            }

            #endregion

            #region ctor

            public TireSurfaceValues(double inside, double middle, double outside)
                : this()
            {
                Inside = inside;
                Middle = middle;
                Outside = outside;
            }

            public TireSurfaceValues()
            {
                _values.Add(TreadPosition.Inside, 0);
                _values.Add(TreadPosition.Middle, 0);
                _values.Add(TreadPosition.Outside, 0);
            }

            #endregion
        }

        public class TireTemperatures : TireSurfaceValues
        {
            #region ctor

            public TireTemperatures(double inside, double middle, double outside)
                : base(inside, middle, outside)
            {
            }

            public TireTemperatures()
                : base()
            {
            }

            #endregion
        }

        public class TireWear : TireSurfaceValues
        {
            #region ctor

            public TireWear(double inside, double middle, double outside)
                : base(inside, middle, outside)
            {
            }

            public TireWear()
                : base()
            {
            }

            #endregion
        }

        public class TireSheetValues
        {
            public IDictionary<TirePosition, TireSheetViewModel> Tires { get; set; }

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
                Tires = new Dictionary<TirePosition, TireSheetViewModel>();
                Tires.Add(TirePosition.LF, new TireSheetViewModel(TirePosition.LF));
                Tires.Add(TirePosition.LR, new TireSheetViewModel(TirePosition.LR));
                Tires.Add(TirePosition.RF, new TireSheetViewModel(TirePosition.RF));
                Tires.Add(TirePosition.RR, new TireSheetViewModel(TirePosition.RR));
            }
        }

        #endregion
    }
}
