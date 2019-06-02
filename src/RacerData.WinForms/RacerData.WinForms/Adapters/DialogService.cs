using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RacerData.WinForms.Dialogs;
using RacerData.WinForms.Models;
using RacerData.WinForms.Ports;

namespace RacerData.WinForms.Adapters
{
    public class DialogService : IDialogService
    {
        #region public

        public SelectionDialogResult<TItem> DisplaySelectionDialog<TItem>(
            IWin32Window parent,
            string title,
            string prompt,
            IList<TItem> items,
            string displayMember,
            string valueMember)
        {
            var dialog = new SelectionDialog<TItem>()
            {
                Title = title,
                Prompt = prompt,
                Items = items,
                DisplayMember = displayMember,
                ValueMember = valueMember
            };

            var dialogResult = dialog.ShowDialog(parent);

            return new SelectionDialogResult<TItem>()
            {
                DialogResult = dialogResult,
                SelectedItem = dialogResult == DialogResult.OK ?
                   dialog.Selected :
                   default(TItem)
            };
        }

        public void DisplayAboutDialog(IWin32Window parent, string title, string company, string buildDate)
        {
            var dialog = new AboutDialog(this, title, company, buildDate);

            dialog.ShowDialog(parent);
        }

        public DialogResult DisplayException(IWin32Window parent, Exception ex)
        {
            var dialog = new ExceptionDialog(this, ex);

            return dialog.ShowDialog(parent);
        }
        public DialogResult DisplayException(IWin32Window parent, string message, Exception ex)
        {
            var dialog = new ExceptionDialog(this, message, ex);

            return dialog.ShowDialog(parent);
        }

        public DialogResult DisplayException(IWin32Window parent, string message, ButtonTypes buttonTypes, Exception ex)
        {
            var dialog = new ExceptionDialog(this, message, buttonTypes, ex);

            return dialog.ShowDialog(parent);
        }

        public DialogResult DisplayErrorMessage(IWin32Window parent, string message)
        {
            var dialog = new MsgBox("Error", message, ButtonTypes.Ok, MsgIcon.Error);

            return dialog.ShowDialog(parent);
        }

        public DialogResult DisplayInfoMessage(IWin32Window parent, string message)
        {
            var dialog = new MsgBox("Information", message, ButtonTypes.Ok, MsgIcon.Information);

            return dialog.ShowDialog(parent);
        }

        public DialogResult DisplayWarningMessage(IWin32Window parent, string message)
        {
            var dialog = new MsgBox("Warning", message, ButtonTypes.Ok, MsgIcon.Warning);

            return dialog.ShowDialog(parent);
        }

        public DialogResult DisplayMessageBox(IWin32Window parent, string title, string message, ButtonTypes buttonTypes)
        {
            var dialog = new MsgBox(title, message, buttonTypes);

            return dialog.ShowDialog(parent);
        }

        public DialogResult DisplayMessageBox(IWin32Window parent, string title, string message, ButtonTypes buttonTypes, MsgIcon messageIcon)
        {
            var dialog = new MsgBox(title, message, buttonTypes, messageIcon);

            return dialog.ShowDialog(parent);
        }

        public void DisplayFileViewer(IWin32Window parent, string title, string filePath)
        {
            var dialog = new FileViewerDialog(title, filePath);

            dialog.ShowDialog(parent);
        }

        public InputDialogResult DisplayInputDialog(IWin32Window parent, string title, string prompt, string defaultResponse = "")
        {
            var dialog = new InputDialog(title, prompt, defaultResponse);

            var dialogResult = dialog.ShowDialog(parent);

            return new InputDialogResult()
            {
                DialogResult = dialogResult,
                Response = dialogResult == DialogResult.OK ?
                    dialog.Value :
                    String.Empty
            };
        }

        #endregion
    }
}
