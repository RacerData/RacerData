using System;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using AutoMapper;
using log4net;
using RacerData.NascarApi.Client.Models;
using RacerData.NascarApi.Client.Models.LiveFeed;
using RacerData.NascarApi.Models;
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

        public event EventHandler<ServiceStatusChangedEventArgs> ServiceStatusChanged;
        protected virtual void OnServiceStatusChanged(string serviceStatus)
        {
            var handler = ServiceStatusChanged;
            if (handler != null)
                handler.Invoke(this, new ServiceStatusChangedEventArgs() { ServiceStatus = serviceStatus });
        }

        #endregion

        #region fields

        private ILog _log;
        private IMapper _mapper;
        private IApiClient _apiClient;
        private CancellationToken _cancellationToken;
        private CancellationTokenSource _cancellationTokenSource;
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

                OnServiceActivity("Requesting live event feed");

                var newFeedData = await _apiClient.GetLiveFeedAsync(cancellationToken);

                if (_lastElapsedTime != null && _lastElapsedTime == newFeedData.elapsed_time)
                {
                    return;
                }
                else
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        State = ServiceState.Canceled;
                        return;
                    }

                    _pollTimer.Stop();

                    _lastElapsedTime = newFeedData.elapsed_time;

                    var mappedFeedData = _mapper.Map<LiveFeedData>(newFeedData);

                    if (!cancellationToken.IsCancellationRequested)
                        OnLiveFeedUpdated(mappedFeedData);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error reading feed", ex);
            }
            finally
            {
                if (!cancellationToken.IsCancellationRequested)
                    _pollTimer.Start();
            }
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
