namespace RacerData.iRacing.Setups.ClassBuilder.Models
{
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
}
