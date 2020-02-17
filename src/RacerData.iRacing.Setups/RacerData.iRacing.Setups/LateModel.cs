using RacerData.iRacing.Extensions;
using RacerData.iRacing.Setups.Models;
using RacerData.iRacing.Setups.Models.LateModel;

namespace RacerData.iRacing.Setups.LateModel
{
    public class LateModel : SetupBase
    {
        public int UpdateCount { get; set; }
        public Tires Tires { get; set; }
        public Chassis Chassis { get; set; }

        public string Description
        {
            get
            {
                return $"{System.IO.Path.GetFileNameWithoutExtension(SetupFileName)} ({UpdateCount})";
            }
        }

        public LateModel()
        {

        }

        public LateModel(LateModelSetup setup)
        {
            UpdateCount = int.Parse(setup.UpdateCount);
            Tires = new Tires(setup);
            Chassis = new Chassis(setup);
            TelemetryFileName = setup.TelemetryFileName;
            SetupFileName = setup.SetupFileName;
        }
    }

    public class Tire
    {
        /// <summary>
        /// PSI
        /// </summary>
        public double ColdPressure { get; set; }
        /// <summary>
        /// PSI
        /// </summary>
        public double LastHotPressure { get; set; }
        /// <summary>
        /// Farenheit
        /// </summary>
        public double LastTempI { get; set; }
        /// <summary>
        /// Farenheit
        /// </summary>
        public double LastTempM { get; set; }
        /// <summary>
        /// Farenheit
        /// </summary>
        public double LastTempO { get; set; }
        /// <summary>
        /// Percent
        /// </summary>
        public double TreadRemainingI { get; set; }
        /// <summary>
        /// Percent
        /// </summary>
        public double TreadRemainingM { get; set; }
        /// <summary>
        /// Percent
        /// </summary>
        public double TreadRemainingO { get; set; }
    }

    public class Tires
    {
        public Tire LeftFront { get; set; }
        public Tire LeftRear { get; set; }
        public Tire RightFront { get; set; }
        public Tire RightRear { get; set; }

        public double FrontStagger { get; set; }
        public double RearStagger { get; set; }

        public Tires(LateModelSetup setup)
        {
            LeftFront = new Tire()
            {
                ColdPressure = setup.Tires.LeftFront.ColdPressure.GetPsi(),
                LastHotPressure = setup.Tires.LeftFront.LastHotPressure.GetPsi()
            };
            var lfTemps = setup.Tires.LeftFront.LastTempsOMI.GetTireWear();
            LeftFront.LastTempO = lfTemps[0];
            LeftFront.LastTempM = lfTemps[1];
            LeftFront.LastTempI = lfTemps[2];
            var lfWear = setup.Tires.LeftFront.TreadRemaining.GetTireWear();
            LeftFront.TreadRemainingO = lfWear[0];
            LeftFront.TreadRemainingM = lfWear[1];
            LeftFront.TreadRemainingI = lfWear[2];

            LeftRear = new Tire()
            {
                ColdPressure = setup.Tires.LeftRear.ColdPressure.GetPsi(),
                LastHotPressure = setup.Tires.LeftRear.LastHotPressure.GetPsi()
            };
            var lrTemps = setup.Tires.LeftRear.LastTempsOMI.GetTireWear();
            LeftRear.LastTempO = lrTemps[0];
            LeftRear.LastTempM = lrTemps[1];
            LeftRear.LastTempI = lrTemps[2];
            var lrWear = setup.Tires.LeftRear.TreadRemaining.GetTireWear();
            LeftRear.TreadRemainingO = lrWear[0];
            LeftRear.TreadRemainingM = lrWear[1];
            LeftRear.TreadRemainingI = lrWear[2];

            RightFront = new Tire()
            {
                ColdPressure = setup.Tires.RightFront.ColdPressure.GetPsi(),
                LastHotPressure = setup.Tires.RightFront.LastHotPressure.GetPsi()
            };
            var rfTemps = setup.Tires.RightFront.LastTempsIMO.GetTireTemps();
            RightFront.LastTempI = rfTemps[0];
            RightFront.LastTempM = rfTemps[1];
            RightFront.LastTempO = rfTemps[2];
            var rfWear = setup.Tires.RightFront.TreadRemaining.GetTireTemps();
            RightFront.TreadRemainingI = rfWear[0];
            RightFront.TreadRemainingM = rfWear[1];
            RightFront.TreadRemainingO = rfWear[2];

            RightRear = new Tire()
            {
                ColdPressure = setup.Tires.RightRear.ColdPressure.GetPsi(),
                LastHotPressure = setup.Tires.RightRear.LastHotPressure.GetPsi()
            };
            var rrTemps = setup.Tires.RightRear.LastTempsIMO.GetTireTemps();
            RightRear.LastTempI = rrTemps[0];
            RightRear.LastTempM = rrTemps[1];
            RightRear.LastTempO = rrTemps[2];
            var rrWear = setup.Tires.RightRear.TreadRemaining.GetTireTemps();
            RightRear.TreadRemainingI = rrWear[0];
            RightRear.TreadRemainingM = rrWear[1];
            RightRear.TreadRemainingO = rrWear[2];

            FrontStagger = setup.Tires.RightFront.Stagger.GetInchesFromMillimeters();
            RearStagger = setup.Tires.RightRear.Stagger.GetInchesFromMillimeters();
        }
    }

