using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using RacerData.iRacing.Telemetry.Sdk.Internal;

namespace RacerData.iRacing.Telemetry.Sdk.Adapters
{
    public class TelemetryClassBuilder
    {
        #region fields

        private readonly string _file;
        private readonly ASCIIEncoding _ascii = new ASCIIEncoding();
        private readonly byte[] _telemetryFileBytes;
        private readonly string _sessionInfoYaml;
        private FrameDataClassStrings _fieldDataClassStrings;
        private SessionInfoClassStrings _sessionInfoClassStrings;
        private readonly irsdk_header _header;

        #endregion

        #region ctor

        public TelemetryClassBuilder(string file)
        {
            _file = file ?? throw new ArgumentNullException(nameof(file));

            _telemetryFileBytes = File.ReadAllBytes(file);

            _header.sessionInfoLen = BitConverter.ToInt32(_telemetryFileBytes, TelemetryConsts.SessionInfoLenOffset);
            _header.sessionInfoOffset = BitConverter.ToInt32(_telemetryFileBytes, TelemetryConsts.SessionInfoOffsetOffset);

            _sessionInfoYaml = GetSessionInfoYaml();
        }

        #endregion

        #region public

        public FrameDataClassStrings GenerateFrameDataClass(byte[] telemetryBytes)
        {
            if (_fieldDataClassStrings == null)
            {
                var fieldDefinitions = ParseTelemetryFields(telemetryBytes, 0);

                _fieldDataClassStrings = new FrameDataClassStrings()
                {
                    FrameDataString = BuildFrameClass(fieldDefinitions),
                    IFrameDataString = BuildFrameInterface(fieldDefinitions)
                };
            }

            return _fieldDataClassStrings;
        }
        public SessionInfoClassStrings GenerateSessionInfoClasses()
        {
            if (_sessionInfoClassStrings == null)
            {
                var sessionInfo = new SessionDictionaries(_sessionInfoYaml);

                _sessionInfoClassStrings = new SessionInfoClassStrings()
                {
                    ISessionInfoString = BuildSessionInterface(sessionInfo)
                };
            }

            return _sessionInfoClassStrings;
        }

        #endregion

        #region private

        private string GetSessionInfoYaml()
        {
            return _ascii.GetString(_telemetryFileBytes, _header.sessionInfoOffset, _header.sessionInfoLen).TrimEnd('\0');
        }

        private IList<TelemetryField> ParseTelemetryFields(byte[] telemetryBytes, int idx)
        {
            var fieldDefinitions = new List<TelemetryField>();

            var fieldCount = BitConverter.ToInt32(telemetryBytes, TelemetryConsts.NumVarsOffset);

            for (var i = 0; i < fieldCount; i++)
            {
                idx = TelemetryConsts.FieldDescriptionLength + (TelemetryConsts.FieldDescriptionLength * i);
                var fieldDefinition = ParseTelemetryField(telemetryBytes, idx);
                fieldDefinitions.Add(fieldDefinition);
            }

            idx += TelemetryConsts.FieldDescriptionLength;

            idx++;

            return fieldDefinitions;
        }

        private TelemetryField ParseTelemetryField(byte[] telemetryBytes, int idx)
        {
            var fieldDescriptionBytes = new byte[TelemetryConsts.FieldDescriptionLength];

            Array.Copy(telemetryBytes, idx, fieldDescriptionBytes, 0, TelemetryConsts.FieldDescriptionLength);

            var field = new TelemetryField
            {
                DataType = (irsdk_VarType)BitConverter.ToInt32(fieldDescriptionBytes, TelemetryConsts.FieldDescriptionLengthStart),
                Index = BitConverter.ToInt32(fieldDescriptionBytes, TelemetryConsts.FieldDescriptionPositionStart),
                Name = _ascii.GetString(fieldDescriptionBytes, TelemetryConsts.FieldDescriptionNameStart, TelemetryConsts.FieldDescriptionNameLength).TrimEnd('\0'),
                Description =
                    _ascii.GetString(fieldDescriptionBytes, TelemetryConsts.FieldDescriptionDescriptionStart,
                        TelemetryConsts.FieldDescriptionDescriptionLength).TrimEnd('\0'),
                Unit = _ascii.GetString(fieldDescriptionBytes, TelemetryConsts.FieldDescriptionUnitStart, TelemetryConsts.FieldDescriptionUnitLength).TrimEnd('\0')
            };

            return field;
        }

