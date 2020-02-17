using System;

namespace RacerData.iRacing.Extensions
{
    public static class DoubleConversions
    {
        public const Double DegreesToRadiansRatio = 57.2958F;

        public static Double DegreesToRadians(this Double value)
        {
            return value * DegreesToRadiansRatio;
        }
    }
}