    public class Front
    {
        public double BallastForward { get; set; }
        public double NoseWeight { get; set; }
        public double CrossWeight { get; set; }
        public double ToeIn { get; set; }
        public string SteeringRatio { get; set; }
        public double SteeringOffset { get; set; }
        public double BrakeBalanceBar { get; set; }
        public double AntiRollBarSize { get; set; }
        public double LeftBarEndClearance { get; set; }
        public bool AttachLeftSide { get; set; }
        public string TapeConfiguration { get; set; }

        public Front(LateModelSetup setup)
        {
            BallastForward = setup.Chassis.Front.BallastForward.GetInchesFromMeters();
            NoseWeight = setup.Chassis.Front.NoseWeight.GetPercent();
            CrossWeight = setup.Chassis.Front.CrossWeight.GetPercent();
            ToeIn = setup.Chassis.Front.ToeIn.GetInchesFromMillimeters();
            SteeringRatio = setup.Chassis.Front.SteeringRatio;
            TapeConfiguration = setup.Chassis.Front.TapeConfiguration;

            SteeringOffset = setup.Chassis.Front.SteeringOffset.GetDegrees();
            BrakeBalanceBar = setup.Chassis.Front.BrakeBalanceBar.GetPercent();
            AntiRollBarSize = setup.Chassis.Front.AntiRollBarSize.GetInchesFromMillimeters();
            LeftBarEndClearance = setup.Chassis.Front.LeftBarEndClearance.GetInchesFromMillimeters();
            AttachLeftSide = (setup.Chassis.Front.AttachLeftSide == "1");

        }
    }

    public class Rear
    {
        public double FuelFillTo { get; set; }
        public double RearEndRatio { get; set; }

        public Rear(LateModelSetup setup)
        {
            FuelFillTo = setup.Chassis.Rear.FuelFillTo.GetGallons();
            RearEndRatio = double.Parse(setup.Chassis.Rear.RearEndRatio);
        }
    }

    public class Chassis
    {
        public Front Front { get; set; }
        public ChassisFrontCorner LeftFront { get; set; }
        public ChassisRearCorner LeftRear { get; set; }
        public ChassisFrontCorner RightFront { get; set; }
        public ChassisRearCorner RightRear { get; set; }
        public Rear Rear { get; set; }

        public Chassis(LateModelSetup setup)
        {
            Front = new Front(setup);

            LeftFront = new ChassisFrontCorner(setup, true);
            LeftRear = new ChassisRearCorner(setup, true);
            RightFront = new ChassisFrontCorner(setup, false);
            RightRear = new ChassisRearCorner(setup, false);

            Rear = new Rear(setup);
        }
    }

    public class ChassisFrontCorner
    {
        public double CornerWeight { get; set; }
        public double RideHeight { get; set; }
        public double SpringPerchOffset { get; set; }
        public int SpringRate { get; set; }
        public double BumpStiffness { get; set; }
        public double ReboundStiffness { get; set; }
        public double Camber { get; set; }
        public double Caster { get; set; }

