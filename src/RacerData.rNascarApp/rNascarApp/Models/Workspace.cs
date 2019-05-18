using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using RacerData.rNascarApp.Services;

namespace RacerData.rNascarApp.Models
{
    public class Workspace : IEquatable<Workspace>, INotifyPropertyChanged
    {
        #region events

        /// <summary>
        /// Property on this Workspace changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// ViewState Id list is changed
        /// </summary>
        public event EventHandler<ViewStateIdsChangedEventArgs> ViewStateIdsChanged;
        protected virtual void OnViewStateIdsChanged(IList<Guid> viewStates)
        {
            var handler = ViewStateIdsChanged;
            handler?.Invoke(this, new ViewStateIdsChangedEventArgs() { ViewStateIds = viewStates });
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

        #region consts

        public const string DefaultWorkspaceName = "Default";

        #endregion

        #region properties

        private string _name = "<WORKSPACE NAME>";
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private bool _isActive = false;
        public bool IsActive
        {
            get
            {
                return _isActive;
            }
            set
            {
                _isActive = value;
                OnPropertyChanged(nameof(IsActive));
            }
        }

        private int _rows = 8;
        public int GridRowCount
        {
            get
            {
                return _rows;
            }
            set
            {
                _rows = value;
                OnPropertyChanged(nameof(GridRowCount));
            }
        }
        private int _columns = 8;
        public int GridColumnCount
        {
            get
            {
                return _columns;
            }
            set
            {
                _columns = value;
                OnPropertyChanged(nameof(GridColumnCount));
            }
        }

        private bool _isDefaultPracticeWorkspace;
        public bool IsDefaultPracticeWorkspace
        {
            get
            {
                return _isDefaultPracticeWorkspace;
            }
            set
            {
                _isDefaultPracticeWorkspace = value;
                OnPropertyChanged(nameof(IsDefaultPracticeWorkspace));
            }
        }

        private bool _isDefaultQualifyingWorkspace;
        public bool IsDefaultQualifyingWorkspace
        {
            get
            {
                return _isDefaultQualifyingWorkspace;
            }
            set
            {
                _isDefaultQualifyingWorkspace = value;
                OnPropertyChanged(nameof(IsDefaultQualifyingWorkspace));
            }
        }

        private bool _isDefaultRaceWorkspace;
        public bool IsDefaultRaceWorkspace
        {
            get
            {
                return _isDefaultRaceWorkspace;
            }
            set
            {
                _isDefaultRaceWorkspace = value;
                OnPropertyChanged(nameof(IsDefaultRaceWorkspace));
            }
        }

        private BindingList<Guid> _viewStates;
        public BindingList<Guid> ViewStates
        {
            get
            {
                if (_viewStates == null)
                {
                    _viewStates = new BindingList<Guid>();
                    _viewStates.ListChanged += OnViewStatesListItemChanged;
                }

                return _viewStates;
            }
            protected set
            {
                if (_viewStates != null)
                {
                    _viewStates.ListChanged -= OnViewStatesListItemChanged;
                }
                _viewStates = new BindingList<Guid>(value);
                _viewStates.ListChanged += OnViewStatesListItemChanged;

                OnViewStateIdsChanged(_viewStates.ToList());
            }
        }

        #endregion

        #region ctor

        public Workspace()
        {
            ViewStates = new BindingList<Guid>();
        }

        #endregion

        #region public

        public Workspace Copy(string newName)
        {
            return new Workspace()
            {
                Name = newName,
                ViewStates = new BindingList<Guid>(ViewStates),
                GridColumnCount = GridColumnCount,
                GridRowCount = GridRowCount
            };
        }

        #region IEquatable

        public override bool Equals(object obj)
        {
            return Equals(obj as Workspace);
        }

        public bool Equals(Workspace other)
        {
            var isEqual = other != null &&
                   Name == other.Name &&
                   GridColumnCount == other.GridColumnCount &&
                   GridRowCount == other.GridRowCount &&
                   ViewStates.Count() == other.ViewStates.Count();

            if (isEqual)
            {
                var firstNotSecond = ViewStates.Except(other.ViewStates).ToList();
                var secondNotFirst = other.ViewStates.Except(ViewStates).ToList();

                isEqual = !firstNotSecond.Any() && !secondNotFirst.Any(); ;
            }

            return isEqual;
        }

        public override int GetHashCode()
        {
            var hashCode = 389143722;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<int>.Default.GetHashCode(GridColumnCount);
            hashCode = hashCode * -1521134295 + EqualityComparer<int>.Default.GetHashCode(GridRowCount);
            hashCode = hashCode * -1521134295 + ViewStates.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(Workspace state1, Workspace state2)
        {
            return EqualityComparer<Workspace>.Default.Equals(state1, state2);
        }

        public static bool operator !=(Workspace state1, Workspace state2)
        {
            return !(state1 == state2);
        }

        #endregion
        #endregion
    }
}
