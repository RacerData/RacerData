using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using RacerData.NascarApi.Client.Models.LiveFeed;
using RacerData.NascarApi.Client.Models.LiveFlag;
using RacerData.NascarApi.Client.Models.LivePit;
using RacerData.NascarApi.Client.Models.LivePoints;
using RacerData.NascarApi.Client.Models.LiveQualifying;
using RacerData.rNascarApp.Extensions;
using RacerData.rNascarApp.Services;
using RacerData.rNascarApp.Settings;
using RacerData.rNascarApp.Themes;

namespace RacerData.rNascarApp.Controls
{
    public partial class UserControlBase : UserControl
    {
        #region constants

        public const int DefaultRowHeight = 20;

        #endregion

        #region events

        public event EventHandler<Guid> EditThemeRequest;
        protected virtual void OnEditThemeRequest()
        {
            var handler = EditThemeRequest;

            if (handler != null)
            {
                handler.Invoke(this, State.ThemeId);
            }
        }

        public event EventHandler<ViewState> EditViewRequest;
        protected virtual void OnEditViewRequest()
        {
            var handler = EditViewRequest;

            if (handler != null)
            {
                handler.Invoke(this, State);
            }
        }

        public event EventHandler ResizeControlRequest;
        protected virtual void OnResizeControlRequest()
        {
            var handler = ResizeControlRequest;

            if (handler != null)
            {
                handler.Invoke(this, EventArgs.Empty);
            }
        }

        public event EventHandler RemoveControlRequest;
        protected virtual void OnRemoveControlRequest()
        {
            var handler = RemoveControlRequest;

            if (handler != null)
            {
                handler.Invoke(this, EventArgs.Empty);
            }
        }

        #endregion

        #region fields

        private Theme _theme;

        #endregion

        #region properties

        public LiveFeedData LiveFeedData { get; set; } = new LiveFeedData();
        public IList<LivePitData> LivePitData { get; set; } = new List<LivePitData>();
        public IList<LivePointsData> LivePointsData { get; set; } = new List<LivePointsData>();
        public IList<LiveFlagData> LiveFlagData { get; set; } = new List<LiveFlagData>();
        public IList<LiveQualifyingData> LiveQualifyingData { get; set; } = new List<LiveQualifyingData>();

        public ViewState State { get; set; }

        protected virtual ListHeader GridHeader { get; set; } = new ListHeader();

        protected virtual IList<ListRow> GridRows
        {
            get
            {
                return pnlDetail.Controls.OfType<ListRow>().Where(l => l.Index >= 0).ToList();
            }
        }

        #endregion

        #region ctor

        public UserControlBase(ViewState viewState)
            : this()
        {
            State = viewState;
        }

        public UserControlBase()
        {
            InitializeComponent();
        }

        #endregion

        #region public

        public void InitializeView(ViewState state)
        {
            State = state;

            lblHeader.Text = state.HeaderText;

            lblHeader.Visible = state.ListSettings.ShowHeader;

            tipDescription.SetToolTip(lblHeader, this.State.Description);

            tipDescription.SetToolTip(pnlDetail, this.State.Description);

            InitializeGridRows(state.ListSettings);

            _theme = UserThemeRepository.GetThemeOrDefault(State.ThemeId);

            ApplyTheme(_theme);
        }

        public virtual void OnThemeUpdated(object sender, Theme theme)
        {
            if (theme.Id == State.ThemeId)
            {
                ApplyTheme(theme);
            }
        }

        public virtual void OnViewStateUpdated(object sender, ViewState viewState)
        {
            if (viewState.Id == State.Id)
            {
                InitializeView(viewState);
            }
        }

        #endregion

        #region protected

