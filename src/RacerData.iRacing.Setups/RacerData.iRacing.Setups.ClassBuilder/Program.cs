using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using RacerData.iRacing.Setups.ClassBuilder.Forms;

namespace RacerData.iRacing.Setups.ClassBuilder
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PracticeMonitor()); //Application.Run(new PracticeMonitor());
        }
    }
}
