using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using RacerData.WinForms.Dialogs;
using RacerData.WinForms.Logging;
using RacerData.WinForms.Models;
using RacerData.WinForms.Ports;

namespace RacerData.WinForms
{
    public partial class StartMenu : Form
    {
        #region fields

        IDialogService _service = null;

        #endregion

        #region ctor

        public StartMenu()
        {
            InitializeComponent();

            _service = ServiceProvider.Instance.GetRequiredService<IDialogService>();

            Logger.Setup();
        }

        #endregion

        #region protected

        protected virtual void ExceptionHandler(Exception ex)
        {
            _service.DisplayException(this, ex);
        }

        #endregion

        #region private

        private void btnDialogBase_Click(object sender, EventArgs e)
        {
            var dialog = new DialogBase() { DialogType = Models.ButtonTypes.SaveCancel };

            dialog.ShowDialog(this);
        }

        private void btnLeaderboardViewTest_Click(object sender, EventArgs e)
        {
            var dialog = new LeaderboardViewTest();

            dialog.ShowDialog(this);
        }

        private void btnMaintenanceFormBase_Click(object sender, EventArgs e)
        {
            var dialog = new EditorBase();

            dialog.ShowDialog(this);
        }

        private void btnMsgBoxEx_Click(object sender, EventArgs e)
        {
            try
            {
                throw new InvalidOperationException("You can't do that");
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void btnInputDialog_Click(object sender, EventArgs e)
        {
            var dialog = new InputDialog("Title", "Prompt", "Default Response");

            dialog.ShowDialog(this);
        }

        private void btnMsgBox_Click(object sender, EventArgs e)
        {
            var dialog = new MsgBox("WARNING", "You will encounter errors when you do that.\r\nDon't do that any more.", ButtonTypes.Ok, MsgIcon.Warning);

            dialog.ShowDialog(this);
        }

        private void btnMsgBoxErr_Click(object sender, EventArgs e)
        {
            var dialog = new MsgBox("Error Doing That", "Error encountered when you did that.\r\n\r\nI told you not to do that any more.", ButtonTypes.Ok, MsgIcon.Error);

            dialog.ShowDialog(this);
        }

        private void btnMsgBoxQuestion_Click(object sender, EventArgs e)
        {
            var dialog = new MsgBox("Why are you doing that?", "Error encountered when you did that.\r\n\r\nDo you want to keep doing that?", ButtonTypes.YesNo, MsgIcon.Question);

            dialog.ShowDialog(this);
        }

        private void btnMsgBoxInfo_Click(object sender, EventArgs e)
        {
            var dialog = new MsgBox("Hey you", "Here's a tip. Stop doing that.\r\n\r\nSchmuck.", ButtonTypes.Ok, MsgIcon.Information);

            dialog.ShowDialog(this);
        }

        private void btnAboutDialog_Click(object sender, EventArgs e)
        {
            try
            {
                _service.DisplayAboutDialog(this, "Start Menu", "Macrosoft", DateTime.Now.ToString());
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void btnFileViewer_Click(object sender, EventArgs e)
        {
            try
            {
                _service.DisplayFileViewer(this, "File Stuff", @"C:\Users\Rob\source\repos\RacerData\src\RacerData.LiveFeedMonitor\LiveFeedMonitor\bin\Debug\errorLog.txt.1");
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void btnSelectionDialog_Click(object sender, EventArgs e)
        {
            try
            {
                var items = new List<MyListItem>();

                items.Add(new MyListItem() { Name = "One", Id = 1 });
                items.Add(new MyListItem() { Name = "Two", Id = 2 });
                items.Add(new MyListItem() { Name = "Three", Id = 3 });

                var ordered = items.OrderBy(i => i.Name);

                var result = _service.DisplaySelectionDialog(this, "Available MyItems", "Select a MyItem", ordered.ToList(), "Name", "Id");

                if (result.DialogResult == DialogResult.OK)
                {
                    MessageBox.Show($"Selected {result.SelectedItem.Name}");
                }
                else
                {
                    MessageBox.Show("No Selection");
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler(ex);
            }
        }

        private void btnAppAppearance_Click(object sender, EventArgs e)
        {
            //var repo = ServiceProvider.Instance.GetRequiredService<IAppAppearanceRepository>();

            //var appAppearance = repo.GetAppearance();

            var dialog = ServiceProvider.Instance.GetRequiredService<AppearanceEditorDialog>(); //new AppearanceEditorDialog();
            //{
            //    AppAppearance = appAppearance
            //};

            dialog.ShowDialog(this);
        }

        private void btnViewGridTest_Click(object sender, EventArgs e)
        {
            var dialog = new ViewGridTest();

            dialog.ShowDialog(this);
        }

        #endregion
    }
}
