using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using rNascarApp.UI.Ports;

namespace rNascarApp.UI.Controllers
{
    class ViewController : IViewController
    {
        #region fields

        private readonly Form _parentForm;
        private readonly Panel _controlPanel;
        #endregion

        #region ctor

        public ViewController(
            Form parentForm,
            Panel controlPanel)
        {
            _parentForm = parentForm ?? throw new ArgumentNullException(nameof(parentForm));
            _controlPanel = controlPanel ?? throw new ArgumentNullException(nameof(controlPanel));
        }

        #endregion

    }
}
