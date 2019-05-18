using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RacerData.rNascarApp.Models;
using RacerData.rNascarApp.Services;
using RacerData.rNascarApp.Settings;
using RacerData.rNascarApp.Themes;

namespace RacerData.rNascarApp.Controls.ListColumnEditor
{
    public partial class ListColumnEditor : UserControl, INotifyPropertyChanged
    {
        #region consts

        private const int PanelGap = 4;
        private const int ScrollBarMargin = 24;

        #endregion

        #region events

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region fields

        private Theme _viewTheme = null;

        private Point _dragPoint = Point.Empty;
        private Point _dragPointToClient = Point.Empty;
        private Panel _dragFrame;

        private Color _labelForeColor = Color.Black;
        private Color _unselectedCaptionBackColor = Color.FromKnownColor(KnownColor.Control);
        private Color _unselectedFieldBackColor = Color.White;
        private Color _selectedBackColor = Color.Yellow;

        private string _originalViewState = String.Empty;
        private bool _allowResize = false;
        private bool _isLoadingFieldDetails = false;
        private int? _selectedFieldIndex = null;

        private List<int?> _preStretchWidths = new List<int?>();

        #endregion

        #region properties

        public bool ShowViewSettings { get; set; }

        private bool _isEditing = false;
        public bool IsEditing
        {
            get
            {
                return _isEditing;
            }
            set
            {
                _isEditing = value;
                OnPropertyChanged(nameof(IsEditing));
            }
        }

        private bool _hasChanges = false;
        public bool HasChanges
        {
            get
            {
                return _hasChanges;
            }
            set
            {
                _hasChanges = value;
                OnPropertyChanged(nameof(HasChanges));
            }
        }

        private IList<Theme> _themes;
        public IList<Theme> Themes
        {
            get
            {
                if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                    return new List<Theme>();

                if (_themes == null)
                    _themes = UserThemeRepository.GetThemes();

                return _themes;
            }
            set
            {
                _themes = value;
                LoadThemes();
            }
        }

        private ViewState _viewState;
        public ViewState ViewState
        {
            get
            {
                return _viewState;
            }
            set
            {
                _viewState = value;
                _originalViewState = SerializeItem(_viewState);
                DisplayViewState();
            }
        }

        protected Label CaptionLabel
        {
            get
            {
                if (_selectedFieldIndex.HasValue)
                    return pnlCaptions.Controls.OfType<Label>().FirstOrDefault(c => ((ListColumn)c.Tag).Index == _selectedFieldIndex.Value);
                else
                    return null;
            }
        }

        protected Label FieldLabel
        {
            get
            {
                if (_selectedFieldIndex.HasValue)
                    return pnlFields.Controls.OfType<Label>().FirstOrDefault(c => ((ListColumn)c.Tag).Index == _selectedFieldIndex.Value);
                else
                    return null;
            }
        }

        public IOrderedEnumerable<Label> CaptionLabels
        {
            get
            {
                return pnlCaptions.Controls.OfType<Label>().OrderBy(l => l.Location.X);
            }
        }

        public IOrderedEnumerable<Label> FieldLabels
        {
            get
            {
                return pnlFields.Controls.OfType<Label>().OrderBy(l => l.Location.X);
            }
        }

        public IColumnBuilderService ColumnBuilderService { get; set; }

        #endregion

        #region ctor/load

        public ListColumnEditor()
        {
            InitializeComponent();
        }

        private void ListColumnEditor_Load(object sender, EventArgs e)
        {
            _dragFrame = new Panel()
            {
                Visible = false,
                BorderStyle = BorderStyle.FixedSingle
            };

            Controls.Add(_dragFrame);

            DisableChildren(grpEditField);

            grpViewSettings.Visible = ShowViewSettings;

            ColumnBuilderService = ServiceProvider.Instance.GetRequiredService<IColumnBuilderService>();
        }

        #endregion

        #region protected

        protected virtual void DisplayViewState()
        {
            if (ViewState == null)
                return;

            if (ViewState.ListDefinition.ShowHeader)
            {
                lblHeader.Text = ViewState.HeaderText;
            }

            BuildColumnControls(ViewState.ListDefinition);
        }

