using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RacerData.rNascarApp.Factories;
using RacerData.rNascarApp.Models;
using RacerData.rNascarApp.Services;
using RacerData.rNascarApp.Settings;

namespace RacerData.rNascarApp.Controls.CreateViewWizard
{
    public partial class CreateViewWizard3 : WizardStep
    {
        #region fields

        private IList<FormatListItem> _formatListItems = new List<FormatListItem>();
        private DisplayFormatMapService _mapService = null;
        private Point _dragPoint = Point.Empty;
        private Point _dragPointToClient = Point.Empty;
        private Panel _dragFrame;
        private Color _labelForeColor = Color.Black;
        private Color _unselectedCaptionBackColor = Color.FromKnownColor(KnownColor.Control);
        private Color _unselectedFieldBackColor = Color.White;
        private Color _selectedBackColor = Color.Yellow;
        private bool _allowResize = false;
        private bool _isEditing = false;
        private bool _isLoadingFieldDetails = false;
        private int? _selectedFieldIndex = null;
        private List<int?> _preStretchWidths = new List<int?>();

        #endregion

        #region properties

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

        protected IList<ColumnLabel> ColumnLabels { get; set; } = new List<ColumnLabel>();

        public override bool CanGoPrevious
        {
            get
            {
                return base.CanGoPrevious && !Context.IsEditing;
            }
            set
            {
                base.CanGoPrevious = value;
                OnPropertyChanged(nameof(CanGoPrevious));
            }
        }

        #endregion

        #region ctor/load

        public CreateViewWizard3()
        {
            InitializeComponent();

            Index = 2;
            Name = "Set field order";
            Caption = "Set the field properties by right-clicking a field and selecting 'Edit Field'";
            Details = "Set the order, size, alignment, and format of the fields in the view.";
            Error = String.Empty;

            PopulateConvertToList();
            BuildFormatListItemList();
        }

        private void CreateViewWizard3_Load(object sender, EventArgs e)
        {
            lblCaption.Text = Caption;

            _mapService = new DisplayFormatMapService();

            _dragFrame = new Panel()
            {
                Visible = false,
                BorderStyle = BorderStyle.FixedSingle
            };

            Controls.Add(_dragFrame);

            dragTimer.Tick += DragTimer_Tick;

            var listColumns = BuildListColumnsList();

            Context.ViewListColumns = new BindingList<ListColumn>(listColumns);
        }

        #endregion

        #region public 

        public override void SetDataObject(CreateViewContext data)
        {
            Context = data;
        }

        public override void ActivateStep()
        {
            base.ActivateStep();

            if (Context.ViewListColumns.Count == 0)
                Context.ViewListColumns = new BindingList<ListColumn>(BuildListColumnsList());
            else
                SyncColumnList();

            DisplayFields();

            UpdateValidation();
        }

        public override void DeactivateStep()
        {
            base.DeactivateStep();
        }

        public override bool ValidateStep()
        {
            bool isValid = true;
            Error = "";

            if (Context.ViewListColumns == null)
            {
                isValid = true;
                Error = "List settings not configured";
            }

            return isValid;
        }

        #endregion

        #region protected

        #region display

        protected virtual void SyncColumnList()
        {
            foreach (ViewDataMember viewDataMember in Context.ViewDataMembers)
            {
                if (!Context.ViewListColumns.Any(c => c.DataPath == viewDataMember.Path))
                {
                    // new column was added.
                    Context.ViewListColumns.Add(GetListColumn(viewDataMember, Context.ViewListColumns.Count));
                }
            }

            foreach (ListColumn column in Context.ViewListColumns.ToList())
            {
                if (!Context.ViewDataMembers.Any(c => c.Path == column.DataPath))
                {
                    // column was removed.
                    Context.ViewListColumns.Remove(column);
                }
            }

            // Reset the indexes
            for (int i = 0; i < Context.ViewListColumns.Count; i++)
            {
                Context.ViewListColumns[i].Index = i;
            }
        }

