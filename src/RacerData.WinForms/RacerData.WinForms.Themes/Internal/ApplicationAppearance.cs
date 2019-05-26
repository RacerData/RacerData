using System.Drawing;
using System.Windows.Forms;
using RacerData.WinForms.Themes.Models;
using RacerData.WinForms.Themes.Renderers;

namespace RacerData.WinForms.Themes.Internal
{
    internal class ApplicationAppearance : Appearance, IApplicationAppearance
    {
        public virtual Color WorkspaceColor { get; set; }
        public virtual IBaseAppearance DarkAccentAppearance { get; set; }
        public virtual IBaseAppearance LightAccentAppearance { get; set; }
        public virtual IDialogAppearance DialogAppearance { get; set; }
        public virtual IListAppearance ListAppearance { get; set; }
        public virtual IButtonAppearance ButtonAppearance { get; set; }
        public virtual ToolStripCustomRenderer MenuRenderer { get; set; }
        public virtual ProfessionalColorTable MenuColorTable { get; set; }
    }
}
