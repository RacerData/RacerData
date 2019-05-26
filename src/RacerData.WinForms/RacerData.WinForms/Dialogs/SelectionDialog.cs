using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RacerData.WinForms.Models;

namespace RacerData.WinForms.Dialogs
{
    public partial class SelectionDialog<TItem> : DialogBase
    {
        #region properties

        public string Title { get; set; }
        public string Prompt { get; set; }
        public string DisplayMember { get; set; }
        public string ValueMember { get; set; }
        public TItem Selected { get; set; }
        public IList<TItem> Items { get; set; }

        #endregion

        #region ctor/load

        public SelectionDialog()
        {
            InitializeComponent();

            DialogType = ButtonTypes.SaveCancel;
        }

        private void SelectionDialog_Load(object sender, EventArgs e)
        {
            this.Text = Title;
            lblPrompt.Text = Prompt;

            lstItems.DisplayMember = DisplayMember;
            lstItems.ValueMember = ValueMember;
            lstItems.DataSource = Items;
            lstItems.SelectedIndex = -1;
        }

        #endregion

        #region protected

        protected override void DialogResultClicked(object sender, Events.DialogResultEventArgs e)
        {
            if (e.Result != DialogResult.OK)
            {
                Selected = default(TItem);
            }

            this.DialogResult = e.Result;
        }

        #endregion

        #region private

        private void lstItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstItems.SelectedItem != null)
            {
                Selected = (TItem)lstItems.SelectedItem;
            }
        }

        private void lstWorkspaces_DoubleClick(object sender, EventArgs e)
        {
            if (lstItems.SelectedItem != null)
            {
                Selected = (TItem)lstItems.SelectedItem;

                DialogResult = DialogResult.OK;
            }
        }

        #endregion
    }
}
