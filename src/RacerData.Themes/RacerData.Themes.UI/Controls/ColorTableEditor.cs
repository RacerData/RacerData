using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RacerData.Themes.UI.ColorTables;
using RacerData.Themes.UI.Renderers;

namespace RacerData.Themes.UI.Controls
{
    public partial class ColorTableEditor : UserControl
    {
        SimpleCustomColorTable table = new SimpleCustomColorTable();

        public ColorTableEditor()
        {
            InitializeComponent();
        }


        void Clear()
        {
            this.sampleToolStrip.Renderer = new ToolStripProfessionalRenderer(new ProfessionalColorTable());
            this.sampleStatusStrip.Renderer = new ToolStripProfessionalRenderer(new ProfessionalColorTable());
            this.sampleMenuStrip.Renderer = new ToolStripProfessionalRenderer(new ProfessionalColorTable());
        }
        void Apply()
        {
            this.sampleToolStrip.Renderer = new CustomProToolStripSystemRenderer2(table);
            this.sampleMenuStrip.Renderer = new CustomProToolStripSystemRenderer2(table);
            this.sampleStatusStrip.Renderer = new CustomProToolStripSystemRenderer2(table);
        }
        void Reset()
        {
            table = new SimpleCustomColorTable();
            propertyGrid1.SelectedObject = table;
            Apply();
        }

        private void mnuCheckable_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;

            menuItem.Text = $"Menu Item - {(menuItem.Checked ? "Checked" : "Unchecked")}";
        }

        private void tsbCheckButton_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripButton button = sender as ToolStripButton;

            button.Text = $"Button - {(button.Checked ? "Checked" : "Unchecked")}";
        }

        private void propertyGrid1_SelectedObjectsChanged(object sender, EventArgs e)
        {
            table = (SimpleCustomColorTable)propertyGrid1.SelectedObject;
            if (table != null)
                Apply();
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            Apply();
        }

        private void ColorTableEditor_Load(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = table;
        }
    }
}
