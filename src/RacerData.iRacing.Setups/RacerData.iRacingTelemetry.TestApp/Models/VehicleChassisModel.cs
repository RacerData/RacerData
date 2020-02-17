using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RacerData.iRacing;
using RacerData.iRacing.Extensions;
using RacerData.iRacing.Telemetry;

namespace RacerData.iRacingTelemetry.TestApp.Models
{
    public class ModifiedChassisLeftFrontWheelModel : ModifiedChassisFrontWheelModel
    {
        private const double LFInstallationRatio = .776;
        private const double LFMotionRatio = 1.28;

        public override TirePosition Position => TirePosition.LF;

        //public override double InstallationRatio => LFInstallationRatio;
        //public override double MotionRatio => LFMotionRatio;
    }
    public class ModifiedChassisRightFrontWheelModel : ModifiedChassisFrontWheelModel
    {
        private const double RFInstallationRatio = .759;
        private const double RFMotionRatio = 1.31;

        public override TirePosition Position => TirePosition.RF;

        //public override double InstallationRatio => RFInstallationRatio;
        //public override double MotionRatio => RFMotionRatio;
    }
    public abstract class ModifiedChassisFrontWheelModel : VehicleChassisWheelModel
    {
        private const double FrontUnsprungWeight = 97.0;

        public override double UnsprungWeight => FrontUnsprungWeight;

        /// <summary>
        /// Coil over inclination, in degrees
        /// </summary>
        public override double SpringAngle => 18.0;
        public override double SpringToWheelTravelRatio { get; set; } = .765;
    }

    public class ModifiedChassisLeftRearWheelModel : ModifiedChassisRearWheelModel
    {
        public override TirePosition Position => TirePosition.LR;
    }
    public class ModifiedChassisRightRearWheelModel : ModifiedChassisRearWheelModel
    {
        public override TirePosition Position => TirePosition.RR;

    }
    public abstract class ModifiedChassisRearWheelModel : VehicleChassisWheelModel
    {
        private const double RearUnsprungWeight = 146.25;
        private const double RearSpringAngle = 0;
        private const double RearMotionRatio = 1;
        private const double RearInstallationRatio = 1;

        public override double UnsprungWeight => RearUnsprungWeight;
        public override double SpringAngle => RearSpringAngle;
        public override double SpringToWheelTravelRatio { get; set; } = 1;
    }

    public abstract class VehicleChassisWheelModel : IVehicleChassisWheelModel
    {
        public virtual TirePosition Position { get; set; }

        public virtual double StaticHeight { get; set; }
        public virtual double StaticWeight { get; set; }
        public virtual double SpringRate { get; set; }
        public virtual double StaticSpringDeflection { get; set; }

        public abstract double SpringAngle { get; }
        public virtual double MotionRatio
        {
            get
            {
                return Math.Pow(SpringToWheelTravelRatio, 2);
            }
        }
        /// <summary>
        /// Spring travel over wheel travel
        /// </summary>
        public virtual double SpringToWheelTravelRatio { get; set; }

        public abstract double UnsprungWeight { get; }
        public virtual double SprungWeight
        {
            get
            {
                return StaticWeight - UnsprungWeight;
            }
        }
        public virtual double WheelRate
        {
            get
            {
                return Math.Pow(MotionRatio, 2) * SpringRate;// * Math.Pow(Math.Cos(SpringAngle.DegreesToRadians()), 2);
            }
        }
    }

    public class SkModifiedChassisModel : VehicleChassisModel
    {
        public override double BaseTireDiameter { get; set; } = 81.5; // left = 81.5, right = 84, per Hoosier
        public override double Track { get; set; } = 84;
        public override double Wheelbase { get; set; } = 110;
        public override ISwayBarModel SwayBar { get; set; } = new ModifiedSwayBarModel();

        public override IVehicleChassisWheelModel LFWheel { get; protected set; } = new ModifiedChassisLeftFrontWheelModel();
        public override IVehicleChassisWheelModel LRWheel { get; protected set; } = new ModifiedChassisLeftRearWheelModel();
        public override IVehicleChassisWheelModel RFWheel { get; protected set; } = new ModifiedChassisRightFrontWheelModel();
        public override IVehicleChassisWheelModel RRWheel { get; protected set; } = new ModifiedChassisRightRearWheelModel();


        public SkModifiedChassisModel()
            : base()
        {

        }

        public SkModifiedChassisModel(string chassisAnalysisName)
            : base(2, "skmodified", chassisAnalysisName)
        {
        }
    }

    public class VehicleChassisModel
    {
        #region properties

        public long VehicleId { get; set; }
        public string VehicleName { get; set; }
        public string ChassisAnalysisName { get; set; }

