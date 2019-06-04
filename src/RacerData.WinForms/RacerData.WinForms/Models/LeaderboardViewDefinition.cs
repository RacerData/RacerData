using System.Collections.Generic;

namespace RacerData.WinForms.Models
{
    public class LeaderboardViewDefinition
    {
        #region properties

        public string Header { get; set; }

        public string DataSource { get; set; }
        public string DataMember { get; set; }

        public int? MaxRows { get; set; }

        public bool ShowCaptions { get; set; }

        public List<LeaderboardViewColumn> Columns { get; set; }

        #endregion

        #region ctor

        public LeaderboardViewDefinition()
        {
            ShowCaptions = true;
            Columns = new List<LeaderboardViewColumn>();
        }

        #endregion

        #region public

        public override string ToString()
        {
            return $"{Header} ({Columns.Count} Columns)";
        }

        #endregion
    }
}
