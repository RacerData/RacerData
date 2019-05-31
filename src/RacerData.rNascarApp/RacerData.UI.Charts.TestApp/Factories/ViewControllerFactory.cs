using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using rNascarApp.UI.Controllers;
using rNascarApp.UI.Models;
using rNascarApp.UI.Ports;

namespace rNascarApp.UI.Factories
{
    class ViewControllerFactory : IViewControllerFactory
    {
        public ViewControllerFactory()
        {

        }

        public IViewController GetViewController(Form parentForm, Panel controlPanel, ViewType viewType)
        {
            return new ViewController(parentForm, controlPanel);
        }
    }
}
