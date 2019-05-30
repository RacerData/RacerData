using System.Collections.Generic;

namespace rNascarApp.UI.Models
{
    public class StaticViewInfo : ViewInfo
    {
        #region fields
        #endregion

        #region properties

        public IList<StaticField> StaticFields { get; set; }

        #endregion

        #region ctor

        public StaticViewInfo()
            : base(ViewType.Static)
        {
            StaticFields = new List<StaticField>();
        }

        #endregion

        #region public
        #endregion

        #region protected
        #endregion

        #region private
        #endregion
    }
}
