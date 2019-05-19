using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using AutoMapper;
using log4net;
using Microsoft.Extensions.Configuration;
using RacerData.Commmon.Results;
using RacerData.NascarApi.Client.Models.LapAverages;
using RacerData.NascarApi.Client.Models.LapTimes;
using RacerData.NascarApi.Client.Models.LiveFeed;
using RacerData.NascarApi.Client.Models.LiveFlag;
using RacerData.NascarApi.Client.Models.LivePit;
using RacerData.NascarApi.Client.Models.LivePoints;
using RacerData.NascarApi.Client.Models.LiveQualifying;
using RacerData.NascarApi.Client.Ports;
using RacerData.NascarApi.Factories;
using RacerData.NascarApi.Ports;
using RacerData.NascarApi.Service.Ports;
using Timer = System.Timers.Timer;

namespace RacerData.NascarApi.Service.Adapters
{
    class MonitorService : IMonitorService
    {
        #region consts

        /*
        3600000 = 1 hour
        60000 = 1 minute
        1000 = 1 second
        */
        private const int SleepPollInterval = 60000;
        private const int DefaultPollInterval = 10000; // 10 seconds

        #endregion

        #region events

        public event EventHandler<LiveFeedStartedEventArgs> LiveFeedStarted;
        protected virtual void OnLiveFeedStarted(LiveFeedInfo data)
        {
            var handler = LiveFeedStarted;
            if (handler != null)
                handler.Invoke(this, new LiveFeedStartedEventArgs() { LiveFeedInfo = data });
        }

        public event EventHandler<ServiceStateChangedEventArgs> ServiceStateChanged;
        protected virtual void OnServiceStateChanged(ServiceState state)
        {
            var handler = ServiceStateChanged;
            if (handler != null)
                handler.Invoke(this, new ServiceStateChangedEventArgs() { State = state });
        }

        public event EventHandler<ServiceActivityEventArgs> ServiceActivity;
        protected virtual void OnServiceActivity(string serviceActivity)
        {
            var handler = ServiceActivity;
            if (handler != null)
                handler.Invoke(this, new ServiceActivityEventArgs() { ServiceActivity = serviceActivity });
        }

        public event EventHandler<ServiceStatusChangedEventArgs> ServiceStatusChanged;
        protected virtual void OnServiceStatusChanged(string serviceStatus)
        {
            var handler = ServiceStatusChanged;
            if (handler != null)
                handler.Invoke(this, new ServiceStatusChangedEventArgs() { ServiceStatus = serviceStatus });
        }

        public event EventHandler<LiveFeedUpdatedEventArgs> LiveFeedUpdated;
        protected virtual void OnLiveFeedUpdated(LiveFeedData data)
        {
            var handler = LiveFeedUpdated;
            if (handler != null)
                handler.Invoke(this, new LiveFeedUpdatedEventArgs() { LiveFeedData = data });
        }

        public event EventHandler<LapAveragesUpdatedEventArgs> LapAverageUpdated;
        protected virtual void OnLapAverageUpdated(LapAverageData data)
        {
            var handler = LapAverageUpdated;
            if (handler != null)
                handler.Invoke(this, new LapAveragesUpdatedEventArgs() { Data = data });
        }

        public event EventHandler<LapTimesUpdatedEventArgs> LapTimesUpdated;
        protected virtual void OnLLapTimesUpdated(LapTimeData data)
        {
            var handler = LapTimesUpdated;
            if (handler != null)
                handler.Invoke(this, new LapTimesUpdatedEventArgs() { Data = data });
        }

        public event EventHandler<LivePitDataUpdatedEventArgs> LivePitDataUpdated;
        protected virtual void OnLivePitDataUpdated(IEnumerable<LivePitData> data)
        {
            var handler = LivePitDataUpdated;
            if (handler != null)
                handler.Invoke(this, new LivePitDataUpdatedEventArgs() { Data = data });
        }

