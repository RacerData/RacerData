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
        #region properties

        public ApplicationAppearance Appearance { get; set; }

        #endregion

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
            var dialog = new AboutDialog(this, title, company, buildDate)
            {
                Appearance = Appearance
            };

            dialog.ShowDialog(parent);
        }

        public DialogResult DisplayException(IWin32Window parent, Exception ex)
        {
            var dialog = new ExceptionDialog(this, ex)
            {
                Appearance = Appearance
            };

            return dialog.ShowDialog(parent);
        }
        public DialogResult DisplayException(IWin32Window parent, string message, Exception ex)
        {
            var dialog = new ExceptionDialog(this, message, ex)
            {
                Appearance = Appearance
            };

            return dialog.ShowDialog(parent);
        }

        public DialogResult DisplayException(IWin32Window parent, string message, ButtonTypes buttonTypes, Exception ex)
        {
            var dialog = new ExceptionDialog(this, message, buttonTypes, ex)
            {
                Appearance = Appearance
            };

            return dialog.ShowDialog(parent);
        }

        public DialogResult DisplayErrorMessage(IWin32Window parent, string message)
        {
            var dialog = new MsgBox(Appearance, "Error", message, ButtonTypes.Ok, MsgIcon.Error);

            return dialog.ShowDialog(parent);
        }

        public DialogResult DisplayInfoMessage(IWin32Window parent, string message)
        {
            var dialog = new MsgBox(Appearance, "Information", message, ButtonTypes.Ok, MsgIcon.Information);

            return dialog.ShowDialog(parent);
        }

        public DialogResult DisplayWarningMessage(IWin32Window parent, string message)
        {
            var dialog = new MsgBox(Appearance, "Warning", message, ButtonTypes.Ok, MsgIcon.Warning);

            return dialog.ShowDialog(parent);
        }

        public DialogResult DisplayMessageBox(IWin32Window parent, string title, string message, ButtonTypes buttonTypes)
        {
            var dialog = new MsgBox(Appearance, title, message, buttonTypes);

            return dialog.ShowDialog(parent);
        }

        public DialogResult DisplayMessageBox(IWin32Window parent, string title, string message, ButtonTypes buttonTypes, MsgIcon messageIcon)
        {
            var dialog = new MsgBox(Appearance, title, message, buttonTypes, messageIcon);

            return dialog.ShowDialog(parent);
        }

        public void DisplayFileViewer(IWin32Window parent, string title, string filePath)
        {
            var dialog = new FileViewerDialog(title, filePath)
            {
                Appearance = Appearance
            };

            dialog.ShowDialog(parent);
        }

        public InputDialogResult DisplayInputDialog(IWin32Window parent, string title, string prompt, string defaultResponse = "")
        {
            var dialog = new InputDialog(title, prompt, defaultResponse)
            {
                Appearance = Appearance
            };

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
