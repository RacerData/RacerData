using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using RacerData.iRacing.Extensions;
using RacerData.iRacing.Telemetry.Sdk.Internal;
using RacerData.iRacing.Telemetry.Sdk.Models;

namespace RacerData.iRacing.Telemetry.Sdk.Adapters
{
    internal class TelemetryFileReader : ITelemetryFileReader
    {
        #region consts

        const string TrackLengthToken = "TrackLength: ";
        const string CarSetupYamlHeader = "CarSetup:";

        #endregion

        #region fields

        private readonly string _file;
        private readonly ASCIIEncoding _ascii = new ASCIIEncoding();
        private readonly IList<TelemetryField> _telemetryFields;
        private readonly int _fieldCount;
        private readonly int _fieldDefinitionBytesLength;
        private readonly int _sessionInfoStartIndex;
        private readonly int _telemetryFrameSize;
        private readonly int _telemetryFramesStartIndex;
        private readonly int _telemetryFramesSectionLength;
        private readonly irsdk_header _header;
        private ITelemetryFile _telemetryData;

        #endregion

        #region properties

        private byte[] _telemetryFileBytes;
        public byte[] TelemetryFileBytes
        {
            get
            {
                return _telemetryFileBytes;
            }
        }

        #endregion

        #region ctor

        public TelemetryFileReader(string file)
        {
            _file = file ?? throw new ArgumentNullException(nameof(file));

            _telemetryFileBytes = File.ReadAllBytes(file);

            _header.ver = BitConverter.ToInt32(_telemetryFileBytes, TelemetryConsts.VersionOffset);
            _header.status = BitConverter.ToInt32(_telemetryFileBytes, TelemetryConsts.StatusOffset);
            _header.tickRate = BitConverter.ToInt32(_telemetryFileBytes, TelemetryConsts.TickRateOffset);
            _header.sessionInfoUpdate = BitConverter.ToInt32(_telemetryFileBytes, TelemetryConsts.SessionInfoUpdateOffset);
            _header.sessionInfoLen = BitConverter.ToInt32(_telemetryFileBytes, TelemetryConsts.SessionInfoLenOffset);
            _header.sessionInfoOffset = BitConverter.ToInt32(_telemetryFileBytes, TelemetryConsts.SessionInfoOffsetOffset);
            _header.numVars = BitConverter.ToInt32(_telemetryFileBytes, TelemetryConsts.NumVarsOffset);
            _header.varHeaderOffset = BitConverter.ToInt32(_telemetryFileBytes, TelemetryConsts.VarHeaderOffsetOffset);
            _header.numBuf = BitConverter.ToInt32(_telemetryFileBytes, TelemetryConsts.NumberOfBuffersOffset);
            _header.bufLen = BitConverter.ToInt32(_telemetryFileBytes, TelemetryConsts.BufferLengthOffset);

            _fieldCount = _header.numVars;
            _telemetryFrameSize = _header.bufLen;
            _sessionInfoStartIndex = _header.sessionInfoOffset;
            _telemetryFramesStartIndex = _header.sessionInfoOffset + _header.sessionInfoLen;
            _fieldDefinitionBytesLength = _header.sessionInfoOffset;
            _telemetryFramesSectionLength = _telemetryFileBytes.Length - _telemetryFramesStartIndex;

            _telemetryFields = ParseTelemetryFields(_telemetryFileBytes);

            //foreach (TelemetryField field in _telemetryFields)
            //{
            //    Console.WriteLine($"{field.Name}\t\t{field.Description}\t\t{field.Unit}");
            //}
        }

        #endregion

        #region public

        /// <summary>
        /// Parses the telemetry file
        /// </summary>
        /// <returns>Instance of ITelemetryFile</returns>
        public async Task<ITelemetryFile> ReadTelemetryFileAsync()
        {
            if (_telemetryData == null)
            {
                _telemetryData = await ParseTelemetryDataAsync(_telemetryFileBytes);
            }

            return _telemetryData;
        }
        public ITelemetryFile ReadTelemetrySession()
        {
            try
            {
                if (_telemetryData == null)
                {
                    _telemetryData = ParseTelemetrySessionAsync(_telemetryFileBytes);
                }
            }
            catch (Exception ex)
            {
                _telemetryData = null;
                throw new Exception($"Error parsing telemetry session data in {Path.GetFileName(_file)}: {ex.Message}", ex);
            }

            return _telemetryData;
        }
        #endregion