        public event EventHandler<LiveFlagDataUpdatedEventArgs> LiveFlagDataUpdated;
        protected virtual void OnLiveFlagDataUpdated(IEnumerable<LiveFlagData> data)
        {
            var handler = LiveFlagDataUpdated;
            if (handler != null)
                handler.Invoke(this, new LiveFlagDataUpdatedEventArgs() { Data = data });
        }

        public event EventHandler<LivePointsDataUpdatedEventArgs> LivePointsDataUpdated;
        protected virtual void OnLivePointsDataUpdated(IEnumerable<LivePointsData> data)
        {
            var handler = LivePointsDataUpdated;
            if (handler != null)
                handler.Invoke(this, new LivePointsDataUpdatedEventArgs() { Data = data });
        }

        public event EventHandler<LiveQualifyingDataUpdatedEventArgs> LiveQualifyingDataUpdated;
        protected virtual void OnLiveQualifyingDataUpdated(IEnumerable<LiveQualifyingData> data)
        {
            var handler = LiveQualifyingDataUpdated;
            if (handler != null)
                handler.Invoke(this, new LiveQualifyingDataUpdatedEventArgs() { Data = data });
        }

        #endregion

        #region fields

        private readonly ILog _log;
        private readonly IMapper _mapper;
        private readonly INascarApiClient _nascarApiClient;
        private CancellationToken _cancellationToken;
        private CancellationTokenSource _cancellationTokenSource;
        private Timer _sleepTimer;
        private Timer _pollTimer;
        private readonly int _pollInterval = DefaultPollInterval;
        private readonly bool _verbose = false;
        private int? _lastElapsedTime;
        private int _lastLapTimeUpdate = -1;
        private int _lastLapAverageUpdate = -1;
        private int _lastFlagDataLap = -1;
        private double _lastPitOutElapsed = -1.0;
        private IDictionary<IMonitorClient, ApiFeedType> _masterFeedTypeList = new Dictionary<IMonitorClient, ApiFeedType>();
        private ApiFeedType _masterFeedType = new ApiFeedType();

        #endregion

        #region properties

        private ServiceState _state = ServiceState.Paused;
        public ServiceState State
        {
            get
            {
                return _state;
            }
            private set
            {
                _state = value;
                OnServiceStateChanged(_state);
            }
        }

        public DateTime? WakeTarget { get; set; }

        #endregion

        #region ctor

        public MonitorService(
            IConfiguration configuration,
            INascarApiClientFactory apiClientFactory,
            IMapper mapper,
            ILog log)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            if (apiClientFactory == null)
                throw new ArgumentNullException(nameof(apiClientFactory));

            _verbose = configuration["monitor:verbose"] == "true";

            var useMock = configuration["mock:useMock"] == "true";

            var interval = configuration["monitor:interval"];

            if (!String.IsNullOrEmpty(interval))
            {
                _pollInterval = Int32.Parse(interval);
            }

            if (useMock)
            {
                _nascarApiClient = apiClientFactory.GetMockNascarApiClient(configuration);
            }
            else
                _nascarApiClient = apiClientFactory.GetNascarApiClient();


            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _log = log ?? throw new ArgumentNullException(nameof(log));

            _pollTimer = new Timer(DefaultPollInterval);
            _pollTimer.Elapsed += _pollTimer_Elapsed;

            _sleepTimer = new Timer(SleepPollInterval);
            _sleepTimer.Elapsed += _sleepTimer_Elapsed;

            ServiceStateChanged += MonitorService_ServiceStateChanged;
        }

        #endregion

        #region public

        public void Pause()
        {
            State = ServiceState.Paused;
        }

        public void Start()
        {
            State = ServiceState.Running;
        }

        public void Start(CancellationToken cancellationToken)
        {
            _cancellationToken = cancellationToken;

            State = ServiceState.Running;
        }

        public void Sleep()
        {
            State = ServiceState.Sleep;
        }

        public void Sleep(DateTime wakeTimestamp)
        {
            WakeTarget = wakeTimestamp;
            State = ServiceState.Sleep;
        }

