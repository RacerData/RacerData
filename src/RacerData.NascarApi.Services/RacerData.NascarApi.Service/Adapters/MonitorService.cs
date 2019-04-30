using System;
using System.Threading.Tasks;
using System.Timers;
using AutoMapper;
using log4net;
using RacerData.NascarApi.Client.Models;
using RacerData.NascarApi.Client.Models.LiveFeed;
using RacerData.NascarApi.Models;
using RacerData.NascarApi.Ports;
using RacerData.NascarApi.Service.Ports;

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
        protected virtual void OnLiveFeedStarted(LiveFeedInfo liveFeedInfo)
        {
            var handler = LiveFeedStarted;
            if (handler != null)
                handler.Invoke(this, new LiveFeedStartedEventArgs() { LiveFeedInfo = liveFeedInfo });
        }

        public event EventHandler<LiveFeedUpdatedEventArgs> LiveFeedUpdated;
        protected virtual void OnLiveFeedUpdated(LiveFeedData liveFeedData)
        {
            var handler = LiveFeedUpdated;
            if (handler != null)
                handler.Invoke(this, new LiveFeedUpdatedEventArgs() { LiveFeedData = liveFeedData });
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

        #endregion

        #region fields

        private ILog _log;
        private IMapper _mapper;
        private IApiClient _apiClient;
        private EventSettings _eventSettings;
        private Timer _sleepTimer;
        private Timer _pollTimer;
        private int _pollInterval = DefaultPollInterval;
        private int? _lastElapsedTime;

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
            IApiClient apiClient,
            IMapper mapper,
            ILog log)
        {
            _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
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

        public void Register(IMonitorClient client)
        {
            LiveFeedStarted += client.Monitor_LiveFeedStarted;
            LiveFeedUpdated += client.Monitor_LiveFeedUpdated;
            ServiceStateChanged += client.Monitor_ServiceStateChanged;
            ServiceActivity += client.Monitor_ServiceActivity;
        }

        public void Unregister(IMonitorClient client)
        {
            LiveFeedStarted -= client.Monitor_LiveFeedStarted;
            LiveFeedUpdated -= client.Monitor_LiveFeedUpdated;
            ServiceStateChanged -= client.Monitor_ServiceStateChanged;
            ServiceActivity -= client.Monitor_ServiceActivity;
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
            try
            {
                OnServiceActivity("Requesting live event feed");

                var newFeedData = await _apiClient.GetLiveFeedAsync();

                if (_lastElapsedTime != null && _lastElapsedTime == newFeedData.elapsed_time)
                {
                    OnServiceActivity("Live feed not updated");
                    return;
                }
                else
                {
                    _pollTimer.Stop();

                    OnServiceActivity("Live feed updated");

                    _lastElapsedTime = newFeedData.elapsed_time;

                    var mappedFeedData = _mapper.Map<LiveFeedData>(newFeedData);

                    OnLiveFeedUpdated(mappedFeedData);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error reading feed", ex);
            }
            finally
            {
                _pollTimer.Start();
            }
        }

        protected virtual async Task NewEventSettings(EventSettings eventSettings)
        {
            _eventSettings = eventSettings;

            var liveFeedInfo = new LiveFeedInfo()
            {
                RaceId = eventSettings.race_id,
                RunName = eventSettings.run_name,
                RunId = eventSettings.run_id,
                RunType = (RunType)eventSettings.run_type,
                Season = eventSettings.season,
                Series = (SeriesType)eventSettings.series_id,
                TrackId = eventSettings.track_id,
                TrackLength = eventSettings.track_length,
            };

            OnServiceActivity($"Live event found: {liveFeedInfo.RaceId}");

            OnLiveFeedStarted(liveFeedInfo);

            await ReadLiveFeedDataAsync();
        }

        #endregion

        #region private

        private async void _pollTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                await ReadLiveFeedDataAsync();
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

                OnServiceActivity($"Service sleeping until {WakeTarget}");
            }
            if (e.State == ServiceState.Running)
            {
                StopSleepTimer();
                StartPollTimer(_pollInterval);
                OnServiceActivity("Service started");
            }
            if (e.State == ServiceState.Paused)
            {
                StopPollTimer();
                StopSleepTimer();
                OnServiceActivity("Service Stopped");
            }
            if (e.State == ServiceState.Error)
            {
                StopSleepTimer();
                StopPollTimer();
                OnServiceActivity("Service Error! Polling suspended");
            }
        }

        #endregion
    }
}
