using System;
using RacerData.iRacingTelemetry.TestApp.Models;

namespace RacerData.iRacingTelemetry.TestApp.Services
{
    public static class SwayBarService
    {
        public static double CalculateRate(ISwayBarModel model)
        {
            var k = 500000 * (
                    Math.Pow(model.OuterDiameter, 4) - Math.Pow(model.InnerDiameter.GetValueOrDefault(0), 4))
                    / (
                        (0.4244 * Math.Pow(model.ArmPerpindicularLength, 2) * model.Length) + (0.2264 * Math.Pow(model.ArmLength, 3)
                       )
                    );

            return k;

        }

        public static double CalculateTwist(ISwayBarModel model, double deltaLeftInches, double deltaRightInches)
        {
            var displacement = Math.Abs(deltaLeftInches - deltaRightInches);

            var twistAngle = Math.Acos(
                (Math.Pow(model.ArmLength, 2) + Math.Pow(model.ArmLength, 2) - Math.Pow(displacement, 2)) /
                (2 * model.ArmLength * model.ArmLength)
                );

            return twistAngle;
        }

        public static double CalculateForce(ISwayBarModel model, double deltaLeftInches, double deltaRightInches)
        {
            var r = CalculateRate(model); // per degree

            var twistAngle = CalculateTwist(model, deltaLeftInches, deltaRightInches);

            return r * twistAngle;
        }
    }
}