        private string BuildFrameClass(IList<TelemetryField> fieldDefinitions)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("namespace RacerData.iRacing.Telemetry.Sdk.Models");
            sb.AppendLine("{");
            sb.AppendLine("  public class FrameData : IFrameData");
            sb.AppendLine("  {");
            sb.AppendLine("    #region properties");
            sb.AppendLine();
            foreach (TelemetryField fieldDefinition in fieldDefinitions)
            {
                var propString = $"    public {GetDataTypeName(fieldDefinition.DataType)} {fieldDefinition.Name}";
                sb.AppendLine($"{propString}" + " { get; set; }");
            }
            sb.AppendLine();
            sb.AppendLine("    #endregion");
            sb.AppendLine("  }");
            sb.AppendLine("}");

            return sb.ToString();
        }

        private string BuildFrameInterface(IList<TelemetryField> fieldDefinitions)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("namespace RacerData.iRacing.Telemetry.Sdk");
            sb.AppendLine("{");
            sb.AppendLine("  public interface IFrameData");
            sb.AppendLine("  {");
            sb.AppendLine("    #region properties");
            sb.AppendLine();
            foreach (TelemetryField fieldDefinition in fieldDefinitions)
            {
                var propString = $"    {GetDataTypeName(fieldDefinition.DataType)} {fieldDefinition.Name}";
                sb.AppendLine($"{propString}" + " { get; set; }");
            }
            sb.AppendLine();
            sb.AppendLine("    #endregion");
            sb.AppendLine("  }");
            sb.AppendLine("}");

