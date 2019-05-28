using System;
using System.Drawing;
using System.Windows.Forms;
using RacerData.WinForms.Themes.Models;

namespace RacerData.WinForms.Themes.Editors
{
    public partial class AppearanceEditor : UserControl
    {
        #region events

        public ColorRequestHandler ColorRequest;
        protected virtual void OnColorRequest(ref Color color)
        {
            var handler = ColorRequest;
            handler?.Invoke(ref color);
        }

        public FontRequestHandler FontRequest;
        protected virtual void OnFontRequest(ref Font font)
        {
            var handler = FontRequest;
            handler?.Invoke(ref font);
        }

        #endregion

        #region properties

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

        public Color CaptionForeColor
        {
            get
            {
                return lblCaption.ForeColor;
            }
            set
            {
                if (lblCaption != null)
                    lblCaption.ForeColor = value;
            }
        }

        public Color CaptionBackColor
        {
            get
            {
                return lblCaption.BackColor;
            }
            set
            {
                if (lblCaption != null)
                    lblCaption.BackColor = value;
            }
        }

        private Models.Appearance _base;
        public Models.Appearance BaseAppearance
        {
            get
            {
                return _base;
            }
            set
            {
                _base = value;
                DisplayAppearance(_base);
            }
        }

        #endregion

        #region ctor

        public AppearanceEditor()
        {
            InitializeComponent();
        }

        #endregion

        #region public

        public void ApplyChanges()
        {
            BaseAppearance = UpdateAppearance(BaseAppearance);
        }

        public void Clear()
        {
            ClearAppearance();
        }

        #endregion

        #region protected

        protected virtual void ClearAppearance()
        {
            foreColorEditor.SelectedColor = default(Color);
            backColorEditor.SelectedColor = default(Color);
            fontEditor.SelectedFont = default(Font);
        }

        protected virtual void DisplayAppearance(Models.Appearance baseAppearance)
        {
            ClearAppearance();

            if (baseAppearance == null)
                return;

            foreColorEditor.SelectedColor = baseAppearance.ForeColor;
            backColorEditor.SelectedColor = baseAppearance.BackColor;
            fontEditor.SelectedFont = baseAppearance.Font;
        }

        protected virtual Models.Appearance UpdateAppearance(Models.Appearance appearance)
        {
            if (appearance == null)
                appearance = new Models.Appearance();

            appearance.ForeColor = foreColorEditor.SelectedColor;
            appearance.BackColor = backColorEditor.SelectedColor;
            appearance.Font = fontEditor.SelectedFont;

            return appearance;
        }

        #endregion

        #region private

        private void AppearanceEditor_Load(object sender, EventArgs e)
        {
            DisplayAppearance(BaseAppearance);

            foreColorEditor.ColorRequest += OnColorRequest;
            backColorEditor.ColorRequest += OnColorRequest;
            fontEditor.FontRequest += this.FontRequest;
        }

        #endregion
    }
}
