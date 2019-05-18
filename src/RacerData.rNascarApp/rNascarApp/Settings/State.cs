using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using log4net.Core;
using RacerData.rNascarApp.Models;
using RacerData.rNascarApp.Services;

namespace RacerData.rNascarApp.Settings
{
    public class State : INotifyPropertyChanged, IState
    {
        #region events

        /// <summary>
        /// Property changed on this State instance
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// ViewStates list is changed
        /// </summary>
        public event EventHandler<ViewStatesChangedEventArgs> ViewStatesChanged;
        protected virtual void OnViewStatesChanged(IList<ViewState> viewStates)
        {
            var handler = ViewStatesChanged;
            handler?.Invoke(this, new ViewStatesChangedEventArgs() { ViewStates = viewStates });
        }

        /// <summary>
        /// Item in the ViewStates binding list changed
        /// </summary>
        public event EventHandler<ListChangedEventArgs> ViewStatesListItemChanged;
        private void OnViewStatesListItemChanged(object sender, ListChangedEventArgs e)
        {
            var handler = ViewStatesListItemChanged;
            handler?.Invoke(this, e);
        }

        #endregion

        #region properties

        // App Settings

        private Size _size = new Size(600, 400);
        public Size Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
                OnPropertyChanged(nameof(Size));
            }
        }

        private Point _location = new Point(10, 10);
        public Point Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
                OnPropertyChanged(nameof(Location));
            }
        }

        private FormWindowState _windowState;
        public FormWindowState WindowState
        {
            get
            {
                return _windowState;
            }
            set
            {
                _windowState = value;
                OnPropertyChanged(nameof(WindowState));
            }
        }

        private FormStartPosition _startPosition;
        public FormStartPosition StartPosition
        {
            get
            {
                return _startPosition;
            }
            set
            {
                _startPosition = value;
                OnPropertyChanged(nameof(StartPosition));
            }
        }

        private bool _showToolBar = true;
        public bool ShowToolBar
        {
            get
            {
                return _showToolBar;
            }
            set
            {
                _showToolBar = value;
                OnPropertyChanged(nameof(ShowToolBar));
            }
        }

        private bool _showStatusBar = true;
        public bool ShowStatusBar
        {
            get
            {
                return _showStatusBar;
            }
            set
            {
                _showStatusBar = value;
                OnPropertyChanged(nameof(ShowStatusBar));
            }
        }

        private Level _logLevel;
        public Level LogLevel
        {
            get
            {
                return _logLevel;
            }
            set
            {
                _logLevel = value;
                OnPropertyChanged(nameof(LogLevel));
            }
        }

        // User settings

        private BindingList<ViewState> _viewStates;
        public BindingList<ViewState> ViewStates
        {
            get
            {
                if (_viewStates == null)
                {
                    _viewStates = new BindingList<ViewState>();
                    _viewStates.ListChanged += OnViewStatesListItemChanged;
                }

                return _viewStates;
            }
            set
            {
                if (_viewStates != null)
                {
                    _viewStates.ListChanged -= OnViewStatesListItemChanged;
                }
                _viewStates = new BindingList<ViewState>(value);
                _viewStates.ListChanged += OnViewStatesListItemChanged;

                OnViewStatesChanged(_viewStates.ToList());
            }
        }
        
        private int[] _customColors;
        public int[] CustomColors
        {
            get
            {
                return _customColors;
            }
            set
            {
                _customColors = value;
                OnPropertyChanged(nameof(CustomColors));
            }
        }

        private double _battleGap = 2;
        public double BattleGap
        {
            get
            {
                return _battleGap;
            }
            set
            {
                _battleGap = value;
                OnPropertyChanged(nameof(BattleGap));
            }
        }

        private int _pitWindowWarning = 10;
        public int PitWindowWarning
        {
            get
            {
                return _pitWindowWarning;
            }
            set
            {
                _pitWindowWarning = value;
                OnPropertyChanged(nameof(PitWindowWarning));
            }
        }

        private int _pollInterval = 5000;
        public int PollInterval
        {
            get
            {
                return _pollInterval;
            }
            set
            {
                _pollInterval = value;
                OnPropertyChanged(nameof(PollInterval));
            }
        }

        private IList<string> _favoriteDrivers = new List<string>();
        public IList<string> FavoriteDrivers
        {
            get
            {
                return _favoriteDrivers;
            }
            set
            {
                _favoriteDrivers = value;
                OnPropertyChanged(nameof(FavoriteDrivers));
            }
        }

        // Behavior

        private bool _checkLiveEventOnStartup = false;
        public bool CheckForLiveEventOnStartup
        {
            get
            {
                return _checkLiveEventOnStartup;
            }
            set
            {
                _checkLiveEventOnStartup = value;
                OnPropertyChanged(nameof(CheckForLiveEventOnStartup));
            }
        }

        private bool _checkUpdatesOnStartup = false;
        public bool CheckForUpdatesOnStartup
        {
            get
            {
                return _checkUpdatesOnStartup;
            }
            set
            {
                _checkUpdatesOnStartup = value;
                OnPropertyChanged(nameof(CheckForUpdatesOnStartup));
            }
        }

        private bool _autoStartApiMonitor = false;
        public bool AutoStartApiMonitor
        {
            get
            {
                return _autoStartApiMonitor;
            }
            set
            {
                _autoStartApiMonitor = value;
                OnPropertyChanged(nameof(AutoStartApiMonitor));
            }
        }

        private bool _autoSaveOnExit = false;
        public bool AutoSaveOnExit
        {
            get
            {
                return _autoSaveOnExit;
            }
            set
            {
                _autoSaveOnExit = value;
                OnPropertyChanged(nameof(AutoSaveOnExit));
            }
        }

        #endregion      
    }
}
