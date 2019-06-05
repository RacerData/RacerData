using System;
using System.Collections.Generic;
using System.Linq;
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

            if (Appearance != null)
            {
                this.BackColor = Appearance.DialogAppearance.BackColor;
                this.ForeColor = Appearance.DialogAppearance.ForeColor;
                this.Font = Appearance.DialogAppearance.Font;

                lstItems.BackColor = Appearance.ListAppearance.BackColor;
                lstItems.ForeColor = Appearance.ListAppearance.ForeColor;
                lstItems.Font = Appearance.ListAppearance.Font;

                foreach (Button button in Controls.OfType<Button>())
                {
                    button.BackColor = Appearance.DialogAppearance.ButtonAppearance.BackColor;
                    button.ForeColor = Appearance.DialogAppearance.ButtonAppearance.ForeColor;
                    button.Font = Appearance.DialogAppearance.ButtonAppearance.Font;
                    button.FlatStyle = Appearance.DialogAppearance.ButtonAppearance.FlatStyle; ;
                    button.FlatAppearance.BorderColor = Appearance.DialogAppearance.ButtonAppearance.FlatAppearance.BorderColor;
                    button.FlatAppearance.BorderSize = Appearance.DialogAppearance.ButtonAppearance.FlatAppearance.BorderSize;
                    button.FlatAppearance.MouseDownBackColor = Appearance.DialogAppearance.ButtonAppearance.FlatAppearance.MouseDownBackColor;
                    button.FlatAppearance.MouseOverBackColor = Appearance.DialogAppearance.ButtonAppearance.FlatAppearance.MouseOverBackColor;
                }
            }
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
