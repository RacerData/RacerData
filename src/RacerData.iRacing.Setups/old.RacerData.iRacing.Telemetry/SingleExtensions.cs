using System;
using System.Collections.Generic;
using System.Text;

namespace RacerData.iRacing.Telemetry
{
    public static class SingleExtensions
    {
        public const Single MeterToFeetRatio = 3.28F;
        public const Single MeterToInchRatio = 39.37F;
        public const Single RadiansToDegreesRatio = 57.2958F;
        public const Single kPaToPSIRatio = 0.145038F;
        public const Single BarToHgRatio = 29.53F;
        public const Single LiterToGallonRatio = 0.26417F;
        public const Single NmToFtLbsRatio = 0.737562149277F;
        public const Single Ms2ToGRatio = 0.101972F;

        public static Single MetersToFeet(this Single value)
        {
            return value * MeterToFeetRatio;
        }
        public static Single MetersToInches(this Single value)
        {
            return value * MeterToInchRatio;
        }
        public static Single Ms2ToG(this Single value)
        {
            return value * Ms2ToGRatio;
        }
        public static Single RadiansToDegrees(this Single value)
        {
            return value * RadiansToDegreesRatio;
        }

        public static Single kPaToPSI(this Single value)
        {
            return value * kPaToPSIRatio;
        }
        public static Single BarToHg(this Single value)
        {
            return value * BarToHgRatio;
        }
        public static Single CelciusToFarenheit(this Single value)
        {
            return ((value * 9) / 5) + 32;
        }
        public static Single NmToFtLbs(this Single value)
        {
            return value * NmToFtLbsRatio;
        }
        public static Single LiterToGallon(this Single value)
        {
            return value * LiterToGallonRatio;
        }
    }
}
