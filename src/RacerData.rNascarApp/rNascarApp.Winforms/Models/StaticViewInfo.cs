using System.Collections.Generic;

namespace rNascarApp.UI.Models
{
    public class StaticViewInfo : ViewInfo
    {
        #region fields
        #endregion

        #region properties

        public IList<StaticField> Fields { get; set; }

        #endregion

        #region ctor

        public StaticViewInfo()
            : base(ViewType.Static)
        {
            Fields = new List<StaticField>();
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
