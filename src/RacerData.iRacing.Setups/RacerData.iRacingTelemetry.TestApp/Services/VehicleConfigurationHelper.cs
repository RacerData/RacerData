using System;
using System.Collections.Generic;
using System.Linq;
using RacerData.iRacingTelemetry.TestApp.Models;

namespace RacerData.iRacingTelemetry.TestApp.Services
{
    public static class VehicleConfigurationHelper
    {
        /// <summary>
        /// Returns the installation ratio for the given movement
        /// </summary>
        /// <param name="springPerchOffsetDelta">Change in spring perch offset</param>
        /// <param name="rideHeightDelta">Corresponding change in ride height</param>
        /// <remarks>Installation ratio is the inverse of motion ratio
        /// Measurement should be taken with all four corners at same ride height.
        /// Adjust all four corners the same amount, and note changes.</remarks>
        public static float GetSpringInstallationRatio(float springPerchOffsetDelta, float rideHeightDelta)
        {
            return springPerchOffsetDelta / rideHeightDelta;
        }

        /// <summary>
        /// Returns the spring motion ratio for the given movement
        /// </summary>
        /// <param name="springPerchOffsetDelta">Change in spring perch offset</param>
        /// <param name="rideHeightDelta">Corresponding change in ride height</param>
        /// <remarks>Motion ratio is the inverse of installation ratio.
        /// Measurement should be taken with all four corners at same ride height.
        /// Adjust all four corners the same amount, and note changes.</remarks>
        public static float GetSpringMotionRatio(float springPerchOffsetDelta, float rideHeightDelta)
        {
            return rideHeightDelta / springPerchOffsetDelta;
        }

        /// <summary>
        /// Returns the damper installation ratio for the given movement
        /// </summary>
        /// <param name="damperOffsetDelta">Change in damper offset</param>
        /// <param name="rideHeightDelta">Corresponding change in ride height</param>
        /// <remarks>Installation ratio is the inverse of motion ratio
        /// Measurement should be taken with all four corners at same ride height.
        /// Adjust all four corners the same amount, and note changes.</remarks>
        public static float GetDamperInstallationRatio(float damperOffsetDelta, float rideHeightDelta)
        {
            return damperOffsetDelta / rideHeightDelta;
        }

        /// <summary>
        /// Returns the damper motion matio for the given movement
        /// </summary>
        /// <param name="damperOffsetDelta">Change in damper offset</param>
        /// <param name="rideHeightDelta">Corresponding change in ride height</param>
        /// <remarks>Motion ratio is the inverse of installation ratio
        /// Measurement should be taken with all four corners at same ride height.
        /// Adjust all four corners the same amount, and note changes.</remarks>
        public static float GetDamperMotionRatio(float damperOffsetDelta, float rideHeightDelta)
        {
            return rideHeightDelta / damperOffsetDelta;
        }

        /// <summary>
        /// Calculates damper bump transition speed, in millimeters per second
        /// </summary>
        /// <param name="transitionBumpForce_Newtons">Damper bump transition force, in Newtons</param>
        /// <param name="lowSpeedBumpDamping_Ns_m">Low speed bump damping rate, in Ns/m</param>
        /// <remarks>Should be between 50 mm/s (~2 in/s) and 75 mm/s (~3 in/s)</remarks>
        public static float GetVelocityTransitionSpeedBump(float transitionBumpForce_Newtons, float lowSpeedBumpDamping_Ns_m)
        {
            return (transitionBumpForce_Newtons * lowSpeedBumpDamping_Ns_m) * 1000;
        }

        /// <summary>
        /// Calculates damper rebound transition speed, in millimeters per second
        /// </summary>
        /// <param name="transitionReboundForce_Newtons">Damper rebound transition force, in Newtons</param>
        /// <param name="lowSpeedReboundDamping_Ns_m">Low speed rebound damping rate, in Ns/m</param>
        /// <remarks>Should be between 50 mm/s (~2 in/s) and 75 mm/s (~3 in/s)</remarks>
        public static float GetVelocityTransitionSpeedRebound(float transitionReboundForce_Newtons, float lowSpeedReboundDamping_Ns_m)
        {
            return (transitionReboundForce_Newtons * lowSpeedReboundDamping_Ns_m) * 1000;
        }

        /// <summary>
        /// Returns the average roll gradient for the list of roll angle-to-G values.
        /// </summary>
        /// <param name="rollAngle_G_Values">list of roll angle to acceleration in G's pairs./param>
        /// <returns>Average roll gradient</returns>
        public static float GetRollGradient(IList<ValueTuple<float, float>> rollAngle_G_Values)
        {
            return rollAngle_G_Values.Average(r => r.Item1) / rollAngle_G_Values.Average(r => r.Item2);
        }

