using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using RacerData.NascarApi.Client.Models;
using RacerData.NascarApi.Client.Models.LapTimes;
using RacerData.NascarApi.Client.Models.LiveFeed;

namespace RacerData.NascarApi.LapTimes.Service.Internal
{
    class LapTimeParser : ILapTimeParser
    {
        #region fields

        private bool _verbose = false;

        #endregion

        #region ctor

        public LapTimeParser(
            IConfiguration configuration)
        {

            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            _verbose = configuration["monitor:verbose"] == "true";
        }

        #endregion

        #region public

        public EventVehicleLapTimes ParseLapTimes(EventVehicleLapTimes lapTimes, LiveFeedData data)
        {
            foreach (Vehicle vehicle in data.Vehicles)
            {
                var existingLap = lapTimes.VehicleLapTimes.FirstOrDefault(l => l.VehicleId == vehicle.CarNumber && l.LapNumber == vehicle.LapsCompleted);

                if (existingLap == null)
                {
                    if (_verbose)
                    {
                        Console.WriteLine($"Adding lap time for car {vehicle.CarNumber} for lap {vehicle.LapsCompleted}: {vehicle.LastLapTime}");
                    }

                    lapTimes.VehicleLapTimes.Add(new VehicleLapTime()
                    {
                        VehicleId = vehicle.CarNumber,
                        LapNumber = vehicle.LapsCompleted,
                        LapTime = vehicle.LastLapTime,
                        EventElapsed = data.Elapsed,
                        VehicleElapsed = vehicle.VehicleElapsedTime,
                        TrackState = data.FlagState,
                        VehicleStatus = (VehicleStatus)vehicle.Status
                    });
                }
                else
                {
                    if (existingLap.VehicleElapsed != vehicle.VehicleElapsedTime ||
                        existingLap.LapNumber != vehicle.LapsCompleted ||
                        existingLap.LapTime != vehicle.LastLapTime ||
                        existingLap.VehicleStatus != (VehicleStatus)vehicle.Status ||
                        existingLap.TrackState != data.FlagState)
                    {
                        if (_verbose)
                        {
                            Console.WriteLine($"Updating lap time for car {vehicle.CarNumber} " +
                                $"for lap {vehicle.LapsCompleted}: " +
                                $"  from {existingLap.LapTime} to {vehicle.LastLapTime}" +
                                $"  from {existingLap.VehicleStatus} to {((VehicleStatus)vehicle.Status).ToString()}" +
                                $"  from {existingLap.TrackState} to {data.FlagState.ToString()}");
                        }

                        existingLap.VehicleElapsed = vehicle.VehicleElapsedTime;
                        existingLap.LapNumber = vehicle.LapsCompleted;
                        existingLap.LapTime = vehicle.LastLapTime;
                        existingLap.VehicleStatus = (VehicleStatus)vehicle.Status;
                        existingLap.TrackState = data.FlagState;
                    }
                }

                //foreach (PitStop pitStop in vehicle.PitStops)
                //{
                //    var existingPitStop = history.GetPitStopEventAt(pitStop.PitInElapsed);

                //    if (existingPitStop == null)
                //    {
                //        history.AddPitEvent(pitStop.PitInElapsed, pitStop.PitInLap, pitStop.PitOutElapsed);
                //    }
                //    else
                //    {
                //        if (existingPitStop.PitOutElapsed == 0.0)
                //        {
                //            existingPitStop.PitOutElapsed = pitStop.PitOutElapsed;
                //        }
                //    }
                //}
            }
            return lapTimes;
        }

        #endregion

        #region protected


        #endregion

        #region private


        #endregion

    }
}
