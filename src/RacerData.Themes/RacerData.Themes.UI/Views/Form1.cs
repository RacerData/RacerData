using System;
using System.Windows.Forms;
using AutoMapper;
using Newtonsoft.Json;
using RacerData.Themes.UI.ColorTables;
using RacerData.Themes.UI.Models;
using RacerData.Themes.UI.Renderers;

namespace RacerData.Themes.UI.Views
{
    public partial class Form1 : Form
    {
        ISimpleColorTable table = new SimpleCustomColorTable();

        internal Form1()
        {
            InitializeComponent();
        }

        public Form1(IMapper mapper)
            : this()
        {
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = (ISimpleColorTable)table;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        void Clear()
        {
            this.toolStrip1.Renderer = new ToolStripProfessionalRenderer(new ProfessionalColorTable());
            this.statusStrip1.Renderer = new ToolStripProfessionalRenderer(new ProfessionalColorTable());
            this.menuStrip1.Renderer = new ToolStripProfessionalRenderer(new ProfessionalColorTable());
        }
        void Apply()
        {
            this.toolStrip1.Renderer = new CustomProToolStripSystemRenderer2((ProfessionalColorTable)table);
            this.menuStrip1.Renderer = new CustomProToolStripSystemRenderer2((ProfessionalColorTable)table);
            this.statusStrip1.Renderer = new CustomProToolStripSystemRenderer2((ProfessionalColorTable)table);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }
        void Reset()
        {
            table = new SimpleCustomColorTable();
            propertyGrid1.SelectedObject = (ISimpleColorTable)table;
            Apply();
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            Console.WriteLine(e.ChangedItem.ToString());
            Apply();
        }

        private void propertyGrid1_SelectedObjectsChanged(object sender, EventArgs e)
        {
            table = (SimpleCustomColorTable)propertyGrid1.SelectedObject;
            if (table != null)
                Apply();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var json = JsonConvert.SerializeObject(table);

                table = JsonConvert.DeserializeObject<SimpleCustomColorTable>(json);

                propertyGrid1.SelectedObject = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButton3_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripButton button = sender as ToolStripButton;

            button.Text = $"Button - {(button.Checked ? "Checked" : "Unchecked")}";
        }

        private void item2ToolStripMenuItem1_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;

            menuItem.Text = $"Menu Item - {(menuItem.Checked ? "Checked" : "Unchecked")}";
        }
    }
}
