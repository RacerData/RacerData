using System;
using System.Collections.Generic;
using System.Linq;

namespace RacerData.iRacing.Setups.ClassBuilder.Extensions
{
    public static class Rounding
    {
        public static double StandardDeviation(this IEnumerable<double> values)
        {
            double avg = values.Average();
            return Math.Sqrt(values.Average(v => Math.Pow(v - avg, 2)));
        }

        public static double NearestHalf(this double value)
        {
            return Math.Round(value * 2, MidpointRounding.AwayFromZero) / 2;
        }

        public static double NearestQuarter(this double value)
        {
            return Math.Round(value * 4, MidpointRounding.AwayFromZero) / 4;
        }

        public static double NearestEighth(this double value)
        {
            return Math.Round(value * 8, MidpointRounding.AwayFromZero) / 8;
        }

        public static double NearestSixteenth(this double value)
        {
            return Math.Round(value * 16, MidpointRounding.AwayFromZero) / 16;
        }
        public static string NearestSixteenthAsFraction(this double value)
        {
            double valueAsSixteenth = Math.Round(value * 16, MidpointRounding.AwayFromZero) / 16;

            double numerator = (double)(valueAsSixteenth / ((double)1.0 / (double)16.0));

            return $"{numerator}/16";
        }


        public static int NearestTwentyFive(this int value)
        {
            int adj = 0;
            if (value % 25 >= 13)
                adj = 25;
            return ((value / 25) * 25) + adj;
        }
        public static int NearestTwentyFive(this double value)
        {
            return (int)Math.Round((value / 25) * 25, 0);
        }

        public static double NearestThirtySecond(this double value)
        {
            return Math.Round(value * 32, MidpointRounding.AwayFromZero) / 32;
        }
    }
}
