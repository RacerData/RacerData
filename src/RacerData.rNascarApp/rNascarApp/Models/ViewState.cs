using System;
using System.Collections.Generic;
using RacerData.rNascarApp.Settings;

namespace RacerData.rNascarApp.Models
{
    public class ViewState : IEquatable<ViewState>
    {
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
            }
        }
        public string Name { get; set; }
        public string HeaderText { get; set; }
        public string Description { get; set; }
        public int Index { get; set; }
        public ViewType ViewType { get; set; }
        public ViewCellPosition CellPosition { get; set; } = new ViewCellPosition();
        public ListSettings ListSettings { get; set; } = new ListSettings();
        public Guid ThemeId { get; set; }

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
                ListSettings = ListSettings.Copy()
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
                   _id.Equals(other._id) &&
                   Id.Equals(other.Id) &&
                   Name == other.Name &&
                   Description == other.Description &&
                   Index == other.Index &&
                   ViewType == other.ViewType &&
                   EqualityComparer<ViewCellPosition>.Default.Equals(CellPosition, other.CellPosition) &&
                   EqualityComparer<ListSettings>.Default.Equals(ListSettings, other.ListSettings) &&
                   ThemeId.Equals(other.ThemeId);
        }

        public override int GetHashCode()
        {
            var hashCode = 389143722;
            hashCode = hashCode * -1521134295 + EqualityComparer<Guid>.Default.GetHashCode(_id);
            hashCode = hashCode * -1521134295 + EqualityComparer<Guid>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            hashCode = hashCode * -1521134295 + Index.GetHashCode();
            hashCode = hashCode * -1521134295 + ViewType.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<ViewCellPosition>.Default.GetHashCode(CellPosition);
            hashCode = hashCode * -1521134295 + EqualityComparer<ListSettings>.Default.GetHashCode(ListSettings);
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
