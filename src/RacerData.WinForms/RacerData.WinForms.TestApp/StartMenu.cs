﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using RacerData.WinForms.Adapters;
using RacerData.WinForms.Dialogs;
using RacerData.WinForms.Logging;
using RacerData.WinForms.Models;
using RacerData.WinForms.Ports;
using RacerData.WinForms.Themes.Adapters;
using RacerData.WinForms.Themes.Controls;
using RacerData.WinForms.Themes.Ports;

namespace RacerData.WinForms
{
    public partial class StartMenu : Form
    {
        IDialogService _service = null;

        public StartMenu()
        {
            InitializeComponent();

            _service = ServiceProvider.Instance.GetRequiredService<IDialogService>();

            Logger.Setup();
        }

        protected virtual void ExceptionHandler(Exception ex)
        {
            _service.DisplayException(this, ex);
        }

        private void btnDialogBase_Click(object sender, EventArgs e)
        {
            var dialog = new DialogBase() { DialogType = Models.ButtonTypes.SaveCancel };

            dialog.ShowDialog(this);
        }

        private void btnTheme_Click(object sender, EventArgs e)
        {
            var dialog = new Theme();

            dialog.ShowDialog(this);
        }

        private void btnForm1_Click(object sender, EventArgs e)
        {
            var dialog = new Form1();

            dialog.ShowDialog(this);
        }

        private void btnEditorBase_Click(object sender, EventArgs e)
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
                var items = new List<MyItem>();

                items.Add(new MyItem() { Name = "One", Id = 1 });
                items.Add(new MyItem() { Name = "Two", Id = 2 });
                items.Add(new MyItem() { Name = "Three", Id = 2 });

                var ordered = items.OrderBy(i => i.Name);

                var result = _service.DisplaySelectionDialog<MyItem>(this, "Available MyItems", "Select a MyItem", ordered.ToList(), "Name", "Id");

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
    }
    public class MyItem
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
}
