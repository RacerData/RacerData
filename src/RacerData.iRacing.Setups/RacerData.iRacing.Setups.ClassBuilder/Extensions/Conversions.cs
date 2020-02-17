using System;

namespace RacerData.iRacing.Setups.ClassBuilder.Extensions
{
    public static class Conversions
    {
        public static int CelciusToFarenheit(this string value)
        {
            var temp = (double.Parse(value.Split(' ')[0].Trim()) * 1.8) + 32;

            return (int)Math.Round(temp, 0);
        }
    }
}