        public virtual double Wheelbase { get; set; }
        public virtual double Track { get; set; }

        public virtual ISwayBarModel SwayBar { get; set; } = new SwayBarModel();

        public virtual double BaseTireDiameter { get; set; }

        public virtual double[] GearRatios { get; set; } = new double[] { 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F };
        public virtual double FinalGearRatio { get; set; }

        public virtual IVehicleChassisWheelModel LFWheel { get; protected set; }
        public virtual IVehicleChassisWheelModel LRWheel { get; protected set; }
        public virtual IVehicleChassisWheelModel RFWheel { get; protected set; }
        public virtual IVehicleChassisWheelModel RRWheel { get; protected set; }

        #endregion

        #region ctor

        public VehicleChassisModel()
        {

        }

        public VehicleChassisModel(long vehicleId, string vehicleName, string chassisAnalysisName)
        {
            VehicleId = vehicleId;
            VehicleName = vehicleName;
            ChassisAnalysisName = chassisAnalysisName;
        }

        #endregion

        #region public

        public void LoadSetupParameters(ICarSetup setup)
        {
            IDictionary<object, object> chassis = (IDictionary<object, object>)setup.ValuesDictionary["Chassis"];

            LFWheel.StaticHeight = GetCornerRideHeight(chassis, "LeftFront");
            LRWheel.StaticHeight = GetCornerRideHeight(chassis, "LeftRear");
            RFWheel.StaticHeight = GetCornerRideHeight(chassis, "RightFront");
            RRWheel.StaticHeight = GetCornerRideHeight(chassis, "RightRear");

            LFWheel.StaticWeight = GetCornerWeight(chassis, "LeftFront");
            LRWheel.StaticWeight = GetCornerWeight(chassis, "LeftRear");
            RFWheel.StaticWeight = GetCornerWeight(chassis, "RightFront");
            RRWheel.StaticWeight = GetCornerWeight(chassis, "RightRear");

            LFWheel.SpringRate = GetCornerSpringRate(chassis, "LeftFront");
            LRWheel.SpringRate = GetCornerSpringRate(chassis, "LeftRear");
            RFWheel.SpringRate = GetCornerSpringRate(chassis, "RightFront");
            RRWheel.SpringRate = GetCornerSpringRate(chassis, "RightRear");

            LFWheel.StaticSpringDeflection = GetShockCollarOffset(chassis, "LeftFront");
            LRWheel.StaticSpringDeflection = GetShockCollarOffset(chassis, "LeftRear");
            RFWheel.StaticSpringDeflection = GetShockCollarOffset(chassis, "RightFront");
            RRWheel.StaticSpringDeflection = GetShockCollarOffset(chassis, "RightRear");

            SwayBar.OuterDiameter = GetSwayBarSize(chassis);
        }

        public string Serialize()
        {
            var jsonSerializerSettings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Formatting.Indented
            };

            var json = JsonConvert.SerializeObject(this, jsonSerializerSettings);

            return json;
        }

        public static VehicleChassisModel Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<VehicleChassisModel>(json);
        }

        public VehicleChassisModel Clone()
        {
            var json = this.Serialize();

            return JsonConvert.DeserializeObject<VehicleChassisModel>(json);
        }

        #endregion

        #region private

        private double GetCornerRideHeight(IDictionary<object, object> chassis, string corner)
        {
            IDictionary<object, object> chassisCorner = (IDictionary<object, object>)chassis[corner];
            return chassisCorner["RideHeight"].ToString().GetRideHeight();
        }
        private double GetCornerWeight(IDictionary<object, object> chassis, string corner)
        {
            IDictionary<object, object> chassisCorner = (IDictionary<object, object>)chassis[corner];
            return chassisCorner["CornerWeight"].ToString().GetWeight();
        }
        private int GetCornerSpringRate(IDictionary<object, object> chassis, string corner)
        {
            IDictionary<object, object> chassisCorner = (IDictionary<object, object>)chassis[corner];
            return chassisCorner["SpringRate"].ToString().GetSpringRate();
        }
        private double GetShockCollarOffset(IDictionary<object, object> chassis, string corner)
        {
            IDictionary<object, object> chassisCorner = (IDictionary<object, object>)chassis[corner];
            return chassisCorner["ShockCollarOffset"].ToString().GetShockCollarOffset();
        }
        private double GetSwayBarSize(IDictionary<object, object> chassis)
        {
            IDictionary<object, object> chassisCorner = (IDictionary<object, object>)chassis["Front"];
            return chassisCorner["AntiRollBarSize"].ToString().GetAntiRollBarSize();
        }

        #endregion
    }
}
