using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using RacerData.Common.Results;
using RacerData.WinForms.Themes.Internal;
using RacerData.WinForms.Themes.Internal.Menus;
using RacerData.WinForms.Themes.Models;
using RacerData.WinForms.Themes.Ports;

namespace RacerData.WinForms.Themes.Adapters
{
    public class ApplicationAppearanceRepository : IApplicationAppearanceRepository
    {
        #region fields

        #endregion

        #region ctor

        #endregion

        #region public

        public Task<IResult<IApplicationAppearance>> DeleteAsync(string key)
        {
            throw new System.NotImplementedException();
        }

        public IApplicationAppearance GetAppearance()
        {
            var a = new ApplicationAppearance();

            a.Name = "Default";
            a.BackColor = Color.Blue;
            a.ForeColor = Color.GhostWhite;
            a.Font = new Font("Arial", 9);

            a.WorkspaceColor = Color.DarkGray;

            a.MenuColorTable = new SimpleColorTable();
            a.MenuRenderer = new Renderers.ToolStripCustomRenderer(a.MenuColorTable);

            a.DarkAccentAppearance = new BaseAppearance();
            a.DarkAccentAppearance.BackColor = Color.DarkBlue;
            a.DarkAccentAppearance.ForeColor = Color.Silver;
            a.DarkAccentAppearance.Font = new Font("Arial", 9);

            a.LightAccentAppearance = new BaseAppearance();
            a.LightAccentAppearance.BackColor = Color.LightBlue;
            a.LightAccentAppearance.ForeColor = Color.White;
            a.LightAccentAppearance.Font = new Font("Arial", 9);

            a.ButtonAppearance = new ButtonAppearance();
            a.ButtonAppearance.BackColor = Color.SteelBlue;
            a.ButtonAppearance.ForeColor = Color.GhostWhite;
            a.ButtonAppearance.Font = new Font("Arial", 9, FontStyle.Bold);
            a.ButtonAppearance.FlatStyle = FlatStyle.Standard;

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

        public Task<IResult<IApplicationAppearance>> InsertAsync(IApplicationAppearance applicationAppearance)
        {
            throw new System.NotImplementedException();
        }

        public Task<IResult<IApplicationAppearance>> SelectAsync(string key)
        {
            throw new System.NotImplementedException();
        }

        public Task<IResult<IList<IApplicationAppearance>>> SelectListAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<IResult<IApplicationAppearance>> UpdateAsync(IApplicationAppearance applicationAppearance)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region protected

        #endregion

        #region private

        #endregion
    }
}