        protected virtual void BuildColumnControls(ListDefinition listDefinition)
        {
            if (listDefinition == null)
                return;

            ColumnBuilderService.BuildGridColumns(listDefinition,
                pnlCaptions.Controls,
                pnlFields.Controls,
                _viewTheme);

            foreach (Label captionLabel in pnlCaptions.Controls.OfType<Label>())
            {
                captionLabel.ContextMenuStrip = ctxCaptionLabel;
                captionLabel.DoubleClick += (s, e) =>
                {
                    if (!IsEditing)
                        BeginEdit((Label)s);
                };
                captionLabel.Click += (s, e) =>
                {
                    if (!IsEditing)
                        SelectColumn((Label)s);
                };

                ConfigureResize(captionLabel);
            }

            foreach (Label fieldLabel in pnlFields.Controls.OfType<Label>())
            {
                fieldLabel.ContextMenuStrip = ctxCaptionLabel;
                fieldLabel.AllowDrop = true;

                ConfigureResize(fieldLabel);
                ConfigureDragging(fieldLabel);
            }

            UpdateColumnAligmnents();

            ApplyTheme(_viewTheme);
        }

        protected virtual void ConfigureResize(Label label)
        {
            PictureBox resizePictureBox = new PictureBox();
            resizePictureBox.BackColor = Color.Transparent;
            resizePictureBox.Image = Properties.Resources.ColumnSeparator;
            resizePictureBox.Size = new Size(3, label.Height);
            resizePictureBox.Location = new Point(label.Width - resizePictureBox.Width, label.Height - resizePictureBox.Height);
            resizePictureBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            resizePictureBox.Dock = DockStyle.Right;

            resizePictureBox.Cursor = Cursors.SizeWE;
            resizePictureBox.MouseDown += (s, e) =>
            {
                _allowResize = true;
            };
            resizePictureBox.MouseMove += (s, e) =>
            {
                if (_allowResize)
                {
                    Label captionLabel = null;
                    PictureBox pictureBox = (PictureBox)s;
                    Label parent = (Label)pictureBox.Parent;
                    parent.Width = pictureBox.Left + e.X;

                    if (label.Name.EndsWith("Caption"))
                    {
                        var fieldLabelName = parent.Name.Replace("Caption", "");
                        Label fieldLabel = pnlFields.Controls.OfType<Label>().FirstOrDefault(l => l.Name == fieldLabelName);

                        if (fieldLabel != null)
                            fieldLabel.Width = pictureBox.Left + e.X;

                        captionLabel = label;
                    }
                    else
                    {
                        var captionLabelName = $"{parent.Name}Caption";
                        captionLabel = pnlCaptions.Controls.OfType<Label>().FirstOrDefault(l => l.Name == captionLabelName);

                        if (captionLabel != null)
                            captionLabel.Width = pictureBox.Left + e.X;
                    }

                    UpdatePanelHeights(captionLabel);
                }
            };
            resizePictureBox.MouseUp += (s, e) =>
            {
                _allowResize = false;

                UpdateViewListItems();

                UpdateHasChanges();
            };

            label.Controls.Add(resizePictureBox);

            resizePictureBox.BringToFront();
        }
        protected virtual void ConfigureDragging(Label label)
        {
            label.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    _dragPoint = e.Location;

                    dragTimer.Start();

                    _dragFrame.Size = label.Size;

                    Point pt = this.PointToClient(Cursor.Position);

                    _dragPointToClient = pt;

                    _dragFrame.Location = new Point(pt.X - _dragPoint.X,
                                                   pt.Y + 3);

                    if (_dragFrame.BackgroundImage != null)
                        _dragFrame.BackgroundImage.Dispose();
                    Bitmap bmp = new Bitmap(_dragFrame.ClientSize.Width,
                                            _dragFrame.ClientSize.Height);
                    label.DrawToBitmap(bmp, _dragFrame.ClientRectangle);
                    _dragFrame.BackgroundImage = bmp;

                    _dragFrame.BringToFront();
                    _dragFrame.Show();

                    label.DoDragDrop(label, DragDropEffects.Move);
                }
            };

            label.DragOver += (s, e) =>
            {
                e.Effect = DragDropEffects.Move;
            };

