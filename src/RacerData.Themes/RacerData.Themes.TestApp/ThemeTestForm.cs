using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using RacerData.Common.Ports;
using RacerData.Themes.Models;
using RacerData.Themes.Ports;
using RacerData.Themes.UI.ColorTables;
using RacerData.Themes.UI.Ports;
using RacerData.Themes.UI.Renderers;
using RacerData.Themes.UI.Views;

namespace RacerData.Themes.TestApp
{
    public partial class ThemeTestForm : Form
    {
        IThemeDefinitionRepository _repo;
        IThemeUiService _service;
        bool _loading = true;

        public ThemeTestForm()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                _repo = ServiceProvider.Instance.GetRequiredService<IThemeDefinitionRepository>();
                _service = ServiceProvider.Instance.GetRequiredService<IThemeUiService>();

                var themes = new List<ThemeDefinition>();

                var repoThemes = await _repo.SelectListAsync();

                foreach (ThemeDefinition item in repoThemes.Value)
                {
                    themes.Add(item);
                }

                cboThemes.DataSource = null;

                cboThemes.DisplayMember = "Name";
                cboThemes.DataSource = themes;
                cboThemes.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            _loading = false;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnClearTheme_Click(object sender, EventArgs e)
        {
            await _service.ClearThemeAsync(this, true);

            this.toolStrip1.Renderer = new ToolStripProfessionalRenderer(new ProfessionalColorTable());
            this.statusStrip1.Renderer = new ToolStripProfessionalRenderer(new ProfessionalColorTable());
            this.menuStrip1.Renderer = new ToolStripProfessionalRenderer(new ProfessionalColorTable());
        }

        private void sendToPropertyGrid(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = sender;
        }

        private async void btnApplyToSelected_Click(object sender, EventArgs e)
        {
            if (cboThemes.SelectedItem == null || propertyGrid1.SelectedObject == null || _loading)
                return;

            var themeName = ((ThemeDefinition)cboThemes.SelectedItem).Name;

            var result = await _repo.SelectThemeAsync(themeName);

            IThemeDefinition theme = result.Value;

            await _service.ApplyThemeAsync((Control)propertyGrid1.SelectedObject, theme, true);
        }

        private void btnApplyToForm_Click(object sender, EventArgs e)
        {
            //////if (cboThemes.SelectedItem == null || _loading)
            //////    return;

            //////var themeName = ((ThemeDefinition)cboThemes.SelectedItem).Name;

            //////var result = await _repo.SelectThemeAsync(themeName);

            //////IThemeDefinition theme = result.Value;

            //////await _service.ApplyThemeAsync(this, theme, true);

            //this.toolStrip1.Renderer = new ToolStripProfessionalRenderer(new CustomColorTable());
            //this.menuStrip1.Renderer = new ToolStripProfessionalRenderer(new CustomColorTable());
            //this.statusStrip1.Renderer = new BasicToolStripRenderer();

            //this.toolStrip1.Renderer = new CustomProToolStripSystemRenderer(new CustomColorTable());
            //this.menuStrip1.Renderer = new CustomProToolStripSystemRenderer(new CustomColorTable());
            //this.statusStrip1.Renderer = new CustomProToolStripSystemRenderer(new CustomColorTable());

            this.toolStrip1.Renderer = new CustomProToolStripSystemRenderer2(new CustomColorTable());
            this.menuStrip1.Renderer = new CustomProToolStripSystemRenderer2(new CustomColorTable());
            this.statusStrip1.Renderer = new CustomProToolStripSystemRenderer2(new CustomColorTable());

        }

        private void btnEditor_Click(object sender, EventArgs e)
        {
            try
            {
                using (IServiceScope _scope = ServiceProvider.Instance.CreateScope())
                {
                    var revertService = _scope.ServiceProvider.GetRequiredService<IRevertableService>();
                    var dialog = new ThemeDefinitionEditor(_repo, revertService);

                    dialog.ShowDialog(this);
                }
                // reload em.              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            toolStripButton4.Text = toolStripButton4.Checked.ToString();
            propertyGrid1.SelectedObject = sender;
        }

        private void btnMap_Click(object sender, EventArgs e)
        {
            try
            {
                var dialog = ServiceProvider.Instance.GetRequiredService<Form1>();

                dialog.ShowDialog(this);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}