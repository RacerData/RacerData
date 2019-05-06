using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RacerData.rNascarApp.Models;
using RacerData.rNascarApp.Settings;
using RacerData.rNascarApp.Themes;

namespace RacerData.rNascarApp.Dialogs
{
    interface IViewDesigner : IDisposable
    {
        Guid? ViewStateId { get; set; }
        IList<Theme> Themes { get; set; }
        IList<ViewDataSource> DataSources { get; set; }
        IList<ViewState> ViewStates { get; set; }

        DialogResult ShowDialog(IWin32Window parent);
    }
}
