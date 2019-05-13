using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using RacerData.NascarApi.Client.Models.LapAverages;
using RacerData.NascarApi.Client.Models.LapTimes;
using RacerData.NascarApi.Client.Models.LiveFeed;
using RacerData.NascarApi.Client.Models.LiveFlag;
using RacerData.NascarApi.Client.Models.LivePit;
using RacerData.NascarApi.Client.Models.LivePoints;
using RacerData.NascarApi.Client.Models.LiveQualifying;
using RacerData.NascarApi.Service;
using RacerData.rNascarApp.Extensions;
using RacerData.rNascarApp.Models;
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
        List<List<object>> _viewData = new List<List<object>>();
        private DataParserService _parserService = null;

        #endregion

        #region properties

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

            var sortColumn = State.
                ListSettings.
                OrderedColumns.
                FirstOrDefault(c => c.SortType != SortType.None);

            _parserService = new DataParserService()
            {
                Columns = State.ListSettings.Columns,
                RowCount = State.ListSettings.MaxRows,
                ApiFeedType = State.ListSettings.ApiFeedType,
                SortColumnIndex = sortColumn.Index,
                SortType = sortColumn.SortType
            };

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

        public virtual object[,] GetViewData(object data, ApiFeedType apiFeedType)
        {
            if (State.ListSettings.ApiFeedType.HasFlag(apiFeedType))
                return _parserService.GetListData(data);
            else
                return null;
        }

        public virtual void UpdateListRowsData(object[,] viewData)
        {
            try
            {
                this.SuspendLayout();

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

                    if (i < viewData.GetLength(0))
                    {
                        for (int x = 0; x < viewData.GetLength(1); x++)
                        {
                            if (viewData[i, x] != null)
                            {
                                var label = row
                                .Controls
                                .OfType<Label>()
                                .FirstOrDefault(r => ((ListColumn)r.Tag).Index == x);

                                var column = ((ListColumn)label.Tag);

                                if (!String.IsNullOrEmpty(column.Format))
                                {
                                    label.Text = FormatValue(viewData[i, x], column.Format);
                                }
                                else
                                {
                                    label.Text = viewData[i, x].ToString();
                                }
                            }
                        }
                    }
                    else
                    {
                        // More grid rows than data rows
                        row.ClearColumns();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                this.ResumeLayout();
            }
        }

        #endregion

        #region protected

        protected virtual void InitializeGridRows(ListSettings settings)
        {
            ClearGridControls();

            if (settings.ShowCaptions)
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
                gridRow.Controls.OfType<Label>().FirstOrDefault(c => ((ListColumn)c.Tag).Index == 0).Text = "0";

                pnlDetail.Controls.Add(gridRow);

                var maxRows = settings.MaxRows.HasValue ? settings.MaxRows.Value : 8;

                for (int i = 1; i < maxRows; i++)
                {
                    var newRow = gridRow.DeepCopy();
                    newRow.Index = i;
                    newRow.Controls.OfType<Label>().FirstOrDefault(c => ((ListColumn)c.Tag).Index == 0).Text = i.ToString();
                    pnlDetail.Controls.Add(newRow);
                    newRow.BringToFront();
                }
            }
            GridHeader.SendToBack();
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
