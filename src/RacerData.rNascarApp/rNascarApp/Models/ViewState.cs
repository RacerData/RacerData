using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace RacerData.rNascarApp.Models
{
    public class ViewState : IEquatable<ViewState>, INotifyPropertyChanged
    {
        #region events

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region properties

        private Guid _id;
        public Guid Id
        {
            get
            {
                if (_id == null || _id == Guid.Empty)
                    _id = Guid.NewGuid();

                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private string _name;
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

        private string _headerText;
        public string HeaderText
        {
            get
            {
                return _headerText;
            }
            set
            {
                _headerText = value;
                OnPropertyChanged(nameof(HeaderText));
            }
        }

        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        private int _index;
        public int Index
        {
            get
            {
                return _index;
            }
            set
            {
                _index = value;
                OnPropertyChanged(nameof(Index));
            }
        }

        private ViewType _viewType;
        public ViewType ViewType
        {
            get
            {
                return _viewType;
            }
            set
            {
                _viewType = value;
                OnPropertyChanged(nameof(ViewType));
            }
        }

        private ListDefinition _listDefinition = new ListDefinition();
        public ListDefinition ListDefinition
        {
            get
            {
                return _listDefinition;
            }
            set
            {
                _listDefinition = value;
                OnPropertyChanged(nameof(ListDefinition));
            }
        }

        private ViewCellPosition _cellPosition = new ViewCellPosition();
        public ViewCellPosition CellPosition
        {
            get
            {
                return _cellPosition;
            }
            set
            {
                _cellPosition = value;
                OnPropertyChanged(nameof(CellPosition));
            }
        }
        
        private Guid _themeId;
        public Guid ThemeId
        {
            get
            {
                return _themeId;
            }
            set
            {
                _themeId = value;
                OnPropertyChanged(nameof(ThemeId));
            }
        }
        
        #endregion

        #region public

        public ViewState Copy()
        {
            return new ViewState()
            {
                Id = Guid.NewGuid(),
                Name = $"Copy of {Name}",
                HeaderText = HeaderText,
                CellPosition = CellPosition,
                Description = Description,
                Index = Index,
                ThemeId = ThemeId,
                ViewType = ViewType,
                ListDefinition = ListDefinition.Copy()
            };
        }

        #region public [overrides]

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ViewState);
        }

        public bool Equals(ViewState other)
        {
            return other != null &&
                   Id.Equals(other.Id) &&
                   Name == other.Name &&
                   Description == other.Description &&
                   Index == other.Index &&
                   ViewType == other.ViewType &&
                   EqualityComparer<ViewCellPosition>.Default.Equals(CellPosition, other.CellPosition) &&
                   EqualityComparer<ListDefinition>.Default.Equals(ListDefinition, other.ListDefinition) &&
                   ThemeId.Equals(other.ThemeId);
        }

        public override int GetHashCode()
        {
            var hashCode = 389143722;
            hashCode = hashCode * -1521134295 + EqualityComparer<Guid>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            hashCode = hashCode * -1521134295 + Index.GetHashCode();
            hashCode = hashCode * -1521134295 + ViewType.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<ViewCellPosition>.Default.GetHashCode(CellPosition);
            hashCode = hashCode * -1521134295 + EqualityComparer<ListDefinition>.Default.GetHashCode(ListDefinition);
            hashCode = hashCode * -1521134295 + EqualityComparer<Guid>.Default.GetHashCode(ThemeId);
            return hashCode;
        }

        public static bool operator ==(ViewState state1, ViewState state2)
        {
            return EqualityComparer<ViewState>.Default.Equals(state1, state2);
        }

        public static bool operator !=(ViewState state1, ViewState state2)
        {
            return !(state1 == state2);
        }

        #endregion

        #endregion
    }
}