        public void Sleep(TimeSpan wakeTimeSpan)
        {
            WakeTarget = DateTime.Now.Add(wakeTimeSpan);
            State = ServiceState.Sleep;
        }

        public void Register(IMonitorClient client, ApiFeedType feeds)
        {

            if (feeds == ApiFeedType.All)
            {
                Register(client);
                return;
            }

            _masterFeedType |= feeds;

            _masterFeedTypeList.Add(client, feeds);

            if (feeds.HasFlag(ApiFeedType.LiveFeedData))
                LiveFeedUpdated += client.Monitor_LiveFeedUpdated;

            if (feeds.HasFlag(ApiFeedType.LapAverageData))
                LapAverageUpdated += client.Monitor_LapAveragesUpdated;

            if (feeds.HasFlag(ApiFeedType.LapTimeData))
                LapTimesUpdated += client.Monitor_LapTimesUpdated;

            if (feeds.HasFlag(ApiFeedType.LiveFlagData))
                LiveFlagDataUpdated += client.Monitor_LiveFlagDataUpdated;

            if (feeds.HasFlag(ApiFeedType.LivePitData))
                LivePitDataUpdated += client.Monitor_LivePitDataUpdated;

            if (feeds.HasFlag(ApiFeedType.LivePointsData))
                LivePointsDataUpdated += client.Monitor_LivePointsDataUpdated;

            if (feeds.HasFlag(ApiFeedType.LiveQualifyingData))
                LiveQualifyingDataUpdated += client.Monitor_LiveQualifyingDataUpdated;

            LiveFeedStarted += client.Monitor_LiveFeedStarted;
            ServiceStateChanged += client.Monitor_ServiceStateChanged;
            ServiceActivity += client.Monitor_ServiceActivity;

        }

        public void Register(IMonitorClient client)
        {
            _masterFeedType |= ApiFeedType.All;

            _masterFeedTypeList.Add(client, ApiFeedType.All);

            LiveFeedStarted += client.Monitor_LiveFeedStarted;
            ServiceStateChanged += client.Monitor_ServiceStateChanged;
            ServiceActivity += client.Monitor_ServiceActivity;

            LiveFeedUpdated += client.Monitor_LiveFeedUpdated;
            LapAverageUpdated += client.Monitor_LapAveragesUpdated;
            LapTimesUpdated += client.Monitor_LapTimesUpdated;
            LiveFlagDataUpdated += client.Monitor_LiveFlagDataUpdated;
            LivePitDataUpdated += client.Monitor_LivePitDataUpdated;
            LivePointsDataUpdated += client.Monitor_LivePointsDataUpdated;
            LiveQualifyingDataUpdated += client.Monitor_LiveQualifyingDataUpdated;
        }

        public void Unregister(IMonitorClient client)
        {
            _masterFeedTypeList.Remove(client);

            LiveFeedStarted -= client.Monitor_LiveFeedStarted;
            ServiceStateChanged -= client.Monitor_ServiceStateChanged;
            ServiceActivity -= client.Monitor_ServiceActivity;

            LiveFeedUpdated -= client.Monitor_LiveFeedUpdated;
            LapAverageUpdated -= client.Monitor_LapAveragesUpdated;
            LapTimesUpdated -= client.Monitor_LapTimesUpdated;
            LiveFlagDataUpdated -= client.Monitor_LiveFlagDataUpdated;
            LivePitDataUpdated -= client.Monitor_LivePitDataUpdated;
            LivePointsDataUpdated -= client.Monitor_LivePointsDataUpdated;
            LiveQualifyingDataUpdated -= client.Monitor_LiveQualifyingDataUpdated;

            _masterFeedType = ApiFeedType.None;
            foreach (ApiFeedType feedType in _masterFeedTypeList.Values)
            {
                _masterFeedType |= feedType;
            }
        }

        #endregion

        #region protected

        protected virtual void ExceptionHandler(string message, Exception ex)
        {
            _log?.Error(message, ex);
#if DEBUG
            Console.WriteLine(ex);
#endif
            State = ServiceState.Error;
        }

