using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitsNet;

namespace RacerData.iRacing.Telemetry.Models
{
    public class IbtSessionParser : IIbtSessionParser
    {
        #region fields
        private readonly ASCIIEncoding _ascii = new ASCIIEncoding();
        #endregion

        #region consts
        const int FieldDescriptionLength = 144;
        const int FieldDescriptionLengthStart = 0;
        const int FieldDescriptionPositionStart = 4;
        const int FieldDescriptionNameStart = 16;
        const int FieldDescriptionNameLength = 32;
        const int FieldDescriptionDescriptionStart = 48;
        const int FieldDescriptionDescriptionLength = 64;
        const int FieldDescriptionUnitStart = 112;
        const int FieldDescriptionUnitLength = 32;

        const int IntFieldLength = 2;
        const int DoubleFieldLength = 4;
        const int DateFieldLength = 4;

        const int VersionOffset = 0;
        const int StatusOffset = 4;
        const int TickRateOffset = 8;
        const int SessionInfoUpdateOffset = 12;
        const int SessionInfoLenOffset = 16;
        const int SessionInfoOffsetOffset = 20;
        const int NumVarsOffset = 24;
        const int VarHeaderOffsetOffset = 28;
        const int NumberOfBuffersOffset = 32;
        const int BufferLengthOffset = 36;
        // PADDING - 2 ints = 8 bytes.
        const int BufferArrayOffset = 48;
        const int BufferArrayItemLength = 32;
        const int BufferArrayCount = 4;

        const int FrameCountOffset = 140;
        #endregion

        #region structs
        internal struct lapInfo
        {
            public int startFrameIdx;
            public int frameCount;
            public int lapIndex;
            public int lapNumber;
            public Single lapTime;
            public Single lapSpeed;
            public irsdk_SessionState sessionState;
        }
        #endregion

        #region public   
        public async Task<ISessionData> ParseTelemetrySessionAsync(byte[] telemetryBytes)
        {
            return await ParseTelemetrySessionAsync(telemetryBytes, IbtParseOptions.All);
        }
        public async Task<ISessionData> ParseTelemetrySessionAsync(byte[] telemetryBytes, IbtParseOptions options)
        {
            return await ParseTelemetrySession(telemetryBytes, options).ConfigureAwait(false);
        }
        #endregion

        #region protected
        protected virtual async Task<ISessionData> ParseTelemetrySession(byte[] telemetryBytes, IbtParseOptions options)
        {
            var s = await Task.Run(() =>
            {
                var session = new SessionData();

                var idx = 0;

                var fieldDefinitions = ParseFieldDescriptions(telemetryBytes, ref idx);
                session.Fields = fieldDefinitions;

                var sessionInfo = ParseSessionInfo(telemetryBytes, options, ref idx);
                session.SessionInfo = sessionInfo;

                if (options.HasFlag(IbtParseOptions.CarSetup))
                {
                    session.SetupInfo = new SetupInfo(session.SessionInfo.CarSetupYaml);
                }

                if (options.HasFlag(IbtParseOptions.LapTimes))
                {
                    var sessionFrames = ParseFrames(telemetryBytes, session.Fields, true, ref idx);
                    session.Frames = sessionFrames;
                }
                else if (options.HasFlag(IbtParseOptions.TelemetryData))
                {
                    var sessionFrames = ParseFrames(telemetryBytes, session.Fields, false, ref idx);
                    session.Frames = sessionFrames;
                }

                var sessionLaps = ParseLaps(session);
                session.Laps = sessionLaps;

                return session;
            });

            return s;
        }

        #region field descriptions
        protected virtual IList<IFieldDefinition> ParseFieldDescriptions(byte[] telemetryBytes, ref int idx)
        {
            var fieldDefinitions = new List<IFieldDefinition>();

            var fieldCount = BitConverter.ToInt32(telemetryBytes, NumVarsOffset);

            for (var i = 0; i < fieldCount; i++)
            {
                idx = FieldDescriptionLength + (FieldDescriptionLength * i);
                var fieldDefinition = ParseFieldDescription(telemetryBytes, idx);
                fieldDefinitions.Add(fieldDefinition);
            }
            idx += FieldDescriptionLength;
            idx++;

            return fieldDefinitions;
        }
        protected virtual IFieldDefinition ParseFieldDescription(byte[] telemetryBytes, int idx)
        {
            var fieldDescriptionBytes = new byte[FieldDescriptionLength];

            Array.Copy(telemetryBytes, idx, fieldDescriptionBytes, 0, FieldDescriptionLength);

            var field = new IbtFieldDefinition
            {
                DataType = (irsdk_VarType)BitConverter.ToInt32(fieldDescriptionBytes, FieldDescriptionLengthStart),
                Position = BitConverter.ToInt32(fieldDescriptionBytes, FieldDescriptionPositionStart),
                Name = _ascii.GetString(fieldDescriptionBytes, FieldDescriptionNameStart, FieldDescriptionNameLength).TrimEnd('\0'),
                Description =
                    _ascii.GetString(fieldDescriptionBytes, FieldDescriptionDescriptionStart,
                        FieldDescriptionDescriptionLength).TrimEnd('\0'),
                Unit = _ascii.GetString(fieldDescriptionBytes, FieldDescriptionUnitStart, FieldDescriptionUnitLength).TrimEnd('\0'),
                Group = "Telemetry"
            };

            return field;
        }
        #endregion

