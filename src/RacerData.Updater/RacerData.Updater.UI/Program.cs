using System;
using System.Windows.Forms;

namespace RacerData.Updater.UI
{
    static class Program
    {
        // arg[0] = calling application startup path
        // arg[1] = calling application current version
        // arg[2] = autoUpdate

        internal static string[] commandLineArgs;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            commandLineArgs = args;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UpdaterDialog());
        }
    }
}