        protected virtual CancellationToken GetCancellationToken()
        {
            if (_cancellationToken != null)
                return _cancellationToken;

            _cancellationTokenSource = new CancellationTokenSource();
            return _cancellationTokenSource.Token;
        }

        protected virtual void StartSleepTimer()
        {
            if (WakeTarget == null)
                throw new InvalidOperationException("Cannot enter sleep mode, no wake target set");

            StopPollTimer();

            _sleepTimer.Start();
        }

        protected virtual void StopSleepTimer()
        {
            WakeTarget = null;

            _sleepTimer.Stop();
        }

        protected virtual void StartPollTimer(int interval)
        {
            if (_pollTimer.Enabled)
            {
                StopPollTimer();
            }

            _pollTimer.Interval = interval;
            _pollTimer.Start();
        }

        protected virtual void StopPollTimer()
        {
            _pollTimer.Stop();
        }

        protected virtual async Task ReadLiveFeedDataAsync()
        {
            var cancellationToken = GetCancellationToken();

            await ReadLiveFeedDataAsync(cancellationToken);
        }
        protected virtual async Task ReadLiveFeedDataAsync(CancellationToken cancellationToken)
        {
            try
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    State = ServiceState.Canceled;
                    return;
                }

                if (_verbose)
                    OnServiceActivity("Requesting live feed data");

                var newFeedDataResult = await _nascarApiClient.GetLiveFeedDataAsync(cancellationToken);

                if (!newFeedDataResult.IsSuccessful())
                {
                    throw newFeedDataResult.Exception;
                }

                var newFeedData = newFeedDataResult.Value;

