using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using RacerData.WinForms.Models;
using RacerData.WinForms.Ports;

namespace RacerData.WinForms.Adapters
{
    class ExceptionHandlerService : IExceptionHandlerService
    {
        #region fields

        private readonly ILog _log;
        private readonly IDialogService _dialogService;

        #endregion

        #region ctor

        public ExceptionHandlerService(
            ILog log,
            IDialogService dialogService)
        {
            _log = log ?? throw new ArgumentNullException(nameof(log));
            _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
        }

        #endregion

        #region public

        public void HandleException(IWin32Window parent, Exception ex)
        {
            _log?.Error(ex);

            _dialogService.DisplayException(parent, ex);
        }

        public void HandleException(IWin32Window parent, string message, Exception ex)
        {
            _log?.Error(message, ex);
            _dialogService.DisplayException(parent, message, ex);
        }

        public DialogResult PromptException(IWin32Window parent, string message, Exception ex)
        {
            _log?.Error(message, ex);
            return _dialogService.DisplayException(parent, message, ex);
        }

        public DialogResult PromptException(IWin32Window parent, string message, ButtonTypes buttonTypes, Exception ex)
        {
            _log?.Error(message, ex);
            return _dialogService.DisplayException(parent, message, buttonTypes, ex);
        }

        #endregion
    }
}
