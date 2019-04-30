using System.Collections.Generic;
using System.Linq;
using RacerData.NascarApi.Client.Models.LapAverages;

namespace RacerData.NascarApi.LapAverage.Service.Internal
{
    class VehicleConsecutiveLaps
    {
        #region properties

        public string VehicleId { get; set; }
        public int? StartLap
        {
            get
            {
                var firstLap = VehicleLapEvents.OrderBy(l => l.Elapsed).FirstOrDefault();

                //return firstLap != null ? firstLap.LapNumber : -1;

                return firstLap?.LapNumber;
            }
        }
        public int? EndLap
        {
            get
            {
                var lastLap = VehicleLapEvents.OrderBy(l => l.Elapsed).LastOrDefault();

                return lastLap?.LapNumber;
            }
        }
        public int LapCount
        {
            get
            {
                return VehicleLapEvents.Count;
            }
        }

        public IList<VehicleLapEvent> VehicleLapEvents { get; set; }

        #endregion

        #region ctor

        public VehicleConsecutiveLaps()
        {
            VehicleLapEvents = new List<VehicleLapEvent>();
        }

        #endregion

        #region public

        public VehicleNLapAverage BestNLaps(int targetLapCount)
        {
            if (LapCount < targetLapCount)
            {
                return null;
            }
            else
            {
                VehicleNLapAverage average = null;

                for (int lapIndex = 0; lapIndex < LapCount - targetLapCount; lapIndex++)
                {
                    var laps = VehicleLapEvents.OrderBy(l => l.Elapsed).Skip(lapIndex).Take(targetLapCount);

                    var lapAverage = laps.Average(l => l.LapTime);

                    if (average == null || lapAverage < average.AverageLapTime)
                    {
                        average = new VehicleNLapAverage()
                        {
                            VehicleId = VehicleId,
                            StartLap = laps.Min(l => l.LapNumber),
                            EndLap = laps.Max(l => l.LapNumber),
                            LapCount = targetLapCount,
                            AverageLapTime = laps.Average(l => l.LapTime)
                        };
                    }
                }

                return average;
            }
        }

        public VehicleNLapAverage LastNLaps(int targetLapCount)
        {
            if (LapCount < targetLapCount)
            {
                return null;
            }
            else
            {
                var laps = VehicleLapEvents.OrderByDescending(l => l.Elapsed).Take(targetLapCount);

                VehicleNLapAverage average = new VehicleNLapAverage()
                {
                    VehicleId = VehicleId,
                    StartLap = laps.Min(l => l.LapNumber),
                    EndLap = laps.Max(l => l.LapNumber),
                    LapCount = targetLapCount,
                    AverageLapTime = laps.Average(l => l.LapTime)
                };

                return average;
            }
        }

        public override string ToString()
        {
            return $"[{LapCount}] {StartLap} - {EndLap}";
        }

        #endregion
    }
}