        protected virtual void InitializeGridRows(ViewListSettings settings)
        {
            ClearGridControls();

            if (settings.ShowColumnCaptions)
            {
                GridHeader = new ListHeader()
                {
                    Height = settings.RowHeight.HasValue ? settings.RowHeight.Value : DefaultRowHeight
                };
            }

            var gridRow = new ListRow()
            {
                Height = settings.RowHeight.HasValue ? settings.RowHeight.Value : DefaultRowHeight,
                Index = 0
            };

            ColumnBuilderService.BuildGridColumns(settings, GridHeader.Controls, gridRow.Controls);

            pnlDetail.Controls.Add(GridHeader);

            if (State.ListSettings.Columns.Count > 0)
            {
                gridRow.Controls.OfType<Label>().FirstOrDefault(c => ((ViewListColumn)c.Tag).Index == 0).Text = "0";

                pnlDetail.Controls.Add(gridRow);

                var maxRows = settings.MaxRows.HasValue ? settings.MaxRows.Value : 8;

                for (int i = 1; i < maxRows; i++)
                {
                    var newRow = gridRow.DeepCopy();
                    newRow.Index = i;
                    newRow.Controls.OfType<Label>().FirstOrDefault(c => ((ViewListColumn)c.Tag).Index == 0).Text = i.ToString();
                    pnlDetail.Controls.Add(newRow);
                    newRow.BringToFront();
                }
            }
            GridHeader.SendToBack();
        }

