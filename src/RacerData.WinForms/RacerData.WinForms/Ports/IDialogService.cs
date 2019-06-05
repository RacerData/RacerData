using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RacerData.WinForms.Models;

namespace RacerData.WinForms.Ports
{
    public interface IDialogService
    {
        ApplicationAppearance Appearance { get; set; }

        DialogResult DisplayMessageBox(IWin32Window parent, string title, string message, ButtonTypes buttonTypes);
        DialogResult DisplayMessageBox(IWin32Window parent, string title, string message, ButtonTypes buttonTypes, MsgIcon messageIcon);

        DialogResult DisplayErrorMessage(IWin32Window parent, string message);
        DialogResult DisplayInfoMessage(IWin32Window parent, string message);
        DialogResult DisplayWarningMessage(IWin32Window parent, string message);
        DialogResult DisplayException(IWin32Window parent, Exception ex);
        DialogResult DisplayException(IWin32Window parent, string message, Exception ex);
        DialogResult DisplayException(IWin32Window parent, string message, ButtonTypes buttonTypes, Exception ex);

        InputDialogResult DisplayInputDialog(IWin32Window parent, string title, string prompt, string defaultResponse = "");
        void DisplayFileViewer(IWin32Window parent, string title, string filePath);
        void DisplayAboutDialog(IWin32Window parent, string title, string company, string buildDate);

        SelectionDialogResult<TItem> DisplaySelectionDialog<TItem>(
            IWin32Window parent,
            string title,
            string prompt,
            IList<TItem> items,
            string displayMember,
            string valueMember);
    }
}
