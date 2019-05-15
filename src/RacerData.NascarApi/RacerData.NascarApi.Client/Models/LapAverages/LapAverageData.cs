﻿using System.Collections.Generic;

namespace RacerData.NascarApi.Client.Models.LapAverages
{
    public class LapAverageData
    {
        #region properties

        public int RaceId { get; set; }
        public int SeriesId { get; set; }
        public int RunId { get; set; }
        public string TrackName { get; set; }
        public string RunName { get; set; }
        public int Elapsed { get; set; }
        [Newtonsoft.Json.JsonIgnore()]
        public System.TimeSpan ElapsedTime
        {
            get
            {
                return new System.TimeSpan(0, 0, Elapsed);
            }
        }

        public List<VehicleNLapAverage> Best5LapAverages { get; set; }
        public List<VehicleNLapAverage> Best10LapAverages { get; set; }
        public List<VehicleNLapAverage> Best20LapAverages { get; set; }
        public List<VehicleNLapAverage> Last5LapAverages { get; set; }
        public List<VehicleNLapAverage> Last10LapAverages { get; set; }
        public List<VehicleNLapAverage> Last20LapAverages { get; set; }

        #endregion

        #region properties

        public LapAverageData()
        {
            Best5LapAverages = new List<VehicleNLapAverage>();
            Best10LapAverages = new List<VehicleNLapAverage>();
            Best20LapAverages = new List<VehicleNLapAverage>();
            Last5LapAverages = new List<VehicleNLapAverage>();
            Last10LapAverages = new List<VehicleNLapAverage>();
            Last20LapAverages = new List<VehicleNLapAverage>();
        }

        #endregion
    }
}
