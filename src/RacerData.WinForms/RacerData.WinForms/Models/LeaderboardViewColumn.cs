using System.Drawing;

namespace RacerData.WinForms.Models
{
    public class LeaderboardViewColumn
    {
        #region properties

        public int Index { get; set; }
        public string Caption { get; set; }

        public string DataSource { get; set; }
        public string DataMember { get; set; }
        public string DataPath { get; set; }

        public string Type { get; set; }
        public string ConvertedType { get; set; }

        public int? Width { get; set; }
        public bool Fill { get; set; }

        public SortType SortType { get; set; }
        public int? SortOrder { get; set; }

        public string Format { get; set; }
        public ContentAlignment Alignment { get; set; }

        #endregion

        #region ctor

        public LeaderboardViewColumn()
        {
            Alignment = ContentAlignment.MiddleLeft;
        }

        #endregion

        #region public

        public override string ToString()
        {
            return $"[{Index}] {Caption} {Width}";
        }

        #endregion
    }
}
