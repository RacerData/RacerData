﻿using System;
using log4net;
using RacerData.NascarApi.Client.Models.LapAverages;
using RacerData.NascarApi.Client.Models.LiveFeed;
using RacerData.NascarApi.LapAverage.Service.Internal;
using RacerData.NascarApi.LapAverage.Service.Ports;
using RacerData.NascarApi.Service;
using RacerData.NascarApi.Service.Adapters;
using RacerData.NascarApi.Service.Ports;

namespace RacerData.NascarApi.LapAverage.Service.Adapters
{
    class LapAverageHandler : MonitorClientBase, IMonitorClient, ILapAverageHandler
    {
        #region events

        public event EventHandler<LapAveragesUpdatedEventArgs> LapAveragesUpdated;
        protected virtual void OnLapAveragesUpdated(LapAverageData lapAverages)
        {
            var handler = LapAveragesUpdated;
            if (handler != null)
                handler.Invoke(this, new LapAveragesUpdatedEventArgs() { Data = lapAverages });
        }

        #endregion

        #region fields

        private LapAverageData _eventLapAverages = new LapAverageData();
        private readonly ILapAverageService _lapAverageService;
        private readonly ILapAverageDataFileWriter _lapAverageFileWriter;
        private readonly IAwsDataPump _dataPump;
        private readonly ILog _log;
        private int _lastElapsed = -1;
        private int _lastRaceId = -1;
        private int _lastRunId = -1;

        #endregion

        #region ctor

        public LapAverageHandler(
            ILapAverageService lapAverageService,
            ILapAverageDataFileWriter lapAverageFileWriter,
            IAwsDataPump dataPump,
            ILog log)
        {
            _lapAverageService = lapAverageService ?? throw new ArgumentNullException(nameof(lapAverageService));
            _lapAverageFileWriter = lapAverageFileWriter ?? throw new ArgumentNullException(nameof(lapAverageFileWriter));
            _dataPump = dataPump ?? throw new ArgumentNullException(nameof(dataPump));
            _log = log ?? throw new ArgumentNullException(nameof(log));

            LapAveragesUpdated += LiveFeedHandler_LapAveragesUpdated;
        }

        #endregion

        #region public

        public override void Monitor_LiveFeedUpdated(object sender, LiveFeedUpdatedEventArgs e)
        {
            try
            {
                ProcessLiveFeedDataAsync(e.LiveFeedData);
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error processing live feed update", ex);
            }
        }

        #endregion

        #region protected

        protected virtual void ExceptionHandler(string message, Exception ex)
        {
            if (_log != null)
                _log.Error(message, ex);
#if DEBUG
            Console.WriteLine(ex);
#endif
        }

        protected virtual void ProcessLiveFeedDataAsync(LiveFeedData liveFeedData)
        {
            try
            {
                if (liveFeedData.RaceId != _lastRaceId ||
                    liveFeedData.RunId != _lastRunId)
                {
                    ResetLapAverages();

                    _eventLapAverages.RaceId = liveFeedData.RaceId;
                    _eventLapAverages.RunId = liveFeedData.RunId;
                    _eventLapAverages.SeriesId = (int)liveFeedData.SeriesType;
                }

                _eventLapAverages.Elapsed = liveFeedData.Elapsed;

                ReadLapTimes(liveFeedData);

                if (liveFeedData.Elapsed != _lastElapsed)
                {
                    OnLapAveragesUpdated(_eventLapAverages);

                    _lastElapsed = liveFeedData.Elapsed;
                    _lastRaceId = liveFeedData.RaceId;
                    _lastRunId = liveFeedData.RunId;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error pumping lap averages", ex);
            }
        }

        protected virtual void ResetLapAverages()
        {
            _eventLapAverages = new LapAverageData();
            _lastElapsed = -1;
            _lastRaceId = -1;
            _lastRunId = -1;
        }

        protected virtual void ReadLapTimes(LiveFeedData liveFeedData)
        {
            _lapAverageService.ParseVehicleLapData(liveFeedData);

            _eventLapAverages.SeriesId = (int)liveFeedData.SeriesType;
            _eventLapAverages.TrackName = liveFeedData.TrackName;
            _eventLapAverages.TrackName = liveFeedData.TrackName;
            _eventLapAverages.RunName = liveFeedData.RunName;
            _eventLapAverages.Elapsed = liveFeedData.Elapsed;

            _eventLapAverages.Best5LapAverages = _lapAverageService.GetBestLapAverages(5);
            _eventLapAverages.Best10LapAverages = _lapAverageService.GetBestLapAverages(10);
            _eventLapAverages.Best20LapAverages = _lapAverageService.GetBestLapAverages(20);
            _eventLapAverages.Last5LapAverages = _lapAverageService.GetBestLapAverages(5);
            _eventLapAverages.Last10LapAverages = _lapAverageService.GetBestLapAverages(10);
            _eventLapAverages.Last20LapAverages = _lapAverageService.GetBestLapAverages(20);
        }

        #endregion

        #region private

        private async void LiveFeedHandler_LapAveragesUpdated(object sender, LapAveragesUpdatedEventArgs e)
        {
            try
            {
                _lapAverageFileWriter.WriteFile(e.Data);
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error writing lap averages to file", ex);
            }
            try
            {
                await _dataPump.WriteLapAveragesAsync(e.Data);
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error pumping lap averages", ex);
            }
        }

        #endregion
    }
}
