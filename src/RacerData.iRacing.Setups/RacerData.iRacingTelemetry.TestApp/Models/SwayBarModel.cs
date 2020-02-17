namespace RacerData.iRacingTelemetry.TestApp.Models
{
    public class ModifiedSwayBarModel : SwayBarModel
    {
        public override double Length => 37.5;
        public override double ArmLength => 16.5;
        public override double ArmPerpindicularLength => 16.5; // 13.9 for 30 degree bend, 16.5 for 0 degree bend
    }

    public class SwayBarModel : ISwayBarModel
    {
        // All measurements in inches
        // Common lengths - 33, 34, 35, 36.5, 37.5, 38.5, 39, 40.5, 42, 43
        // Common wall thickness - .125, .188, .250,.500
        // Common arm angles - 0*, 15*, 30*
        public virtual double OuterDiameter { get; set; }
        public virtual double? InnerDiameter { get; protected set; }
        public virtual double Length { get; protected set; }
        public virtual double ArmLength { get; protected set; }
        public virtual double ArmPerpindicularLength { get; protected set; }
    }
}
