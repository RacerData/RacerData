using System;
using System.Windows.Forms;
using RacerData.Themes.TestApp.Logging;

namespace RacerData.Themes.TestApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Logger.Setup();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ThemeTestForm());
        }
    }
}