                if (!_verbose && _lastElapsedTime != null && _lastElapsedTime == newFeedData.Elapsed)
                {
                    if (_verbose)
                        OnServiceActivity($"No change in live feed data elapsed time: {newFeedData.Elapsed}");

                    return;
                }
                else
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        State = ServiceState.Canceled;
                        return;
                    }

                    _lastElapsedTime = newFeedData.Elapsed;

                    var mappedFeedData = _mapper.Map<LiveFeedData>(newFeedData);

                    OnLiveFeedUpdated(mappedFeedData);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error reading live feed data", ex);
            }
        }

        protected virtual async Task ReadLiveFlagDataAsync()
        {
            var cancellationToken = GetCancellationToken();

            await ReadLiveFlagDataAsync(cancellationToken);
        }
        protected virtual async Task ReadLiveFlagDataAsync(CancellationToken cancellationToken)
        {
            try
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    State = ServiceState.Canceled;
                    return;
                }

                if (_verbose)
                    OnServiceActivity("Requesting live flag data");

                var newFeedDataResult = await _nascarApiClient.GetLiveFlagDataAsync(cancellationToken);

                if (!newFeedDataResult.IsSuccessful())
                {
                    throw newFeedDataResult.Exception;
                }

                var newFeedData = newFeedDataResult.Value;

                var lastLapBuffer = newFeedData.Max(f => f.LapNumber);

                if (_lastFlagDataLap == lastLapBuffer)
                {
                    if (_verbose)
                        OnServiceActivity($"LiveFlagData - No change in updated lap: {lastLapBuffer}");

                    return;
                }
                else
                {
                    _lastFlagDataLap = lastLapBuffer;

                    if (cancellationToken.IsCancellationRequested)
                    {
                        State = ServiceState.Canceled;
                        return;
                    }

                    OnLiveFlagDataUpdated(newFeedData);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error reading live flag data", ex);
            }
        }

        protected virtual async Task ReadLivePitDataAsync()
        {
            var cancellationToken = GetCancellationToken();

            await ReadLivePitDataAsync(cancellationToken);
        }
        protected virtual async Task ReadLivePitDataAsync(CancellationToken cancellationToken)
        {
            try
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    State = ServiceState.Canceled;
                    return;
                }

                if (_verbose)
                    OnServiceActivity("Requesting live pit data");

                var newFeedDataResult = await _nascarApiClient.GetLivePitDataAsync(cancellationToken);

                if (!newFeedDataResult.IsSuccessful())
                {
                    throw newFeedDataResult.Exception;
                }

                var newFeedData = newFeedDataResult.Value;

                var lastUpdateBuffer = newFeedData.Max(l => l.PitOutRaceTime);

                if (_lastPitOutElapsed == lastUpdateBuffer)
                {
                    if (_verbose)
                        OnServiceActivity($"Live Pit Data - No change in last update elapsed: {_lastPitOutElapsed}");

                    return;
                }
                else
                {
                    _lastPitOutElapsed = lastUpdateBuffer;

                    if (cancellationToken.IsCancellationRequested)
                    {
                        State = ServiceState.Canceled;
                        return;
                    }

                    OnLivePitDataUpdated(newFeedData);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error reading live pit data", ex);
            }
        }

        protected virtual async Task ReadLivePointsDataAsync()
        {
            var cancellationToken = GetCancellationToken();

            await ReadLivePointsDataAsync(cancellationToken);
        }
        protected virtual async Task ReadLivePointsDataAsync(CancellationToken cancellationToken)
        {
            try
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    State = ServiceState.Canceled;
                    return;
                }

                if (_verbose)
                    OnServiceActivity("Requesting live points data");

                var newFeedDataResult = await _nascarApiClient.GetLivePointsDataAsync(cancellationToken);

                if (!newFeedDataResult.IsSuccessful())
                {
                    throw newFeedDataResult.Exception;
                }

                var newFeedData = newFeedDataResult.Value;

                if (cancellationToken.IsCancellationRequested)
                {
                    State = ServiceState.Canceled;
                    return;
                }

                OnLivePointsDataUpdated(newFeedData);

            }
            catch (Exception ex)
            {
                ExceptionHandler("Error reading live points data", ex);
            }
            finally
            {
                if (!cancellationToken.IsCancellationRequested)
                    _pollTimer.Start();
            }
        }

        protected virtual async Task ReadLiveQualifyingDataAsync()
        {
            var cancellationToken = GetCancellationToken();

            await ReadLiveQualifyingDataAsync(cancellationToken);
        }
        protected virtual async Task ReadLiveQualifyingDataAsync(CancellationToken cancellationToken)
        {
            try
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    State = ServiceState.Canceled;
                    return;
                }

                if (_verbose)
                    OnServiceActivity("Requesting live qualifying data");

                var newFeedDataResult = await _nascarApiClient.GetLiveQualifyingDataAsync(cancellationToken);

                if (!newFeedDataResult.IsSuccessful())
                {
                    throw newFeedDataResult.Exception;
                }

                var newFeedData = newFeedDataResult.Value;

                if (cancellationToken.IsCancellationRequested)
                {
                    State = ServiceState.Canceled;
                    return;
                }

                OnLiveQualifyingDataUpdated(newFeedData);

            }
            catch (Exception ex)
            {
                ExceptionHandler("Error reading live qualifying data", ex);
            }
        }

        protected virtual async Task ReadLapAverageDataAsync()
        {
            var cancellationToken = GetCancellationToken();

            await ReadLapAverageDataAsync(cancellationToken);
        }
        protected virtual async Task ReadLapAverageDataAsync(CancellationToken cancellationToken)
        {
            try
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    State = ServiceState.Canceled;
                    return;
                }

                if (_verbose)
                    OnServiceActivity("Requesting lap average data");

                var newFeedDataResult = await _nascarApiClient.GetLapAverageDataAsync(cancellationToken);

                if (!newFeedDataResult.IsSuccessful())
                {
                    throw newFeedDataResult.Exception;
                }

                var newFeedData = newFeedDataResult.Value;

                if (_lastLapAverageUpdate == newFeedData.Elapsed)
                {
                    if (_verbose)
                        OnServiceActivity($"Lap Average Data - No change in elapsed time: {newFeedData.Elapsed}");

                    return;
                }
                else
                {
                    _lastLapAverageUpdate = newFeedData.Elapsed;

                    if (cancellationToken.IsCancellationRequested)
                    {
                        State = ServiceState.Canceled;
                        return;
                    }

                    OnLapAverageUpdated(newFeedData);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error reading lap average data", ex);
            }
        }

        protected virtual async Task ReadLapTimeDataAsync()
        {
            var cancellationToken = GetCancellationToken();

            await ReadLapTimeDataAsync(cancellationToken);
        }
        protected virtual async Task ReadLapTimeDataAsync(CancellationToken cancellationToken)
        {
            try
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    State = ServiceState.Canceled;
                    return;
                }

                if (_verbose)
                    OnServiceActivity("Requesting lap time data");

                var newFeedDataResult = await _nascarApiClient.GetLapTimeDataAsync(cancellationToken);

                if (!newFeedDataResult.IsSuccessful())
                {
                    throw newFeedDataResult.Exception;
                }

                var newFeedData = newFeedDataResult.Value;

                if (_lastLapTimeUpdate == newFeedData.Elapsed)
                {
                    if (_verbose)
                        OnServiceActivity($"Lap Time Data - No change in elapsed time: {newFeedData.Elapsed}");

                    return;
                }
                else
                {
                    _lastLapTimeUpdate = newFeedData.Elapsed;

                    if (cancellationToken.IsCancellationRequested)
                    {
                        State = ServiceState.Canceled;
                        return;
                    }

                    OnLLapTimesUpdated(newFeedData);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error reading lap time data", ex);
            }
        }

        #endregion

        #region private

        private async void _pollTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                if (State != ServiceState.Running)
                    return;

                if (_masterFeedType.HasFlag(ApiFeedType.LiveFeedData))
                    await ReadLiveFeedDataAsync();

                if (_masterFeedType.HasFlag(ApiFeedType.LiveFlagData))
                    await ReadLiveFlagDataAsync();

                if (_masterFeedType.HasFlag(ApiFeedType.LivePointsData))
                    await ReadLivePointsDataAsync();

                if (_masterFeedType.HasFlag(ApiFeedType.LivePitData))
                    await ReadLivePitDataAsync();

                if (_masterFeedType.HasFlag(ApiFeedType.LiveQualifyingData))
                    await ReadLiveQualifyingDataAsync();

                if (_masterFeedType.HasFlag(ApiFeedType.LapAverageData))
                    await ReadLapAverageDataAsync();

                if (_masterFeedType.HasFlag(ApiFeedType.LapTimeData))
                    await ReadLapTimeDataAsync();
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error in timer elapsed process", ex);
            }
        }

        private void _sleepTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (WakeTarget == null)
            {
                StopSleepTimer();
                State = ServiceState.Error;
                OnServiceActivity("Error - No wake target!");
                return;
            }

            if (DateTime.Now >= WakeTarget.Value)
            {
                StopSleepTimer();
                OnServiceActivity("Monitor service awake!");
                StartPollTimer(_pollInterval);
            }
        }

        private void MonitorService_ServiceStateChanged(object sender, ServiceStateChangedEventArgs e)
        {
            if (e.State == ServiceState.Sleep)
            {
                if (WakeTarget == null)
                    WakeTarget = DateTime.Now.AddMinutes(1);

                StopPollTimer();
                StartSleepTimer();
                OnServiceStatusChanged($"Service sleeping until {WakeTarget}");
            }
            if (e.State == ServiceState.Running)
            {
                StopSleepTimer();
                StartPollTimer(_pollInterval);
                OnServiceStatusChanged("Service started");
            }
            if (e.State == ServiceState.Paused)
            {
                StopPollTimer();
                StopSleepTimer();
                OnServiceStatusChanged("Service Stopped");
            }
            if (e.State == ServiceState.Error)
            {
                StopSleepTimer();
                StopPollTimer();
                OnServiceStatusChanged("Service Error! Polling suspended");
            }
            if (e.State == ServiceState.Canceled)
            {
                StopSleepTimer();
                StopPollTimer();
                OnServiceStatusChanged("Service Operation Cancelled");
            }
        }

        #endregion
    }
}
