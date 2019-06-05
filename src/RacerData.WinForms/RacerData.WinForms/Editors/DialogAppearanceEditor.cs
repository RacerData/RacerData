using System;
using System.Drawing;
using System.Windows.Forms;
using RacerData.WinForms.Models;

namespace RacerData.WinForms.Editors
{
    public partial class DialogAppearanceEditor : UserControl
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

        DialogAppearance _dialogAppearance;
        public DialogAppearance DialogAppearance
        {
            get
            {
                return _dialogAppearance;
            }
            set
            {
                _dialogAppearance = value;
                DisplayDialogAppearance(_dialogAppearance);
            }
        }

        public string Caption
        {
            get
            {
                return dialogButtonAppearanceEditor?.Caption;
            }
            set
            {
                if (dialogButtonAppearanceEditor != null)
                    dialogButtonAppearanceEditor.Caption = value;
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

        public DialogAppearanceEditor()
        {
            InitializeComponent();

            dialogButtonAppearanceEditor.ColorRequest += OnColorRequest;
            dialogButtonAppearanceEditor.FontRequest += OnFontRequest;

            dialogListAppearanceEditor.ColorRequest += OnColorRequest;
            dialogListAppearanceEditor.FontRequest += OnFontRequest;

            dialogAppearanceEditor1.ColorRequest += OnColorRequest;
            dialogAppearanceEditor1.FontRequest += OnFontRequest;
        }

        #endregion

        #region public

        public void ApplyChanges()
        {
            dialogButtonAppearanceEditor.ApplyChanges();
            dialogListAppearanceEditor.ApplyChanges();
            dialogAppearanceEditor1.ApplyChanges();

            DialogAppearance = UpdateAppearance(DialogAppearance);
        }

        public void Clear()
        {
            ClearAppearance();
        }

        #endregion

        #region protected

        protected virtual void ClearAppearance()
        {
            dialogButtonAppearanceEditor.Clear();
            dialogListAppearanceEditor.Clear();
            dialogAppearanceEditor1.Clear();
        }

        protected virtual void DisplayDialogAppearance(DialogAppearance appearance)
        {
            ClearAppearance();

            if (appearance == null)
                return;

            dialogAppearanceEditor1.BaseAppearance = appearance;
            dialogButtonAppearanceEditor.ButtonAppearance = appearance.ButtonAppearance;
            dialogListAppearanceEditor.BaseAppearance = appearance.ListAppearance.ListItemAppearance;
        }

        protected virtual DialogAppearance UpdateAppearance(DialogAppearance appearance)
        {
            if (appearance == null)
                appearance = new DialogAppearance();

            appearance.BackColor =  dialogAppearanceEditor1.BaseAppearance.BackColor;
            appearance.ForeColor = dialogAppearanceEditor1.BaseAppearance.ForeColor;
            appearance.Font = dialogAppearanceEditor1.BaseAppearance.Font;

            appearance.ButtonAppearance = dialogButtonAppearanceEditor.ButtonAppearance;
            appearance.ListAppearance.ListItemAppearance = dialogListAppearanceEditor.BaseAppearance;

            return appearance;
        }

        #endregion

        #region private

        private void DialogAppearanceEditor_Load(object sender, EventArgs e)
        {
        }

        #endregion
    }
}
