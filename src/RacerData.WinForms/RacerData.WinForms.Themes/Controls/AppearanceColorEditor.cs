using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RacerData.Themes.UI.Controls
{
    public partial class AppearanceColorEditor : UserControl, INotifyPropertyChanged
    {
        #region events

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        private Color _color = default(Color);
        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;

                OnPropertyChanged(nameof(Color));

                DisplayColor(_color);
            }
        }
        public string FieldName { get; set; }

        public AppearanceColorEditor()
        {
            InitializeComponent();
        }

        private void AppearanceColorEditor_Load(object sender, EventArgs e)
        {

            lblFieldTitle.Text = FieldName;
            DisplayColor(Color);
        }

        private void picColor_DoubleClick(object sender, EventArgs e)
        {
            DisplayColorDialog(Color);
        }

        protected virtual void DisplayColor(Color color)
        {
            picColor.BackColor = color;
            lblColorArgb.Text = color.ToArgb().ToString();
        }

        protected virtual void DisplayColorDialog(Color originalColor)
        {
            var dialog = new ColorDialog();

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                Color = dialog.Color;
            }
        }

        public class ColorChangedEventArgs
        {
            public string FieldName { get; set; }
            public Color Color { get; set; }
        }
    }
}
