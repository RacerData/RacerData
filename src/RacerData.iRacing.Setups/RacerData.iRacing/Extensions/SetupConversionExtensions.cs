using System;

namespace RacerData.iRacing.Extensions
{
    /// <summary>
    /// Strips setup-specific unit suffix from raw values, converts to freedom units
    /// </summary>
    public static class SetupConversionExtensions
    {
        /// <summary>
        /// Steering ratio
        /// </summary>
        public static double GetSteeringRatio(this string value)
        {
            // SteeringRatio: 10:1

            return double.Parse(value.Split(':')[0]);
        }
        /// <summary>
        /// Stagger, in eights
        /// </summary>
        public static double GetStagger(this string value)
        {
            // Stagger: 25 mm

            return value.GetInchesFromMillimeters().NearestEighth();
        }
        /// <summary>
        /// Stagger, in eights
        /// </summary>
        public static double GetSwayBarArmLength(this string value)
        {
            // Stagger: 25 mm

            return Math.Round(value.GetInchesFromMillimeters(), 0);
        }
        /// <summary>
        /// TrackBar Height, in half-inches
        /// </summary>
        public static double GetTrackBarHeight(this string value)
        {
            // TrackBarHeight: +267 mm

            return value.GetInchesFromMillimeters().NearestHalf();
        }
        /// <summary>
        /// Toe in, in sixteenths
        /// </summary>
        public static double GetToeIn(this string value)
        {
            // TrackBarHeight: +267 mm

            return value.GetInchesFromMillimeters().NearestSixteenth();
        }

        /// <summary>
        /// AntiRollBar diameter, in sixteenths
        /// </summary>
        public static double GetAntiRollBarSize(this string value)
        {
            // AntiRollBarSize: 40 mm

            return value.GetInchesFromMillimeters().NearestSixteenth();
        }

        /// <summary>
        /// Newton/millimeters to Pounds/inch
        /// </summary>
        public static int GetSpringRate(this string value)
        {
            // 88 N/mm

            var nmm = double.Parse(value.Split(' ')[0]);

            return Math.Round(nmm * 5.7101471627692, 0).NearestTwentyFive();
        }
        /// <summary>
        /// Millimeters to inches
        /// </summary>
        public static double GetRideHeight(this string value)
        {
            // RideHeight: 59 mm

            var rh = double.Parse(value.Split(' ')[0]);

            return Math.Round(rh * 0.0393701, 3);
        }
        /// <summary>
        /// Millimeters to inches
        /// </summary>
        public static double GetShockCollarOffset(this string value)
        {
            // ShockCollarOffset: 111 mm

            var sco = double.Parse(value.Split(' ')[0]);

            return Math.Round(sco * 0.0393701, 3);
        }

        /// <summary>
        /// Newtons to pounds
        /// </summary>
        public static double GetWeight(this string value)
        {
            // CornerWeight: 2568 N

            var w = double.Parse(value.Split(' ')[0]);

            return Math.Round(w * 0.224809, 0);
        }

        /// <summary>
        /// Clicks
        /// </summary>
        public static double GetShockRate(this string value)
        {
            // -15 clicks

            return double.Parse(value.Split(' ')[0]);
        }
        /// <summary>
        /// Tire Temps Celcius to Farenheit
        /// </summary>
        public static double[] GetTireTemps(this string value)
        {
            // LastTempsIMO: 78C, 70C, 49C
            double[] temps = new double[3];

            var tempsC = value.Split(',');

            temps[0] = (double.Parse(tempsC[0].Replace('C', ' ').Trim()) * 1.8) + 32;
            temps[1] = (double.Parse(tempsC[1].Replace('C', ' ').Trim()) * 1.8) + 32;
            temps[2] = (double.Parse(tempsC[2].Replace('C', ' ').Trim()) * 1.8) + 32;

            return temps;
        }
        /// <summary>
        /// Tire Temps Wear Percent
        /// </summary>
        public static double[] GetTireWear(this string value)
        {
            // TreadRemaining: 100%, 100%, 100%
            double[] temps = new double[3];

            var tempsC = value.Split(',');

            temps[0] = tempsC[0].GetPercent();
            temps[1] = tempsC[1].GetPercent();
            temps[2] = tempsC[2].GetPercent();

            return temps;
        }
        /// <summary>
        /// Clicks
        /// </summary>
        public static double GetClicks(this string value)
        {
            // ReboundStiffness: -17 clicks

            return double.Parse(value.Replace("+", "").Split(' ')[0]);
        }
    }
}