        protected virtual IList<ListColumn> BuildListColumnsList()
        {
            var viewListColumns = new List<ListColumn>();

            int i = 0;

            foreach (ViewDataMember viewDataMember in Context.ViewDataMembers)
            {
                viewListColumns.Add(GetListColumn(viewDataMember, i));
                i++;
            }

            _mapService.Save();

            return viewListColumns;
        }

        protected virtual ListColumn GetListColumn(ViewDataMember viewDataMember, int index)
        {

            if (!_mapService.Map.ContainsKey(viewDataMember) || _mapService.Map[viewDataMember].Name == "Default")
            {
                var newViewDisplayFormat = new ViewDisplayFormat()
                {
                    Name = viewDataMember.Name
                };

                var typeName = viewDataMember.Type.Name.Replace("System.", "");

                if (typeName == "String")
                {
                    newViewDisplayFormat.Sample = "Abcdefg Hijklmnop";
                }
                else if (typeName == "Int32")
                {
                    newViewDisplayFormat.Sample = "12345";
                    newViewDisplayFormat.Format = "###";
                }
                else if (typeName == "Decimal" || typeName == "Double")
                {
                    newViewDisplayFormat.Sample = "123.456";
                    newViewDisplayFormat.Format = "###.##0";
                }
                else if (typeName == "TimeSpan")
                {
                    newViewDisplayFormat.Sample = "56.789";
                    newViewDisplayFormat.Format = "ss.fff";
                }
                else
                {
                    newViewDisplayFormat.Sample = "";
                }

                _mapService.Map[viewDataMember] = newViewDisplayFormat;
            }

            var viewDisplayFormat = _mapService.Map[viewDataMember];

            return new ListColumn()
            {
                Index = index,
                Alignment = viewDisplayFormat.ContentAlignment,
                Caption = viewDataMember.Caption,
                Format = viewDisplayFormat.Format,
                Sample = viewDisplayFormat.Sample,
                Width = viewDisplayFormat.MaxWidth,
                Type = viewDataMember.Type.Name,
                ConvertedType = viewDataMember.ConvertedType.Name,
                SortType = index == 0 ? SortType.Ascending : SortType.None,
                DataMember = viewDataMember.Name,
                DataPath = viewDataMember.Path,
                DataFeed = viewDataMember.DataFeed
            };
        }

        protected virtual void DisplayFields()
        {
            pnlFields.Controls.Clear();
            pnlCaptions.Controls.Clear();
            ColumnLabels.Clear();

            int? stretchColumnIndex = null;

            foreach (ListColumn viewListColumn in Context.ViewListColumns.OrderBy(c => c.Index))
            {
                /** Caption Label **/
                var captionLabel = ColumnBuilderService.BuildColumnLabel(viewListColumn, true);
                captionLabel.ContextMenuStrip = ctxCaptionLabel;
                captionLabel.DoubleClick += (s, e) =>
                {
                    if (!_isEditing)
                        BeginEdit(viewListColumn.Index);
                };
                captionLabel.Click += (s, e) =>
                {
                    if (!_isEditing)
                        SelectColumn(viewListColumn.Index);
                };
                captionLabel.Text = viewListColumn.Caption;

                pnlCaptions.Controls.Add(captionLabel);

                /** FieldLabel **/
                var fieldLabel = ColumnBuilderService.BuildColumnLabel(viewListColumn, false);
                fieldLabel.ContextMenuStrip = ctxCaptionLabel;
                fieldLabel.Text = FormatSampleValue(
                    viewListColumn.ConvertedType,
                    viewListColumn.Format,
                    String.IsNullOrEmpty(viewListColumn.Sample) ?
                        viewListColumn.Caption :
                        viewListColumn.Sample);
                fieldLabel.AllowDrop = true;

                ConfigureResize(fieldLabel);
                ConfigureDragging(fieldLabel);

                pnlFields.Controls.Add(fieldLabel);

                // Ensure all columns except the fill column have a value for width
                if (stretchColumnIndex == null && viewListColumn.Width == null)
                    stretchColumnIndex = viewListColumn.Index;
                else if (stretchColumnIndex != null && viewListColumn.Width == null)
                    viewListColumn.Width = fieldLabel.Width;

                ColumnLabels.Add(new ColumnLabel()
                {
                    FieldLabel = fieldLabel,
                    CaptionLabel = captionLabel,
                    Column = viewListColumn,
                    DisplayIndex = viewListColumn.Index
                });
            }

            UpdateColumnAligmnents();
        }
        protected virtual void UpdateColumnAligmnents()
        {
            var stretchColumn = Context.ViewListColumns.FirstOrDefault(c => c.Width == null);
            UpdateColumnAligmnents(stretchColumn?.Index);
        }
        protected virtual void UpdateColumnAligmnents(int? stretchColumnIndex)
        {
            ColumnBuilderService.AlignControls(pnlCaptions.Controls, stretchColumnIndex);
            ColumnBuilderService.AlignControls(pnlFields.Controls, stretchColumnIndex);
        }

