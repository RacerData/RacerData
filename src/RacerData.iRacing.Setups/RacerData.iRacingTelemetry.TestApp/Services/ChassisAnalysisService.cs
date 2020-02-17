using System;
using RacerData.iRacingTelemetry.TestApp.Models;

namespace RacerData.iRacingTelemetry.TestApp.Services
{
    public static class ChassisAnalysisService
    {
        public static ChassisAnalysis AnalyzeChassis(VehicleChassisModel model)
        {
            ChassisAnalysis analysis = new ChassisAnalysis();

            double swayBarWheelRate = SwayBarService.CalculateRate(model.SwayBar);

            var lfHz = GetSuspensionFrequency(model.LFWheel, swayBarWheelRate);
            var rfHz = GetSuspensionFrequency(model.LFWheel, swayBarWheelRate);
            analysis.FrontFrequency = (lfHz + rfHz) / 2;

            var lrHz = GetSuspensionFrequency(model.LRWheel);
            var rrHz = GetSuspensionFrequency(model.LRWheel);
            analysis.RearFrequency = (lrHz + rrHz) / 2;

            analysis.FrontRollStiffness = GetRollStiffness(model.Track, model.LFWheel, model.RFWheel);
            //var lfRs = GetRollStiffness(model.Track, model.LFWheel);
            //var rfRs = GetRollStiffness(model.Track, model.RFWheel);
            // var springCenter = ((model.LFWheel.SpringRate - model.RFWheel.SpringRate) / (model.LFWheel.SpringRate + model.RFWheel.SpringRate))
            //var sbRs = GetRollStiffness(model.Track, model.SwayBar.W
            //analysis.FrontRollStiffness = (lfRs + rfRs) / 2;

            analysis.RearRollStiffness = GetRollStiffness(model.Track, model.LRWheel, model.RRWheel);
            //var lrRs = GetRollStiffness(model.Track, model.LRWheel);
            //var rrRs = GetRollStiffness(model.Track, model.RRWheel);
            //analysis.RearRollStiffness = (lrRs + rrRs) / 2;


            return analysis;
        }

        private static double GetSuspensionFrequency(IVehicleChassisWheelModel model)
        {
            return GetSuspensionFrequency(model, 0);
        }
        private static double GetSuspensionFrequency(IVehicleChassisWheelModel model, double swayBarWheelRate)
        {
            return SuspensionFrequencyHertz(model.WheelRate + swayBarWheelRate, model.SprungWeight);
        }

        private static double DeflectionRate(double barDiameter, double barLength, double armLength)
        {
            var G = 1;
            var r = armLength;

            var length = 37.5; // barLength
            var diameter = 1.5;// barDiameter

            var F = Math.PI * Math.Pow(diameter, 4) * G;
           
            var o = 32 * length * Math.Pow(r, 2);

            var deflectionAtEnd
            return F / o;
        }

        private static double GetRollStiffness(double trackWidth, IVehicleChassisWheelModel lWheel, IVehicleChassisWheelModel rWheel)
        {
            double track = trackWidth;// 68; // trackWidth
            double lWheelRate = lWheel.WheelRate;// 150; // lWheel.WheelRate
            double rWheelRate = rWheel.WheelRate;// 200; // rWheel.WheelRate

            //double trackSquared = Math.Pow(track, 2);
            //double totalWheelRate = lWheelRate + rWheelRate;
            //double leftOverTotalSquared = Math.Pow(lWheelRate / totalWheelRate, 2);
            //double top = trackSquared * (totalWheelRate * leftOverTotalSquared);
            //double result = top / 688;

            //var xtop = 688 * 432;
            //var xbrace = xtop / trackSquared;
            // xbrace = 350 * (150/350)^2

            // 150/350 = .4285714
            // (150/350)^2= 0.1836734693877551
            // 350 * 0.1836734693877551 = 64.28571428571429‬
            // 68^2=4,624
            // 4,624 * 64.28571428571429‬= 297,257.1428571429‬
            // 297,257.1428571429‬ / 688 = 432.0598006644519
            var x = (Math.Pow(track, 2) * ((lWheelRate + rWheelRate) * Math.Pow((lWheelRate / (lWheelRate + rWheelRate)), 2))) / 688;



            return x;
        }

        public static double GetSpringAngleCorrectionFactorFromDegrees(double springAngleInDegrees)
        {
            var radians = (springAngleInDegrees * Math.PI) / 1800;
            return GetSpringAngleCorrectionFactorFromRadians(radians);
        }
        public static double GetSpringAngleCorrectionFactorFromRadians(double springAngleInRadians)
        {
            //return Math.Cos(springAngleInRadians);
            return Math.Pow(Math.Cos(springAngleInRadians), 2);
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
        public static double SuspensionFrequencyHertz(double wheelRate, double sprungWeight)
        {
            return SuspensionCyclesPerMinute(wheelRate, sprungWeight) / 60;
        }
    }
}
