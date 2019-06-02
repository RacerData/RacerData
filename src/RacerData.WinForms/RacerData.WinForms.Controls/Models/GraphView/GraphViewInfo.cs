namespace RacerData.WinForms.Models
{
    // https://www.codeproject.com/Articles/32836/A-simple-C-library-for-graph-plotting

    public class GraphViewInfo : ViewInfo
    {
        #region fields
        #endregion

        #region properties

        public GraphType GraphType { get; set; }
        public GraphSeries GraphSeries { get; set; }

        #endregion

        #region ctor

        public GraphViewInfo()
            : base(ViewType.Graph)
        {

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
