using System.Collections.Generic;
using System.Linq;
using RacerData.NascarApi.Client.Models.LapAverages;

namespace RacerData.NascarApi.LapAverage.Service.Internal
{
    class VehicleLapEventHistory
    {
        #region properties

        public string VehicleId { get; set; }
        public IList<VehicleEvent> VehicleEvents { get; set; }
        public IList<VehicleConsecutiveLaps> VehicleConsecutiveLaps
        {
            get
            {
                var consecutiveLaps = new List<VehicleConsecutiveLaps>();

                VehicleConsecutiveLaps laps = new VehicleConsecutiveLaps();

                foreach (VehicleEvent vehicleEvent in VehicleEvents.OrderBy(e => e.Elapsed))
                {
                    if (vehicleEvent is VehiclePitStopEvent)
                    {
                        if (laps.LapCount > 0)
                            consecutiveLaps.Add(laps);
                        laps = new VehicleConsecutiveLaps() { VehicleId = VehicleId };

                    }
                    if (vehicleEvent is VehicleLapEvent)
                    {
                        if (((VehicleLapEvent)vehicleEvent).LapTime > 0.0)
                            laps.VehicleLapEvents.Add((VehicleLapEvent)vehicleEvent);
                    }
                }

                if (laps.LapCount > 0)
                    consecutiveLaps.Add(laps);

                return consecutiveLaps;
            }
        }

        #endregion

        #region ctor

        public VehicleLapEventHistory()
        {
            VehicleEvents = new List<VehicleEvent>();
        }

        #endregion

        #region public

        public IList<VehicleNLapAverage> GetBestLapAverage(int targetLapCount)
        {
            var averages = VehicleConsecutiveLaps.Select(a => a.BestNLaps(targetLapCount));

            return averages.ToList();
        }

        public IList<VehicleNLapAverage> GetLastLapAverage(int targetLapCount)
        {
            var averages = VehicleConsecutiveLaps.Select(a => a.LastNLaps(targetLapCount));

            return averages.ToList();
        }

        public VehiclePitStopEvent GetPitStopEventAt(double elapsed)
        {
            return VehicleEvents.OfType<VehiclePitStopEvent>().FirstOrDefault(e => e.Elapsed == elapsed);
        }

        public VehicleLapEvent GetLapEventAt(int lapNumber)
        {
            return VehicleEvents.OfType<VehicleLapEvent>().FirstOrDefault(e => e.LapNumber == lapNumber);
        }

        public void AddPitEvent(double pitInElapsed, int pitInLap, double pitOutElapsed)
        {
            VehicleEvents.Add(new VehiclePitStopEvent(VehicleId, pitInElapsed, pitInLap, pitOutElapsed));
        }

        public void AddLapEvent(double elapsed, int lapNumber, double lapTime)
        {
            VehicleEvents.Add(new VehicleLapEvent(VehicleId, elapsed, lapNumber, lapTime));
        }

        #endregion
    }
}
