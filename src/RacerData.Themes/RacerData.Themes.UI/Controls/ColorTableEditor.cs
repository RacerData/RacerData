using System;
using System.Windows.Forms;
using RacerData.Themes.UI.ColorTables;
using RacerData.Themes.UI.Renderers;

namespace RacerData.Themes.UI.Controls
{
    public partial class ColorTableEditor : UserControl
    {
        #region properties

        SimpleColorTable ColorTable { get; set; } = new SimpleColorTable();

        #endregion

        #region ctor / load

        public ColorTableEditor()
        {
            InitializeComponent();
        }

        private void ColorTableEditor_Load(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = ColorTable;

            ApplyChanges();
        }

        #endregion

        #region public

        public void Reset()
        {
            RevertChanges();
        }

        #endregion

        #region protected

        protected virtual void ApplyChanges()
        {
            sampleToolStrip.Renderer = new ToolStripCustomRenderer(ColorTable);
            sampleMenuStrip.Renderer = new ToolStripCustomRenderer(ColorTable);
            sampleStatusStrip.Renderer = new ToolStripCustomRenderer(ColorTable);
        }

        protected virtual void RevertChanges()
        {
            ColorTable = new SimpleColorTable();

            propertyGrid1.SelectedObject = ColorTable;

            ApplyChanges();
        }

        #endregion

        #region private

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
            ColorTable = (SimpleColorTable)propertyGrid1.SelectedObject;

            if (ColorTable != null)
                ApplyChanges();
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            ApplyChanges();
        }

        #endregion
    }
}