        protected virtual void UpdateViewListItems()
        {
            var captionLabels = pnlCaptions.Controls.OfType<Label>().ToList().OrderBy(l => l.Location.X);

            int i = 0;

            foreach (Label captionLabel in captionLabels)
            {
                var viewListColumnTag = (ListColumn)captionLabel.Tag;

                viewListColumnTag.Index = i;
                viewListColumnTag.Caption = captionLabel.Text;
                viewListColumnTag.Width = captionLabel.Width;
                viewListColumnTag.Alignment = captionLabel.TextAlign;
                viewListColumnTag.SortType = i == 0 ? SortType.Ascending : SortType.None;

                i++;
            }

            var listColumns = Context.ViewListColumns.OrderBy(v => v.Index).ToList();

            Context.ViewListColumns = new BindingList<ListColumn>(listColumns);
        }

        private void ConfigureResize(Label label)
        {
            PictureBox pictureBox1 = new PictureBox();
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Size = new Size(10, 10);
            pictureBox1.Location = new Point(label.Width - pictureBox1.Width, label.Height - pictureBox1.Height);
            pictureBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pictureBox1.Dock = DockStyle.Right;
            pictureBox1.Cursor = Cursors.SizeWE;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            pictureBox1.MouseUp += pictureBox1_MouseUp;
            label.Controls.Add(pictureBox1);
            pictureBox1.BringToFront();
        }

        protected virtual void UpdateValidation()
        {
            CanGoPrevious = !_isEditing;
            CanGoNext = !_isEditing && ValidateStep();
        }

        protected virtual void PopulateConvertToList()
        {
            var convertTargets = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string,string>("Don't convert", "NONE"),
                new KeyValuePair<string,string>("Timespan (for elapsed times)", TypeNames.TimeSpanTypeName)
            };
            cboConvertedType.DisplayMember = "Key";
            cboConvertedType.ValueMember = "Value";
            cboConvertedType.DataSource = convertTargets;
            cboConvertedType.SelectedIndex = 0;
        }

        protected virtual void BuildFormatListItemList()
        {
            _formatListItems.Add(new FormatListItem()
            {
                Type = TypeNames.Int32TypeName,
                HelpText = "Valid format characters are '#', '0', and ','\r\n" +
                "Example Formats:\r\n" +
                "##\r\n" +
                "##,###\r\n" +
                "0##"
            });
            _formatListItems.Add(new FormatListItem()
            {
                Type = TypeNames.DecimalTypeName,
                HelpText = "Valid format characters are '#', '0', '.', and ','\r\n" +
                "Example Formats:\r\n" +
                " ##.#0\r\n" +
                " ##,###.#0\r\n" +
                " 0##.###"
            });
            _formatListItems.Add(new FormatListItem()
            {
                Type = TypeNames.DoubleTypeName,
                HelpText = "Valid format characters are '#', '0', '.', and ','\r\n" +
                "Example Formats:\r\n" +
                " ##.#0\r\n" +
                " ##,###.#0\r\n" +
                " 0##.###"
            });
            _formatListItems.Add(new FormatListItem()
            {
                Type = TypeNames.TimeSpanTypeName,
                HelpText = "Valid format characters are 'd', 'h', 'm', 's', 'f' (fractional seconds), and\r\n" +
                "'\\:' and '\\.' (Separator characters must have a leading backspace).\r\n" +
                "Example Formats:\r\n" +
                " dd\\:hh\\:mm\\:ss (Days, hours, minutes, and seconds)r\n" +
                " mm\\:ss\\.fff (Minutes, seconds, and milliseconds)r\n"
            });
        }

