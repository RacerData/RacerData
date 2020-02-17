using System;
using System.Collections.Generic;

namespace RacerData.iRacing.Telemetry.Sdk.Models
{
    public class TireReadings : ITireReadings
    {
        #region properties

        public TirePosition TirePosition { get; set; }
        public IDictionary<TreadPosition, float> Temperatures { get; set; }
        public IDictionary<TreadPosition, float> Wear { get; set; }
        public float ColdPsi { get; set; }
        public float HotPsi { get; set; }

        public float DeltaPsi
        {
            get
            {
                return (float)Math.Round(HotPsi - ColdPsi, 1);
            }
        }
        public float EffectiveTemperature
        {
            get
            {
                if (TirePosition == TirePosition.LF || TirePosition == TirePosition.LR)
                {
                    return (float)Math.Round((Temperatures[TreadPosition.Outside] + Temperatures[TreadPosition.Middle]) / 2, 1);
                }
                else
                {
                    return (float)Math.Round((Temperatures[TreadPosition.Inside] + Temperatures[TreadPosition.Middle]) / 2, 1);
                }
            }
        }
        public float EffectiveWear
        {
            get
            {
                if (TirePosition == TirePosition.LF || TirePosition == TirePosition.LR)
                {
                    return (float)Math.Round((Wear[TreadPosition.Outside] + Wear[TreadPosition.Middle]) / 2, 1);
                }
                else
                {
                    return (float)Math.Round((Wear[TreadPosition.Inside] + Wear[TreadPosition.Middle]) / 2, 1);
                }
            }
        }

        #endregion

        #region ctor

        public TireReadings(TirePosition position)
           : this()
        {
            TirePosition = position;
        }

        internal TireReadings()
        {
            Temperatures = new Dictionary<TreadPosition, float>();
            Temperatures.Add(TreadPosition.Inside, 0);
            Temperatures.Add(TreadPosition.Middle, 0);
            Temperatures.Add(TreadPosition.Outside, 0);

            Wear = new Dictionary<TreadPosition, float>();
            Wear.Add(TreadPosition.Inside, 0);
            Wear.Add(TreadPosition.Middle, 0);
            Wear.Add(TreadPosition.Outside, 0);
        }

        #endregion

    }
}
