using System.Collections.Generic;

namespace RacerData.WinForms.Models
{
    public class StaticViewInfo : ViewInfo
    {
        #region fields
        #endregion

        #region properties

        public IList<StaticField> Fields { get; protected set; }

        #endregion

        #region ctor

        public StaticViewInfo()
            : base(ViewType.Static)
        {
            Fields = new List<StaticField>();
        }

        #endregion

        #region public

        public virtual int AddField(StaticField field)
        {
            field.Index = Fields.Count;
            Fields.Add(field);
            return field.Index;
        }

        #endregion

        #region protected
        #endregion

        #region private
        #endregion
    }
}
