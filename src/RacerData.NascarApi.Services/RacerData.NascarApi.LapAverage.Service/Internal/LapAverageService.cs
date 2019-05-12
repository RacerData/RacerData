using System.Collections.Generic;
using System.Linq;
using RacerData.NascarApi.Client.Models.LapAverages;
using RacerData.NascarApi.Client.Models.LiveFeed;
using RacerData.NascarApi.LapAverage.Service.Ports;

namespace RacerData.NascarApi.LapAverage.Service.Internal
{
    class LapAverageService : ILapAverageService
    {
        #region fields

        private IDictionary<string, VehicleLapEventHistory> _vehicleLapHistory;

        #endregion

        #region ctor

        public LapAverageService()
        {
            _vehicleLapHistory = new Dictionary<string, VehicleLapEventHistory>();
        }

        #endregion

        #region public

        public IEnumerable<VehicleLap> VehicleLaps(string carNumber)
        {
            return _vehicleLapHistory[carNumber]
                .VehicleConsecutiveLaps
                .SelectMany(l => l.VehicleLapEvents)
                .Select(l => new VehicleLap()
                {
                    VehicleId = l.VehicleId,
                    LapNumber = l.LapNumber,
                    LapTime = l.LapTime
                })
                .OrderBy(l => l.LapNumber);
        }

        public List<VehicleNLapAverage> GetBestLapAverages(int targetLapCount)
        {
            var averages = _vehicleLapHistory.Values.SelectMany(a => a.GetBestLapAverage(targetLapCount));

            return averages.Where(a => a != null).OrderBy(a => a.AverageLapTime).ToList();
        }

        public List<VehicleNLapAverage> GetLastLapAverages(int targetLapCount)
        {
            var averages = _vehicleLapHistory.Values.SelectMany(a => a.GetLastLapAverage(targetLapCount));

            return averages.Where(a => a != null).OrderBy(a => a.AverageLapTime).ToList();
        }

        public void ParseVehicleLapData(LiveFeedData data)
        {
            var elapsed = data.Elapsed;

            foreach (Vehicle vehicle in data.Vehicles)
            {
                if (!_vehicleLapHistory.Keys.Contains(vehicle.CarNumber))
                {
                    _vehicleLapHistory.Add(vehicle.CarNumber, new VehicleLapEventHistory() { VehicleId = vehicle.CarNumber });
                }

                var history = _vehicleLapHistory[vehicle.CarNumber];

                var existingLap = history.GetLapEventAt(vehicle.LapsCompleted);

                if (existingLap == null)
                {
                    history.AddLapEvent(vehicle.VehicleElapsedTime, vehicle.LapsCompleted, vehicle.LastLapTime);
                }
                else
                {
                    existingLap.Elapsed = vehicle.VehicleElapsedTime;
                    existingLap.LapNumber = vehicle.LapsCompleted;
                    existingLap.LapTime = vehicle.LastLapTime;
                }

                foreach (PitStop pitStop in vehicle.PitStops)
                {
                    var existingPitStop = history.GetPitStopEventAt(pitStop.PitInElapsed);

                    if (existingPitStop == null)
                    {
                        history.AddPitEvent(pitStop.PitInElapsed, pitStop.PitInLap, pitStop.PitOutElapsed);
                    }
                    else
                    {
                        if (existingPitStop.PitOutElapsed == 0.0)
                        {
                            existingPitStop.PitOutElapsed = pitStop.PitOutElapsed;
                        }
                    }
                }
            }
        }

        #endregion
    }
}