            return sb.ToString();
        }

        private string GetDataTypeName(irsdk_VarType varType)
        {
            switch (varType)
            {
                case irsdk_VarType.irsdk_char:
                    return "string";
                case irsdk_VarType.irsdk_bool:
                    return "bool";
                case irsdk_VarType.irsdk_int:
                    return "int";
                case irsdk_VarType.irsdk_bitField:
                    return "byte";
                case irsdk_VarType.irsdk_float:
                    return "float";
                case irsdk_VarType.irsdk_double:
                    return "double";
                case irsdk_VarType.irsdk_ETCount:
                    return "irsdk_ETCount";
                default:
                    throw new ArgumentException(nameof(varType)); ;
            }
        }

        private string BuildSessionClass(SessionDictionaries session)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("namespace RacerData.iRacing.Telemetry.Models");
            sb.AppendLine("{");
            sb.AppendLine("  public class SessionInfo : ISessionInfo");
            sb.AppendLine("  {");
            sb.AppendLine("    #region properties");
            sb.AppendLine();
            //foreach (TelemetryField fieldDefinition in fieldDefinitions)
            //{
            //    var propString = $"    public {GetDataTypeName(fieldDefinition.DataType)} {fieldDefinition.Name}";
            //    sb.AppendLine($"{propString}" + " { get; set; }");
            //}
            sb.AppendLine();
            sb.AppendLine("    #endregion");
            sb.AppendLine("  }");
            sb.AppendLine("}");

            return sb.ToString();
        }

        private string BuildSessionInterface(SessionDictionaries session)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("namespace RacerData.iRacing.Telemetry");
            sb.AppendLine("{");
            sb.AppendLine("  public class SessionInfo");
            sb.AppendLine("  {");
            sb.AppendLine("    #region properties");
            sb.AppendLine();

            Dictionary<object, object> rootList = (Dictionary<object, object>)session.root;

            foreach (KeyValuePair<object, object> rootItem in rootList)
            {
                if (rootItem.Key.ToString() == "WeekendInfo")
                {
                    //weekendOptions = (Dictionary<object, object>)weekendInfoItem.Value;
                    sb.AppendLine("    WeekendInfo WeekendInfo { get; set; }");
                }
                else if (rootItem.Key.ToString() == "SessionInfo")
                {
                    //telemetryOptions = (Dictionary<object, object>)weekendInfoItem.Value;
                    sb.AppendLine("    IList<Session> Sessions { get; set; }");
                }
                if (rootItem.Key.ToString() == "CameraInfo")
                {
                    //weekendOptions = (Dictionary<object, object>)weekendInfoItem.Value;
                    //sb.AppendLine("    CameraInfo CameraInfo { get; set; }");
                }
                else if (rootItem.Key.ToString() == "RadioInfo")
                {
                    //telemetryOptions = (Dictionary<object, object>)weekendInfoItem.Value;
                    //sb.AppendLine("    RadioInfo RadioInfo { get; set; }");
                }
                else if (rootItem.Key.ToString() == "DriverInfo")
                {
                    //telemetryOptions = (Dictionary<object, object>)weekendInfoItem.Value;
                    sb.AppendLine("    DriverInfo DriverInfo { get; set; }");
                }
                else if (rootItem.Key.ToString() == "SplitTimeInfo")
                {
                    //telemetryOptions = (Dictionary<object, object>)weekendInfoItem.Value;
                    //sb.AppendLine("    SplitTimeInfo SplitTimeInfo { get; set; }");
                }
            }

            sb.AppendLine();
            sb.AppendLine("    #endregion");
            sb.AppendLine("  }");
            sb.AppendLine("}");

            sb.AppendLine("##########################################################");


            sb.AppendLine("namespace RacerData.iRacing.Telemetry");
            sb.AppendLine("{");
            sb.AppendLine("  public class Session");
            sb.AppendLine("  {");
            sb.AppendLine("    #region properties");
            sb.AppendLine();

            IList<object> sessionList = (IList<object>)session.sessionInfo["Sessions"];
            // sessionList has 3 dicts

            Dictionary<object, object> sessionInstance = (Dictionary<object, object>)sessionList[0];

            foreach (KeyValuePair<object, object> sessionInstanceItem in sessionInstance)
            {
                var propertyName = sessionInstanceItem.Key.ToString();
                var propString = $"    string {propertyName}";
                sb.AppendLine($"{propString}" + " { get; set; }");
            }

            sb.AppendLine();
            sb.AppendLine("    #endregion");
            sb.AppendLine("  }");
            sb.AppendLine("}");

            sb.AppendLine("##########################################################");

            sb.AppendLine("namespace RacerData.iRacing.Telemetry");
            sb.AppendLine("{");
            sb.AppendLine("  public class WeekendInfo");
            sb.AppendLine("  {");
            sb.AppendLine("    #region properties");
            sb.AppendLine();


            Dictionary<object, object> weekendInfo = (Dictionary<object, object>)session.weekendInfo;
            Dictionary<object, object> weekendOptions = null;
            Dictionary<object, object> telemetryOptions = null;

            foreach (KeyValuePair<object, object> weekendInfoItem in weekendInfo)
            {
                if (weekendInfoItem.Key.ToString() == "WeekendOptions")
                {
                    weekendOptions = (Dictionary<object, object>)weekendInfoItem.Value;
                    sb.AppendLine("    WeekendOptions WeekendOptions { get; set; }");
                }
                else if (weekendInfoItem.Key.ToString() == "TelemetryOptions")
                {
                    telemetryOptions = (Dictionary<object, object>)weekendInfoItem.Value;
                    sb.AppendLine("    TelemetryOptions TelemetryOptions { get; set; }");
                }
                else
                {
                    var propertyName = weekendInfoItem.Key.ToString();
                    var propString = $"    string {propertyName}";
                    sb.AppendLine($"{propString}" + " { get; set; }");
                }
            }

            sb.AppendLine();
            sb.AppendLine("    #endregion");
            sb.AppendLine("  }");
            sb.AppendLine("}");

            sb.AppendLine("##########################################################");

            sb.AppendLine("namespace RacerData.iRacing.Telemetry");
            sb.AppendLine("{");
            sb.AppendLine("  public class WeekendOptions");
            sb.AppendLine("  {");
            sb.AppendLine("    #region properties");
            sb.AppendLine();
            foreach (KeyValuePair<object, object> weekendOptionItem in weekendOptions)
            {
                var propertyName = weekendOptionItem.Key.ToString();
                var propString = $"    string {propertyName}";
                sb.AppendLine($"{propString}" + " { get; set; }");
            }
            sb.AppendLine();
            sb.AppendLine("    #endregion");
            sb.AppendLine("  }");
            sb.AppendLine("}");

            sb.AppendLine("##########################################################");

            sb.AppendLine("namespace RacerData.iRacing.Telemetry");
            sb.AppendLine("{");
            sb.AppendLine("  public class TelemetryOptions");
            sb.AppendLine("  {");
            sb.AppendLine("    #region properties");
            sb.AppendLine();
            foreach (KeyValuePair<object, object> telemetryOptionItem in telemetryOptions)
            {
                var propertyName = telemetryOptionItem.Key.ToString();
                var propString = $"    string {propertyName}";
                sb.AppendLine($"{propString}" + " { get; set; }");
            }
            sb.AppendLine();
            sb.AppendLine("    #endregion");
            sb.AppendLine("  }");
            sb.AppendLine("}");

            sb.AppendLine("##########################################################");

            Dictionary<object, object> driverInfo = (Dictionary<object, object>)session.driverInfo;
            IList<object> driversList = null;

            sb.AppendLine("namespace RacerData.iRacing.Telemetry");
            sb.AppendLine("{");
            sb.AppendLine("  public class DriverInfo");
            sb.AppendLine("  {");
            sb.AppendLine("    #region properties");
            sb.AppendLine();
            foreach (KeyValuePair<object, object> driverInfoItem in driverInfo)
            {
                if (driverInfoItem.Key.ToString() == "Drivers")
                {
                    driversList = (IList<object>)driverInfoItem.Value;
                    sb.AppendLine("    IList<Driver> Drivers { get; set; }");
                }
                else
                {
                    var propertyName = driverInfoItem.Key.ToString();
                    var propString = $"    string {propertyName}";
                    sb.AppendLine($"{propString}" + " { get; set; }");
                }
            }
            sb.AppendLine();
            sb.AppendLine("    #endregion");
            sb.AppendLine("  }");
            sb.AppendLine("}");

            sb.AppendLine("##########################################################");

            sb.AppendLine("namespace RacerData.iRacing.Telemetry");
            sb.AppendLine("{");
            sb.AppendLine("  public class Driver");
            sb.AppendLine("  {");
            sb.AppendLine("    #region properties");
            sb.AppendLine();

            Dictionary<object, object> driverListItem = (Dictionary<object, object>)driversList[0];
            foreach (KeyValuePair<object, object> driverInfoItem in driverListItem)
            {
                var propertyName = driverInfoItem.Key.ToString();
                var propString = $"    string {propertyName}";
                sb.AppendLine($"{propString}" + " { get; set; }");
            }
            sb.AppendLine();
            sb.AppendLine("    #endregion");
            sb.AppendLine("  }");
            sb.AppendLine("}");

            sb.AppendLine("##########################################################");
            
            return sb.ToString();
        }
        //foreach (KeyValuePair<object, object> item in session.sessionInfo)
        //{
        //    if (item.Value is Dictionary<object, object>)
        //    {
        //        foreach (KeyValuePair<object, object> subItem in (Dictionary<object, object>)item.Value)
        //        {
        //            var propertyName = subItem.Key.ToString();
        //            var propString = $"    string {propertyName}";
        //            sb.AppendLine($"{propString}" + " { get; set; }");
        //        }

        //    }
        //    else if (item.Value is IList<object>)
        //    {
        //        IList<object> itemList = (IList<object>)item.Value;

        //        foreach (object itemListObject in itemList)
        //        {
        //            if (itemListObject is Dictionary<string, string>)
        //            {

        //            }
        //            else if (itemListObject is IList<object>)
        //            {

        //            }
        //            else
        //            {
        //                var propertyName = item.Key.ToString();
        //                var propString = $"    string {propertyName}";
        //                sb.AppendLine($"{propString}" + " { get; set; }");
        //            }
        //        }
        //    }
        //    else
        //    {
        //        var propertyName = item.Key.ToString();
        //        var propString = $"    string {propertyName}";
        //        sb.AppendLine($"{propString}" + " { get; set; }");
        //    }
        //}

        //foreach (TelemetryField fieldDefinition in fieldDefinitions)
        //{
        //    var propString = $"    {GetDataTypeName(fieldDefinition.DataType)} {fieldDefinition.Name}";
        //    sb.AppendLine($"{propString}" + " { get; set; }");
        //}

        #endregion

        #region classes

        public class FrameDataClassStrings
        {
            public string IFrameDataString { get; set; }
            public string FrameDataString { get; set; }
        }

        public class SessionInfoClassStrings
        {
            public string ISessionInfoString { get; set; }
            public string SessionInfoString { get; set; }
        }

        #endregion
    }
}
