using System;

namespace RacerData.iRacing.Telemetry.Sdk.Models
{
    internal class TireSheet : ITireSheet
    {
        #region properties

        public ITireReadings RF { get; set; }
        public ITireReadings RR { get; set; }
        public ITireReadings LF { get; set; }
        public ITireReadings LR { get; set; }

        public float EffectiveTemperatureBalance
        {
            get
            {
                var leftSpreadFrontToRear = Math.Abs(LF.EffectiveTemperature - LR.EffectiveTemperature);
                var rightSpreadFrontToRear = Math.Abs(RF.EffectiveTemperature - RR.EffectiveTemperature);
                var frontSpreadLeftToRight = Math.Abs(LF.EffectiveTemperature - RF.EffectiveTemperature);
                var rearSpreadLeftToRight = Math.Abs(LR.EffectiveTemperature - RR.EffectiveTemperature);
                var crossSpread = Math.Abs(LR.EffectiveTemperature - RF.EffectiveTemperature);
                var antiCrossSpread = Math.Abs(LR.EffectiveTemperature - RF.EffectiveTemperature);

                return leftSpreadFrontToRear +
                    rightSpreadFrontToRear +
                    frontSpreadLeftToRight +
                    rearSpreadLeftToRight +
                    crossSpread +
                    antiCrossSpread;
            }
        }
        public float EffectiveWearBalance
        {
            get
            {
                var leftSpreadFrontToRear = Math.Abs(LF.EffectiveWear - LR.EffectiveWear);
                var rightSpreadFrontToRear = Math.Abs(RF.EffectiveWear - RR.EffectiveWear);
                var frontSpreadLeftToRight = Math.Abs(LF.EffectiveWear - RF.EffectiveWear);
                var rearSpreadLeftToRight = Math.Abs(LR.EffectiveWear - RR.EffectiveWear);
                var crossSpread = Math.Abs(LR.EffectiveWear - RF.EffectiveWear);
                var antiCrossSpread = Math.Abs(LR.EffectiveWear - RF.EffectiveWear);

                return leftSpreadFrontToRear +
                    rightSpreadFrontToRear +
                    frontSpreadLeftToRight +
                    rearSpreadLeftToRight +
                    crossSpread +
                    antiCrossSpread;
            }
        }

        #endregion

        #region ctor

        public TireSheet()
        {
            LF = new TireReadings(TirePosition.LF);
            LR = new TireReadings(TirePosition.LR);
            RF = new TireReadings(TirePosition.RF);
            RR = new TireReadings(TirePosition.RR);
        }

        #endregion
    }
}
