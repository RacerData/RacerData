using System;
using System.Collections.Generic;
using System.Linq;
using RacerData.iRacing.Extensions;
using RacerData.iRacing.Telemetry;

namespace RacerData.iRacing.Setups.ClassBuilder.Models
{
    public class LapData
    {
        #region properties

        public int StartLap
        {
            get
            {
                return Laps.Count > 0 ? Laps[0].LapNumber : 0;
            }
        }

        public int LapCount
        {
            get
            {
                return ValidLaps.Count();
            }
        }

        public IEnumerable<ILapInfo> ValidLaps
        {
            get
            {
                if (Laps.Count < 3)
                {
                    return Laps;
                }
                else
                {
                    return Laps.Where(l => l.LapTime > 0);
                }
            }
        }

        public ILapInfo BestLap
        {
            get
            {
                return ValidLaps.OrderBy(l => l.LapTime).FirstOrDefault();
            }
        }

        public int BestLapNumber
        {
            get
            {
                return BestLap.LapNumber;
            }
        }

        public double BestLapTime
        {
            get
            {
                return Math.Round(BestLap.LapTime, 3);
            }
        }

        public double AverageLapTime
        {
            get
            {
                return Math.Round(ValidLaps.Average(l => l.LapTime), 3);
            }
        }

        public double LapTimeStandardDeviation
        {
            get
            {
                var lapTimes = ValidLaps.Select(l => (double)l.LapTime);
                var bestLap = lapTimes.Min();
                var lapTimeCutoff = bestLap * 1.07;
                var cleanLapTimes = lapTimes.Where(l => l < lapTimeCutoff);
                if (cleanLapTimes.Count() == 0)
                    return 0;
                var stdDev = cleanLapTimes.StandardDeviation();
                return Math.Round(stdDev, 3);
            }
        }

        public IList<ILapInfo> Laps { get; set; }

        #endregion

        #region ctor

        public LapData()
        {
            Laps = new List<ILapInfo>();
        }

        #endregion
    }
}
