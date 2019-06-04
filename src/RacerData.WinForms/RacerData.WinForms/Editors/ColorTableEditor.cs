using System;
using System.Windows.Forms;
using RacerData.WinForms.Models;
using RacerData.WinForms.Renderers;

namespace RacerData.WinForms.Editors
{
    public partial class ColorTableEditor : UserControl
    {
        #region fields

        private SimpleColorTable _originalState;
        private SimpleColorTable _editItem;

        #endregion

        #region properties

        private SimpleColorTable _colorTable = new SimpleColorTable();
        public SimpleColorTable ColorTable
        {
            get
            {
                return _colorTable;
            }
            set
            {
                _colorTable = value;

                _originalState = _colorTable.Copy();

                _editItem = _colorTable.Copy();

                propertyGrid1.SelectedObject = _editItem;

                UpdateDisplay();
            }
        }

        #endregion

        #region ctor / load

        public ColorTableEditor()
        {
            InitializeComponent();
        }

        private void ColorTableEditor_Load(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        #endregion

        #region public

        public void ApplyChanges()
        {
            ColorTable = (SimpleColorTable)propertyGrid1.SelectedObject;
        }

        public void Clear()
        {
            RevertChanges();
        }

        #endregion

        #region protected

        protected virtual void UpdateDisplay()
        {
            sampleToolStrip.Renderer = new ToolStripCustomRenderer((SimpleColorTable)propertyGrid1.SelectedObject);
            sampleMenuStrip.Renderer = new ToolStripCustomRenderer((SimpleColorTable)propertyGrid1.SelectedObject);
            sampleStatusStrip.Renderer = new ToolStripCustomRenderer((SimpleColorTable)propertyGrid1.SelectedObject);
        }

        protected virtual void RevertChanges()
        {
            ColorTable = _originalState;

            _editItem = _originalState.Copy();

            propertyGrid1.SelectedObject = _editItem;

            UpdateDisplay();
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
            UpdateDisplay();
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            UpdateDisplay();
        }

        #endregion
    }
}
