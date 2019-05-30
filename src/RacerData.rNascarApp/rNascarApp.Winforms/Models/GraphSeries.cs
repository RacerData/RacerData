namespace rNascarApp.UI.Models
{
    public class GraphSeries
    {
        #region fields
        #endregion

        #region properties

        public string Name { get; set; }
        public bool ShowCaption { get; set; }
        public int Color { get; set; }

        public GraphRange GraphXRange { get; set; }
        public GraphRange GraphYRange { get; set; }


        public string DataSource { get; set; }

        #endregion

        #region ctor

        public GraphSeries()
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