            label.MouseUp += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    _dragFrame.Hide();
                    dragTimer.Stop();
                }
            };

            label.Leave += (s, e) =>
            {
                _dragFrame.Hide();
                dragTimer.Stop();
            };

            label.DragDrop += pnlFields_DragDrop;
        }

        protected virtual void UpdateViewListItems()
        {
            var captionLabels = pnlCaptions.Controls.OfType<Label>().ToList().OrderBy(l => l.Location.X);

            int i = 0;

            foreach (Label captionLabel in captionLabels)
            {
                var listColumn = (ListColumn)captionLabel.Tag;

                listColumn.Index = i;
                listColumn.Caption = captionLabel.Text;
                listColumn.Width = captionLabel.Dock != DockStyle.Fill ?
                        captionLabel.Width :
                        (int?)null;
                listColumn.Alignment = captionLabel.TextAlign;
                listColumn.SortType = i == 0 ? SortType.Ascending : SortType.None;

                i++;
            }
        }

        protected virtual void BeginEdit(Label label)
        {
            var listColumn = (ListColumn)label.Tag;
            SetUIEditState(true, listColumn.Index);
        }

        protected virtual void SelectColumn(Label label)
        {
            var listColumn = (ListColumn)label.Tag;
            SetUIEditState(false, listColumn.Index);
        }
        protected virtual void SaveChanges()
        {
            if (!_selectedFieldIndex.HasValue)
            {
                MessageBox.Show("No field selected!");
                return;
            }

            foreach (Label label in FieldLabels)
            {
                ((ListColumn)label.Tag).Width = label.Width;
            }
            foreach (Label label in CaptionLabels)
            {
                ((ListColumn)label.Tag).Width = label.Width;
            }

            var viewListColumn = ViewState.ListDefinition.OrderedColumns[_selectedFieldIndex.Value];

            viewListColumn.Caption = txtColCaption.Text;
            viewListColumn.Alignment = calAlignment.Alignment;
            viewListColumn.HasBorder = chkBorder.Checked;
            viewListColumn.Format = txtColFormat.Text;
            viewListColumn.Sample = txtColTest.Text;

            if (chkStretch.Checked)
                viewListColumn.Width = null;
            else
            {
                int width = 0;
                if (Int32.TryParse(txtWidth.Text, out width))
                {
                    viewListColumn.Width = width;
                }
            }

            if (cboThemes.SelectedItem != null)
                ViewState.ThemeId = ((Theme)cboThemes.SelectedItem).Id;

            ViewState.ListDefinition.OrderedColumns[_selectedFieldIndex.Value] = viewListColumn;

            SetUIEditState(false, null);
        }
        protected virtual void CancelEdit()
        {
            RevertColumnWidths();

            SetUIEditState(false);
        }

        protected virtual void UpdateColumnAligmnents()
        {
            var stretchColumn = ViewState.ListDefinition.Columns.FirstOrDefault(c => c.Width == null);
            UpdateColumnAligmnents(stretchColumn?.Index);
        }
        protected virtual void UpdateColumnAligmnents(int? stretchColumnIndex)
        {
            ColumnBuilderService.AlignControls(pnlCaptions.Controls, stretchColumnIndex);
            ColumnBuilderService.AlignControls(pnlFields.Controls, stretchColumnIndex);

            FormatSampleValues();

            ApplyTheme(_viewTheme);
        }

        protected virtual void SetUIEditState(bool isEditing, int? index = null)
        {
            if (FieldLabel != null)
                FieldLabel.SizeChanged -= selectedLabel_WidthChanged;

            _isLoadingFieldDetails = true;
            _selectedFieldIndex = index;

            if (isEditing)
                SaveColumnWidths();

            if (!isEditing)
            {
                EnableChildren(grpViewSettings);
                DisableChildren(grpEditField);
            }
            else
            {
                EnableChildren(grpEditField);
                DisableChildren(grpViewSettings);
            }

            pnlFields.Enabled = !isEditing;
            pnlCaptions.Enabled = !isEditing;

            ClearSelectedColumn();

            if (index.HasValue)
                ColumnSelected(index.Value);

            ClearColumnDetails();

            if (index.HasValue)
                DisplayColumnDetails(index.Value);

            IsEditing = isEditing;
            _isLoadingFieldDetails = false;

            UpdateHasChanges();

        }
        protected virtual void ColumnSelected(int index)
        {
            FieldLabel.BackColor = _selectedBackColor;
            CaptionLabel.BackColor = _selectedBackColor;

            FieldLabel.SizeChanged += selectedLabel_WidthChanged;
        }
        protected virtual void ClearSelectedColumn()
        {
            for (int i = 0; i < pnlFields.Controls.OfType<Label>().Count(); i++)
            {
                pnlFields.Controls.OfType<Label>().ElementAt(i).BackColor = _unselectedFieldBackColor;
                pnlCaptions.Controls.OfType<Label>().ElementAt(i).BackColor = _unselectedCaptionBackColor;
            }
        }
        protected virtual void DisplayColumnDetails(int index)
        {
            if (cboThemes.Items.Count == 0)
                LoadThemes();

            var viewListColumn = ViewState.ListDefinition.Columns.FirstOrDefault(c => c.Index == index);

            txtColCaption.Text = viewListColumn.Caption;

            calAlignment.Alignment = viewListColumn.Alignment;
            chkStretch.Checked = !viewListColumn.Width.HasValue;
            txtWidth.Enabled = !chkStretch.Checked;
            txtWidth.Text = FieldLabel.Width.ToString();

            txtColFormat.Text = viewListColumn.Format;
            txtColTest.Text = viewListColumn.Sample;

            chkBorder.Checked = viewListColumn.HasBorder;

            FormatSampleValue(index);
        }
        protected virtual void ClearColumnDetails()
        {
            txtColCaption.Clear();
            txtColFormat.Clear();
            txtColTest.Clear();
            txtWidth.Clear();
            chkBorder.Checked = false;
            chkStretch.Checked = false;
            calAlignment.Alignment = ContentAlignment.MiddleLeft;
        }

        protected virtual void SaveColumnWidths()
        {
            _preStretchWidths.Clear();

            foreach (ListColumn column in ViewState.ListDefinition.OrderedColumns)
            {
                _preStretchWidths.Add(column.Width);
            }
        }
        protected virtual void RevertColumnWidths()
        {
            for (int i = 0; i < ViewState.ListDefinition.OrderedColumns.Count; i++)
            {
                ViewState.ListDefinition.OrderedColumns[i].Width = _preStretchWidths[i];
            }
        }

        protected virtual void FormatSampleValues()
        {
            if (_isLoadingFieldDetails)
                return;

            for (int i = 0; i < ViewState.ListDefinition.Columns.Count; i++)
            {
                FormatSampleValue(i);
            }
        }

        protected virtual void FormatSampleValue(int? index)
        {
            if (_isLoadingFieldDetails)
                return;

            if (!index.HasValue)
                return;

            int columnIndex = index.Value;

            var fieldLabel = pnlFields.Controls.OfType<Label>().ElementAt(columnIndex);

            var viewListColumn = ViewState.ListDefinition.OrderedColumns[columnIndex];

            var type = viewListColumn.ConvertedType;

            var formattedText = FieldFormatService.FormatValue(type, viewListColumn.Format, viewListColumn.Sample);

            fieldLabel.Text = formattedText;
        }

        protected virtual void FormatSampleValue(int? index, string format, string value)
        {
            if (_isLoadingFieldDetails)
                return;

            if (!index.HasValue)
                return;

            int columnIndex = index.Value;

            var fieldLabel = pnlFields.Controls.OfType<Label>().ElementAt(columnIndex);

            var viewListColumn = ViewState.ListDefinition.OrderedColumns[columnIndex];

            var type = viewListColumn.ConvertedType;

            var formattedText = FieldFormatService.FormatValue(type, format, value);

            fieldLabel.Text = formattedText;
        }

        protected virtual void LoadThemes()
        {
            cboThemes.DataSource = null; ;
            cboThemes.ValueMember = "Id";
            cboThemes.DisplayMember = "Name";
            cboThemes.DataSource = Themes;
        }

        protected virtual void ApplyTheme(Theme theme)
        {
            if (theme == null)
                return;

            pnlTop.BackColor = theme.HeaderBackColor;

            pnlHeader.BackColor = theme.HeaderBackColor;
            pnlHeader.Font = theme.HeaderFont;

            lblHeader.BackColor = theme.HeaderBackColor;
            lblHeader.ForeColor = theme.HeaderForeColor;
            lblHeader.Font = theme.HeaderFont;

            pnlCaptions.BackColor = theme.GridColumnHeaderBackColor;
            pnlCaptions.ForeColor = theme.GridColumnHeaderForeColor;
            pnlCaptions.Font = theme.GridColumnHeaderFont;
            foreach (Label label in pnlCaptions.Controls.OfType<Label>())
            {
                label.BackColor = pnlCaptions.BackColor;
                label.ForeColor = pnlCaptions.ForeColor;
                label.Font = pnlCaptions.Font;
            }

            pnlFields.BackColor = theme.PrimaryBackColor;
            pnlFields.ForeColor = theme.PrimaryForeColor;
            pnlFields.Font = theme.GridFont;
            foreach (Label label in pnlFields.Controls.OfType<Label>())
            {
                label.BackColor = pnlFields.BackColor;
                label.ForeColor = pnlFields.ForeColor;
                label.Font = pnlFields.Font;
            }

            _labelForeColor = theme.PrimaryForeColor;
            _unselectedFieldBackColor = theme.PrimaryBackColor;
            _unselectedCaptionBackColor = theme.GridColumnHeaderBackColor;

            this.Invalidate();
        }

        protected virtual void SetSelectedLabelWidth()
        {
            if (_selectedFieldIndex.HasValue)
            {
                int width = 0;
                var column = ViewState.ListDefinition.OrderedColumns[_selectedFieldIndex.Value];
                if (Int32.TryParse(txtWidth.Text, out width))
                {
                    CaptionLabel.Width = width;
                    FieldLabel.Width = width;
                }


                UpdatePanelHeights(CaptionLabel);
            }
        }
        protected virtual void UpdatePanelHeights(Label captionLabel)
        {
            Bitmap stringLengthBitmap = new Bitmap(1, 1);
            SizeF stringSize = new SizeF();
            using (Graphics g = Graphics.FromImage(stringLengthBitmap))
            {
                stringSize = g.MeasureString(captionLabel.Text, captionLabel.Font);
            }

            if (stringSize.Width > (captionLabel.Width - 2) &&
                ViewState.ListDefinition.MultilineHeader == false &&
                ViewState.ListDefinition.RowHeight.HasValue)
            {
                ViewState.ListDefinition.MultilineHeader = true;
                pnlCaptions.Height = ViewState.ListDefinition.RowHeight.Value * 2;
            }
            else if (stringSize.Width < (captionLabel.Width - 2) &&
                ViewState.ListDefinition.MultilineHeader == true &&
                ViewState.ListDefinition.RowHeight.HasValue)
            {
                ViewState.ListDefinition.MultilineHeader = false;
                pnlCaptions.Height = ViewState.ListDefinition.RowHeight.Value;
            }
        }

        protected virtual void DisableChildren(Control control)
        {
            foreach (var child in control.Controls.OfType<Control>().Where(c => c.GetType() != typeof(Label) && c.GetType() != typeof(GroupBox)))
            {
                if (child.HasChildren)
                {
                    DisableChildren(child);
                }
                child.Enabled = false;
            }
        }

        protected virtual void EnableChildren(Control control)
        {
            foreach (var child in control.Controls.OfType<Control>().Where(c => c.GetType() != typeof(Label) && c.GetType() != typeof(GroupBox)))
            {
                if (child.HasChildren)
                {
                    EnableChildren(child);
                }
                child.Enabled = true;
            }
        }

        protected virtual void UpdateHasChanges()
        {
            var currentViewState = SerializeItem(ViewState);

            HasChanges = (_originalViewState != currentViewState);
        }

        protected virtual string SerializeItem(ViewState view)
        {
            if (view == null)
                return string.Empty;

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                NullValueHandling = NullValueHandling.Include
            };

            return JsonConvert.SerializeObject(
                    view,
                    Formatting.Indented,
                    settings);
        }

        protected virtual ViewState DeserializeItem(string json)
        {
            return JsonConvert.DeserializeObject<ViewState>(json);
        }

        #endregion

        #region private

        private void DragTimer_Tick(object sender, EventArgs e)
        {
            if ((Control.MouseButtons & MouseButtons.Left) == MouseButtons.None)
            {
                _dragFrame.Hide();
                dragTimer.Stop();
            }

            if (_dragFrame.Visible)
            {
                Point pt = this.PointToClient(Cursor.Position);

                _dragFrame.Location = new Point(pt.X - _dragPoint.X,
                                               pt.Y + 3);
            }
        }
        private void pnlFields_DragDrop(object sender, DragEventArgs e)
        {
            _dragFrame.Hide();
            dragTimer.Stop();

            Label movedLabel = e.Data.GetData(e.Data.GetFormats()[0]) as Label;
            Label droppedOnLabel = (Label)sender;

            var movedColumn = (ListColumn)movedLabel.Tag;
            var movedOriginalIndex = movedColumn.Index;

            var droppedOnColumn = (ListColumn)droppedOnLabel.Tag;
            var droppedOnIndex = droppedOnColumn.Index;

            if (movedOriginalIndex == droppedOnIndex)
                return;

            if (movedOriginalIndex < droppedOnIndex)
            {
                // moved to the right
                foreach (Label columnLabel in FieldLabels.Where(c =>
                    ((ListColumn)c.Tag).Index > movedOriginalIndex &&
                    ((ListColumn)c.Tag).Index <= droppedOnIndex))
                {
                    ((ListColumn)columnLabel.Tag).Index -= 1;
                }

                movedColumn.Index = droppedOnIndex;
            }
            else if (movedOriginalIndex > droppedOnIndex)
            {
                // moved to the left
                foreach (Label columnLabel in FieldLabels.Where(c =>
                    ((ListColumn)c.Tag).Index >= droppedOnIndex &&
                    ((ListColumn)c.Tag).Index < movedOriginalIndex))
                {
                    ((ListColumn)columnLabel.Tag).Index += 1;
                }
                movedColumn.Index = droppedOnIndex;
            }

            UpdateColumnAligmnents();

            UpdateHasChanges();
        }

        private void selectedLabel_WidthChanged(object sender, EventArgs e)
        {
            txtWidth.Text = ((Label)sender).Width.ToString();
        }

        private void pnlHeader_FontChanged(object sender, EventArgs e)
        {
            pnlHeader.Height = lblHeader.Height + 2;
        }

        private void lblHeader_TextChanged(object sender, EventArgs e)
        {
            pnlHeader.Height = lblHeader.Height + 2;
        }

        private void pnlHeader_Resize(object sender, EventArgs e)
        {
            pnlCaptions.Size = new Size(
               pnlHeader.Size.Width,
               pnlCaptions.Size.Height);

            pnlCaptions.Location = new Point(
              pnlHeader.Location.X,
              pnlHeader.Location.Y + pnlHeader.Height + PanelGap);
        }

        private void pnlCaptions_Resize(object sender, EventArgs e)
        {
            pnlFields.Size = new Size(
               pnlCaptions.Size.Width,
               pnlFields.Size.Height);

            pnlFields.Location = new Point(
                pnlCaptions.Location.X,
                pnlCaptions.Location.Y + pnlCaptions.Height + PanelGap);

            pnlTop.Size = new Size(
                pnlTop.Width,
                pnlFields.Location.Y +
                    pnlFields.Height +
                    PanelGap +
                    (pnlTop.HorizontalScroll.Visible ? ScrollBarMargin : 0)
                );
        }

        private void mnuEditField_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            ContextMenuStrip menuItemOwner = (ContextMenuStrip)menuItem.Owner;
            Label label = (Label)menuItemOwner.SourceControl;
            BeginEdit(label);
        }

        private void txtWidth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SetSelectedLabelWidth();
        }
        private void txtWidth_Leave(object sender, EventArgs e)
        {
            SetSelectedLabelWidth();
        }

        private void btnCancelEditField_Click(object sender, EventArgs e)
        {
            CancelEdit();

            DisplayViewState();
        }

        private void btnSaveEditedField_Click(object sender, EventArgs e)
        {
            SaveChanges();

            DisplayViewState();
        }

        private void cboThemes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboThemes.SelectedValue != null)
            {
                _viewTheme = (Theme)cboThemes.SelectedItem;

                if (_viewTheme != null)
                    ApplyTheme(_viewTheme);
            }
        }

        private void FormatSample_TextChanged(object sender, EventArgs e)
        {
            FormatSampleValue(_selectedFieldIndex, txtColFormat.Text, txtColTest.Text);
        }

        #endregion
    }
}