        #region protected

        /// <summary>
        /// Parses the telemetry file
        /// </summary>
        /// <param name="telemetryBytes">Byte array of the telemetry file content</param>
        /// <returns>Instance of ITelemetryFile</returns>
        protected virtual async Task<ITelemetryFile> ParseTelemetryDataAsync(byte[] telemetryBytes)
        {
            var sessionInfoYaml = _ascii.GetString(
                telemetryBytes,
                _header.sessionInfoOffset,
                _header.sessionInfoLen
                ).TrimEnd('\0');

            var parser = new SessionInfoParser();
            var sessionInfo = parser.ParseYaml(sessionInfoYaml);

            IEnumerable<ITelemetryFrame> frames = await ParseTelemetryFramesAsync(telemetryBytes);
            IEnumerable<ILapInfo> laps = GetLapTimes(frames, sessionInfo.WeekendInfo.TrackLength);
            ITireSheet tireSheet = GetTireSheet(frames.ToList());
            ITireSheet setupTireSheet = GetTireSheetFromSetup(sessionInfo);

            return new TelemetryFile()
            {
                FileName = _file,
                Frames = frames,
                Laps = laps,
                SessionInfo = sessionInfo,
                TireSheet = tireSheet,
                TireSheetFromSetup = setupTireSheet
            };
        }

        /// <summary>
        /// Parses the telemetry file
        /// </summary>
        /// <param name="telemetryBytes">Byte array of the telemetry file content</param>
        /// <returns>Instance of ITelemetryFile</returns>
        protected virtual ITelemetryFile ParseTelemetrySessionAsync(byte[] telemetryBytes)
        {
            var sessionInfoYaml = _ascii.GetString(
                telemetryBytes,
                _header.sessionInfoOffset,
                _header.sessionInfoLen
                ).TrimEnd('\0');

            var parser = new SessionInfoParser();
            var sessionInfo = parser.ParseYaml(sessionInfoYaml);

            return new TelemetryFile()
            {
                FileName = _file,
                SessionInfo = sessionInfo,
            };
        }

        // fields
        /// <summary>
        /// Parses the individual field definitions from the telemetry
        /// </summary>
        /// <param name="telemetryBytes">binary telemetry file content</param>
        /// <returns>List of telemetry fields defined in the file</returns>
        protected virtual IList<TelemetryField> ParseTelemetryFields(byte[] telemetryBytes)
        {
            var fieldDefinitions = new List<TelemetryField>();

            for (var i = 0; i < _fieldCount; i++)
            {
                var fieldDefinition = ParseTelemetryField(telemetryBytes, TelemetryConsts.FieldDescriptionLength + (TelemetryConsts.FieldDescriptionLength * i));
                fieldDefinitions.Add(fieldDefinition);
            }

            return fieldDefinitions;
        }
        /// <summary>
        /// Parses a single telemetry field definition from the byte array
        /// </summary>
        /// <param name="telemetryBytes">Telemetry file byte array</param>
        /// <param name="idx">Index of the field definition within the byte array</param>
        /// <returns>A single telemetry field definition</returns>
        protected virtual TelemetryField ParseTelemetryField(byte[] telemetryBytes, int idx)
        {
            var fieldDescriptionBytes = new byte[TelemetryConsts.FieldDescriptionLength];

            Array.Copy(telemetryBytes, idx, fieldDescriptionBytes, 0, TelemetryConsts.FieldDescriptionLength);

            var field = new TelemetryField
            {
                DataType = (irsdk_VarType)BitConverter.ToInt32(fieldDescriptionBytes, TelemetryConsts.FieldDescriptionLengthStart),
                Index = BitConverter.ToInt32(fieldDescriptionBytes, TelemetryConsts.FieldDescriptionPositionStart),
                Name = _ascii.GetString(
                    fieldDescriptionBytes,
                    TelemetryConsts.FieldDescriptionNameStart,
                    TelemetryConsts.FieldDescriptionNameLength).TrimEnd('\0'),
                Description = _ascii.GetString(
                    fieldDescriptionBytes,
                    TelemetryConsts.FieldDescriptionDescriptionStart,
                        TelemetryConsts.FieldDescriptionDescriptionLength).TrimEnd('\0'),
                Unit = _ascii.GetString(
                    fieldDescriptionBytes,
                    TelemetryConsts.FieldDescriptionUnitStart,
                    TelemetryConsts.FieldDescriptionUnitLength).TrimEnd('\0'),
                FieldCountAsTime = BitConverter.ToBoolean(fieldDescriptionBytes, TelemetryConsts.FieldCountAsTimePositionStart),
                FieldInstanceCount = BitConverter.ToBoolean(fieldDescriptionBytes, TelemetryConsts.FieldInstanceCountPositionStart)
            };

            return field;
        }

