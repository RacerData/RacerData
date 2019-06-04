namespace RacerData.WinForms.Models
{
    public class GraphRange
    {
        #region fields
        #endregion

        #region properties

        public string Name { get; set; }
        public bool ShowCaption { get; set; }
        public bool ShowLabels { get; set; }
        public bool AutoScale { get; set; }

        public double Increment { get; set; }
        public double RangeMin { get; set; }
        public double RangeMax { get; set; }

        public string DisplayMember { get; set; }
        public string ValueMember { get; set; }
        public string DataPath { get; set; }
        public string Format { get; set; }

        #endregion

        #region ctor

        public GraphRange()
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
