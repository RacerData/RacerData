﻿using System.Collections.Generic;
using System.Threading.Tasks;
using RacerData.Common.Results;
using RacerData.NascarApi.Client.Models.LapAverages;
using RacerData.NascarApi.Client.Models.LiveFeed;
using RacerData.NascarApi.Client.Models.LiveFlag;
using RacerData.NascarApi.Client.Models.LivePit;
using RacerData.NascarApi.Client.Models.LivePoints;

namespace RacerData.NascarApi.Client.Ports
{
    public interface INascarApiClient
    {
        Task<IResult<LiveFeedData>> GetLiveFeedDataAsync();
        Task<IResult<LiveFlagData>> GetLiveFlagDataAsync();
        Task<IResult<LivePitData>> GetLivePitDataAsync();
        Task<IResult<IEnumerable<LivePointsData>>> GetLivePointsDataAsync();
        Task<IResult<EventVehicleLapAverages>> GetLapAverageDataAsync();
    }
}
