using System;

namespace rNascarApp.UI.Models
{
    public abstract class ViewInfo
    {
        #region properties

        public Guid Key { get; set; }
        public string Name { get; set; }
        public ViewType ViewType { get; private set; }

        public string DataSource { get; set; }
        public string DataMember { get; set; }

        public ViewPosition CellPosition { get; set; }

        #endregion

        #region ctor

        public ViewInfo(ViewType viewType)
        {
            ViewType = viewType;

            CellPosition = new ViewPosition();
        }

        #endregion

        #region public

        public override string ToString()
        {
            return $"{Name} [{ViewType.ToString()}]";
        }

        #endregion
    }
}