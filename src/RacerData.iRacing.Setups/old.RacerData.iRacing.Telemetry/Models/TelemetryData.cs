using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RacerData.iRacing.Telemetry.Models
{
    public class SessionData : TelemetryData, ISessionData
    {

    }

    public class TelemetryData : ITelemetryData
    {
        #region properties
        public IList<IFrame> Frames { get; set; }
        public IList<IFieldDefinition> Fields { get; set; }
        public IList<ILapInfo> Laps { get; set; }
        public ISessionDictionaries SessionInfo { get; set; }
        public ISetupInfo SetupInfo { get; set; }

        public IDictionary<object, object> ActiveSessionInfo
        {
            get
            {
                IDictionary<object, object> session = null;

                IList<object> sessions = (IList<object>)SessionInfo.sessionInfo["Sessions"];

                for (int i = 0; i < sessions.Count; i++)
                {
                    IDictionary<object, object> selectedSession = (IDictionary<object, object>)sessions[i];

                    if (selectedSession["ResultsOfficial"].ToString() == "0")
                    {
                        session = selectedSession;

                        break;
                    }
                }

                return session;
            }
        }
        #endregion

        #region ctor
        public TelemetryData()
        {
            Frames = new List<IFrame>();
            Fields = new List<IFieldDefinition>();
            Laps = new List<ILapInfo>();
        }
        #endregion

        #region ToString
        public override string ToString()
        {
            return String.Format("{0} Fields, {1} Frames", Fields.Count(), Frames.Count());
        }
        public string ValuesToString()
        {
            var sb = new StringBuilder();
            foreach (var telemetryFrame in Frames)
            {
                foreach (FrameFieldValue telemetryFieldValue in ((Frame)telemetryFrame).FieldValues)
                {
                    sb.AppendFormat("{0}: {1} [{2}] ", telemetryFieldValue.FieldName, telemetryFieldValue.ByteString, telemetryFieldValue.FieldValue);
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
        public string FieldsToString()
        {
            var sb = new StringBuilder();
            var fieldIdx = 0;
            foreach (var telemetryField in Fields)
            {
                sb.AppendFormat("{0,-3}) {1,-32} {2,-64} {3,-32} {4,-4} {5,-4}", fieldIdx.ToString(), telemetryField.Name, telemetryField.Description, telemetryField.Unit, telemetryField.DataType.ToString(), telemetryField.Position.ToString());
                sb.AppendLine();
                fieldIdx++;
            }
            return sb.ToString();
        }
        #endregion
    }
}
