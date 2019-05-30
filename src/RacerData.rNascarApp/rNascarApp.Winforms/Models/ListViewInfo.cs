namespace rNascarApp.UI.Models
{
    public class ListViewInfo : ViewInfo
    {
        #region fields
        #endregion

        #region properties

        public ListDefinition ListDefinition { get; set; }

        #endregion

        #region ctor

        public ListViewInfo()
            : base(ViewType.List)
        {
            ListDefinition = new ListDefinition();
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
