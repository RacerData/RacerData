using System;
using System.Windows.Forms;

namespace RacerData.rNascarApp
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
            if (Properties.Settings.Default.ShowSplash)
                Dialogs.SplashForm.ShowSplashScreen();
            Application.Run(new MainForm());
        }
    }
}
