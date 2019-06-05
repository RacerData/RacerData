using System;
using System.Drawing;
using System.Windows.Forms;
using RacerData.WinForms.Models;

namespace RacerData.WinForms.Editors
{
    public partial class ListAppearanceEditor : UserControl
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

        private ListAppearance _listAppearance;
        public ListAppearance ListAppearance
        {
            get
            {
                return _listAppearance;
            }
            set
            {
                _listAppearance = value;
                DisplayAppearance(_listAppearance);
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
                if (lblCaption != null)
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

        #endregion

        #region ctor

        public ListAppearanceEditor()
        {
            InitializeComponent();

            baseAppearanceEditor1.ColorRequest += OnColorRequest;
            baseAppearanceEditor1.FontRequest += OnFontRequest;

            baseAppearanceEditor2.ColorRequest += OnColorRequest;
            baseAppearanceEditor2.FontRequest += OnFontRequest;

            captionAppearanceEditor.ColorRequest += OnColorRequest;
            captionAppearanceEditor.FontRequest += OnFontRequest;
        }

        #endregion

        #region public

        public void ApplyChanges()
        {
            baseAppearanceEditor1.ApplyChanges();
            baseAppearanceEditor2.ApplyChanges();
            captionAppearanceEditor.ApplyChanges();

            ListAppearance = UpdateAppearance(ListAppearance);
        }

        public void Clear()
        {
            ClearAppearance();
        }

        #endregion

        #region protected

        protected virtual void ClearAppearance()
        {
            baseAppearanceEditor1.Clear();
            baseAppearanceEditor2.Clear();
            captionAppearanceEditor.Clear();
        }

        protected virtual void DisplayAppearance(ListAppearance appearance)
        {
            ClearAppearance();

            if (appearance == null)
                return;

            baseAppearanceEditor1.BaseAppearance = appearance.ListItemAppearance;
            baseAppearanceEditor2.BaseAppearance = appearance.AlternatingListItemAppearance;
            captionAppearanceEditor.BaseAppearance = appearance;
        }

        protected virtual ListAppearance UpdateAppearance(ListAppearance appearance)
        {
            if (appearance == null)
                appearance = new ListAppearance();

            appearance.ListItemAppearance = baseAppearanceEditor1.BaseAppearance;
            appearance.AlternatingListItemAppearance = baseAppearanceEditor2.BaseAppearance;

            appearance.BackColor = captionAppearanceEditor.BaseAppearance.BackColor;
            appearance.ForeColor = captionAppearanceEditor.BaseAppearance.ForeColor;
            appearance.Font = captionAppearanceEditor.BaseAppearance.Font;

            return appearance;
        }

        #endregion

        #region private

        private void ListAppearanceEditor_Load(object sender, EventArgs e)
        {
        }

        #endregion
    }
}
