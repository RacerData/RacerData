using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RacerData.iRacing;

namespace RacerData.iRacingTelemetry.TestApp.Models
{
    class VehicleConfigurationModel : Object
    {
        #region fields

        private IDictionary<TirePosition, VehicleWheelSettings> _wheelSettings = new Dictionary<TirePosition, VehicleWheelSettings>()
        {
            { TirePosition.LF, new VehicleWheelSettings(TirePosition.LF) },
            { TirePosition.LR, new VehicleWheelSettings(TirePosition.LR) },
            { TirePosition.RF, new VehicleWheelSettings(TirePosition.RF) },
            { TirePosition.RR, new VehicleWheelSettings(TirePosition.RR) }
        };

        #endregion

        #region properties

        public long VehicleId { get; set; }

        public float Wheelbase { get; set; }
        public float FrontTrack { get; set; }
        public float RearTrack { get; set; }

        public float FtUnsprungWeight { get; set; }
        public float RearUnsprungWeight { get; set; }

        public SwayBarModel SwayBar { get; set; } = new SwayBarModel();

        public float FrontInstallationRatio { get; set; }
        public float FrontMotionRatio { get; set; }
        public float FrontSpringRatio { get; set; }

        public float RearInstallationRatio { get; set; }
        public float RearMotionRatio { get; set; }
        public float RearSpringRatio { get; set; }

        public float LeftBaseTireDiameter { get; set; }
        public float RightBaseTireDiameter { get; set; }

        public float[] GearRatios { get; set; } = new float[] { 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F, 0.0F };
        public float FinalGearRatio { get; set; }

        public VehicleWheelSettings LFWheel => _wheelSettings[TirePosition.LF];
        public VehicleWheelSettings LRWheel => _wheelSettings[TirePosition.LR];
        public VehicleWheelSettings RFWheel => _wheelSettings[TirePosition.RF];
        public VehicleWheelSettings RRWheel => _wheelSettings[TirePosition.RR];

        #endregion

        public VehicleConfigurationModel()
        {

        }

        public VehicleConfigurationModel(long vehicleId)
        {
            VehicleId = vehicleId;
        }

        public VehicleConfigurationModel Clone()
        {
            var json = JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject<VehicleConfigurationModel>(json);
        }
    }

    public class VehicleWheelSettings
    {
        #region properties

        public TirePosition Position { get; set; }
        public float StaticWeight { get; set; }
        public float StaticHeight { get; set; }
        public float SpringRate { get; set; }
        public float StaticSpringDeflection { get; set; }

        #endregion

        #region ctor

        public VehicleWheelSettings()
        {

        }

        public VehicleWheelSettings(TirePosition position)
        {
            Position = position;
        }

        #endregion
    }
}
