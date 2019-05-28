using System;
using System.Drawing;
using System.Windows.Forms;

namespace RacerData.WinForms.Themes.Editors
{
    public partial class FlatButtonAppearanceEditor : UserControl
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
        
        Models.FlatButtonAppearance _flatButtonAppearance;
        public Models.FlatButtonAppearance ButtonAppearance
        {
            get
            {
                return _flatButtonAppearance;
            }
            set
            {
                _flatButtonAppearance = value;
                DisplayAppearance(_flatButtonAppearance);
            }
        }

        #endregion

        #region ctor

        public FlatButtonAppearanceEditor()
        {
            InitializeComponent();
        }

        #endregion

        #region public

        public void ApplyChanges()
        {
            ButtonAppearance = UpdateAppearance(ButtonAppearance);
        }

        public void Clear()
        {
            ClearAppearance();
        }

        #endregion

        #region protected

        protected virtual void ClearAppearance()
        {
            mouseDownColorEditor.SelectedColor = default(Color);
            mouseOverColorEditor.SelectedColor = default(Color);
            borderColorEditor.SelectedColor = default(Color);
            numBorderSize.Value = 1;
        }

        protected virtual void DisplayAppearance(Models.FlatButtonAppearance appearance)
        {
            ClearAppearance();
            
            if (appearance == null)
                return;

            mouseDownColorEditor.SelectedColor = appearance.MouseDownBackColor;
            mouseOverColorEditor.SelectedColor = appearance.MouseOverBackColor;
            borderColorEditor.SelectedColor = appearance.BorderColor;
            numBorderSize.Value = appearance.BorderSize;
        }

        protected virtual Models.FlatButtonAppearance UpdateAppearance(Models.FlatButtonAppearance appearance)
        {
            if (appearance == null)
                appearance = new Models.FlatButtonAppearance();
            
            appearance.MouseDownBackColor = mouseDownColorEditor.SelectedColor;
            appearance.MouseOverBackColor = mouseOverColorEditor.SelectedColor;
            appearance.BorderColor = borderColorEditor.SelectedColor;
            appearance.BorderSize = (int)numBorderSize.Value;

            return appearance;
        }

        #endregion

        #region private

        private void FlatButtonAppearanceEditor_Load(object sender, EventArgs e)
        {
            mouseDownColorEditor.ColorRequest += OnColorRequest;
            mouseOverColorEditor.ColorRequest += OnColorRequest;
            borderColorEditor.ColorRequest += OnColorRequest;
        }

        #endregion
    }
}
