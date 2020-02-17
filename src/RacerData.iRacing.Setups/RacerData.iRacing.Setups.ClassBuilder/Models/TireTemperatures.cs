namespace RacerData.iRacing.Setups.ClassBuilder.Models
{
    public class TireTemperatures : TireSurfaceValues
    {
        #region ctor

        public TireTemperatures(double inside, double middle, double outside)
            : base(inside, middle, outside)
        {            
        }

        public TireTemperatures()
            :base()
        {
        }

        #endregion
    }
}
