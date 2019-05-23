using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using RacerData.Commmon.Results;
using RacerData.Common.Ports;
using RacerData.Themes.Models;
using RacerData.Themes.Ports;
using RacerData.Themes.UI.Controls;

namespace RacerData.Themes.UI.Views
{
    public partial class ThemeDefinitionEditor : Form
    {
        bool _isEditing = false;
        bool _isNew = false;
        bool _loading = true;
        IThemeDefinitionRepository _repo;
        IThemeDefinition _selected;
        IRevertableService _revertService;
        Guid? _revertKey = null;
        IList<ThemeDefinition> _themes = null;

        internal ThemeDefinitionEditor()
        {
            InitializeComponent();
        }

        public ThemeDefinitionEditor(
            IThemeDefinitionRepository repo,
            IRevertableService revertService)
            : this()
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _revertService = revertService ?? throw new ArgumentNullException(nameof(revertService));
        }

        private async void ThemeDefinitionEditor_Load(object sender, EventArgs e)
        {
            await LoadThemes();
        }

        private async Task LoadThemes()
        {
            await LoadThemes(null);
        }
        private async Task LoadThemes(Guid? selectedId)
        {
            _loading = true;

            var result = await _repo.SelectListAsync();

            if (!result.IsSuccessful())
            {
                MessageBox.Show(result.Exception.Message);
                return;
            }

            _themes = result.Value;

            cboThemes.DataSource = null;

            cboThemes.DisplayMember = "Name";
            cboThemes.ValueMember = "Key";
            cboThemes.DataSource = _themes.OrderBy(t => t.Name).ToList();
            cboThemes.SelectedIndex = -1;

            foreach (IThemeDefinition theme in _themes)
            {
                Console.WriteLine($"Theme {theme.Name} BackColor={theme.Appearance.BackColor}");
            }
            Console.WriteLine();

            _loading = false;

            if (selectedId.HasValue)
                cboThemes.SelectedValue = selectedId.Value;
        }