        public ChassisFrontCorner(LateModelSetup setup, bool isLeftSide)
        {
            CornerWeight = isLeftSide ?
                  setup.Chassis.LeftFront.CornerWeight.GetPounds() :
                  setup.Chassis.RightFront.CornerWeight.GetPounds();

            RideHeight = isLeftSide ?
                setup.Chassis.LeftFront.RideHeight.GetInchesFromMillimeters() :
                setup.Chassis.RightFront.RideHeight.GetInchesFromMillimeters();

            SpringPerchOffset = isLeftSide ?
                setup.Chassis.LeftFront.SpringPerchOffset.GetInchesFromMillimeters() :
                setup.Chassis.RightFront.SpringPerchOffset.GetInchesFromMillimeters();

            SpringRate = isLeftSide ?
                setup.Chassis.LeftFront.SpringRate.GetSpringRate() :
                setup.Chassis.RightFront.SpringRate.GetSpringRate();

            BumpStiffness = isLeftSide ?
               setup.Chassis.LeftFront.BumpStiffness.GetShockRate() :
               setup.Chassis.RightFront.BumpStiffness.GetShockRate();

            ReboundStiffness = isLeftSide ?
               setup.Chassis.LeftFront.ReboundStiffness.GetShockRate() :
               setup.Chassis.RightFront.ReboundStiffness.GetShockRate();

            Camber = isLeftSide ?
                setup.Chassis.LeftFront.Camber.GetDegrees() :
                setup.Chassis.RightFront.Camber.GetDegrees();

            Caster = isLeftSide ?
              setup.Chassis.LeftFront.Caster.GetDegrees() :
              setup.Chassis.RightFront.Caster.GetDegrees();
        }
    }

    public class ChassisRearCorner
    {
        public double CornerWeight { get; set; }
        public double RideHeight { get; set; }
        public double SpringPerchOffset { get; set; }
        public int SpringRate { get; set; }
        public double BumpStiffness { get; set; }
        public double ReboundStiffness { get; set; }
        public double TrackBarHeight { get; set; }
        public string TruckArmMount { get; set; }

        public ChassisRearCorner(LateModelSetup setup, bool isLeftSide)
        {
            CornerWeight = isLeftSide ?
                setup.Chassis.LeftRear.CornerWeight.GetPounds() :
                setup.Chassis.RightRear.CornerWeight.GetPounds();

            RideHeight = isLeftSide ?
                setup.Chassis.LeftRear.RideHeight.GetInchesFromMillimeters() :
                setup.Chassis.RightRear.RideHeight.GetInchesFromMillimeters();

            SpringPerchOffset = isLeftSide ?
                setup.Chassis.LeftRear.SpringPerchOffset.GetInchesFromMillimeters() :
                setup.Chassis.RightRear.SpringPerchOffset.GetInchesFromMillimeters();

            SpringRate = isLeftSide ?
                setup.Chassis.LeftRear.SpringRate.GetSpringRate() :
                setup.Chassis.RightRear.SpringRate.GetSpringRate();

            BumpStiffness = isLeftSide ?
               setup.Chassis.LeftFront.BumpStiffness.GetShockRate() :
               setup.Chassis.RightFront.BumpStiffness.GetShockRate();

            ReboundStiffness = isLeftSide ?
               setup.Chassis.LeftRear.ReboundStiffness.GetShockRate() :
               setup.Chassis.RightRear.ReboundStiffness.GetShockRate();

            TrackBarHeight = isLeftSide ?
                setup.Chassis.LeftRear.TrackBarHeight.GetInchesFromMillimeters() :
                setup.Chassis.RightRear.TrackBarHeight.GetInchesFromMillimeters();

            TruckArmMount = isLeftSide ?
                setup.Chassis.LeftRear.TruckArmMount :
                setup.Chassis.RightRear.TruckArmMount;
        }
    }

    public class ChassisRightRearCorner : ChassisRearCorner
    {
        public string TruckArmPreload { get; set; }

        public ChassisRightRearCorner(LateModelSetup setup, bool isLeftSide)
            : base(setup, isLeftSide)
        {
            TruckArmPreload = setup.Chassis.RightRear.TruckArmPreload;
        }
    }
}
