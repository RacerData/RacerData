using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RacerData.rNascarApp.Dialogs;
using RacerData.rNascarApp.Models;
using RacerData.rNascarApp.Settings;
using RacerData.rNascarApp.Themes;

namespace RacerData.rNascarApp.Controls.CreateViewWizard
{
    public partial class CreateViewWizard4 : WizardStep
    {
        #region consts

        private const string NewViewNamePrompt = "<View Title>";

        #endregion

        #region fields

        private IList<FlowLayoutPanel> _oddPanels = new List<FlowLayoutPanel>();
        private IList<FlowLayoutPanel> _evenPanels = new List<FlowLayoutPanel>();

        private ViewState _newViewState = null;
        private List<Theme> _themes = null;

        private bool _isSaved = false;
        private bool _isLoading = true;

        private Font _fieldsFont = null;
        private Font _fields1Font = null;
        private Font _captionFont = null;
        private Font _titleFont = null;

        private Color _fieldsBackColor = Color.Empty;
        private Color _fields1BackColor = Color.Empty;
        private Color _captionBackColor = Color.Empty;
        private Color _titleBackColor = Color.Empty;

        private Color _fieldsForeColor = Color.Empty;
        private Color _fields1ForeColor = Color.Empty;
        private Color _captionForeColor = Color.Empty;
        private Color _titleForeColor = Color.Empty;

        private Color _viewContainerBackColor = Color.Empty;
        private Color _labelForeColor = Color.Black;
        private Color _unselectedCaptionBackColor = Color.FromKnownColor(KnownColor.Control);
        private Color _unselectedFieldBackColor = Color.White;
        private Color _selectedBackColor = Color.Yellow;
        private Theme _theme = null;

        #endregion

        #region properties

        private bool _canSave = false;
        public bool CanSave
        {
            get
            {
                return _canSave;
            }
            set
            {
                _canSave = value;
                OnPropertyChanged(nameof(CanSave));
            }
        }

        protected virtual bool NameIsSet
        {
            get
            {
                return (!String.IsNullOrEmpty(lblViewTitle.Text) && lblViewTitle.Text != NewViewNamePrompt);
            }
        }

        protected virtual bool ThemeIsSet
        {
            get
            {
                return (_theme != null);
            }
        }

        #endregion

        #region ctor/load

        public CreateViewWizard4()
        {
            InitializeComponent();

            Index = 3;
            Name = "Set Name and Theme";
            Caption = "Select the name and theme for the new view, then click 'Save' to finish";
            Details = "Select the name and the theme for the new view.";
            Error = String.Empty;
        }

        private void CreateViewWizard4_Load(object sender, EventArgs e)
        {
            lblCaption.Text = Caption;

            lblViewTitle.Text = NewViewNamePrompt;

            _viewContainerBackColor = pnlListView.BackColor;

            _fieldsFont = pnlFields.Font;
            _fields1Font = pnlFields1.Font;
            _captionFont = pnlCaptions.Font;
            _titleFont = pnlViewTitle.Font;

            _fieldsBackColor = pnlFields.BackColor;
            _fields1BackColor = pnlFields1.BackColor;
            _captionBackColor = pnlCaptions.BackColor;
            _titleBackColor = pnlViewTitle.BackColor;

            _fieldsForeColor = pnlFields.ForeColor;
            _fields1ForeColor = pnlFields1.ForeColor;
            _captionForeColor = pnlCaptions.ForeColor;
            _titleForeColor = pnlViewTitle.ForeColor;

            btnSaveView.DataBindings.Add(new Binding("Enabled", this, "CanSave"));

            _themes = new List<Theme>();
            _themes.Add(new Theme() { Name = "None", Id = Guid.Empty });

            var userThemes = UserThemeRepository.GetThemes();

            _themes.AddRange(userThemes.OrderBy(t => t.Name));

            DisplayThemeList();

            _evenPanels.Add(pnlFields);
            _evenPanels.Add(ClonePanel(pnlFields));
            _evenPanels.Add(ClonePanel(pnlFields));
            _evenPanels.Add(ClonePanel(pnlFields));

            _oddPanels.Add(pnlFields1);
            _oddPanels.Add(ClonePanel(pnlFields1));
            _oddPanels.Add(ClonePanel(pnlFields1));
            _oddPanels.Add(ClonePanel(pnlFields1));

            for (int i = 2; i < _evenPanels.Count + _evenPanels.Count; i++)
            {
                var evenOdd = i % 2;
                var idx = (int)(i / 2);

                if (evenOdd == 1)
                {
                    pnlListView.Controls.Add(_oddPanels[idx]);
                }
                else
                {
                    pnlListView.Controls.Add(_evenPanels[idx]);
                }
            }
        }

