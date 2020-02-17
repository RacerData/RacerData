using System;

namespace RacerData.iRacing.Telemetry.Extensions
{
    public static class StringConversions
    {
        public static double CelciusToFarenheit(this string value)
        {
            Single telpValue = Single.Parse(value.Split(' ')[0].Trim());

            return telpValue.CelciusToFarenheit();
        }
    }
}
