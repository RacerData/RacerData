using System;
using System.Windows.Forms;
using RacerData.WinForms.Themes.Adapters;
using RacerData.WinForms.Themes.Models;

namespace RacerData.WinForms
{
    public partial class Theme : Form
    {
        public Theme()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ApplicationAppearanceRepository repo = new ApplicationAppearanceRepository();
            IApplicationAppearance a = repo.GetAppearance();

            pnlWorkspace.BackColor = a.WorkspaceColor;

            label1.BackColor = a.ListAppearance.BackColor;
            label1.ForeColor = a.ListAppearance.ForeColor;
            label1.Font = a.ListAppearance.Font;

            listBox1.BackColor = a.ListAppearance.ListItemAppearance.BackColor;
            listBox1.ForeColor = a.ListAppearance.ListItemAppearance.ForeColor;
            listBox1.Font = a.ListAppearance.ListItemAppearance.Font;

            panel1.BackColor = a.LightAccentAppearance.BackColor;
            panel1.ForeColor = a.LightAccentAppearance.ForeColor;
            panel1.Font = a.LightAccentAppearance.Font;

            button1.BackColor = a.ButtonAppearance.BackColor;
            button1.ForeColor = a.ButtonAppearance.ForeColor;
            button1.Font = a.ButtonAppearance.Font;

            menuStrip1.Renderer = a.MenuRenderer;
            toolStrip1.Renderer = a.MenuRenderer;
            statusStrip1.Renderer = a.MenuRenderer;
        }
    }
}