        // frames
        /// <summary>
        /// Parses the frames section of the telemetry file.
        /// </summary>
        /// <param name="telemetryBytes">byte array of the telemetry file</param>
        protected virtual async Task<IEnumerable<ITelemetryFrame>> ParseTelemetryFramesAsync(byte[] telemetryBytes)
        {
            return await Task.Run(() =>
            {
                IList<ITelemetryFrame> telemetryFrames = new List<ITelemetryFrame>();

                var telemetryFramesBytes = new byte[_telemetryFramesSectionLength];
                Array.Copy(telemetryBytes, _telemetryFramesStartIndex, telemetryFramesBytes, 0, _telemetryFramesSectionLength);

                for (var frameByteIndex = 0; frameByteIndex < telemetryFramesBytes.Length - 1; frameByteIndex += _telemetryFrameSize)
                {
                    var telemetryFrameBytes = new byte[_telemetryFrameSize];

                    Array.Copy(telemetryFramesBytes, frameByteIndex, telemetryFrameBytes, 0, _telemetryFrameSize);

                    var frame = new TelemetryFrame();

                    foreach (var field in _telemetryFields)
                    {
                        byte[] bytes = new byte[field.Size];

                        Array.Copy(telemetryFrameBytes, field.Index, bytes, 0, field.Size);

                        PropertyInfo propertyInfo = frame.GetType().GetProperty(field.Name);

                        if (propertyInfo != null)
                        {
                            var value = GetFieldValueObject(field, bytes);

                            propertyInfo.SetValue(frame, Convert.ChangeType(value, propertyInfo.PropertyType), null);
                        }
                        else
                        {
                            //Console.WriteLine($"Missing FrameData Field! {field.Name} {field.Description} {field.DataType.ToString()}");
                        }
                    }

                    telemetryFrames.Add(frame);
                }

                return telemetryFrames;
            });
        }

