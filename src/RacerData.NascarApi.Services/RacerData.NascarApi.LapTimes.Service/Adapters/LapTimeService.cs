﻿using System;
using log4net;
using RacerData.Data.Aws.Ports;
using RacerData.NascarApi.Client.Models.LapTimes;
using RacerData.NascarApi.Client.Models.LiveFeed;
using RacerData.NascarApi.LapTimes.Service.Internal;
using RacerData.NascarApi.LapTimes.Service.Models;
using RacerData.NascarApi.LapTimes.Service.Ports;
using RacerData.NascarApi.Service;
using RacerData.NascarApi.Service.Ports;

namespace RacerData.NascarApi.LapTimes.Service.Adapters
{
    class LapTimeService : IMonitorClient, ILapTimeService
    {
        #region events

        public event EventHandler<LapTimesUpdatedEventArgs> LapTimesUpdated;
        protected virtual void OnLapTimesUpdated(EventVehicleLapTimes lapTimes)
        {
            var handler = LapTimesUpdated;
            if (handler != null)
                handler.Invoke(this, new LapTimesUpdatedEventArgs() { LapTimes = lapTimes });
        }

        #endregion

        #region fields

        private readonly ILapTimeDataFileWriter _lapTimeFileWriter;
        private readonly AwsLapTimeDataPump _dataPump;
        private readonly ILapTimeParser _lapTimeParser;
        private readonly ILog _log;
        private EventVehicleLapTimes _lapTimes;
        private int _lastElapsed = -1;
        private int _lastRaceId = -1;
        private int _lastSeriesId = -1;
        private int _lastRunId = -1;

        #endregion

        #region ctor

        public LapTimeService(
            IAwsRepositoryFactory awsRepositoryFactory,
            ILapTimeParser lapTimeParser,
            ILapTimeDataFileWriter lapTimeFileWriter,
            ILog log)
        {
            if (awsRepositoryFactory == null)
                throw new ArgumentNullException(nameof(awsRepositoryFactory));

            IAwsBucketConfiguration awsConfiguraiton = new AwsLapTimeBucketConfiguration();
            var lapTimeRepository = awsRepositoryFactory.GetAwsRepository(awsConfiguraiton);
            _dataPump = new AwsLapTimeDataPump(lapTimeRepository);

            _lapTimeFileWriter = lapTimeFileWriter ?? throw new ArgumentNullException(nameof(lapTimeFileWriter));
            _lapTimeParser = lapTimeParser ?? throw new ArgumentNullException(nameof(lapTimeParser));
            _log = log ?? throw new ArgumentNullException(nameof(log));

            LapTimesUpdated += LapTimeService_LapTimesUpdated;
        }

        #endregion

        #region public

        public void Monitor_LiveFeedUpdated(object sender, LiveFeedUpdatedEventArgs e)
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

        public void Monitor_LiveFeedStarted(object sender, LiveFeedStartedEventArgs e)
        {

        }

        public void Monitor_ServiceStateChanged(object sender, ServiceStateChangedEventArgs e)
        {

        }

        public void Monitor_ServiceActivity(object sender, ServiceActivityEventArgs e)
        {

        }

        public void Monitor_ServiceStatusChanged(object sender, ServiceActivityEventArgs e)
        {

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
                    liveFeedData.SeriesId != _lastSeriesId ||
                    liveFeedData.RunId != _lastRunId)
                {
                    ResetLapTimes();

                    _lapTimes.RaceId = liveFeedData.RaceId;
                    _lapTimes.SeriesId = liveFeedData.SeriesId;
                    _lapTimes.RunId = liveFeedData.RunId;
                    _lapTimes.Elapsed = liveFeedData.Elapsed;
                    _lapTimes.TrackName = liveFeedData.TrackName;
                    _lapTimes.RunName = liveFeedData.RunName;
                }

                _lapTimes = ReadLapTimes(liveFeedData);

                if (liveFeedData.Elapsed != _lastElapsed)
                {
                    OnLapTimesUpdated(_lapTimes);

                    _lastElapsed = liveFeedData.Elapsed;
                    _lastRaceId = liveFeedData.RaceId;
                    _lastSeriesId = liveFeedData.SeriesId;
                    _lastRunId = liveFeedData.RunId;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error pumping lap times", ex);
            }
        }

        protected virtual void ResetLapTimes()
        {
            _lapTimes = new EventVehicleLapTimes();
            _lastElapsed = -1;
            _lastRaceId = -1;
            _lastSeriesId = -1;
            _lastRunId = -1;
        }

        protected virtual EventVehicleLapTimes ReadLapTimes(LiveFeedData liveFeedData)
        {
            return _lapTimeParser.ParseLapTimes(_lapTimes, liveFeedData);
        }

        #endregion

        #region private

        private async void LapTimeService_LapTimesUpdated(object sender, LapTimesUpdatedEventArgs e)
        {
            try
            {
                _lapTimeFileWriter.WriteFile(e.LapTimes);
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error writing lap times to file", ex);
            }
            try
            {
                await _dataPump.WriteLapTimesAsync(e.LapTimes);
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error pumping lap times", ex);
            }
        }

        #endregion
    }
}
