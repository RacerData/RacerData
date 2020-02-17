using System;
using System.Globalization;
using RacerData.iRacing.Setups.Modifieds;
using RacerData.iRacing.Telemetry;

namespace RacerData.iRacing.Setups.ClassBuilder.Models
{
    public class EventSessionData
    {
        #region properties

        public EventData EventData { get; }

        public int SessionNumber { get; set; }
        public SessionType SessionType { get; set; }
        public string TelemetryFileName { get; set; }
        public DateTime Timestamp
        {
            get
            {
                return DateTime.ParseExact(TelemetryFileName.Substring(TelemetryFileName.Length - 23, 19), "yyyy-MM-dd HH-mm-ss", CultureInfo.InvariantCulture);
            }
        }
        public string TrackRubberState { get; set; }
        public int CumulativeLapCount { get; set; }
        public double CumulativeBestLap { get; set; }
        public double CumulativeBestLapTime { get; set; }
        private string _setupName;
        public string SetupName
        {
            get
            {

                return String.IsNullOrEmpty(_setupName) ?
                    Setup.Description :
                    _setupName;
            }
            set
            {
                _setupName = value;
            }
        }
        public string SetupBackupName { get; set; }
        public int UpdateCount
        {
            get
            {
                return Setup.UpdateCount;
            }
        }

        public SkModified Setup { get; set; }
        public TireSheetValues TireSheet { get; set; }

        public LapData LapData { get; set; }

        #endregion

        #region ctor

        public EventSessionData(EventData eventData)
        {
            EventData = eventData;
        }

        #endregion
    }
}
