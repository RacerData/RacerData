using System.Drawing;
using System.Windows.Forms;
using RacerData.WinForms.Themes.Models;

namespace RacerData.WinForms.Themes.Editors
{
    public partial class ColorTableAppearanceEditor : UserControl
    {
        #region properties

        public SimpleColorTable ColorTable
        {
            get
            {
                return colorTableEditor.ColorTable;
            }
            set
            {
                colorTableEditor.ColorTable = value;
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
                if (lblCaption.ForeColor != null)
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

        public string Caption
        {
            get
            {
                return lblCaption?.Text;
            }
            set
            {
                if (lblCaption != null)
                    lblCaption.Text = value;
            }
        }

        #endregion

        #region ctor

        public ColorTableAppearanceEditor()
        {
            InitializeComponent();
        }

        #endregion

        #region public

        public void ApplyChanges()
        {
            colorTableEditor.ApplyChanges();

            ColorTable = colorTableEditor.ColorTable;
        }

        public void Clear()
        {
            colorTableEditor.Clear();
        }

        #endregion
    }
}
