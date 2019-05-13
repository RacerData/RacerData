using System;
using RacerData.rNascarApp.Settings;

namespace RacerData.rNascarApp.Models
{
    public class ViewState
    {
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

        public override string ToString()
        {
            return Name;
        }
    }
}
