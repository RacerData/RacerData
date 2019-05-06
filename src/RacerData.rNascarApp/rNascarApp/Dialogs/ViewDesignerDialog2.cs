using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RacerData.rNascarApp.Models;
using RacerData.rNascarApp.Settings;
using RacerData.rNascarApp.Themes;

namespace RacerData.rNascarApp.Dialogs
{
    public partial class ViewDesignerDialog2 : Form, IViewDesigner
    {
        #region properties

        public Guid? ViewStateId { get; set; }
        public IList<Theme> Themes { get; set; }
        public IList<ViewDataSource> DataSources { get; set; } = new List<ViewDataSource>();
        public IList<ViewState> ViewStates { get; set; } = new List<ViewState>();

        #endregion

        #region ctor

        public ViewDesignerDialog2()
        {
            InitializeComponent();
        }

        #endregion
    }
}
