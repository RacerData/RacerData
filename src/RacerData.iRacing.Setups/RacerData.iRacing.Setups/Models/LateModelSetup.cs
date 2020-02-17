using Newtonsoft.Json;

namespace RacerData.iRacing.Setups.Models.LateModel
{
    public class RootObject
    {
        [JsonProperty("CarSetup")]
        public LateModelSetup CarSetup { get; set; }
    }

    public class LateModelSetup : SetupBase
    {
        public string UpdateCount { get; set; }
        public Tires Tires { get; set; }
        public Chassis Chassis { get; set; }
    }

    public class LeftFront
    {
        public string ColdPressure { get; set; }
        public string LastHotPressure { get; set; }
        public string LastTempsOMI { get; set; }
        public string TreadRemaining { get; set; }
    }

    public class LeftRear
    {
        public string ColdPressure { get; set; }
        public string LastHotPressure { get; set; }
        public string LastTempsOMI { get; set; }
        public string TreadRemaining { get; set; }
    }

    public class RightFront
    {
        public string ColdPressure { get; set; }
        public string LastHotPressure { get; set; }
        public string LastTempsIMO { get; set; }
        public string TreadRemaining { get; set; }
        public string Stagger { get; set; }
    }

    public class RightRear
    {
        public string ColdPressure { get; set; }
        public string LastHotPressure { get; set; }
        public string LastTempsIMO { get; set; }
        public string TreadRemaining { get; set; }
        public string Stagger { get; set; }
    }

    public class Tires
    {
        public LeftFront LeftFront { get; set; }
        public LeftRear LeftRear { get; set; }
        public RightFront RightFront { get; set; }
        public RightRear RightRear { get; set; }
    }

    public class Front
    {
        public string BallastForward { get; set; }
        public string NoseWeight { get; set; }
        public string CrossWeight { get; set; }
        public string ToeIn { get; set; }
        public string SteeringRatio { get; set; }
        public string SteeringOffset { get; set; }
        public string BrakeBalanceBar { get; set; }
        // Property name changed Jan-2019
        private string _antiRollBarSize = "";
        public string AntiRollBarSize
        {
            get
            {
                if (string.IsNullOrEmpty(_antiRollBarSize))
                {
                    _antiRollBarSize = SwayBarSize;
                }

                return _antiRollBarSize;
            }
            set
            {
                _antiRollBarSize = value;
            }
        }
        public string SwayBarSize { get; set; }
        // SwayBarArmLength: 330 mm
        public string SwayBarArmLength { get; set; }
        public string LeftBarEndClearance { get; set; }
        public string AttachLeftSide { get; set; }
        // TapeConfiguration: 25%
        public string TapeConfiguration { get; set; }
    }

    public class Rear
    {
        public string FuelFillTo { get; set; }
        public string RearEndRatio { get; set; }
    }

    public class Chassis
    {
        public Front Front { get; set; }
        public ChassisFrontCorner LeftFront { get; set; }
        public ChassisRearCorner LeftRear { get; set; }
        public ChassisFrontCorner RightFront { get; set; }
        public ChassisRightRearCorner RightRear { get; set; }
        public Rear Rear { get; set; }
    }

    public class ChassisCorner
    {
        public string CornerWeight { get; set; }
        public string RideHeight { get; set; }
        public string SpringPerchOffset { get; set; }
        public string SpringRate { get; set; }
        public string BumpStiffness { get; set; }
        public string ReboundStiffness { get; set; }
    }

    public class ChassisFrontCorner : ChassisCorner
    {
        public string Camber { get; set; }
        public string Caster { get; set; }
    }

    public class ChassisRearCorner : ChassisCorner
    {
        public string TrackBarHeight { get; set; }
        // TruckArmMount: bottom
        public string TruckArmMount { get; set; }
    }
    public class ChassisRightRearCorner : ChassisRearCorner
    {
        // TruckArmPreload: 20.4 Nm
        public string TruckArmPreload { get; set; }
    }
}
