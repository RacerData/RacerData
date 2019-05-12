using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RacerData.rNascarApp.Controls
{

    [DefaultProperty("Alignment")]
    public partial class ContentAlignmentSelector : UserControl, INotifyPropertyChanged
    {
        #region events

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event EventHandler<ContentAlignment> AlignmentChanged;
        protected void OnAlignmentChanged(ContentAlignment alignment)
        {
            var handler = AlignmentChanged;
            handler?.Invoke(this, alignment);
        }

        #endregion

        #region fields

        private bool _isLoading = true;
        private Color _unselectedColor = Color.FromKnownColor(KnownColor.ControlDark);
        private Color _selectedColor = Color.FromKnownColor(KnownColor.ControlLightLight);
        private Color _controlBackColor = Color.FromKnownColor(KnownColor.ControlDarkDark);
        private Color _gridBackColor = Color.FromKnownColor(KnownColor.Control);
        private Color _textBoxBackColor = Color.FromKnownColor(KnownColor.Window);
        private IDictionary<ContentAlignment, Panel> _indicatorPanels { get; set; } = new Dictionary<ContentAlignment, Panel>();

        #endregion

        #region properties

        [Category("Appearance")]
        private ContentAlignment _alignment = ContentAlignment.MiddleLeft;
        public ContentAlignment Alignment
        {
            get
            {
                return _alignment;
            }
            set
            {
                _alignment = value;
                OnAlignmentChanged(_alignment);
                OnPropertyChanged(nameof(Alignment));
            }
        }

        #endregion

        #region ctor

        public ContentAlignmentSelector()
        {
            InitializeComponent();

            BackColor = _controlBackColor;
            pnlLabels.BackColor = _gridBackColor;
            txtAlignment.BackColor = _textBoxBackColor;

            _indicatorPanels.Add(ContentAlignment.TopLeft, panel1);
            _indicatorPanels.Add(ContentAlignment.TopCenter, panel2);
            _indicatorPanels.Add(ContentAlignment.TopRight, panel4);
            _indicatorPanels.Add(ContentAlignment.MiddleLeft, panel16);
            _indicatorPanels.Add(ContentAlignment.MiddleCenter, panel32);
            _indicatorPanels.Add(ContentAlignment.MiddleRight, panel64);
            _indicatorPanels.Add(ContentAlignment.BottomLeft, panel256);
            _indicatorPanels.Add(ContentAlignment.BottomCenter, panel512);
            _indicatorPanels.Add(ContentAlignment.BottomRight, panel1024);

            AlignmentChanged += ContentAlignmentSelector_AlignmentChanged;

            DisplaySelectedAlignment(Alignment);

            _isLoading = false;
        }

        #endregion

        #region private

        private void ContentAlignmentSelector_AlignmentChanged(object sender, ContentAlignment e)
        {
            if (_isLoading)
                return;

            DisplaySelectedAlignment(e);
        }

        private void panel_Click(object sender, EventArgs e)
        {
            var selectedPanel = (Panel)sender;
            int selectedValue = 1;
            if (Int32.TryParse(selectedPanel.Tag.ToString(), out selectedValue))
            {
                Alignment = (ContentAlignment)selectedValue;
            }
        }

        private void DisplaySelectedAlignment(ContentAlignment alignment)
        {
            foreach (Panel panel in _indicatorPanels.Values)
            {
                panel.BackColor = _unselectedColor;
            }

            if (_indicatorPanels.ContainsKey(alignment))
                _indicatorPanels[alignment].BackColor = _selectedColor;

            txtAlignment.Text = alignment.ToString();

            HideSelectors();
        }

        private void txtAlignment_Click(object sender, EventArgs e)
        {
            ShowSelectors();
        }

        private void ShowSelectors()
        {
            this.Height = txtAlignment.Height * 4;
        }

        private void HideSelectors()
        {
            this.Height = txtAlignment.Height + 4;
        }

        private void ContentAlignmentSelector_Leave(object sender, EventArgs e)
        {
            HideSelectors();
        }

        private void txtAlignment_TextChanged(object sender, EventArgs e)
        {
            txtAlignment.SelectionLength = 0;
        }

        #endregion
    }
}