        public virtual List<List<object>> GetViewData()
        {
            string dataColumnErrorMessage = "No Data Member Defined";

            var viewData = new List<List<object>>();

            if (State.ListSettings.Columns.Count == 0)
                return viewData;

            if (State.ListSettings.Columns.Any(c => String.IsNullOrEmpty(c.DataMember)))
                return viewData;

            object[,] dataValues = new object[GridRows.Count, State.ListSettings.Columns.Count];

            Type rootObjectType = null;
            object rootObjectValue = null;

            for (int i = 0; i < State.ListSettings.Columns.Count; i++)
            {
                var column = State.ListSettings.Columns.FirstOrDefault(c => c.Index == i);

                if (!String.IsNullOrEmpty(column.DataMember))
                {
                    var dataFullPath = column.DataFullPath;
                    var dataPathSections = dataFullPath.Split('\\');

                    if (rootObjectType == null || rootObjectType.FullName != column.DataFeedFullName)
                    {
                        if (column.DataFeed == "LiveFeedData")
                        {
                            rootObjectType = LiveFeedData.GetType();
                            rootObjectValue = LiveFeedData;
                        }
                        else if (column.DataFeed == "LiveFlagData")
                        {
                            rootObjectType = LiveFlagData.GetType();
                            rootObjectValue = LiveFlagData;
                        }
                        else if (column.DataFeed == "LivePitData")
                        {
                            rootObjectType = LivePitData.GetType();
                            rootObjectValue = LivePitData;
                        }
                        else if (column.DataFeed == "LivePointsData")
                        {
                            rootObjectType = LivePointsData.GetType();
                            rootObjectValue = LivePointsData;
                        }
                        else if (column.DataFeed == "LiveQualifyingData")
                        {
                            rootObjectType = LiveQualifyingData.GetType();
                            rootObjectValue = LiveQualifyingData;
                        }
                    }

                    string listPropertyName = String.Empty;
                    string lengthPropertyName = String.Empty;
                    object listValue = null;
                    string[] dataPathSectionsFromList = null;
                    Type sectionType = null;
                    object sectionObject = null;

                    if (rootObjectType.Name == "List`1")
                    {
                        listValue = rootObjectValue;
                        lengthPropertyName = "Count";
                    }
                    else if (rootObjectType.IsArray)
                    {
                        listValue = rootObjectValue;
                        lengthPropertyName = "Length";
                    }
                    else
                    {
                        PropertyInfo listPropertyInfo = null;
                        lengthPropertyName = "Count";

                        sectionType = rootObjectType;
                        sectionObject = rootObjectValue;

                        int listSectionIndex = -1;

                        for (int a = 0; a < dataPathSections.Length; a++)
                        {
                            if (dataPathSections[a].Contains("[]"))
                            {
                                listSectionIndex = a;
                                listPropertyName = dataPathSections[a].Replace("[]", "");
                                listPropertyInfo = sectionType.GetProperty(listPropertyName);
                                listValue = listPropertyInfo.GetValue(sectionObject);
                                break;
                            }
                        }

                        int sectionsFromListCount = dataPathSections.Length - listSectionIndex - 1;
                        dataPathSectionsFromList = new string[sectionsFromListCount];
                        Array.Copy(dataPathSections, listSectionIndex + 1, dataPathSectionsFromList, 0, sectionsFromListCount);
                    }

                    int maxRows;

                    if (listValue != null)
                    {
                        String indexerName = ((DefaultMemberAttribute)listValue.GetType()
                            .GetCustomAttributes(typeof(DefaultMemberAttribute),
                            true)[0]).MemberName;

                        PropertyInfo indexerPropertyInfo = listValue.GetType().GetProperty(indexerName);

                        PropertyInfo lengthPropertyInfo = listValue.GetType().GetProperty(lengthPropertyName);

                        int listItemCount = (int)lengthPropertyInfo.GetValue(listValue);

                        maxRows = State.ListSettings.MaxRows.HasValue ?
                            State.ListSettings.MaxRows.Value <= listItemCount ?
                            State.ListSettings.MaxRows.Value :
                            listItemCount :
                        listItemCount;

                        maxRows = maxRows > GridRows.Count ? GridRows.Count : maxRows;

                        for (int r = 0; r < maxRows; r++)
                        {
                            Object listItemValue = indexerPropertyInfo.GetValue(listValue, new Object[] { r });

                            PropertyInfo sectionProperty = null;
                            object sectionValue = null;
                            sectionObject = listItemValue;
                            sectionType = sectionObject.GetType();

                            for (int x = 0; x < dataPathSectionsFromList.Length; x++)
                            {
                                sectionProperty = sectionType.GetProperty(dataPathSectionsFromList[x]);
                                sectionValue = sectionProperty.GetValue(sectionObject);
                                sectionType = sectionValue.GetType();
                                sectionObject = sectionValue;
                            }

                            dataValues[r, i] = sectionValue;
                        }
                    }
                    else
                    {
                        // Property on the root object (ex LiveFeedData.LapNumber)
                        // All rows get the same value.
                        maxRows = State.ListSettings.MaxRows.HasValue ?
                            State.ListSettings.MaxRows.Value :
                            GridRows.Count;

                        maxRows = maxRows > GridRows.Count ? GridRows.Count : maxRows;

                        PropertyInfo sectionProperty = sectionType.GetProperty(dataPathSectionsFromList[0]);
                        object sectionValue = sectionProperty.GetValue(sectionObject);

                        for (int r = 0; r < maxRows; r++)
                        {
                            dataValues[r, i] = sectionValue;
                        }
                    }
                }
                else
                {
                    var maxRows = State.ListSettings.MaxRows.HasValue ?
                            State.ListSettings.MaxRows.Value <= GridRows.Count ?
                            State.ListSettings.MaxRows.Value :
                            GridRows.Count :
                        GridRows.Count;

                    for (int r = 0; r < maxRows; r++)
                    {
                        dataValues[r, i] = dataColumnErrorMessage;
                    }
                }
            }

            var sortColumn = State.ListSettings.OrderedColumns.FirstOrDefault(c => c.SortType != Models.SortType.None);

            object[,] sortedDataRows = sortColumn == null ?
                dataValues :
                    sortColumn.SortType == Models.SortType.Ascending ?
                    dataValues.OrderBy(x => x[sortColumn.Index]) :
                dataValues.OrderByDescending(x => x[sortColumn.Index]);

            for (int g = 0; g < sortedDataRows.GetLength(0); g++)
            {
                List<object> viewRowData = new List<object>();
                for (int h = 0; h < sortedDataRows.GetLength(1); h++)
                {
                    viewRowData.Add(sortedDataRows[g, h]);
                }
                viewData.Add(viewRowData);
            }

            return viewData;
        }

