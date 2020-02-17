using System;
using System.Linq;
using System.Collections.Generic;


namespace RacerData.iRacing.SessionMonitor.Extensions
{
    public static class MathExtensions
    {
        public static double StandardDeviation(this IEnumerable<double> values)
        {
            double avg = values.Average();
            return Math.Sqrt(values.Average(v => Math.Pow(v - avg, 2)));
        }

        public static float StandardDeviation(this IEnumerable<float> values)
        {
            double avg = values.Average();
            return (float)Math.Sqrt(values.Average(v => Math.Pow(v - avg, 2)));
        }
    }
}