        #region session info
        protected virtual ISessionDictionaries ParseSessionInfo(byte[] telemetryBytes, IbtParseOptions options, ref int idx)
        {
            idx += 3; // skip the three '-' characters that denote the start of the YAML section.
            int yamlStartIdx = idx;
            // find the three '.' characters that denote the end of the YAML section.
            while (true)
            {
                idx++;
                if (telemetryBytes[idx] == 46)
                {
                    if ((telemetryBytes[idx + 1] == 46) && (telemetryBytes[idx + 2] == 46))
                    {
                        idx += 3;
                        break;
                    }
                }
            }

            var yamlLength = idx - yamlStartIdx - 3; // exclude the three '.' characters on the end.
                                                     //_sessionData.Yaml = GetTextFromBytes(telemetryBytes, yamlStartIdx, yamlLength);
            var telemetryYaml = _ascii.GetString(telemetryBytes, yamlStartIdx, yamlLength).TrimEnd('\0');

            var sessionInfo = new SessionDictionaries(telemetryYaml, options);

            if (options.HasFlag(IbtParseOptions.CarSetup))
            {
                var beginSetupIdx = telemetryYaml.IndexOf("CarSetup:");
                if (beginSetupIdx > 0)
                {
                    sessionInfo.CarSetupYaml = telemetryYaml.Substring(beginSetupIdx);
                }
            }

            return sessionInfo;
        }
        #endregion

        #region frames
        /// <summary>
        /// Parses the value section of the telemetry file.
        /// </summary>
        /// <param name="telemetryBytes">byte array of the telemetry file</param>
        /// <param name="dataStartIdx">starting index of the value section</param>
        protected virtual IList<IFrame> ParseFrames(byte[] telemetryBytes, IList<IFieldDefinition> fieldDefinitions, bool lapTimesOnly, ref int dataStartIdx)
        {
            dataStartIdx += 1;
            var valueLength = telemetryBytes.Length - dataStartIdx;
            var frameBytes = new byte[valueLength];
            Array.Copy(telemetryBytes, dataStartIdx, frameBytes, 0, valueLength);
            return ParseValues(frameBytes, fieldDefinitions, lapTimesOnly);
        }

        /// <summary>
        ///  Parses the value byte array of the telemetry file.
        /// </summary>
        /// <param name="framesSectionBytes">byte array of the value section (laps/frames)</param>
        protected virtual IList<IFrame> ParseValues(byte[] framesSectionBytes, IList<IFieldDefinition> fieldDefinitions, bool lapTimesOnly)
        {
            IList<IFrame> sessionFrames = new List<IFrame>();

            var startIdx = 0;
            // gets the size of a single frame of data
            var frameSize = fieldDefinitions.Max(f => f.Position + f.Size);
            while (true)
            {
                // iterates through each frame of data in the byte array
                for (var frameByteIndex = startIdx; frameByteIndex < framesSectionBytes.Length - 1; frameByteIndex += frameSize)
                {
                    // gets the bytes for a single frame of data
                    var frameBytes = new byte[frameSize];
                    Array.Copy(framesSectionBytes, frameByteIndex, frameBytes, 0, frameSize);


                    var frame = new Frame();
                    // iterates through each field in the frame
                    foreach (var field in fieldDefinitions)
                    {
                        if (!lapTimesOnly || field.Name.Contains("Lap"))
                        {
                            // parses the value for a single field
                            var fieldValue = new FrameFieldValue(field);
                            fieldValue.Bytes = new byte[field.Size];
                            Array.Copy(frameBytes, field.Position, fieldValue.Bytes, 0, field.Size);
                            frame.FieldValues.Add(fieldValue);
                        }
                    }
                    sessionFrames.Add((IFrame)frame);

                }
                break;
            }

            return sessionFrames;
        }

