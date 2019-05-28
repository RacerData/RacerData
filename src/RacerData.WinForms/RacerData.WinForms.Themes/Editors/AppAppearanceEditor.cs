using System.Drawing;
using System.Windows.Forms;
using RacerData.WinForms.Themes.Models;

namespace RacerData.WinForms.Themes.Editors
{
    public partial class AppAppearanceEditor : UserControl
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

        private ApplicationAppearance _appAppearance;
        public ApplicationAppearance AppAppearance
        {
            get
            {
                return _appAppearance;
            }
            set
            {
                _appAppearance = value;
                DisplayAppearance(_appAppearance);
            }
        }

        private bool _allowEdit = true;
        public bool AllowEdit
        {
            get
            {
                return _allowEdit;
            }
            set
            {
                _allowEdit = value;
                UpdateAllowEdit(_allowEdit);
            }
        }

        #endregion

        #region ctor

        public AppAppearanceEditor()
        {
            InitializeComponent();

            workspaceAppearanceEditor.ColorRequest += OnColorRequest;

            lightAccentAppearanceEditor.ColorRequest += OnColorRequest;
            lightAccentAppearanceEditor.FontRequest += OnFontRequest;

            darkAccentAppearanceEditor.ColorRequest += OnColorRequest;
            darkAccentAppearanceEditor.FontRequest += OnFontRequest;

            buttonAppearanceEditor.ColorRequest += OnColorRequest;
            buttonAppearanceEditor.FontRequest += OnFontRequest;

            listAppearanceEditor.ColorRequest += OnColorRequest;
            listAppearanceEditor.FontRequest += OnFontRequest;

            dialogAppearanceEditor.ColorRequest += OnColorRequest;
            dialogAppearanceEditor.FontRequest += OnFontRequest;
        }

        #endregion

        #region public

        public void ApplyChanges()
        {
            workspaceAppearanceEditor.ApplyChanges();
            lightAccentAppearanceEditor.ApplyChanges();
            darkAccentAppearanceEditor.ApplyChanges();
            buttonAppearanceEditor.ApplyChanges();
            listAppearanceEditor.ApplyChanges();
            dialogAppearanceEditor.ApplyChanges();
            colorTableAppearanceEditor.ApplyChanges();

            AppAppearance = UpdateAppearance(AppAppearance);
        }

        public void Clear()
        {

            ClearAppearance();
        }

        #endregion

        #region protected

        protected virtual void ClearAppearance()
        {
            txtName.Clear();

            workspaceAppearanceEditor.Clear();
            lightAccentAppearanceEditor.Clear();
            darkAccentAppearanceEditor.Clear();
            buttonAppearanceEditor.Clear();
            listAppearanceEditor.Clear();
            dialogAppearanceEditor.Clear();
            colorTableAppearanceEditor.Clear();
        }

        protected virtual void DisplayAppearance(ApplicationAppearance appAppearance)
        {
            ClearAppearance();

            if (appAppearance == null)
                return;

            txtName.Text = appAppearance.Name;

            workspaceAppearanceEditor.SelectedColor = appAppearance.WorkspaceColor;

            lightAccentAppearanceEditor.BaseAppearance = appAppearance.LightAccentAppearance;

            darkAccentAppearanceEditor.BaseAppearance = appAppearance.DarkAccentAppearance;

            buttonAppearanceEditor.ButtonAppearance = appAppearance.ButtonAppearance;

            listAppearanceEditor.ListAppearance = appAppearance.ListAppearance;

            dialogAppearanceEditor.DialogAppearance = appAppearance.DialogAppearance;

            colorTableAppearanceEditor.ColorTable = (SimpleColorTable)appAppearance.MenuColorTable;
        }

        protected virtual ApplicationAppearance UpdateAppearance(ApplicationAppearance appAppearance)
        {
            appAppearance.Name = txtName.Text;

            appAppearance.WorkspaceColor = workspaceAppearanceEditor.SelectedColor;

            appAppearance.LightAccentAppearance = lightAccentAppearanceEditor.BaseAppearance;

            appAppearance.DarkAccentAppearance = darkAccentAppearanceEditor.BaseAppearance;

            appAppearance.ButtonAppearance = buttonAppearanceEditor.ButtonAppearance;

            appAppearance.ListAppearance = listAppearanceEditor.ListAppearance;

            appAppearance.DialogAppearance = dialogAppearanceEditor.DialogAppearance;

            appAppearance.MenuColorTable = colorTableAppearanceEditor.ColorTable;

            return appAppearance;
        }

        protected virtual void UpdateAllowEdit(bool allowEdit)
        {
            pnlDetails.Enabled = allowEdit;

            workspaceAppearanceEditor.Enabled = allowEdit;
            lightAccentAppearanceEditor.Enabled = allowEdit;
            darkAccentAppearanceEditor.Enabled = allowEdit;
            buttonAppearanceEditor.Enabled = allowEdit;
            listAppearanceEditor.Enabled = allowEdit;
            dialogAppearanceEditor.Enabled = allowEdit;
            colorTableAppearanceEditor.Enabled = allowEdit;
        }

        #endregion

        #region private

        private void dialogAppearanceEditor_Load(object sender, System.EventArgs e)
        {
            DisplayAppearance(AppAppearance);
        }

        #endregion
    }
}
