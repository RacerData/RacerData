using System;
using System.Drawing;
using System.Windows.Forms;

namespace RacerData.WinForms.Themes.Editors
{
    public partial class WorkspaceAppearanceEditor : UserControl
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
                return workspaceColorEditor.SelectedColor;
            }
            set
            {
                if (workspaceColorEditor != null)
                    workspaceColorEditor.SelectedColor = value;
            }
        }

        public string Caption
        {
            get
            {
                return workspaceColorEditor?.Caption;
            }
            set
            {
                if (workspaceColorEditor != null)
                    workspaceColorEditor.Caption = value;
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

        public WorkspaceAppearanceEditor()
        {
            InitializeComponent();

            workspaceColorEditor.ColorRequest += OnColorRequest;
        }

        #endregion

        #region public

        public void ApplyChanges()
        {

        }

        public void Clear()
        {
            workspaceColorEditor.Clear();

            ClearAppearance();
        }

        #endregion

        #region protected

        protected virtual void ClearAppearance()
        {

        }

        #endregion

        #region private

        private void WorkspaceAppearanceEditor_Load(object sender, EventArgs e)
        {
        }

        #endregion
    }
}