        private void cboThemes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_loading || cboThemes.SelectedItem == null)
                return;

            _selected = (IThemeDefinition)cboThemes.SelectedItem;

            DisplayTheme(_selected);

            btnEdit.Enabled = !_selected.IsReadOnly;
            btnDelete.Enabled = !_selected.IsReadOnly;
        }

        private void DisplayTheme(IThemeDefinition theme)
        {
            ClearTheme();

            txtName.Text = theme.Name;

            flwColors.Controls.Add(new AppearanceColorEditor()
            {
                FieldName = nameof(theme.Appearance.BackColor),
                Color = theme.Appearance.BackColor
            });

            flwColors.Controls.Add(new AppearanceColorEditor()
            {
                FieldName = nameof(theme.Appearance.ForeColor),
                Color = theme.Appearance.ForeColor
            });

            flwColors.Controls.Add(new AppearanceColorEditor()
            {
                FieldName = nameof(theme.Appearance.BackColor2),
                Color = theme.Appearance.BackColor2
            });

            flwColors.Controls.Add(new AppearanceColorEditor()
            {
                FieldName = nameof(theme.Appearance.ForeColor2),
                Color = theme.Appearance.ForeColor2
            });

            flwColors.Controls.Add(new AppearanceColorEditor()
            {
                FieldName = nameof(theme.Appearance.SelectedBackColor),
                Color = theme.Appearance.SelectedBackColor
            });

            flwColors.Controls.Add(new AppearanceColorEditor()
            {
                FieldName = nameof(theme.Appearance.SelectedForeColor),
                Color = theme.Appearance.SelectedForeColor
            });

            flwColors.Controls.Add(new AppearanceColorEditor()
            {
                FieldName = nameof(theme.Appearance.MouseOverBackColor),
                Color = theme.Appearance.MouseOverBackColor
            });

            flwColors.Controls.Add(new AppearanceColorEditor()
            {
                FieldName = nameof(theme.Appearance.MouseOverForeColor),
                Color = theme.Appearance.MouseOverForeColor
            });

            flwColors.Controls.Add(new AppearanceColorEditor()
            {
                FieldName = nameof(theme.Appearance.BorderColor),
                Color = theme.Appearance.BorderColor
            });

            txtBorderSize.Text = theme.Appearance.BorderThickness.ToString();
        }

        private IThemeDefinition UpdateTheme(IThemeDefinition theme)
        {
            _selected.Name = txtName.Text;

            float borderSize;
            if (float.TryParse(txtBorderSize.Text, out borderSize))
            {
                _selected.Appearance.BorderThickness = (int)borderSize;
            }

            _selected.Appearance.ForeColor = flwColors.Controls.OfType<AppearanceColorEditor>().
                FirstOrDefault(c => c.FieldName == nameof(_selected.Appearance.ForeColor)).Color;

            _selected.Appearance.BackColor = flwColors.Controls.OfType<AppearanceColorEditor>().
                FirstOrDefault(c => c.FieldName == nameof(_selected.Appearance.BackColor)).Color;

            _selected.Appearance.ForeColor2 = flwColors.Controls.OfType<AppearanceColorEditor>().
                FirstOrDefault(c => c.FieldName == nameof(_selected.Appearance.ForeColor2)).Color;

            _selected.Appearance.BackColor2 = flwColors.Controls.OfType<AppearanceColorEditor>().
                FirstOrDefault(c => c.FieldName == nameof(_selected.Appearance.BackColor2)).Color;

            _selected.Appearance.SelectedForeColor = flwColors.Controls.OfType<AppearanceColorEditor>().
                FirstOrDefault(c => c.FieldName == nameof(_selected.Appearance.SelectedForeColor)).Color;

            _selected.Appearance.SelectedBackColor = flwColors.Controls.OfType<AppearanceColorEditor>().
                FirstOrDefault(c => c.FieldName == nameof(_selected.Appearance.SelectedBackColor)).Color;

            _selected.Appearance.MouseOverForeColor = flwColors.Controls.OfType<AppearanceColorEditor>().
                FirstOrDefault(c => c.FieldName == nameof(_selected.Appearance.MouseOverForeColor)).Color;

            _selected.Appearance.MouseOverBackColor = flwColors.Controls.OfType<AppearanceColorEditor>().
                FirstOrDefault(c => c.FieldName == nameof(_selected.Appearance.MouseOverBackColor)).Color;

            _selected.Appearance.BorderColor = flwColors.Controls.OfType<AppearanceColorEditor>().
                FirstOrDefault(c => c.FieldName == nameof(_selected.Appearance.BorderColor)).Color;

            return _selected;
        }

        private void ClearTheme()
        {
            txtName.Clear();
            txtBorderSize.Clear();

            foreach (var item in flwColors.Controls.OfType<AppearanceColorEditor>().ToList())
            {
                flwColors.Controls.Remove(item);
                item.Dispose();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            _isNew = true;
            _isEditing = true;

            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnCancelEdit.Enabled = true;
            btnSave.Enabled = true;
            btnClose.Enabled = false;
            btnCancel.Enabled = false;

            pnlSelection.Enabled = false;
            pnlDetail.Enabled = true;

            _selected = new ThemeDefinition()
            {
                Name = "New Theme"
            };

            DisplayTheme(_selected);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _isNew = false;
            _isEditing = true;

            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnCancelEdit.Enabled = true;
            btnSave.Enabled = true;
            btnClose.Enabled = false;
            btnCancel.Enabled = false;

            pnlSelection.Enabled = false;
            pnlDetail.Enabled = true;

            _revertKey = _revertService.PersistState((ThemeDefinition)_selected);
        }

        private async void btnCancelEdit_Click(object sender, EventArgs e)
        {
            _isNew = false;
            _isEditing = false;

            btnNew.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnCancelEdit.Enabled = false;
            btnSave.Enabled = false;
            btnClose.Enabled = true;
            btnCancel.Enabled = true;

            pnlSelection.Enabled = true;
            pnlDetail.Enabled = false;

            if (_revertKey != null)
                _selected = _revertService.RevertState<ThemeDefinition>(_revertKey.Value);

            ClearTheme();

            await LoadThemes(_selected.Key);
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (_isNew)
                _selected.Key = Guid.NewGuid();

            _selected = UpdateTheme(_selected);

            var result = await _repo.PutAsync((ThemeDefinition)_selected);

            if (!result.IsSuccessful())
            {
                MessageBox.Show(result.Exception.Message);
                return;
            }

            _isNew = false;
            _isEditing = false;

            btnNew.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnCancelEdit.Enabled = false;
            btnSave.Enabled = false;
            btnClose.Enabled = true;
            btnCancel.Enabled = true;

            pnlSelection.Enabled = true;
            pnlDetail.Enabled = false;

            ClearTheme();

            await LoadThemes(_selected.Key);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _repo.RevertChanges();
            DialogResult = DialogResult.Cancel;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _repo.SaveChanges();
            DialogResult = DialogResult.OK;
        }
    }
}
