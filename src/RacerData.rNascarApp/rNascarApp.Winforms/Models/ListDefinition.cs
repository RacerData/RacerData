using System.Collections.Generic;

namespace rNascarApp.UI.Models
{
    public class ListDefinition
    {
        #region properties

        public string Header { get; set; }

        public string DataSource { get; set; }
        public string DataMember { get; set; }

        public int? MaxRows { get; set; }

        public bool ShowCaptions { get; set; }

        public List<ListColumn> Columns { get; set; }

        #endregion

        #region ctor

        public ListDefinition()
        {
            ShowCaptions = true;
            Columns = new List<ListColumn>();
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
