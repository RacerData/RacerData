using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
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

        private IList<ColumnLabel> _columnLabels = new List<ColumnLabel>();
        protected IList<ColumnLabel> ColumnLabels
        {
            get
            {
                return _columnLabels;
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

            CreateViewContext.ViewListColumns = new BindingList<ListColumn>(listColumns);
        }

        #endregion

        #region public 

        public override void ActivateStep()
        {
            base.ActivateStep();

            if (CreateViewContext.ViewListColumns.Count == 0)
                CreateViewContext.ViewListColumns = new BindingList<ListColumn>(BuildListColumnsList());

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

            if (CreateViewContext.ViewListColumns == null || CreateViewContext.ViewListColumns.Count != CreateViewContext.ViewDataMembers.Count)
            {
                isValid = true;
                Error = "List settings not configured";
            }

            return isValid;
        }

        #endregion

        #region protected

        protected virtual IList<ListColumn> BuildListColumnsList()
        {
            var viewListColumns = new List<ListColumn>();

            int i = 0;

            foreach (ViewDataMember viewDataMember in CreateViewContext.ViewDataMembers)
            {
                if (!_mapService.Map.ContainsKey(viewDataMember) || _mapService.Map[viewDataMember].Name == "Default")
                {
                    var newViewDisplayFormat = new ViewDisplayFormat()
                    {
                        Name = viewDataMember.Name
                    };

                    if (viewDataMember.Type.Name.ToString() == "System.String")
                    {
                        newViewDisplayFormat.Sample = "Abcdefg Hijklmnop";
                    }
                    else if (viewDataMember.Type.Name.ToString() == "System.Int32")
                    {
                        newViewDisplayFormat.Sample = "12345";
                        newViewDisplayFormat.Format = "###";
                    }
                    else if (viewDataMember.Type.Name.ToString() == "System.Decimal" || viewDataMember.Type.Name.ToString() == "System.Double")
                    {
                        newViewDisplayFormat.Sample = "123.456";
                        newViewDisplayFormat.Format = "###.##0";
                    }
                    else if (viewDataMember.Type.Name.ToString() == "System.TimeSpan")
                    {
                        newViewDisplayFormat.Sample = "12:34:56.78";
                        newViewDisplayFormat.Format = "hh\\:mm\\:ss.fff";
                    }
                    else
                    {
                        Console.WriteLine($"Unrecognized field type: {viewDataMember.Type.Name.ToString()}, field: {viewDataMember.Name}");
                    }

                    _mapService.Map[viewDataMember] = newViewDisplayFormat;
                }

                var viewDisplayFormat = _mapService.Map[viewDataMember];

                viewListColumns.Add(new ListColumn()
                {
                    Index = i,
                    Alignment = viewDisplayFormat.ContentAlignment,
                    Caption = viewDataMember.Caption,
                    Format = viewDisplayFormat.Format,
                    Sample = viewDisplayFormat.Sample,
                    Width = viewDisplayFormat.MaxWidth,
                    Type = viewDataMember.Type.Name,
                    ConvertedType = viewDataMember.ConvertedType.Name,
                    SortType = i == 0 ? SortType.Ascending : SortType.None,
                    DataMember = viewDataMember.Name,
                    DataPath = viewDataMember.Path,
                    DataFeed = viewDataMember.DataFeed
                });

                i++;
            }

            _mapService.Save();

            return viewListColumns;
        }

        protected virtual void DisplayFields()
        {
            pnlFields.Controls.Clear();
            pnlCaptions.Controls.Clear();
            ColumnLabels.Clear();

            int? stretchColumnIndex = null;

            foreach (ListColumn viewListColumn in CreateViewContext.ViewListColumns.OrderBy(c => c.Index))
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
                //captionLabel.Text = $"[{viewListColumn.Index}]" +
                // $"[{((ListColumn)captionLabel.Tag).Index}] " +
                // $"{captionLabel.Dock} {viewListColumn.Caption}";

                //captionLabel.DockChanged += (s, e) =>
                //{
                //    ((Label)s).Text = $"[{viewListColumn.Index}]" +
                //        $"[{((ListColumn)((Label)s).Tag).Index}] " +
                //        $"{((Label)s).Dock} {((Label)s).Name}";
                //};
                //captionLabel.LocationChanged += (s, e) =>
                //{
                //    ((Label)s).Text = $"[{viewListColumn.Index}]" +
                //        $"[{((ListColumn)((Label)s).Tag).Index}] " +
                //        $"{((Label)s).Dock} {((Label)s).Name}";
                //};

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
                //fieldLabel.Text = $"[{viewListColumn.Index}]" +
                //   $"[{((ListColumn)fieldLabel.Tag).Index}] " +
                //   $"{fieldLabel.Dock}  {viewListColumn.Caption}";

                //fieldLabel.DockChanged += (s, e) =>
                //{
                //    ((Label)s).Text = $"[{viewListColumn.Index}]" +
                //        $"[{((ListColumn)((Label)s).Tag).Index}] " +
                //        $"{((Label)s).Dock} {((Label)s).Name}";
                //};
                //fieldLabel.LocationChanged += (s, e) =>
                //{
                //    ((Label)s).Text = $"[{viewListColumn.Index}]" +
                //        $"[{((ListColumn)((Label)s).Tag).Index}] " +
                //        $"{((Label)s).Dock} {((Label)s).Name}";
                //};
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
            var stretchColumn = CreateViewContext.ViewListColumns.FirstOrDefault(c => c.Width == null);
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

            var listColumns = CreateViewContext.ViewListColumns.OrderBy(v => v.Index).ToList();

            CreateViewContext.ViewListColumns = new BindingList<ListColumn>(listColumns);
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

        #region resize

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

                Label captionLabel = GetCaptionLabel(parent);
                if (captionLabel != null)
                    captionLabel.Width = pictureBox.Left + e.X;
            }
        }
        private void pictureBox1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _allowResize = false;

            UpdateViewListItems();
        }

        private Label GetCaptionLabel(Label fieldLabel)
        {
            var captionLabelName = $"{fieldLabel.Name}Caption";
            return pnlCaptions.Controls.OfType<Label>().FirstOrDefault(l => l.Name == captionLabelName);
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
        protected virtual void DragTimer_Tick(object sender, EventArgs e)
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

            var viewListColumn = CreateViewContext.ViewListColumns[_selectedFieldIndex.Value];

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

            CreateViewContext.ViewListColumns[_selectedFieldIndex.Value] = viewListColumn;

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
                FieldLabel.SizeChanged -= SelectedLabelWidthChanged;

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

            FieldLabel.SizeChanged += SelectedLabelWidthChanged;
        }
        protected virtual void ClearSelectedColumn()
        {
            for (int i = 0; i < pnlFields.Controls.OfType<Label>().Count(); i++)
            {
                pnlFields.Controls.OfType<Label>().ElementAt(i).BackColor = _unselectedFieldBackColor;
                pnlCaptions.Controls.OfType<Label>().ElementAt(i).BackColor = _unselectedCaptionBackColor;
            }
        }
        protected virtual void SelectedLabelWidthChanged(object sender, EventArgs e)
        {
            txtWidth.Text = ((Label)sender).Width.ToString();
        }
        protected virtual void DisplayColumnDetails(int index)
        {
            var viewListColumn = CreateViewContext.ViewListColumns.FirstOrDefault(c => c.Index == index);

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

            foreach (ListColumn column in CreateViewContext.ViewListColumns)
            {
                _preStretchWidths.Add(column.Width);
            }
        }
        private void RevertColumnWidths()
        {
            for (int i = 0; i < CreateViewContext.ViewListColumns.Count; i++)
            {
                CreateViewContext.ViewListColumns[i].Width = _preStretchWidths[i];
            }
        }

        private Label GetFieldLabel(int index)
        {
            return pnlFields.Controls.OfType<Label>().ElementAt(index);
        }
        private Label GetCaptionLabel(int index)
        {
            return pnlCaptions.Controls.OfType<Label>().ElementAt(index);
        }

        private void TestFormat()
        {
            if (_isLoadingFieldDetails)
                return;

            Error = String.Empty;

            var fieldLabel = pnlFields.Controls.OfType<Label>().ElementAt(_selectedFieldIndex.Value);

            var viewListColumn = CreateViewContext.ViewListColumns[_selectedFieldIndex.Value];

            var field = CreateViewContext.ViewDataMembers[_selectedFieldIndex.Value];

            var type = String.IsNullOrEmpty(viewListColumn.ConvertedType) ? field.Type.Name : viewListColumn.ConvertedType;

            var formattedText = FormatSampleValue(type, txtColFormat.Text, txtColTest.Text);

            fieldLabel.Text = formattedText;
        }
        private string FormatSampleValue(string type, string format, string value)
        {
            var formattedText = String.Empty;

            try
            {
                if (type == TypeNames.StringTypeName)
                {
                    formattedText = value;
                }
                else if (type == TypeNames.Int32TypeName)
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
                else if (type == TypeNames.DecimalTypeName || type == TypeNames.DoubleTypeName)
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
                else if (type == TypeNames.TimeSpanTypeName)
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
                else if (type == TypeNames.RunTypeTypeName)
                {
                    formattedText = value;
                }
                else if (type == TypeNames.VehicleStatusTypeName)
                {
                    formattedText = value;
                }
                else if (type == TypeNames.FlagStateTypeName)
                {
                    formattedText = value;
                }
                else
                {
                    Console.WriteLine($"Unrecognized field type: {type}");
                }

            }
            catch (FormatException)
            {
                formattedText = "-ERROR-";
                Error = $"Invalid format for {type}";
            }
            catch (Exception)
            {
                throw;
            }

            return formattedText;
        }

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

        private void FormatTest_TextChanged(object sender, EventArgs e)
        {
            TestFormat();
        }
        private void cboConvertedType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboConvertedType.SelectedItem == null ||
                _isLoadingFieldDetails ||
                !_selectedFieldIndex.HasValue)
                return;

            var viewListColumn = CreateViewContext.ViewListColumns[_selectedFieldIndex.Value];
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
                    txtColFormat.Text = "hh\\:mm\\:ss\\.fff";
                    txtColTest.Text = "00:15:23.123";
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

                foreach (ListColumn column in CreateViewContext.ViewListColumns)
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
                    var column = CreateViewContext.ViewListColumns[_selectedFieldIndex.Value];
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
                var column = CreateViewContext.ViewListColumns[_selectedFieldIndex.Value];
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

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"-> {(_selectedFieldIndex.HasValue ? _selectedFieldIndex.Value.ToString() : "null")}");
            foreach (ListColumn column in CreateViewContext.ViewListColumns.OrderBy(c => c.Index))
            {
                Console.WriteLine($"{column.Index} {column.Width}");
            }
        }
    }
}
