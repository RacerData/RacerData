namespace RacerData.iRacingTelemetry.TestApp.Models
{
    public interface ISwayBarModel
    {
        double ArmLength { get; }
        double ArmPerpindicularLength { get; }
        double? InnerDiameter { get; }
        double Length { get; }
        double OuterDiameter { get; set; }
    }
}