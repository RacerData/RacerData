using System.IO;
using Newtonsoft.Json;
using RacerData.iRacing.Setups.ClassBuilder.Models;
using RacerData.iRacing.Setups.Models.LateModel;
using RacerData.iRacing.Telemetry;
using YamlDotNet.Serialization;

namespace RacerData.iRacing.Setups.ClassBuilder.Forms
{
    public static class LateModelTemeletryLoader
    {
        public static LateModel.LateModel GetLateModelFromTelemetry(ITelemetryFile telemetryData)
        {
            LateModelSetup setup = GetLateModelSetupFromTelemetry(telemetryData);

            return new LateModel.LateModel(setup);
        }

        private static LateModelSetup GetLateModelSetupFromTelemetry(ITelemetryFile telemetryData)
        {
            LateModelSetup setup = null;

            string setupYaml = telemetryData.SessionInfo.CarSetup.SetupYaml;

            string setupJson = ConvertYamlToJson(setupYaml);

            setup = DeserializeLateModelSetupJson(setupJson);

            setup.SetupFileName = telemetryData.SessionInfo.DriverInfo.DriverSetupName;

            setup.TelemetryFileName = telemetryData.FileName;

            setup.Track = telemetryData.SessionInfo.WeekendInfo.TrackDisplayName;

            return setup;
        }

        public static TireSheetValues GetTireSheet(LateModel.LateModel setup)
        {
            TireSheetValues model = new TireSheetValues();

            model.FileName = setup.TelemetryFileName;
            model.Setup = setup.Description;

            var lf = new TireViewModel(TirePosition.LF)
            {
                ColdPsi = setup.Tires.LeftFront.ColdPressure,
                HotPsi = setup.Tires.LeftFront.LastHotPressure
            };
            lf.Temperatures.Inside = setup.Tires.LeftFront.LastTempI;
            lf.Temperatures.Middle = setup.Tires.LeftFront.LastTempM;
            lf.Temperatures.Outside = setup.Tires.LeftFront.LastTempO;
            lf.Wear.Inside = setup.Tires.LeftFront.TreadRemainingI;
            lf.Wear.Middle = setup.Tires.LeftFront.TreadRemainingM;
            lf.Wear.Outside = setup.Tires.LeftFront.TreadRemainingO;
            model.Tires[TirePosition.LF] = lf;

            var lr = new TireViewModel(TirePosition.LR)
            {
                ColdPsi = setup.Tires.LeftRear.ColdPressure,
                HotPsi = setup.Tires.LeftRear.LastHotPressure
            };
            lr.Temperatures.Inside = setup.Tires.LeftRear.LastTempI;
            lr.Temperatures.Middle = setup.Tires.LeftRear.LastTempM;
            lr.Temperatures.Outside = setup.Tires.LeftRear.LastTempO;
            lr.Wear.Inside = setup.Tires.LeftRear.TreadRemainingI;
            lr.Wear.Middle = setup.Tires.LeftRear.TreadRemainingM;
            lr.Wear.Outside = setup.Tires.LeftRear.TreadRemainingO;
            model.Tires[TirePosition.LR] = lr;

            var rf = new TireViewModel(TirePosition.RF)
            {
                ColdPsi = setup.Tires.RightFront.ColdPressure,
                HotPsi = setup.Tires.RightFront.LastHotPressure
            };
            rf.Temperatures.Inside = setup.Tires.RightFront.LastTempI;
            rf.Temperatures.Middle = setup.Tires.RightFront.LastTempM;
            rf.Temperatures.Outside = setup.Tires.RightFront.LastTempO;
            rf.Wear.Inside = setup.Tires.RightFront.TreadRemainingI;
            rf.Wear.Middle = setup.Tires.RightFront.TreadRemainingM;
            rf.Wear.Outside = setup.Tires.RightFront.TreadRemainingO;
            model.Tires[TirePosition.RF] = rf;

            var rr = new TireViewModel(TirePosition.RR)
            {
                ColdPsi = setup.Tires.RightRear.ColdPressure,
                HotPsi = setup.Tires.RightRear.LastHotPressure
            };
            rr.Temperatures.Inside = setup.Tires.RightRear.LastTempI;
            rr.Temperatures.Middle = setup.Tires.RightRear.LastTempM;
            rr.Temperatures.Outside = setup.Tires.RightRear.LastTempO;
            rr.Wear.Inside = setup.Tires.RightRear.TreadRemainingI;
            rr.Wear.Middle = setup.Tires.RightRear.TreadRemainingM;
            rr.Wear.Outside = setup.Tires.RightRear.TreadRemainingO;
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

        private static LateModelSetup DeserializeLateModelSetupJson(string setupJson)
        {
            LateModelSetup setup = null;

            var rootObject = JsonConvert.DeserializeObject<Setups.Models.LateModel.RootObject>(setupJson);

            setup = rootObject.CarSetup;

            return setup;
        }
    }
}
