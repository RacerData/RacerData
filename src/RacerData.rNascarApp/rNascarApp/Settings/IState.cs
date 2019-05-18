using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using log4net.Core;
using RacerData.rNascarApp.Models;

namespace RacerData.rNascarApp.Settings
{
    public interface IState
    {
        double BattleGap { get; set; }
        bool CheckForLiveEventOnStartup { get; set; }
        bool CheckForUpdatesOnStartup { get; set; }
        bool AutoSaveOnExit { get; set; }
        bool AutoStartApiMonitor { get; set; }
        int[] CustomColors { get; set; }
        IList<string> FavoriteDrivers { get; set; }
        Point Location { get; set; }
        Level LogLevel { get; set; }
        int PitWindowWarning { get; set; }
        int PollInterval { get; set; }
        bool ShowStatusBar { get; set; }
        bool ShowToolBar { get; set; }
        Size Size { get; set; }
        FormStartPosition StartPosition { get; set; }
        BindingList<ViewState> ViewStates { get; set; }
        FormWindowState WindowState { get; set; }

        event PropertyChangedEventHandler PropertyChanged;
    }
}