        /// <summary>
        /// Returns the average pitch gradient for the list of pitch angle-to-G values.
        /// </summary>
        /// <param name="pitchAngle_G_Values">list of pitch angle to acceleration in G's pairs./param>
        /// <returns>Average pitch gradient</returns>
        public static float GetPitchGradient(IList<ValueTuple<float, float>> pitchAngle_G_Values)
        {
            return pitchAngle_G_Values.Average(r => r.Item1) / pitchAngle_G_Values.Average(r => r.Item2);
        }

        /// <summary>
        /// Returns histogram data for the given damper velocity values,
        /// </summary>
        /// <param name="damperVelocities">List of damper velocity values in m/s</param>
        /// <returns>Histogram for the given range, in % for each 10 mm/s range from -240 mm/s to 240 mm/s</returns>
        public static HistogramData GetDamperHistogramData(IList<float> damperVelocities)
        {
            var lowHighTransition = 40;

            return new HistogramData(-240, 240, 10, lowHighTransition, damperVelocities);
        }

        public static double GetSpringAngleCorrectionFactorFromDegrees(double springAngleInDegrees)
        {
            var radians = (springAngleInDegrees * Math.PI) / 1800;
            return GetSpringAngleCorrectionFactorFromRadians(radians);
        }
        public static double GetSpringAngleCorrectionFactorFromRadians(double springAngleInRadians)
        {
            return Math.Cos(springAngleInRadians);
        }

        public static double GetWheelRate(double motionRatio, double springRate, double springAngleInDegrees)
        {
            var correctionFactor = GetSpringAngleCorrectionFactorFromDegrees(springAngleInDegrees);
            return Math.Pow(motionRatio, 2) * springRate * correctionFactor;
        }

        public static double SuspensionCyclesPerMinute(double wheelRate, double sprungWeight)
        {
            return 187.8 * Math.Sqrt(wheelRate / sprungWeight);
        }
        public static double SuspensionFrequencyHertz(double suspensionCyclesPerMinute)
        {
            return suspensionCyclesPerMinute / 60;
        }
    }

    public class SuspensionAnalysisData
    {
        public double FrontFrequency { get; set; }
        public double RearFrequency { get; set; }
        public double FrequencyDistribution { get; set; }

        public double FrontRollStiffness { get; set; }
        public double RearRollStiffness { get; set; }
        public double TotalRollStiffness { get; set; }

        public double RollStiffnessDistribution { get; set; }
    }

    public class HistogramData
    {
        public IDictionary<int, float> Histogram { get; private set; }
        public IList<float> DamperVelocities { get; private set; }
        public float HighSpeedRebound { get; private set; }
        public float LowSpeedRebound { get; private set; }
        public float LowSpeedBump { get; private set; }
        public float HighSpeedBump { get; private set; }
        public float ZeroBin { get; private set; }
        public int Min { get; private set; } = -240;
        public int Max { get; private set; } = 240;
        public int BinSize { get; private set; } = 10;
        public float LowHighThreshold { get; private set; } = 100;

        public HistogramData(int min, int max, int binSize, float lowHighThreshold, IList<float> damperVelocities)
        {
            Min = min;
            Max = max;
            BinSize = binSize;
            LowHighThreshold = lowHighThreshold;
            DamperVelocities = damperVelocities;

            Histogram = GetNewHistogramDictionary(Min, Max, BinSize);

            PopulateHistogram();
        }

        private void PopulateHistogram()
        {
            int[] velocityRangeCounts = new int[Histogram.Count];

            HighSpeedRebound = DamperVelocities.Where(v => v < (LowHighThreshold * -1)).Average();
            LowSpeedRebound = DamperVelocities.Where(v => v >= (LowHighThreshold * -1) && v < 0).Average();
            LowSpeedBump = DamperVelocities.Where(v => v > 0 && v <= LowHighThreshold).Average();
            HighSpeedBump = DamperVelocities.Where(v => v > LowHighThreshold).Average();

            int zeroBinCount = DamperVelocities.Where(v => v >= (BinSize * -1) && v <= BinSize).Count();
            ZeroBin = (float)zeroBinCount / (float)DamperVelocities.Count;

            for (int i = 0; i < Histogram.Count - 1; i++)
            {
                var lowerVelocityRange = Histogram.Keys.ElementAt(i);
                var upperVelocityRange = Histogram.Keys.ElementAt(i + 1);

                velocityRangeCounts[i] = DamperVelocities.Where(v => v > lowerVelocityRange && v <= upperVelocityRange).Count();
            }

            velocityRangeCounts[Histogram.Count - 1] = DamperVelocities.Where(v => v > Histogram.Keys.ElementAt(Histogram.Count - 1)).Count();

            for (int i = 0; i < Histogram.Count; i++)
            {
                Histogram[Histogram.Keys.ElementAt(i)] = (float)velocityRangeCounts[i] / (float)DamperVelocities.Count;
            }
        }

        private IDictionary<int, float> GetNewHistogramDictionary(int min, int max, int step)
        {
            IDictionary<int, float> histogram = new Dictionary<int, float>();

            for (int i = min; i <= max; i += step)
            {
                histogram.Add(i, 0);
            }

            return histogram;
        }

    }
}