        protected virtual object GetFieldValue(int dataType, byte[] bytes)
        {
            object fieldValue = null;

            switch (dataType)
            {
                case 1:
                    {
                        fieldValue = BitConverter.ToBoolean(bytes, 0);
                        break;
                    }
                case 2:
                    {
                        fieldValue = BitConverter.ToInt16(bytes, 0);
                        break;
                    }
                case 3:
                    {
                        fieldValue = BitConverter.ToInt16(bytes, 0);
                        break;
                    }
                case 4:
                    {
                        fieldValue = BitConverter.ToSingle(bytes, 0);
                        break;
                    }
                case 5:
                    {
                        fieldValue = BitConverter.ToDouble(bytes, 0);
                        break;
                    }
            }
            return fieldValue;
        }
        #endregion

        #region laps
        protected virtual IList<ILapInfo> ParseLaps(SessionData session)
        {
            var sessionLaps = new List<ILapInfo>();

            var currentLapNumber = -999;
            var currentLapIndex = 0;
            var currentFrameIndex = 0;
            var lapFrameCount = 0;
            var lapMap = new Dictionary<int, lapInfo>();
            lapInfo _lapInfo = new lapInfo();

            foreach (var frame in session.Frames.OrderBy(f => f.SessionTime))
            {
                if (frame.Lap > 0)
                {
                    if (frame.Lap != currentLapNumber)
                    {
                        // save existing lap info, if any.
                        if (currentLapNumber != -999)
                        {
                            _lapInfo.frameCount = lapFrameCount;
                            _lapInfo.lapIndex = currentLapIndex;
                            lapMap.Add(currentLapIndex, _lapInfo);
                            currentLapIndex++;
                        }
                        _lapInfo = new lapInfo();
                        _lapInfo.lapNumber = frame.Lap;
                        _lapInfo.sessionState = (irsdk_SessionState)frame.SessionState;
                        _lapInfo.startFrameIdx = currentFrameIndex;
                        lapFrameCount = 0;
                        currentLapNumber = frame.Lap;
                    }
                    else
                    {
                        if (lapMap.Count > 0)
                        {
                            var lastLap = lapMap[lapMap.Count - 1];
                            // same lap... lap time changed?
                            if (frame.LapLastLapTime != lastLap.lapTime)
                            {
                                lastLap.lapTime = frame.LapLastLapTime;
                                lastLap.lapSpeed = 0F; // TODO: Calculate Speed
                                lapMap[lapMap.Count - 1] = lastLap;
                            }
                        }
                    }
                    lapFrameCount++;
                    currentFrameIndex++;
                }
            }
            // add the last lap
            _lapInfo.frameCount = lapFrameCount;
            if (lapMap.Count > 0)
            {
                var lastLapInfo = lapMap[lapMap.Count - 1];
                var lastFrame = session.Frames.OrderBy(f => f.SessionTime).LastOrDefault();
                if ((null == lastFrame) || lastLapInfo.lapTime == lastFrame.LapLastLapTime)
                {
                    _lapInfo.lapTime = -2;
                }
                else
                {
                    _lapInfo.lapTime = lastFrame.LapLastLapTime;
                }
            }
            else
            {
                _lapInfo.lapTime = -1;
            }
            _lapInfo.lapIndex = currentLapIndex;
            lapMap.Add(currentLapIndex, _lapInfo);

            var trackLength = GetTrackLengthInMiles(session);

            // map is built, build the lap list.
            foreach (lapInfo lap in lapMap.Values)
            {
                var lapSpeed = (lap.lapTime > 1) ? ((float)trackLength / lap.lapTime) * 3600 : 0;
                var newLap = new LapInfo()
                {
                    FrameIndex = lap.startFrameIdx,
                    LapIndex = lap.lapIndex,
                    LapNumber = lap.lapNumber,
                    LapSpeed = lapSpeed,
                    LapTime = lap.lapTime,
                    SessionState = lap.sessionState,
                    LapFrames = session.Frames.Skip(lap.startFrameIdx).Take(lap.frameCount).ToList()
                };
                sessionLaps.Add(newLap);
            }

            return sessionLaps;
        }

        protected virtual double GetTrackLengthInMiles(SessionData session)
        {
            var trackLengthKM = Convert.ToDouble(session.SessionInfo.weekendInfo["TrackLength"].ToString().Replace(" km", ""));
            Length trackLength = Length.FromKilometers(trackLengthKM);
            return trackLength.Miles;
        }
        #endregion
        #endregion
    }
}