        #endregion

        #region drag/drop    

        protected virtual void ConfigureDragging(Label ctl)
        {
            ctl.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    _dragPoint = e.Location;

                    dragTimer.Start();

                    _dragFrame.Size = ctl.Size;

                    Point pt = this.PointToClient(Cursor.Position);

                    _dragPointToClient = pt;

                    _dragFrame.Location = new Point(pt.X - _dragPoint.X,
                                                   pt.Y + 3);

                    if (_dragFrame.BackgroundImage != null)
                        _dragFrame.BackgroundImage.Dispose();
                    Bitmap bmp = new Bitmap(_dragFrame.ClientSize.Width,
                                            _dragFrame.ClientSize.Height);
                    ctl.DrawToBitmap(bmp, _dragFrame.ClientRectangle);
                    _dragFrame.BackgroundImage = bmp;

                    _dragFrame.BringToFront();
                    _dragFrame.Show();

                    ctl.DoDragDrop(ctl, DragDropEffects.Move);
                }
            };

            ctl.DragOver += (s, e) =>
            {
                e.Effect = DragDropEffects.Move;
            };

            ctl.MouseUp += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    _dragFrame.Hide();
                    dragTimer.Stop();
                }
            };

            ctl.Leave += (s, e) =>
            {
                _dragFrame.Hide();
                dragTimer.Stop();
            };

            ctl.DragDrop += pnlFields_DragDrop;
        }

        #endregion

        #region edit

        protected virtual void SelectColumn(int index)
        {
            SetUIEditState(false, index);
        }
        protected virtual void BeginEdit(int index)
        {
            SetUIEditState(true, index);
        }
        protected virtual void SaveChanges()
        {
            if (!_selectedFieldIndex.HasValue)
            {
                MessageBox.Show("No field selected!");
                return;
            }

            foreach (ColumnLabel columnLabel in ColumnLabels)
            {
                columnLabel.Column.Width = columnLabel.FieldLabel.Width;
            }

            var viewListColumn = Context.ViewListColumns[_selectedFieldIndex.Value];

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

            Context.ViewListColumns[_selectedFieldIndex.Value] = viewListColumn;

            SetUIEditState(false, null);
        }
        protected virtual void CancelEdit()
        {
            RevertColumnWidths();

            SetUIEditState(false);
        }

        protected virtual void SetUIEditState(bool isEditing, int? index = null)
        {
            if (FieldLabel != null)
                FieldLabel.SizeChanged -= selectedLabel_WidthChanged;

            _isLoadingFieldDetails = true;
            _selectedFieldIndex = index;

            if (isEditing)
                SaveColumnWidths();

            grpEditField.Enabled = isEditing;
            pnlFields.Enabled = !isEditing;
            pnlCaptions.Enabled = !isEditing;

            ClearSelectedColumn();

            if (index.HasValue)
                ColumnSelected(index.Value);

            ClearColumnDetails();

            if (index.HasValue)
                DisplayColumnDetails(index.Value);

            _isEditing = isEditing;
            _isLoadingFieldDetails = false;

            UpdateValidation();
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
            var viewListColumn = Context.ViewListColumns.FirstOrDefault(c => c.Index == index);

            txtColCaption.Text = viewListColumn.Caption;
            txtColType.Text = viewListColumn.Type;

            calAlignment.Alignment = viewListColumn.Alignment;
            chkStretch.Checked = !viewListColumn.Width.HasValue;
            txtWidth.Enabled = !chkStretch.Checked;
            txtWidth.Text = FieldLabel.Width.ToString();

            txtColFormat.Text = viewListColumn.Format;
            txtColTest.Text = viewListColumn.Sample;

            var format = _formatListItems.FirstOrDefault(f => f.Type == viewListColumn.ConvertedType);
            lblFormatHelp.Text = format?.HelpText;

            if (viewListColumn.Type == viewListColumn.ConvertedType)
            {
                cboConvertedType.SelectedIndex = -1;
            }
            else
            {
                cboConvertedType.SelectedItem = cboConvertedType.Items.OfType<KeyValuePair<string, string>>().FirstOrDefault(i => i.Value == viewListColumn.ConvertedType);
            }

            chkBorder.Checked = viewListColumn.HasBorder;

            TestFormat();
        }
        protected virtual void ClearColumnDetails()
        {
            txtColCaption.Clear();
            txtColFormat.Clear();
            txtColType.Clear();
            txtColTest.Clear();
            txtWidth.Clear();
            chkBorder.Checked = false;
            chkStretch.Checked = false;
            cboConvertedType.SelectedIndex = -1;
            calAlignment.Alignment = ContentAlignment.MiddleLeft;
            lblFormatHelp.Text = "";
        }

        private void SaveColumnWidths()
        {
            _preStretchWidths.Clear();

            foreach (ListColumn column in Context.ViewListColumns)
            {
                _preStretchWidths.Add(column.Width);
            }
        }
        private void RevertColumnWidths()
        {
            for (int i = 0; i < Context.ViewListColumns.Count; i++)
            {
                Context.ViewListColumns[i].Width = _preStretchWidths[i];
            }
        }

        private void TestFormat()
        {
            if (_isLoadingFieldDetails)
                return;

            Error = String.Empty;

            var fieldLabel = pnlFields.Controls.OfType<Label>().ElementAt(_selectedFieldIndex.Value);

            var viewListColumn = Context.ViewListColumns[_selectedFieldIndex.Value];

            var field = Context.ViewDataMembers[_selectedFieldIndex.Value];

            var type = String.IsNullOrEmpty(viewListColumn.ConvertedType) ? field.Type.Name : viewListColumn.ConvertedType;

            var formattedText = FormatSampleValue(type, txtColFormat.Text, txtColTest.Text);

            fieldLabel.Text = formattedText;
        }
        private string FormatSampleValue(string type, string format, string value)
        {
            return FieldFormatService.FormatValue(type, format, value);

            var formattedText = String.Empty;

            var typeName = type.Replace("System.", "");

            try
            {
                if (typeName == TypeNames.StringTypeName)
                {
                    formattedText = value;
                }
                else if (typeName == TypeNames.Int32TypeName)
                {
                    int buffer = 0;
                    if (!Int32.TryParse(value, out buffer))
                    {
                        formattedText = "--ERROR--";
                        Error = "Test value must be a integer.";
                    }
                    else
                    {
                        try
                        {
                            formattedText = buffer.ToString(format);
                        }
                        catch (FormatException)
                        {
                            formattedText = "--ERROR--";
                            Error = "Invalid format.\r\nValid format characters: '#', '0', and ','";
                        }
                    }
                }
                else if (typeName == TypeNames.DecimalTypeName || typeName == TypeNames.DoubleTypeName)
                {
                    double buffer = 0.0;
                    if (!double.TryParse(value, out buffer))
                    {
                        formattedText = "--ERROR--";
                        Error = "Test value must be a number, and may have values to the right of the decimal place.";
                    }
                    else
                    {
                        try
                        {
                            formattedText = buffer.ToString(format);
                        }
                        catch (FormatException)
                        {
                            formattedText = "--ERROR--";
                            Error = "Invalid format.\r\nValid format characters: '#', '0', ',', and '.'";
                        }
                    }
                }
                else if (typeName == TypeNames.TimeSpanTypeName)
                {
                    TimeSpan buffer = new TimeSpan();
                    if (!TimeSpan.TryParse(value, out buffer))
                    {
                        formattedText = "--ERROR--";
                        Error = "Test value must be a time interval.\r\nValid format characters: '#', '0', ',', and '.'";
                    }
                    else
                    {
                        try
                        {
                            formattedText = buffer.ToString(format);
                        }
                        catch (FormatException)
                        {
                            formattedText = "Invalid format";
                            Error = "Valid format characters: 'd', 'h', 'm', 's', 'f', '\\:', and '\\.'.\r\n" +
                                "':' and '.' must have a leading backslash (\\: and \\.)";
                        }
                    }
                }
                else if (typeName == TypeNames.RunTypeTypeName)
                {
                    formattedText = value;
                }
                else if (typeName == TypeNames.VehicleStatusTypeName)
                {
                    formattedText = value;
                }
                else if (typeName == TypeNames.FlagStateTypeName)
                {
                    formattedText = value;
                }
                else if (typeName == TypeNames.TrackStateTypeName)
                {
                    formattedText = value;
                }
                else
                {
                    throw new ArgumentException($"Unrecognized field type: {typeName}");
                }

            }
            catch (FormatException)
            {
                formattedText = "-ERROR-";
                Error = $"Invalid format for {typeName}";
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error formatting sample data", ex);
            }

            return formattedText;
        }

        #endregion

        #endregion

        #region private

        // resize
        private void pictureBox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _allowResize = true;
        }
        private void pictureBox1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (_allowResize)
            {
                PictureBox pictureBox = (PictureBox)sender;
                Label parent = (Label)pictureBox.Parent;
                parent.Width = pictureBox.Left + e.X;

                var captionLabelName = $"{parent.Name}Caption";
                Label captionLabel = pnlCaptions.Controls.OfType<Label>().FirstOrDefault(l => l.Name == captionLabelName);

                if (captionLabel != null)
                    captionLabel.Width = pictureBox.Left + e.X;
            }
        }
        private void pictureBox1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _allowResize = false;

            UpdateViewListItems();
        }

        // drag drop
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
            try
            {
                _dragFrame.Hide();

                dragTimer.Stop();

                Label movedLabel = e.Data.GetData(e.Data.GetFormats()[0]) as Label;

                Label droppedOnLabel = (Label)sender;

                var movedColumn = ColumnLabels.FirstOrDefault(c => c.FieldLabel.Name == movedLabel.Name).Column;
                var movedOriginalIndex = movedColumn.Index;

                var droppedOnColumn = ColumnLabels.FirstOrDefault(c => c.FieldLabel.Name == droppedOnLabel.Name).Column;
                var droppedOnIndex = droppedOnColumn.Index;

                if (movedOriginalIndex == droppedOnIndex)
                    return;

                if (movedOriginalIndex < droppedOnIndex)
                {
                    // moved to the right
                    foreach (ColumnLabel columnLabel in ColumnLabels.Where(c =>
                        c.DisplayIndex > movedOriginalIndex &&
                        c.DisplayIndex <= droppedOnIndex))
                    {
                        columnLabel.Column.Index -= 1;
                    }

                    movedColumn.Index = droppedOnIndex;
                }
                else if (movedOriginalIndex > droppedOnIndex)
                {
                    // moved to the left
                    foreach (ColumnLabel columnLabel in ColumnLabels.Where(c =>
                        c.DisplayIndex >= droppedOnIndex &&
                        c.DisplayIndex < movedOriginalIndex))
                    {
                        columnLabel.Column.Index += 1;
                    }
                    movedColumn.Index = droppedOnIndex;
                }

                UpdateColumnAligmnents();
            }
            catch (ArgumentException)
            {
                MessageBox.Show(this, "Can't move field here", "Invalid Move", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error moving field", ex);
            }
        }

        // edit
        private void btnCancelEditField_Click(object sender, EventArgs e)
        {
            CancelEdit();

            DisplayFields();
        }
        private void btnSaveEditedField_Click(object sender, EventArgs e)
        {
            SaveChanges();

            DisplayFields();
        }
        private void mnuEditField_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            ContextMenuStrip menuItemOwner = (ContextMenuStrip)menuItem.Owner;
            Label label = (Label)menuItemOwner.SourceControl;

            var selectedIndex = label.Parent.Controls.GetChildIndex(label);

            BeginEdit(selectedIndex);
        }

        protected virtual void selectedLabel_WidthChanged(object sender, EventArgs e)
        {
            txtWidth.Text = ((Label)sender).Width.ToString();
        }
        private void formatTest_TextChanged(object sender, EventArgs e)
        {
            TestFormat();
        }
        private void cboConvertedType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboConvertedType.SelectedItem == null ||
                _isLoadingFieldDetails ||
                !_selectedFieldIndex.HasValue)
                return;

            var viewListColumn = Context.ViewListColumns[_selectedFieldIndex.Value];
            var selectedConvertedType = (KeyValuePair<string, string>)cboConvertedType.SelectedItem;

            if (selectedConvertedType.Value == "NONE")
            {
                viewListColumn.ConvertedType = txtColType.Text;
            }
            else
            {
                viewListColumn.ConvertedType = selectedConvertedType.Value;
                if (selectedConvertedType.Value == TypeNames.TimeSpanTypeName)
                {
                    txtColFormat.Text = "ss\\.fff";
                    txtColTest.Text = "23.123";
                }
            }

            var format = _formatListItems.FirstOrDefault(f => f.Type == viewListColumn.ConvertedType);
            lblFormatHelp.Text = format?.HelpText;

            TestFormat();
        }
        private void txtColCaption_TextChanged(object sender, EventArgs e)
        {
            if (_isLoadingFieldDetails)
                return;

            CaptionLabel.Text = txtColCaption.Text;
        }
        private void calAlignment_AlignmentChanged(object sender, ContentAlignment e)
        {
            if (_isLoadingFieldDetails)
                return;

            FieldLabel.TextAlign = calAlignment.Alignment;
            CaptionLabel.TextAlign = calAlignment.Alignment;
        }
        private void chkBorder_CheckedChanged(object sender, EventArgs e)
        {
            if (_isLoadingFieldDetails)
                return;

            FieldLabel.BorderStyle = chkBorder.Checked ? BorderStyle.FixedSingle : BorderStyle.None;
            CaptionLabel.BorderStyle = chkBorder.Checked ? BorderStyle.FixedSingle : BorderStyle.None;
        }
        private void chkStretch_CheckedChanged(object sender, EventArgs e)
        {
            if (_isLoadingFieldDetails)
                return;

            if (chkStretch.Checked)
            {
                txtWidth.Enabled = false;

                foreach (ListColumn column in Context.ViewListColumns)
                {
                    if (column.Index != _selectedFieldIndex.Value)
                        column.Width = pnlFields.Controls.OfType<Label>().FirstOrDefault(c => ((ListColumn)c.Tag).Index == column.Index).Width;// ColumnLabels.FirstOrDefault(c => c.DisplayIndex == _selectedFieldIndex.Value).FieldLabel.Width;
                    else
                        column.Width = null;
                }

                UpdateColumnAligmnents();
            }
            else
            {
                txtWidth.Enabled = true;

                RevertColumnWidths();

                UpdateColumnAligmnents();
            }
        }
        private void txtWidth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (_selectedFieldIndex.HasValue)
                {
                    int width = 0;
                    var column = Context.ViewListColumns[_selectedFieldIndex.Value];
                    if (Int32.TryParse(txtWidth.Text, out width))
                    {
                        CaptionLabel.Width = width;
                        FieldLabel.Width = width;
                    }
                }
            }
        }
        private void txtWidth_Leave(object sender, EventArgs e)
        {
            if (_selectedFieldIndex.HasValue)
            {
                int width = 0;
                var column = Context.ViewListColumns[_selectedFieldIndex.Value];
                if (Int32.TryParse(txtWidth.Text, out width))
                {
                    CaptionLabel.Width = width;
                    FieldLabel.Width = width;
                }
            }
        }

        #endregion

        #region classes

        private class FormatListItem
        {
            public string Type { get; set; }
            public string HelpText { get; set; }
        }

        protected class ColumnLabel
        {
            public Label CaptionLabel { get; set; }
            public Label FieldLabel { get; set; }
            public ListColumn Column { get; set; }
            public int DisplayIndex
            {
                get
                {
                    return Column.Index;
                }
                set
                {
                    Column.Index = value;
                }
            }
        }
        #endregion
    }
}
