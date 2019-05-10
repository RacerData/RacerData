using System;
using System.Text;
using log4net;
using Microsoft.Extensions.Configuration;
using RacerData.Data.Aws.Ports;
using RacerData.NascarApi.Client.Models;
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
        protected virtual void OnLapTimesUpdated(LapTimeData lapTimes)
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
        private LapTimeData _lapTimes;
        private int _lastElapsed = -1;
        private int _lastRaceId = -1;
        private SeriesType _lastSeriesId;
        private int _lastRunId = -1;
        private bool _verbose = false;

        #endregion

        #region ctor

        public LapTimeService(
            IConfiguration configuration,
            IAwsRepositoryFactory awsRepositoryFactory,
            ILapTimeParser lapTimeParser,
            ILapTimeDataFileWriter lapTimeFileWriter,
            ILog log)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            if (awsRepositoryFactory == null)
                throw new ArgumentNullException(nameof(awsRepositoryFactory));

            _verbose = configuration["monitor:verbose"] == "true";

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
                if (_verbose)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append($"Elapsed:{liveFeedData.Elapsed} ");
                    sb.Append($"SeriesId:{liveFeedData.SeriesType} ");
                    sb.Append($"RaceId:{liveFeedData.RaceId} ");
                    sb.AppendLine($"RunId:{liveFeedData.RunId}");
                    sb.Append($"LapNumber:{liveFeedData.LapNumber} ");
                    sb.AppendLine($"FlagState:{liveFeedData.FlagState.ToString()}");

                    Console.WriteLine("------------------");
                    Console.WriteLine(sb);
                }

                if (liveFeedData.RaceId != _lastRaceId ||
                    liveFeedData.SeriesType != _lastSeriesId ||
                    liveFeedData.RunId != _lastRunId)
                {
                    if (_verbose)
                    {
                        Console.WriteLine("Resetting lap times");
                    }

                    ResetLapTimes();

                    _lapTimes.RaceId = liveFeedData.RaceId;
                    _lapTimes.SeriesId = (int)liveFeedData.SeriesType;
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
                    _lastSeriesId = liveFeedData.SeriesType;
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
            _lapTimes = new LapTimeData();
            _lastElapsed = -1;
            _lastRaceId = -1;
            _lastRunId = -1;
        }

        protected virtual LapTimeData ReadLapTimes(LiveFeedData liveFeedData)
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