        /// <summary>
        /// Converts the byte array into the field value
        /// </summary>
        /// <param name="field">Field definition</param>
        /// <param name="bytes">byte array containing the value</param>
        /// <returns>Correctly-typed value for the field</returns>
        protected virtual object GetFieldValueObject(TelemetryField field, byte[] bytes)
        {
            object fieldValue = null;

            switch (field.DataType)
            {
                case irsdk_VarType.irsdk_bool:
                    {
                        fieldValue = BitConverter.ToBoolean(bytes, 0);
                        break;
                    }
                case irsdk_VarType.irsdk_int:
                    {
                        switch (field.Unit)
                        {
                            case "irsdk_SessionState":
                                {
                                    var intValue = BitConverter.ToInt16(bytes, 0);
                                    fieldValue = (irsdk_SessionState)intValue;
                                    break;
                                }
                            case "irsdk_TrkLoc":
                                {
                                    var intValue = BitConverter.ToInt16(bytes, 0);
                                    fieldValue = (irsdk_TrkLoc)intValue;
                                    break;
                                }
                            case "irsdk_TrkSurf":
                                {
                                    var intValue = BitConverter.ToInt16(bytes, 0);
                                    fieldValue = (irsdk_TrkSurf)intValue;
                                    break;
                                }
                            case "irsdk_PitSvStatus":
                                {
                                    var intValue = BitConverter.ToInt16(bytes, 0);
                                    fieldValue = (irsdk_PitSvStatus)intValue;
                                    break;
                                }
                            default:
                                {
                                    fieldValue = BitConverter.ToInt16(bytes, 0);
                                    break;
                                }
                        }
                        break;
                    }
                case irsdk_VarType.irsdk_bitField:
                    {
                        switch (field.Unit)
                        {
                            case "irsdk_EngineWarnings":
                                {
                                    var intValue = BitConverter.ToInt16(bytes, 0);
                                    fieldValue = (irsdk_EngineWarnings)intValue;
                                    break;
                                }
                            case "irsdk_PitSvFlags":
                                {
                                    var intValue = BitConverter.ToInt16(bytes, 0);
                                    fieldValue = (irsdk_PitSvFlags)intValue;
                                    break;
                                }
                            default:
                                {
                                    fieldValue = BitConverter.ToInt16(bytes, 0);
                                    break;
                                }
                        }
                        break;
                    }
                case irsdk_VarType.irsdk_float:
                    {
                        fieldValue = BitConverter.ToSingle(bytes, 0);
                        break;
                    }
                case irsdk_VarType.irsdk_double:
                    {
                        fieldValue = BitConverter.ToDouble(bytes, 0);
                        break;
                    }
            }

            return fieldValue;
        }

        // lap times
        /// <summary>
        /// Reads the lap times for all laps in the telemetry
        /// </summary>
        /// <param name="frames">Telemetry frames to read</param>
        /// <returns>List of ILapData</returns>
        protected virtual IEnumerable<ILapInfo> GetLapTimes(IEnumerable<ITelemetryFrame> frames, string trackLengthKm)
        {
            IList<ILapInfo> lapTimes = new List<ILapInfo>();

            float lastLapTime = -999.0F;
            float trackLengthMiles = GetTrackLengthMiles(trackLengthKm);

            foreach (ITelemetryFrame frame in frames)
            {
                if (frame.LapLastLapTime != lastLapTime)
                {
                    lastLapTime = frame.LapLastLapTime;

                    if (lastLapTime > 0)
                    {
                        ILapInfo lapData = new LapInfo()
                        {
                            LapNumber = frame.LapCompleted,
                            LapTime = frame.LapLastLapTime,
                            LapSpeed = trackLengthMiles / (frame.LapLastLapTime / 3600)
                        };

                        lapTimes.Add(lapData);
                    }
                }
            }

            return lapTimes;
        }

        /// <summary>
        /// Reads the track length from the session yaml, converts from km to miles
        /// </summary>
        /// <returns>track length in miles</returns>
        protected virtual float GetTrackLengthMiles(string trackLengthKm)
        {
            float trackLengthKilometers = float.Parse(trackLengthKm.Replace(" km", ""));

            float trackLengthMiles = trackLengthKilometers * 0.621371F;

            return trackLengthMiles;
        }

