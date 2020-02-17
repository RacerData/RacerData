using RacerData.iRacing;

namespace RacerData.iRacingTelemetry.TestApp.Models
{
    public interface IVehicleChassisWheelModel
    {
        //double InstallationRatio { get; }
        double MotionRatio { get; }
        TirePosition Position { get; set; }
        double SpringAngle { get; }
        double SpringRate { get; set; }
        double StaticHeight { get; set; }
        double StaticSpringDeflection { get; set; }
        double StaticWeight { get; set; }
        double SprungWeight { get; }
        double UnsprungWeight { get; }
        double WheelRate { get; }
    }
}