        public virtual void UpdateListRowsData(List<List<object>> viewData)
        {
            var feedDataType = LiveFeedData.GetType();

            var gridRows = pnlDetail.Controls
                .OfType<ListRow>()
                .Where(l => l.Index >= 0)
                .OrderBy(l => l.Index)
                .ToList();

            if (gridRows.Count == 0)
                return;

            for (int i = 0; i < gridRows.Count(); i++)
            {
                ListRow row = gridRows.FirstOrDefault(r => r.Index == i);

                if (i < viewData.Count)
                {
                    List<object> dataRow = viewData[i];

                    for (int x = 0; x < dataRow.Count; x++)
                    {
                        var label = row
                            .Controls
                            .OfType<Label>()
                            .FirstOrDefault(r => ((ViewListColumn)r.Tag).Index == x);

                        var column = ((ViewListColumn)label.Tag);

                        if (!String.IsNullOrEmpty(column.Format))
                            label.Text = FormatValue(dataRow[x], column.Format);
                        else
                            label.Text = dataRow[x].ToString();
                    }
                }
                else
                {
                    // More grid rows than data rows
                    row.ClearColumns();
                }
            }
        }

        protected virtual string FormatValue(object value, string format)
        {
            string formattedValue = null;

            if (value == null)
            {
                formattedValue = String.Empty;
            }
            else if (value is int)
            {
                formattedValue = ((int)value).ToString(format);
            }
            else if (value is double)
            {
                formattedValue = ((double)value).ToString(format);
            }
            else
            {
                formattedValue = value.ToString();
            }

            return formattedValue;
        }

        protected virtual void ApplyTheme(Theme theme)
        {
            lblHeader.BackColor = theme.HeaderBackColor;
            lblHeader.ForeColor = theme.HeaderForeColor;
            lblHeader.Font = theme.HeaderFont;

            GridHeader.BackColor = theme.GridColumnHeaderBackColor;
            GridHeader.ForeColor = theme.GridColumnHeaderForeColor;
            GridHeader.Font = theme.GridColumnHeaderFont;

            foreach (ListRow row in pnlDetail.Controls.OfType<ListRow>())
            {
                row.ApplyTheme(theme);
            }

            this.Invalidate();
        }

        protected virtual void ClearGridControls()
        {
            foreach (ListRow listRow in pnlDetail.Controls.OfType<ListRow>().ToList())
            {
                pnlDetail.Controls.Remove(listRow);
                listRow.Dispose();
            }
        }

        #endregion

        #region private

        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            this.OnMouseDown(e);
        }

        private void resizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnResizeControlRequest();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnRemoveControlRequest();
        }

        private void ctxUserControlBase_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                setThemeToolStripMenuItem.DropDownItems.Clear();

                var themes = UserThemeRepository.GetThemes();

                foreach (Theme theme in themes.OrderBy(t => t.Name))
                {
                    var themeName = (theme.Id == State.ThemeId) ?
                        $"[{theme.Name}]" :
                        theme.Name;

                    var themeMenuItem = new ToolStripMenuItem(themeName);
                    themeMenuItem.Tag = theme;
                    themeMenuItem.Click += selectThemeToolStripMenuItem_Click;
                    setThemeToolStripMenuItem.DropDownItems.Add(themeMenuItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void selectThemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var menuItem = (ToolStripMenuItem)sender;
                var theme = (Theme)menuItem.Tag;

                State.ThemeId = theme.Id;

                ApplyTheme(theme);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UserControlBase_Load(object sender, EventArgs e)
        {
            if (State != null)
                InitializeView(State);
        }

        private void lblHeader_FontChanged(object sender, EventArgs e)
        {
            Image image = new Bitmap(1, 1);
            Graphics graphics = Graphics.FromImage(image);
            SizeF labelTextSize = graphics.MeasureString(lblHeader.Text, lblHeader.Font);
            pnlHeader.Height = (int)labelTextSize.Height + 2;
        }

        private void editThemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnEditThemeRequest();
        }

        private void editViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnEditViewRequest();
        }

        #endregion
    }
}
