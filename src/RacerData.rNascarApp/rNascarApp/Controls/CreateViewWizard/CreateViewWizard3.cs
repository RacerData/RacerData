using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RacerData.rNascarApp.Factories;
using RacerData.rNascarApp.Models;
using RacerData.rNascarApp.Settings;

namespace RacerData.rNascarApp.Controls.CreateViewWizard
{
    public partial class CreateViewWizard3 : WizardStep
    {
        #region fields

        private IList<ViewListColumn> _viewListColumns = null;
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

        #endregion

        #region properties

        private IList<ViewDataMember> _dataMembers = null;
        public IList<ViewDataMember> DataMembers
        {
            get
            {
                return _dataMembers;
            }
            set
            {
                _dataMembers = value;
                OnPropertyChanged(nameof(DataMembers));
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

            _viewListColumns = CreateViewListColumnList();
        }

        #endregion

        #region public 

        public override object GetDataSource()
        {
            return _viewListColumns;
        }

        public override void SetDataObject(object data)
        {
            DataMembers = (IList<ViewDataMember>)data;
        }

        public override void ActivateStep()
        {
            base.ActivateStep();

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

            if (_viewListColumns == null || _viewListColumns.Count != DataMembers.Count)
            {
                isValid = true;
                Error = "List settings not configured";
            }

            return isValid;
        }

        #endregion

        #region protected

        protected virtual IList<ViewListColumn> CreateViewListColumnList()
        {
            var viewListColumns = new List<ViewListColumn>();

            int i = 0;

            foreach (ViewDataMember viewDataMember in DataMembers)
            {
                if (!_mapService.Map.ContainsKey(viewDataMember) || _mapService.Map[viewDataMember].Name == "Default")
                {
                    var newViewDisplayFormat = new ViewDisplayFormat()
                    {
                        Name = viewDataMember.Name
                    };

                    if (viewDataMember.Type.ToString() == "System.String")
                    {
                        newViewDisplayFormat.Sample = "Abcdefg Hijklmnop";
                    }
                    else if (viewDataMember.Type.ToString() == "System.Int32")
                    {
                        newViewDisplayFormat.Sample = "12345";
                        newViewDisplayFormat.Format = "###";
                    }
                    else if (viewDataMember.Type.ToString() == "System.Decimal" || viewDataMember.Type.ToString() == "System.Double")
                    {
                        newViewDisplayFormat.Sample = "123.456";
                        newViewDisplayFormat.Format = "###.##0";
                    }
                    else if (viewDataMember.Type.ToString() == "System.TimeSpan")
                    {
                        newViewDisplayFormat.Sample = "12:34:56.78";
                        newViewDisplayFormat.Format = "hh\\:mm\\:ss.fff";
                    }
                    else
                    {
                        Console.WriteLine($"Unrecognized field type: {viewDataMember.Type.ToString()}, field: {viewDataMember.Name}");
                    }

                    _mapService.Map[viewDataMember] = newViewDisplayFormat;
                }

                var viewDisplayFormat = _mapService.Map[viewDataMember];

                viewListColumns.Add(new ViewListColumn()
                {
                    Index = i,
                    Alignment = viewDisplayFormat.ContentAlignment,
                    Caption = viewDataMember.Caption,
                    Format = viewDisplayFormat.Format,
                    Sample = viewDisplayFormat.Sample,
                    Width = viewDisplayFormat.MaxWidth,
                    Type = viewDataMember.Type,
                    ConvertedType = viewDataMember.ConvertedType,
                    SortType = i == 0 ? SortType.Ascending : SortType.None,
                    DataMember = viewDataMember.Name,
                    DataFullPath = viewDataMember.Path,
                    DataFeed = viewDataMember.DataFeed,
                    DataFeedAssemblyQualifiedName = viewDataMember.DataFeedTypeAssemblyQualifiedName,
                    DataFeedFullName = viewDataMember.DataFeedTypeFullName
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

            foreach (ViewListColumn viewListColumn in _viewListColumns)
            {
                var captionLabel = GetCaptionLabel(viewListColumn);
                pnlCaptions.Controls.Add(captionLabel);

                var fieldLabel = GetLabel(viewListColumn);
                pnlFields.Controls.Add(fieldLabel);
            }
        }

        protected virtual void UpdateViewListItems()
        {
            var captionLabels = pnlCaptions.Controls.OfType<Label>().ToList().OrderBy(l => l.Location.X);

            int i = 0;

            foreach (Label captionLabel in captionLabels)
            {
                var viewListColumnTag = (ViewListColumn)captionLabel.Tag;

                viewListColumnTag.Index = i;
                viewListColumnTag.Caption = captionLabel.Text;
                viewListColumnTag.Width = captionLabel.Width;
                viewListColumnTag.Alignment = captionLabel.TextAlign;
                viewListColumnTag.SortType = i == 0 ? SortType.Ascending : SortType.None;

                i++;
            }

            _viewListColumns = _viewListColumns.OrderBy(v => v.Index).ToList();
        }

        protected virtual Label GetCaptionLabel(ViewListColumn viewListColumn)
        {
            Label label = new Label();

            label.Size = new Size(
                viewListColumn.Width.HasValue ? viewListColumn.Width.Value : 100,
                pnlFields.Height);
            label.Text = viewListColumn.Caption;
            label.Name = "lbl" + viewListColumn.DataMember + "Caption";
            label.TextAlign = viewListColumn.Alignment;
            label.ForeColor = _labelForeColor;
            label.BackColor = _unselectedCaptionBackColor;
            label.BorderStyle = BorderStyle.FixedSingle;
            label.Margin = new Padding(0, 0, 0, 0);
            label.Tag = viewListColumn;
            label.ContextMenuStrip = ctxCaptionLabel;
            label.DoubleClick += (s, e) =>
            {
                SetUIEditState(false, viewListColumn.Index);
            };

            return label;
        }

        protected virtual Label GetLabel(ViewListColumn viewListColumn)
        {
            Label label = new Label();

            label.Text = FormatSampleValue(
                viewListColumn.ConvertedType,
                viewListColumn.Format,
                String.IsNullOrEmpty(viewListColumn.Sample) ?
                    viewListColumn.Caption :
                    viewListColumn.Sample);

            label.Size = new Size(
                viewListColumn.Width.HasValue ? viewListColumn.Width.Value : 100,
                pnlFields.Height);
            label.Name = "lbl" + viewListColumn.DataMember;
            label.TextAlign = viewListColumn.Alignment;
            label.ForeColor = _labelForeColor;
            label.BackColor = _unselectedFieldBackColor;
            label.BorderStyle = BorderStyle.FixedSingle;
            label.Margin = new Padding(0, 0, 0, 0);
            label.Tag = viewListColumn;
            label.ContextMenuStrip = ctxCaptionLabel;

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

            ConfigureDragging(label);

            return label;
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

        private void pictureBox1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _allowResize = false;

            ResetCaptionSizes();

            UpdateViewListItems();
        }
        private void pictureBox1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (_allowResize)
            {
                PictureBox pictureBox = (PictureBox)sender;
                Label parent = (Label)pictureBox.Parent;
                parent.Width = pictureBox.Left + e.X;
            }
        }
        private void pictureBox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _allowResize = true;
        }

        private void ResetCaptionSizes()
        {
            for (int i = 0; i < pnlFields.Controls.Count; i++)
            {
                var fieldLabel = pnlFields.Controls[i];
                var captionLabel = pnlCaptions.Controls[i];

                captionLabel.Size = fieldLabel.Size;
            }
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
                    ctl.DoDragDrop(ctl, DragDropEffects.Copy | DragDropEffects.Move);
                }
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
        private void pnlFields_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        private void pnlFields_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                _dragFrame.Hide();
                dragTimer.Stop();
                Label controlBase = e.Data.GetData(e.Data.GetFormats()[0]) as Label;
                bool inserted = false;
                if (controlBase != null)
                {
                    var hitPoint = this.pnlFields.PointToClient(new Point(e.X, e.Y));
                    var dragPoint = this.pnlFields.PointToClient(_dragPoint);

                    IList<Label> labelBuffer = new List<Label>();

                    var originalLabels = pnlFields.
                        Controls.
                        OfType<Label>().
                        Where(l => l.Name != controlBase.Name).
                        OrderBy(l => l.Location.X).
                        ToList();

                    for (int i = 0; i < originalLabels.Count; i++)
                    {
                        var target = originalLabels[i];

                        if (!inserted && hitPoint.X < target.Location.X)
                        {
                            labelBuffer.Add(controlBase);
                            labelBuffer.Add(target);
                            inserted = true;
                        }
                        else if (!inserted && hitPoint.X >= target.Location.X && hitPoint.X <= target.Location.X + target.Width)
                        {
                            if (_dragPointToClient.X < hitPoint.X)
                            {
                                labelBuffer.Add(target);
                                labelBuffer.Add(controlBase);
                            }
                            else
                            {
                                labelBuffer.Add(controlBase);
                                labelBuffer.Add(target);
                            }
                            inserted = true;
                        }
                        else
                        {
                            labelBuffer.Add(target);
                        }
                    }

                    if (!inserted)
                    {
                        labelBuffer.Add(controlBase);
                    }

                    var captionLabels = pnlCaptions.Controls.OfType<Label>().ToList();

                    pnlFields.Controls.Clear();
                    pnlCaptions.Controls.Clear();

                    int offset = 0;
                    for (int i = 0; i < labelBuffer.Count; i++)
                    {
                        var target = labelBuffer[i];
                        var targetCaption = captionLabels.FirstOrDefault(l => l.Name == target.Name + "Caption");
                        target.Location = new Point(pnlFields.Margin.Left + offset, target.Location.Y);
                        targetCaption.Location = new Point(pnlCaptions.Margin.Left + offset, target.Location.Y);
                        pnlFields.Controls.Add(target);
                        pnlCaptions.Controls.Add(targetCaption);
                        offset += target.Width;
                    }

                    UpdateViewListItems();
                }
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

            var viewListColumn = _viewListColumns[_selectedFieldIndex.Value];

            viewListColumn.Caption = txtColCaption.Text;

            viewListColumn.Alignment = rbLeft.Checked ?
                ContentAlignment.MiddleLeft :
                rbCenter.Checked ?
                ContentAlignment.MiddleCenter :
                ContentAlignment.MiddleRight;

            viewListColumn.Format = txtColFormat.Text;
            viewListColumn.Sample = txtColTest.Text;

            SetUIEditState(false, _selectedFieldIndex.Value);
        }
        protected virtual void CancelEdit()
        {
            SetUIEditState(false);
        }
        protected virtual void SetUIEditState(bool isEditing, int? index = null)
        {
            _isLoadingFieldDetails = true;

            grpEditField.Enabled = isEditing;
            pnlFields.Enabled = !isEditing;
            pnlCaptions.Enabled = !isEditing;

            ClearSelectedColumn();

            if (index.HasValue)
                ColumnSelected(index.Value);

            ClearColumnDetails();

            if (index.HasValue)
                DisplayColumnDetails(index.Value);

            _selectedFieldIndex = index;
            _isEditing = isEditing;
            _isLoadingFieldDetails = false;

            UpdateValidation();
        }
        protected virtual void ColumnSelected(int index)
        {
            var fieldLabel = pnlFields.Controls.OfType<Label>().ElementAt(index);
            var captionLabel = pnlCaptions.Controls.OfType<Label>().ElementAt(index);

            fieldLabel.BackColor = _selectedBackColor;
            captionLabel.BackColor = _selectedBackColor;
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
            var viewListColumn = _viewListColumns[index];

            txtColCaption.Text = viewListColumn.Caption;
            txtColType.Text = viewListColumn.Type;

            rbLeft.Checked = (viewListColumn.Alignment == ContentAlignment.MiddleLeft);
            rbCenter.Checked = (viewListColumn.Alignment == ContentAlignment.MiddleCenter);
            rbRight.Checked = (viewListColumn.Alignment == ContentAlignment.MiddleRight);

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

            TestFormat();
        }
        protected virtual void ClearColumnDetails()
        {
            txtColCaption.Clear();
            txtColFormat.Clear();
            txtColType.Clear();
            txtColTest.Clear();
            cboConvertedType.SelectedIndex = -1;
            rbLeft.Checked = true;
        }
        private void TestFormat()
        {
            if (_isLoadingFieldDetails)
                return;

            Error = String.Empty;

            var fieldLabel = pnlFields.Controls.OfType<Label>().ElementAt(_selectedFieldIndex.Value);

            var viewListColumn = _viewListColumns[_selectedFieldIndex.Value];

            var field = DataMembers[_selectedFieldIndex.Value];

            var type = String.IsNullOrEmpty(viewListColumn.ConvertedType) ? field.Type : viewListColumn.ConvertedType;

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

        private void FormatTest_TextChanged(object sender, EventArgs e)
        {
            TestFormat();
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
        private void txtColCaption_TextChanged(object sender, EventArgs e)
        {
            if (_isLoadingFieldDetails)
                return;

            var captionLabel = pnlCaptions.Controls.OfType<Label>().ElementAt(_selectedFieldIndex.Value);
            captionLabel.Text = txtColCaption.Text;
        }
        private void rbAlignmentControls_CheckedChanged(object sender, EventArgs e)
        {
            if (_isLoadingFieldDetails)
                return;

            RadioButton radioButton = (RadioButton)sender;

            if (radioButton.Checked)
            {
                var fieldLabel = pnlFields.Controls.OfType<Label>().ElementAt(_selectedFieldIndex.Value);
                var captionLabel = pnlCaptions.Controls.OfType<Label>().ElementAt(_selectedFieldIndex.Value);

                ContentAlignment alignment = rbLeft.Checked ?
                   ContentAlignment.MiddleLeft :
                   rbCenter.Checked ?
                   ContentAlignment.MiddleCenter :
                   ContentAlignment.MiddleRight;

                fieldLabel.TextAlign = alignment;
                captionLabel.TextAlign = alignment;
            }
        }
        private void cboConvertedType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboConvertedType.SelectedItem == null ||
                _isLoadingFieldDetails ||
                !_selectedFieldIndex.HasValue)
                return;

            var viewListColumn = _viewListColumns[_selectedFieldIndex.Value];
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
            lblFormatHelp.Text = format.HelpText;

            TestFormat();
        }

        #endregion

        #region classes

        private class FormatListItem
        {
            public string Type { get; set; }
            public string HelpText { get; set; }
        }

        #endregion
    }
}
