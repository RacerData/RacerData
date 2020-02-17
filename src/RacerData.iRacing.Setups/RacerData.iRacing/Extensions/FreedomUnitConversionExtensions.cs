using System;

namespace RacerData.iRacing.Extensions
{
    /// <summary>
    /// Strips unit suffix from raw values, converts to freedom units
    /// </summary>
    public static class FreedomUnitConversionExtensions
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
        /// Percent
        /// </summary>
        public static double GetPercent(this string value)
        {
            // FrontBrakeBias: 70%

            return double.Parse(value.Replace("%", ""));
        }
        /// <summary>
        /// Liters to Gallons
        /// </summary>
        public static double GetGallons(this string value)
        {
            // 39.4 L

            var liters = double.Parse(value.Split(' ')[0]);

            return Math.Round(liters * 0.264172, 1);
        }
        /// <summary>
        /// Kilopascals to Pounds/inch squared
        /// </summary>
        public static double GetPsi(this string value)
        {
            // ColdPressure: 138 kPa
            // LastHotPressure: 171 kPa

            var kpa = double.Parse(value.Split(' ')[0]);

            return Math.Round(kpa * 0.145038, 1);
        }
        /// <summary>
        /// Newtons to Pounds
        /// </summary>
        public static double GetPounds(this string value)
        {
            // 3310 N

            var n = double.Parse(value.Split(' ')[0]);

            return Math.Round(n * 0.224809, 0);
        }
        /// <summary>
        /// Millimeters to inches
        /// </summary>
        public static double GetInchesFromMillimeters(this string value)
        {
            // Stagger: 64 mm

            var mm = double.Parse(value.Split(' ')[0]);

            return Math.Round(mm * 0.0393701, 2);
        }
        /// <summary>
        /// Meters to inches
        /// </summary>
        public static double GetInchesFromMeters(this string value)
        {
            // skmodified: BallastForward: -0.762 m
            // latemodel: BallastForward: 1016 mm
            //try
            //{

                var meters = double.Parse(value.Replace('+', ' ').Split(' ')[0]);

                return Math.Round(meters * 39.3701, 0);
            //}
            //catch (Exception ex)
            //{

            //    throw;
            //}
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
    }
}
