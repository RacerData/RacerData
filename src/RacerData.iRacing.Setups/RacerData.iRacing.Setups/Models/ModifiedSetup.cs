using Newtonsoft.Json;

namespace RacerData.iRacing.Setups.Models.SkModified
{
    public class RootObject
    {
        [JsonProperty("CarSetup")]
        public ModifiedSetup CarSetup { get; set; }
    }

    public class ModifiedSetup : SetupBase
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
        public string FrontBrakeBias { get; set; }
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
        public string LeftBarEndClearance { get; set; }
        public string AttachLeftSide { get; set; }
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
        public ChassisRearCorner RightRear { get; set; }
        public Rear Rear { get; set; }
    }

    public class ChassisCorner
    {
        public string CornerWeight { get; set; }
        public string RideHeight { get; set; }
        public string ShockCollarOffset { get; set; }
        public string SpringRate { get; set; }
        public string Compression { get; set; }
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
    }
}
