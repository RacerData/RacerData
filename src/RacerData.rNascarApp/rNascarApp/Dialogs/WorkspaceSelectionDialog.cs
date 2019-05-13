using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RacerData.rNascarApp.Settings;

namespace RacerData.rNascarApp.Dialogs
{
    public partial class WorkspaceSelectionDialog : Form
    {
        #region properties

        public string Title { get; set; }
        public string Prompt { get; set; }
        public Workspace Workspace { get; set; }
        public IList<Workspace> Workspaces { get; set; }

        #endregion

        #region ctor/load

        public WorkspaceSelectionDialog()
        {
            InitializeComponent();
        }

        private void WorkspaceSelectionDialog_Load(object sender, EventArgs e)
        {
            this.Text = Title;
            lblPrompt.Text = Prompt;
            lstWorkspaces.DisplayMember = "Name";
            lstWorkspaces.DataSource = Workspaces;
            lstWorkspaces.SelectedIndex = -1;
        }

        #endregion

        #region protected

        protected virtual void SelectWorkspace()
        {
            if (lstWorkspaces.SelectedItem == null)
                return;

            Workspace = (Workspace)lstWorkspaces.SelectedItem;

            DialogResult = DialogResult.OK;
        }

        #endregion

        #region private

        private void lstWorkspaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSelect.Enabled = (lstWorkspaces.SelectedItem != null);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SelectWorkspace();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void lstWorkspaces_DoubleClick(object sender, EventArgs e)
        {
            SelectWorkspace();
        }

        #endregion
    }
}
