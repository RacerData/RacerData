﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using RacerData.iRacing.SessionMonitor.ViewModels;

namespace RacerData.iRacing.SessionMonitor
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
            using (var form = new iRacingSessionMonitor())
            {
                Application.Run(form);
            }            
        }
    }
}
