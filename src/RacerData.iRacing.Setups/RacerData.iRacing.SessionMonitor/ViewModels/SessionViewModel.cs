using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;

namespace RacerData.iRacing.SessionMonitor.ViewModels
{
    public class SessionViewModel : ViewModel
    {
        #region properties

        private bool _connected;
        public bool Connected
        {
            get
            {
                return _connected;
            }
            set
            {
                _connected = value;
                OnPropertyChanged(nameof(Connected));
            }
        }

        private string _track;
        public string Track
        {
            get
            {
                return _track;
            }
            set
            {
                _track = value;
                OnPropertyChanged(nameof(Track));
            }
        }

        private string _vehicle;
        public string Vehicle
        {
            get
            {
                return _vehicle;
            }
            set
            {
                _vehicle = value;
                OnPropertyChanged(nameof(Vehicle));
            }
        }

        private string _eventType;
        public string EventType
        {
            get
            {
                return _eventType;
            }
            set
            {
                _eventType = value;
                OnPropertyChanged(nameof(EventType));
            }
        }

        private string _sessionType;
        public string SessionType
        {
            get
            {
                return _sessionType;
            }
            set
            {
                _sessionType = value;
                OnPropertyChanged(nameof(SessionType));
            }
        }

        private string _setupName;
        public string SetupName
        {
            get
            {
                return _setupName;
            }
            set
            {
                _setupName = value;
                OnPropertyChanged(nameof(SetupName));
            }
        }

        private ActivityStatus _activityStatus;
        public ActivityStatus ActivityStatus
        {
            get
            {
                return _activityStatus;
            }
            set
            {
                _activityStatus = value;
                OnPropertyChanged(nameof(ActivityStatus));
            }
        }

        private List<SessionRunViewModel> _sessionRunsBackingList;
        private BindingList<SessionRunViewModel> _sessionRuns;
        public BindingList<SessionRunViewModel> SessionRuns
        {
            get
            {
                if (_sessionRuns == null)
                {
                    _sessionRunsBackingList = new List<SessionRunViewModel>();
                    _sessionRuns = new BindingList<SessionRunViewModel>(_sessionRunsBackingList);
                }

                _sessionRunsBackingList.Sort((SessionRunViewModel X, SessionRunViewModel Y) => X.StartTime.CompareTo(Y.StartTime));
                // tell the bindinglist to raise a list change event so that 
                // bound controls reflect the new item order
                _sessionRuns.ResetBindings();

                return _sessionRuns;
            }
            set
            {
                _sessionRuns = value;
                OnPropertyChanged(nameof(SessionRuns));
            }
        }

        private List<SessionRunViewModel> _selectedSessionRunsBackingList;
        private BindingList<SessionRunViewModel> _selectedSessionRuns;
        public BindingList<SessionRunViewModel> SelectedSessionRuns
        {
            get
            {
                if (_selectedSessionRuns == null)
                {
                    _selectedSessionRunsBackingList = new List<SessionRunViewModel>();
                    _selectedSessionRuns = new BindingList<SessionRunViewModel>(_selectedSessionRunsBackingList);
                }

                _selectedSessionRunsBackingList.Sort((SessionRunViewModel X, SessionRunViewModel Y) => X.Id.CompareTo(Y.Id));
                // tell the bindinglist to raise a list change event so that 
                // bound controls reflect the new item order
                _selectedSessionRuns.ResetBindings();

                return _selectedSessionRuns;
            }
            internal set
            {
                _selectedSessionRuns = value;
                OnPropertyChanged(nameof(SelectedSessionRuns));
            }
        }



        #endregion

        #region ctor

        public SessionViewModel()
            : base()
        {

        }

        #endregion
    }
}
