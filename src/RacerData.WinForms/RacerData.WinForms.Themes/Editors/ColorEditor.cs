using System;
using System.Drawing;
using System.Windows.Forms;

namespace RacerData.WinForms.Themes.Editors
{
    public partial class ColorEditor : UserControl
    {
        #region events

        public ColorRequestHandler ColorRequest;
        protected virtual void OnColorRequest(ref Color color)
        {
            var handler = ColorRequest;
            handler?.Invoke(ref color);
        }

        #endregion

        #region properties

        public Color SelectedColor
        {
            get
            {
                return picColor.BackColor;
            }
            set
            {
                if (value == null)
                    value = default(Color);

                picColor.BackColor = value;
                DisplayColor(picColor.BackColor);
            }
        }

        public string Caption
        {
            get
            {
                return lblCaption.Text;
            }
            set
            {
                lblCaption.Text = value;
            }
        }

        #endregion

        #region ctor

        public ColorEditor()
        {
            InitializeComponent();

            picColor.BackColor = Color.White;
        }

        #endregion

        #region public

        /// <summary>
        ///  Clears all controls
        /// </summary>
        public void Clear()
        {
            ClearColor();
        }

        #endregion

        #region protected

        /// <summary>
        /// Clears controls that are not sub-editors
        /// </summary>
        protected virtual void ClearColor()
        {
            SelectedColor = default(Color);
        }

        protected virtual void DisplayColor(Color color)
        {
            if (color == null)
                return;

            string colorName = string.Empty;

            if (color.IsNamedColor)
                colorName = color.Name;
            else
            {
                colorName = $"A:{color.A} R:{color.R} G:{color.G} B:{color.B}";
            }

            lblColor.Text = colorName;
        }

        #endregion

        #region private

        private void picColor_DoubleClick(object sender, EventArgs e)
        {
            var color = picColor.BackColor;
            OnColorRequest(ref color);
            SelectedColor = color;
        }

        #endregion
    }
}
