using System;
using System.Drawing;
using System.Windows.Forms;

namespace RacerData.WinForms.Themes.Editors
{
    public partial class FontEditor : UserControl
    {
        #region events

        public FontRequestHandler FontRequest;
        protected virtual void OnFontRequest(ref Font font)
        {
            var handler = FontRequest;
            handler?.Invoke(ref font);
        }

        #endregion

        #region properties

        private Font _font = default(Font);
        public Font SelectedFont
        {
            get
            {
                return _font;
            }
            set
            {
                _font = value;
                DisplayFont(_font);
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

        public FontEditor()
        {
            InitializeComponent();

            Font = default(Font);
        }

        /// <summary>
        ///  Clears all controls
        /// </summary>
        public void Clear()
        {
            ClearFont();
        }

        #endregion

        #region protected

        /// <summary>
        /// Clears controls that are not sub-editors
        /// </summary>
        protected virtual void ClearFont()
        {
            SelectedFont = default(Font);
        }

        protected virtual void DisplayFont(Font font)
        {
            if (font == null)
                return;

            var fontName = $"{font.Name}, {font.Size}pt, style={font.Style.ToString()}";
            lblFont.Text = fontName;
        }

        #endregion

        #region private

        private void lblFont_DoubleClick(object sender, EventArgs e)
        {
            var font = SelectedFont;
            OnFontRequest(ref font);
            SelectedFont = font;
        }

        #endregion
    }
}