        // tire sheet
        /// <summary>
        /// Reads the tire temperature, pressure, and wear values from the telemetry values
        /// </summary>
        /// <param name="frames">List of telemetry frames to read</param>
        /// <returns>ITireSheet</returns>
        protected virtual ITireSheet GetTireSheet(IList<ITelemetryFrame> frames)
        {
            ITireSheet tireSheet = new TireSheet();

            var firstFrame = frames.FirstOrDefault();

            tireSheet.LF.ColdPsi = firstFrame.LFcoldPressure.kPaToPSI();
            tireSheet.RF.ColdPsi = firstFrame.RFcoldPressure.kPaToPSI();
            tireSheet.LR.ColdPsi = firstFrame.LRcoldPressure.kPaToPSI();
            tireSheet.RR.ColdPsi = firstFrame.RRcoldPressure.kPaToPSI();

            var lastFrame = frames.LastOrDefault();

            tireSheet.LF.HotPsi = lastFrame.LFpressure.kPaToPSI();
            tireSheet.RF.HotPsi = lastFrame.RFpressure.kPaToPSI();
            tireSheet.LR.HotPsi = lastFrame.LRpressure.kPaToPSI();
            tireSheet.RR.HotPsi = lastFrame.RRpressure.kPaToPSI();

            // temperatures

            tireSheet.LF.Temperatures[TreadPosition.Outside] = lastFrame.LFtempCL.CelciusToFarenheit();
            tireSheet.LF.Temperatures[TreadPosition.Middle] = lastFrame.LFtempCM.CelciusToFarenheit();
            tireSheet.LF.Temperatures[TreadPosition.Inside] = lastFrame.LFtempCR.CelciusToFarenheit();

            tireSheet.LR.Temperatures[TreadPosition.Outside] = lastFrame.LRtempCL.CelciusToFarenheit();
            tireSheet.LR.Temperatures[TreadPosition.Middle] = lastFrame.LRtempCM.CelciusToFarenheit();
            tireSheet.LR.Temperatures[TreadPosition.Inside] = lastFrame.LRtempCR.CelciusToFarenheit();

            tireSheet.RF.Temperatures[TreadPosition.Inside] = lastFrame.RFtempCL.CelciusToFarenheit();
            tireSheet.RF.Temperatures[TreadPosition.Middle] = lastFrame.RFtempCM.CelciusToFarenheit();
            tireSheet.RF.Temperatures[TreadPosition.Outside] = lastFrame.RFtempCR.CelciusToFarenheit();

            tireSheet.RR.Temperatures[TreadPosition.Inside] = lastFrame.RRtempCL.CelciusToFarenheit();
            tireSheet.RR.Temperatures[TreadPosition.Middle] = lastFrame.RRtempCM.CelciusToFarenheit();
            tireSheet.RR.Temperatures[TreadPosition.Outside] = lastFrame.RRtempCR.CelciusToFarenheit();

            // wear

            tireSheet.LF.Wear[TreadPosition.Outside] = (float)Math.Round(lastFrame.LFwearL * 100, 0);
            tireSheet.LF.Wear[TreadPosition.Middle] = (float)Math.Round(lastFrame.LFwearM * 100, 0);
            tireSheet.LF.Wear[TreadPosition.Inside] = (float)Math.Round(lastFrame.LFwearR * 100, 0);

            tireSheet.LR.Wear[TreadPosition.Outside] = (float)Math.Round(lastFrame.LRwearL * 100, 0);
            tireSheet.LR.Wear[TreadPosition.Middle] = (float)Math.Round(lastFrame.LRwearM * 100, 0);
            tireSheet.LR.Wear[TreadPosition.Inside] = (float)Math.Round(lastFrame.LRwearR * 100, 0);

            tireSheet.RF.Wear[TreadPosition.Inside] = (float)Math.Round(lastFrame.RFwearL * 100, 0);
            tireSheet.RF.Wear[TreadPosition.Middle] = (float)Math.Round(lastFrame.RFwearM * 100, 0);
            tireSheet.RF.Wear[TreadPosition.Outside] = (float)Math.Round(lastFrame.RFwearR * 100, 0);

            tireSheet.RR.Wear[TreadPosition.Inside] = (float)Math.Round(lastFrame.RRwearL * 100, 0);
            tireSheet.RR.Wear[TreadPosition.Middle] = (float)Math.Round(lastFrame.RRwearM * 100, 0);
            tireSheet.RR.Wear[TreadPosition.Outside] = (float)Math.Round(lastFrame.RRwearR * 100, 0);

            return tireSheet;
        }

