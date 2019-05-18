using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using RacerData.NascarApi.Service;

namespace RacerData.rNascarApp.Models
{
    public class ListDefinition
    {
        #region properties

        public int? MaxRows { get; set; }
        public int? RowHeight { get; set; }
        public bool MultilineHeader { get; set; } = false;
        public bool ShowCaptions { get; set; } = true;
        public bool ShowHeader { get; set; } = true;
        public List<ListColumn> Columns { get; set; } = new List<ListColumn>();

        [JsonIgnore()]
        public ApiFeedType ApiFeedType
        {
            get
            {
                ApiFeedType feeds = new ApiFeedType();

                var controlFeeds = Columns.Select(c => c.ApiFeedType).Distinct().ToList();

                foreach (ApiFeedType feed in controlFeeds)
                {
                    feeds |= feed;
                }

                return feeds;
            }
        }
        [JsonIgnore()]
        public int? FillColumnIndex
        {
            get
            {
                var fillColumn = Columns.FirstOrDefault(c => c.Width == null);
                return fillColumn != null ? fillColumn.Index : (int?)null;
            }
        }
        [JsonIgnore()]
        public IList<ListColumn> OrderedColumns
        {
            get
            {
                return Columns.OrderBy(c => c.Index).ToList();
            }
        }
        [JsonIgnore()]
        public IEnumerable<ListColumn> SortColumns
        {
            get
            {
                return Columns.Where(c => c.SortType != SortType.None);
            }
        }

        #endregion

        #region public

        public ListDefinition Copy()
        {
            return new ListDefinition()
            {
                MaxRows = MaxRows,
                RowHeight = RowHeight,
                ShowCaptions = ShowCaptions,
                ShowHeader = ShowHeader,
                Columns = Columns.ToList()
            };
        }

        #endregion
    }
}
