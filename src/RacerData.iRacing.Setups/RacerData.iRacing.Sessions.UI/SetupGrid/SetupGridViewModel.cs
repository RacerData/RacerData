using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace RacerData.iRacing.Sessions.Ui.ViewModels
{
    public class SetupGridViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string ChassisName
        {
            get
            {
                if (_setupValues.Any(s => s.SectionName.Contains("Suspension")))
                {
                    return "Suspension";
                }
                else
                {
                    return "Chassis";
                }
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

        private string _previousSetupName;
        public string PreviousSetupName
        {
            get
            {
                return _previousSetupName;
            }
            set
            {
                _previousSetupName = value;
                OnPropertyChanged(nameof(PreviousSetupName));
            }
        }

        private IList<SetupSectionViewModel> _setupValues = new List<SetupSectionViewModel>();
        public IList<SetupSectionViewModel> SetupSections
        {
            get
            {
                return _setupValues;
            }
            set
            {
                _setupValues = value;
                OnPropertyChanged(nameof(SetupSections));
            }
        }

        #region classes

        public class SetupSectionViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            private int _displayIndex;
            public int DisplayIndex
            {
                get
                {
                    return _displayIndex;
                }
                set
                {
                    _displayIndex = value;
                    OnPropertyChanged(nameof(DisplayIndex));
                }
            }

            public string SectionKey
            {
                get
                {
                    return _sectionName.Replace("Suspension", "Chassis");
                }
            }

            private string _sectionName;
            public string SectionName
            {
                get
                {
                    return _sectionName;
                }
                set
                {
                    _sectionName = value;
                    OnPropertyChanged(nameof(SectionName));
                }
            }

            private IList<SetupValueViewModel> _setupValues = new List<SetupValueViewModel>();
            public IList<SetupValueViewModel> SetupValues
            {
                get
                {
                    return _setupValues;
                }
                set
                {
                    _setupValues = value;
                    OnPropertyChanged(nameof(SetupValues));
                }
            }
        }

        public class SetupValueViewModel
        {
            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            private int _displayIndex;
            public int DisplayIndex
            {
                get
                {
                    return _displayIndex;
                }
                set
                {
                    _displayIndex = value;
                    OnPropertyChanged(nameof(DisplayIndex));
                }
            }

            private string _property;
            public string Property
            {
                get
                {
                    return _property;
                }
                set
                {
                    _property = value;
                    OnPropertyChanged(nameof(Property));
                }
            }

            private string _value;
            public string Value
            {
                get
                {
                    return _value;
                }
                set
                {
                    _value = value;
                    OnPropertyChanged(nameof(Value));
                }
            }

            private string _previousValue;
            public string PreviousValue
            {
                get
                {
                    return _previousValue;
                }
                set
                {
                    _previousValue = value;
                    OnPropertyChanged(nameof(PreviousValue));
                }
            }

            private string _delta;
            public string Delta
            {
                get
                {
                    return _delta;
                }
                set
                {
                    _delta = value;
                    OnPropertyChanged(nameof(Delta));
                }
            }
        }

        #endregion
    }
}