        #endregion

        #region public

        public ViewState GetViewState()
        {
            return _newViewState;
        }

        public override void ActivateStep()
        {
            _isLoading = true;

            base.ActivateStep();

            DisplayNewView();

            UpdateValidation();

            _isLoading = false;
        }

        public override bool ValidateStep()
        {
            bool isValid = true;
            Error = "";

            if (!NameIsSet)
            {
                isValid = false;
                Error = "Name has not been set";
            }
            else if (!ThemeIsSet)
            {
                isValid = false;
                Error = "Theme has not been set";
            }
            else if (!_isSaved)
            {
                isValid = false;
                Error = "View not saved";
            }

            return isValid;
        }

        #endregion

        #region protected

        protected virtual FlowLayoutPanel ClonePanel(FlowLayoutPanel source)
        {
            var panel = new FlowLayoutPanel()
            {
                Size = source.Size,
                Dock = source.Dock,
                BorderStyle = source.BorderStyle,
                Padding = source.Padding,
                Margin = source.Margin,
                Font = source.Font,
                BackColor = source.BackColor,
                ForeColor = source.ForeColor
            };

            return panel;
        }

        protected virtual void UpdateMaxRows(int maxRows)
        {
            int i = 0;
            foreach (FlowLayoutPanel panel in pnlListView.Controls.OfType<FlowLayoutPanel>().ToList().Skip(1))
            {
                panel.Visible = (i < maxRows);
                i++;
            }
        }

        protected virtual void UpdateValidation()
        {
            CanSave = NameIsSet && ThemeIsSet;
            CanGoPrevious = true;
            CanGoNext = ValidateStep();
        }

        protected virtual void DisplayThemeList()
        {
            cboThemes.DataSource = null;
            cboThemes.DisplayMember = "Name";
            cboThemes.DataSource = _themes;
            cboThemes.SelectedIndex = 0;
        }

        protected virtual void ApplyTheme(Theme theme)
        {
            if (_isLoading)
                return;

            pnlViewTitle.BackColor = theme.HeaderBackColor;
            pnlViewTitle.ForeColor = theme.HeaderForeColor;
            pnlViewTitle.Font = theme.HeaderFont;

            foreach (Label label in pnlViewTitle.Controls.OfType<Label>())
            {
                label.BackColor = theme.HeaderBackColor;
                label.ForeColor = theme.HeaderForeColor;
                label.Font = theme.HeaderFont;
            }

            pnlCaptions.BackColor = theme.GridColumnHeaderBackColor;
            pnlCaptions.ForeColor = theme.GridColumnHeaderForeColor;
            pnlCaptions.Font = theme.GridColumnHeaderFont;

            foreach (Label label in pnlCaptions.Controls.OfType<Label>())
            {
                label.BackColor = theme.GridColumnHeaderBackColor;
                label.ForeColor = theme.GridColumnHeaderForeColor;
                label.Font = theme.GridColumnHeaderFont;
            }

            foreach (FlowLayoutPanel evenPanel in _evenPanels)
            {
                evenPanel.BackColor = theme.PrimaryBackColor;
                evenPanel.ForeColor = theme.PrimaryForeColor;
                evenPanel.Font = theme.GridFont;

                foreach (Label label in evenPanel.Controls.OfType<Label>())
                {
                    label.BackColor = theme.PrimaryBackColor;
                    label.ForeColor = theme.PrimaryForeColor;
                    label.Font = theme.GridFont;
                }
            }

            foreach (FlowLayoutPanel oddPanel in _oddPanels)
            {
                oddPanel.BackColor = theme.SecondaryBackColor;
                oddPanel.ForeColor = theme.SecondaryForeColor;
                oddPanel.Font = theme.GridFont;

                foreach (Label label in oddPanel.Controls.OfType<Label>())
                {
                    label.BackColor = theme.SecondaryBackColor;
                    label.ForeColor = theme.SecondaryForeColor;
                    label.Font = theme.GridFont;
                }
            }

            _theme = theme;

            this.Invalidate();
        }

        protected virtual void ClearTheme()
        {
            pnlListView.BackColor = _viewContainerBackColor;

            _viewContainerBackColor = pnlListView.BackColor;

            pnlFields.Font = _fieldsFont;
            pnlFields1.Font = _fields1Font;
            pnlCaptions.Font = _captionFont;
            pnlViewTitle.Font = _titleFont;

            pnlFields.BackColor = _fieldsBackColor;
            pnlFields1.BackColor = _fields1BackColor;
            pnlCaptions.BackColor = _captionBackColor;
            pnlViewTitle.BackColor = _titleBackColor;

            pnlFields.ForeColor = _fieldsForeColor;
            pnlFields1.ForeColor = _fields1ForeColor;
            pnlCaptions.ForeColor = _captionForeColor;
            pnlViewTitle.ForeColor = _titleForeColor;

            DisplayFields();
        }

