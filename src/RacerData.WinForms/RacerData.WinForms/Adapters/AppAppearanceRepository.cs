using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using RacerData.Commmon.Results;
using RacerData.Common.Ports;
using RacerData.Common.Results;
using RacerData.Data.Json.Adapters;
using RacerData.Data.Json.Ports;
using RacerData.WinForms.Models;
using RacerData.WinForms.Ports;

namespace RacerData.WinForms.Adapters
{
    public class AppAppearanceRepository : JsonRepository<ApplicationAppearance, Guid>, IAppAppearanceRepository, IJsonRepository<ApplicationAppearance, Guid>
    {
        #region fields

        #endregion

        #region properties

        protected override string JsonFileName { get; set; } = "appAppearances.json";

        #endregion

        #region ctor

        public AppAppearanceRepository(
         ILog log,
         IDirectoryService directoryService,
         ISerializer serializer,
         IRevertableService revertableService,
         IResultFactory<JsonRepository<ApplicationAppearance, Guid>> resultFactory)
          : base(log, directoryService, serializer, revertableService, resultFactory)
        {
        }

        #endregion

        #region public

        public ApplicationAppearance GetAppearance()
        {
            var a = new ApplicationAppearance();

            a.Name = "Default";
            a.BackColor = Color.Blue;
            a.ForeColor = Color.GhostWhite;
            a.Font = new Font("Arial", 9);

            a.WorkspaceColor = Color.DarkGray;

            a.MenuColorTable = new SimpleColorTable();
            a.MenuRenderer = new Renderers.ToolStripCustomRenderer(a.MenuColorTable);

            a.DarkAccentAppearance = new Models.Appearance();
            a.DarkAccentAppearance.BackColor = Color.DarkBlue;
            a.DarkAccentAppearance.ForeColor = Color.Silver;
            a.DarkAccentAppearance.Font = new Font("Arial", 9);

            a.LightAccentAppearance = new Models.Appearance();
            a.LightAccentAppearance.BackColor = Color.LightBlue;
            a.LightAccentAppearance.ForeColor = Color.White;
            a.LightAccentAppearance.Font = new Font("Arial", 9);

            a.ButtonAppearance = new ButtonAppearance();
            a.ButtonAppearance.BackColor = Color.SteelBlue;
            a.ButtonAppearance.ForeColor = Color.GhostWhite;
            a.ButtonAppearance.Font = new Font("Arial", 9, FontStyle.Bold);
            a.ButtonAppearance.FlatStyle = FlatStyle.Standard;

            a.DialogAppearance = new DialogAppearance();
            a.DialogAppearance.BackColor = Color.SteelBlue;
            a.DialogAppearance.ForeColor = Color.GhostWhite;
            a.DialogAppearance.Font = new Font("Arial", 9, FontStyle.Bold);
            a.DialogAppearance.ButtonAppearance = new ButtonAppearance();
            a.DialogAppearance.ButtonAppearance.BackColor = Color.SteelBlue;
            a.DialogAppearance.ButtonAppearance.ForeColor = Color.GhostWhite;
            a.DialogAppearance.ButtonAppearance.Font = new Font("Arial", 9, FontStyle.Bold);
            a.DialogAppearance.ButtonAppearance.FlatStyle = FlatStyle.Standard;
            a.DialogAppearance.ListAppearance = new ListAppearance();
            a.DialogAppearance.ListAppearance.BackColor = Color.SteelBlue;
            a.DialogAppearance.ListAppearance.ForeColor = Color.GhostWhite;
            a.DialogAppearance.ListAppearance.Font = new Font("Arial", 9, FontStyle.Bold);

            a.ListAppearance = new ListAppearance();
            a.ListAppearance.BackColor = Color.White;
            a.ListAppearance.ForeColor = Color.Navy;
            a.ListAppearance.Font = new Font("Arial", 10);

            a.ListAppearance.ListItemAppearance = new ListAppearance();
            a.ListAppearance.ListItemAppearance.BackColor = Color.White;
            a.ListAppearance.ListItemAppearance.ForeColor = Color.Black;
            a.ListAppearance.ListItemAppearance.Font = new Font("Arial", 9);

            return a;
        }

        public override Task<IResult<IList<ApplicationAppearance>>> SelectListAsync()
        {
            if (base.Items == null || base.Items.Count == 0)
            {
                base.Items = new List<ApplicationAppearance>();

                base.Items.Add(GetAppearance());
                base.SaveChanges();
            }

            return base.SelectListAsync();
        }

        #endregion

        #region protected

        #endregion

        #region private

        #endregion
    }
}
