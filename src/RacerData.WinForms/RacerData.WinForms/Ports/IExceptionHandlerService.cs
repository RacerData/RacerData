using System;
using System.Windows.Forms;

namespace RacerData.WinForms.Ports
{
    public interface IExceptionHandlerService
    {
        void HandleException(IWin32Window parent, Exception ex);
        void HandleException(IWin32Window parent, string message, Exception ex);
        DialogResult PromptException(IWin32Window parent, string message, Exception ex);
    }
}
