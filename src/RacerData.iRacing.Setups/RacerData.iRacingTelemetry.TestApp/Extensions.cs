using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacerData.iRacingTelemetry.TestApp
{
    public static class Extensions
    {
        /// <summary>
        /// Temperature
        /// </summary>
        public static int CelciusToFarenheit(this string value)
        {
            var temp = (double.Parse(value.Split(' ')[0].Trim()) * 1.8) + 32;

            return (int)Math.Round(temp, 0);
        }
        /// <summary>
        /// Gear ratio
        /// </summary>
        public static double GetPercent(this string value)
        {
            // FrontBrakeBias: 70%

            return double.Parse(value.Replace("%", ""));
        }
        /// <summary>
        /// Gear ratio
        /// </summary>
        public static double GetGearRatio(this string value)
        {
            // RearEndRatio: 4.69

            return double.Parse(value.Split(' ')[0]);
        }
        /// <summary>
        /// Liters to Gallons
        /// </summary>
        public static double GetGallons(this string value)
        {
            // 39.4 L

            var liters = double.Parse(value.Split(' ')[0]);

            return liters * 0.264172;
        }
        /// <summary>
        /// Kilopascals to Pounds/inch squared
        /// </summary>
        public static double GetPsi(this string value)
        {
            // ColdPressure: 138 kPa
            // LastHotPressure: 171 kPa

            var kpa = double.Parse(value.Split(' ')[0]);

            return kpa * 0.145038;
        }
        /// <summary>
        /// Newtons to Pounds
        /// </summary>
        public static double GetPounds(this string value)
        {
            // 3310 N

            var n = double.Parse(value.Split(' ')[0]);

            return n * 0.224809;
        }
        /// <summary>
        /// Millimeters to inches
        /// </summary>
        public static double GetInchesFromMillimeters(this string value)
        {
            // Stagger: 64 mm

            var mm = double.Parse(value.Split(' ')[0]);

            return mm * 0.0393701;
        }
        /// <summary>
        /// Meters to inches
        /// </summary>
        public static double GetInchesFromMeters(this string value)
        {
            // BallastForward: -0.762 m

            var meters = double.Parse(value.Replace('+', ' ').Split(' ')[0]);

            return meters * 39.3701;
        }
        /// <summary>
        /// Kilometers to Miles
        /// </summary>
        public static double GetMilesFromKilometers(this string value)
        {
            // TrackLength: 0.83 km

            var kilometers = double.Parse(value.Split(' ')[0]);

            return kilometers * 0.621371;
        }
        /// <summary>
        /// Degrees
        /// </summary>
        public static double GetDegrees(this string value)
        {
            // Camber: -3.9 deg
            // Caster: +1.1 deg

            return double.Parse(value.Replace("+", "").Split(' ')[0]);
        }
        /// <summary>
        /// Newton/millimeters to Pounds/inch
        /// </summary>
        public static int GetSpringRate(this string value)
        {
            // 88 N/mm

            var nmm = double.Parse(value.Split(' ')[0]);

            return (int)Math.Round(nmm * 5.7101471627692, 0);
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
        public static double[] GetTemps(this string value)
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
        /// Percent worn
        /// </summary>
        public static double[] GetWear(this string value)
        {
            // TreadRemaining: 100 %, 100 %, 100 %
            double[] wear = new double[3];

            var wearString = value.Replace("%", "").Replace(",", "").Split(' ');

            wear[0] = double.Parse(wearString[0]);
            wear[1] = double.Parse(wearString[1]);
            wear[2] = double.Parse(wearString[2]);

            return wear;
        }



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
