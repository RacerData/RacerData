using RacerData.NascarApi.Client.Models.LapTimes;
using RacerData.NascarApi.Client.Models.LiveFeed;

namespace RacerData.NascarApi.LapTimes.Service.Internal
{
    interface ILapTimeParser
    {
        EventVehicleLapTimes ParseLapTimes(EventVehicleLapTimes lapTimes, LiveFeedData data);
    }
}