        protected virtual ITireSheet GetTireSheetFromSetup(ISessionInfo sessionInfo)
        {
            ITireSheet tireSheet = new TireSheet();

            IDictionary<object, object> lf = ((IDictionary<object, object>)((IDictionary<object, object>)sessionInfo.CarSetup.ValuesDictionary["Tires"])["LeftFront"]);
            IDictionary<object, object> lr = ((IDictionary<object, object>)((IDictionary<object, object>)sessionInfo.CarSetup.ValuesDictionary["Tires"])["LeftRear"]);

            tireSheet.LF.ColdPsi = (float)lf["ColdPressure"].ToString().GetPsi();
            tireSheet.LF.HotPsi = (float)lf["LastHotPressure"].ToString().GetPsi();
            var lftemps = lf["LastTempsOMI"].ToString().GetTireTemps();
            tireSheet.LF.Temperatures[TreadPosition.Outside] = (float)lftemps[0];
            tireSheet.LF.Temperatures[TreadPosition.Middle] = (float)lftemps[1];
            tireSheet.LF.Temperatures[TreadPosition.Inside] = (float)lftemps[2];
            var lfwear = lf["TreadRemaining"].ToString().GetTireWear();
            tireSheet.LF.Wear[TreadPosition.Outside] = (float)lfwear[0];
            tireSheet.LF.Wear[TreadPosition.Middle] = (float)lfwear[1];
            tireSheet.LF.Wear[TreadPosition.Inside] = (float)lfwear[2];

            tireSheet.LR.ColdPsi = (float)lr["ColdPressure"].ToString().GetPsi();
            tireSheet.LR.HotPsi = (float)lr["LastHotPressure"].ToString().GetPsi();
            var lrtemps = lr["LastTempsOMI"].ToString().GetTireTemps();
            tireSheet.LR.Temperatures[TreadPosition.Outside] = (float)lrtemps[0];
            tireSheet.LR.Temperatures[TreadPosition.Middle] = (float)lrtemps[1];
            tireSheet.LR.Temperatures[TreadPosition.Inside] = (float)lrtemps[2];
            var lrwear = lr["TreadRemaining"].ToString().GetTireWear();
            tireSheet.LR.Wear[TreadPosition.Outside] = (float)lrwear[0];
            tireSheet.LR.Wear[TreadPosition.Middle] = (float)lrwear[1];
            tireSheet.LR.Wear[TreadPosition.Inside] = (float)lrwear[2];

            IDictionary<object, object> rf = ((IDictionary<object, object>)((IDictionary<object, object>)sessionInfo.CarSetup.ValuesDictionary["Tires"])["RightFront"]);
            IDictionary<object, object> rr = ((IDictionary<object, object>)((IDictionary<object, object>)sessionInfo.CarSetup.ValuesDictionary["Tires"])["RightRear"]);

            tireSheet.RF.ColdPsi = (float)rf["ColdPressure"].ToString().GetPsi();
            tireSheet.RF.HotPsi = (float)rf["LastHotPressure"].ToString().GetPsi();
            var rftemps = rf["LastTempsIMO"].ToString().GetTireTemps();
            tireSheet.RF.Temperatures[TreadPosition.Inside] = (float)rftemps[0];
            tireSheet.RF.Temperatures[TreadPosition.Middle] = (float)rftemps[1];
            tireSheet.RF.Temperatures[TreadPosition.Outside] = (float)rftemps[2];
            var rfwear = rf["TreadRemaining"].ToString().GetTireWear();
            tireSheet.RF.Wear[TreadPosition.Inside] = (float)rfwear[0];
            tireSheet.RF.Wear[TreadPosition.Middle] = (float)rfwear[1];
            tireSheet.RF.Wear[TreadPosition.Outside] = (float)rfwear[2];

            tireSheet.RR.ColdPsi = (float)rr["ColdPressure"].ToString().GetPsi();
            tireSheet.RR.HotPsi = (float)rr["LastHotPressure"].ToString().GetPsi();
            var rrtemps = rr["LastTempsIMO"].ToString().GetTireTemps();
            tireSheet.RR.Temperatures[TreadPosition.Inside] = (float)rrtemps[0];
            tireSheet.RR.Temperatures[TreadPosition.Middle] = (float)rrtemps[1];
            tireSheet.RR.Temperatures[TreadPosition.Outside] = (float)rrtemps[2];
            var rrwear = rr["TreadRemaining"].ToString().GetTireWear();
            tireSheet.RR.Wear[TreadPosition.Inside] = (float)rrwear[0];
            tireSheet.RR.Wear[TreadPosition.Middle] = (float)rrwear[1];
            tireSheet.RR.Wear[TreadPosition.Outside] = (float)rrwear[2];

            return tireSheet;
        }

        #endregion
    }
}
