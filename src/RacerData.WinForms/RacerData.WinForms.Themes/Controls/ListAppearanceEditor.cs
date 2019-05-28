using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RacerData.WinForms.Themes.Models;

namespace RacerData.WinForms.Themes.Controls
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
                return baseAppearanceEditor1?.Caption;
            }
            set
            {
                if (baseAppearanceEditor1 != null)
                    baseAppearanceEditor1.Caption = value;
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
        }

        #endregion

        #region public

        public void ApplyChanges()
        {
            baseAppearanceEditor1.ApplyChanges();

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
        }

        protected virtual void DisplayAppearance(ListAppearance appearance)
        {
            ClearAppearance();

            if (appearance == null)
                return;

            baseAppearanceEditor1.BaseAppearance = (Models.Appearance)appearance.ListItemAppearance;
        }

        protected virtual ListAppearance UpdateAppearance(ListAppearance appearance)
        {
            if (appearance == null)
                appearance= new ListAppearance();

            appearance.ListItemAppearance = baseAppearanceEditor1.BaseAppearance;

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