        protected virtual void DisplayFields()
        {
            pnlCaptions.Controls.Clear();
            foreach (ListColumn viewListColumn in CreateViewContext.ViewListColumns)
            {
                var captionLabel = GetCaptionLabel(viewListColumn);
                pnlCaptions.Controls.Add(captionLabel);
            }

            foreach (var panel in _evenPanels)
            {
                panel.Controls.Clear();

                foreach (ListColumn viewListColumn in CreateViewContext.ViewListColumns)
                {
                    var fieldLabel = GetLabel(viewListColumn);
                    panel.Controls.Add(fieldLabel);
                }
            }

            foreach (var panel in _oddPanels)
            {
                panel.Controls.Clear();

                foreach (ListColumn viewListColumn in CreateViewContext.ViewListColumns)
                {
                    var fieldLabel = GetLabel(viewListColumn);
                    panel.Controls.Add(fieldLabel);
                }
            }

            //foreach (ViewListColumn viewListColumn in _viewListColumns)
            //{
            //    var captionLabel = GetCaptionLabel(viewListColumn);
            //    pnlCaptions.Controls.Add(captionLabel);

            //    var fieldLabel = GetLabel(viewListColumn);
            //    pnlFields.Controls.Add(fieldLabel);

            //    var fieldLabel1 = GetLabel(viewListColumn);
            //    pnlFields1.Controls.Add(fieldLabel1);
            //}
        }

        protected virtual void DisplayNewView()
        {
            DisplayFields();
        }

        protected virtual Label GetCaptionLabel(ListColumn viewListColumn)
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
            label.BorderStyle = BorderStyle.None;
            label.Margin = new Padding(0, 0, 0, 0);
            label.Tag = viewListColumn;

            return label;
        }

        protected virtual Label GetLabel(ListColumn viewListColumn)
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
            label.BorderStyle = BorderStyle.None;
            label.Margin = new Padding(0, 0, 0, 0);
            label.Tag = viewListColumn;

            return label;
        }

        protected virtual void SetViewTitle()
        {
            try
            {
                var currentName = lblViewTitle.Text == NewViewNamePrompt ? "<New View>" : lblViewTitle.Text;
                using (var dialog = new InputDialog(
                    "New View",
                    "Enter a name for the new view",
                    currentName))
                {
                    if (dialog.ShowDialog(this) != DialogResult.Cancel)
                    {
                        lblViewTitle.Text = dialog.Value;

                        UpdateValidation();
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler("Error setting name for new view", ex);
            }
        }

        protected virtual string FormatSampleValue(string type, string format, string value)
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
                    throw new ArgumentException($"Unrecognized field type: {type}");
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

        protected virtual void SaveView()
        {
            _newViewState = new ViewState()
            {
                Name = lblViewTitle.Text
            };

            UpdateViewState(_newViewState);

            _newViewState.ListSettings.Columns = CreateViewContext.ViewListColumns.ToList();

            IsComplete = true;
        }

        protected virtual void UpdateViewState(ViewState viewState)
        {
            viewState.HeaderText = lblViewTitle.Text.Trim();

            viewState.ListSettings.MaxRows = (int)numMaxRows.Value;

            viewState.ListSettings.RowHeight = null;

            viewState.ListSettings.ShowHeader = true;
            viewState.ListSettings.ShowCaptions = true;

            viewState.ViewType = Models.ViewType.List;

            if (cboThemes.SelectedItem != null)
                viewState.ThemeId = _theme.Id;
        }

        #endregion

        #region private

        private void lblViewTitle_DoubleClick(object sender, EventArgs e)
        {
            SetViewTitle();
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            lblViewTitle.Text = txtTitle.Text;

            UpdateValidation();
        }

        private void numMaxRows_ValueChanged(object sender, EventArgs e)
        {
            UpdateMaxRows((int)numMaxRows.Value);
        }

        private void cboThemes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboThemes.SelectedItem == null)
                return;

            Theme selectedTheme = (Theme)cboThemes.SelectedItem;

            if (selectedTheme.Name == "None")
            {
                ClearTheme();
            }
            else
            {
                ApplyTheme((Theme)cboThemes.SelectedItem);
            }

            UpdateValidation();
        }

        private void btnSaveView_Click(object sender, EventArgs e)
        {
            SaveView();
        }

        #endregion
    }
}
