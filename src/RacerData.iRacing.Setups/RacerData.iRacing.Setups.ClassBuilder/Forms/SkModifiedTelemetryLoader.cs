using System.IO;
using Newtonsoft.Json;
using RacerData.iRacing.Setups.ClassBuilder.Models;
using RacerData.iRacing.Setups.Models.SkModified;
using RacerData.iRacing.Setups.Modifieds;
using RacerData.iRacing.Telemetry;
using YamlDotNet.Serialization;

namespace RacerData.iRacing.Setups.ClassBuilder.Forms
{
    public static class SkModifiedTelemetryLoader
    {
        public static SkModified GetSkModifiedFromTelemetry(ITelemetryFile telemetryData)
        {
            ModifiedSetup setup = GetModifiedSetupFromTelemetry(telemetryData);

            return new SkModified(setup);
        }

        private static ModifiedSetup GetModifiedSetupFromTelemetry(ITelemetryFile telemetryData)
        {
            ModifiedSetup setup = null;

            string setupYaml = telemetryData.SessionInfo.CarSetup.SetupYaml;

            string setupJson = ConvertYamlToJson(setupYaml);

            setup = DeserializeModifiedSetupJson(setupJson);

            setup.SetupFileName = telemetryData.SessionInfo.DriverInfo.DriverSetupName;

            setup.TelemetryFileName = telemetryData.FileName;

            setup.Track = telemetryData.SessionInfo.WeekendInfo.TrackDisplayName;

            return setup;
        }

        public static TireSheetValues GetTireSheet(SkModified skSetup)
        {
            TireSheetValues model = new TireSheetValues();

            model.FileName = skSetup.TelemetryFileName;
            model.Setup = skSetup.Description;

            var lf = new TireViewModel(TirePosition.LF)
            {
                ColdPsi = skSetup.Tires.LeftFront.ColdPressure,
                HotPsi = skSetup.Tires.LeftFront.LastHotPressure
            };
            lf.Temperatures.Inside = skSetup.Tires.LeftFront.LastTempI;
            lf.Temperatures.Middle = skSetup.Tires.LeftFront.LastTempM;
            lf.Temperatures.Outside = skSetup.Tires.LeftFront.LastTempO;
            lf.Wear.Inside = skSetup.Tires.LeftFront.TreadRemainingI;
            lf.Wear.Middle = skSetup.Tires.LeftFront.TreadRemainingM;
            lf.Wear.Outside = skSetup.Tires.LeftFront.TreadRemainingO;
            model.Tires[TirePosition.LF] = lf;

            var lr = new TireViewModel(TirePosition.LR)
            {
                ColdPsi = skSetup.Tires.LeftRear.ColdPressure,
                HotPsi = skSetup.Tires.LeftRear.LastHotPressure
            };
            lr.Temperatures.Inside = skSetup.Tires.LeftRear.LastTempI;
            lr.Temperatures.Middle = skSetup.Tires.LeftRear.LastTempM;
            lr.Temperatures.Outside = skSetup.Tires.LeftRear.LastTempO;
            lr.Wear.Inside = skSetup.Tires.LeftRear.TreadRemainingI;
            lr.Wear.Middle = skSetup.Tires.LeftRear.TreadRemainingM;
            lr.Wear.Outside = skSetup.Tires.LeftRear.TreadRemainingO;
            model.Tires[TirePosition.LR] = lr;

            var rf = new TireViewModel(TirePosition.RF)
            {
                ColdPsi = skSetup.Tires.RightFront.ColdPressure,
                HotPsi = skSetup.Tires.RightFront.LastHotPressure
            };
            rf.Temperatures.Inside = skSetup.Tires.RightFront.LastTempI;
            rf.Temperatures.Middle = skSetup.Tires.RightFront.LastTempM;
            rf.Temperatures.Outside = skSetup.Tires.RightFront.LastTempO;
            rf.Wear.Inside = skSetup.Tires.RightFront.TreadRemainingI;
            rf.Wear.Middle = skSetup.Tires.RightFront.TreadRemainingM;
            rf.Wear.Outside = skSetup.Tires.RightFront.TreadRemainingO;
            model.Tires[TirePosition.RF] = rf;

            var rr = new TireViewModel(TirePosition.RR)
            {
                ColdPsi = skSetup.Tires.RightRear.ColdPressure,
                HotPsi = skSetup.Tires.RightRear.LastHotPressure
            };
            rr.Temperatures.Inside = skSetup.Tires.RightRear.LastTempI;
            rr.Temperatures.Middle = skSetup.Tires.RightRear.LastTempM;
            rr.Temperatures.Outside = skSetup.Tires.RightRear.LastTempO;
            rr.Wear.Inside = skSetup.Tires.RightRear.TreadRemainingI;
            rr.Wear.Middle = skSetup.Tires.RightRear.TreadRemainingM;
            rr.Wear.Outside = skSetup.Tires.RightRear.TreadRemainingO;
            model.Tires[TirePosition.RR] = rr;

            return model;
        }

        private static string ConvertYamlToJson(string setupYaml)
        {
            string setupJson = null;

            var reader = new StringReader(setupYaml);
            var deserializer = new Deserializer();
            var yamlObject = deserializer.Deserialize(reader);

            var writer = new StringWriter();
            var serializer = new JsonSerializer();
            serializer.Serialize(writer, yamlObject);

            setupJson = writer.ToString();

            return setupJson;
        }

        private static ModifiedSetup DeserializeModifiedSetupJson(string setupJson)
        {
            ModifiedSetup setup = null;

            var rootObject = JsonConvert.DeserializeObject<RootObject>(setupJson);

            setup = rootObject.CarSetup;

            return setup;
        }
    }
}
