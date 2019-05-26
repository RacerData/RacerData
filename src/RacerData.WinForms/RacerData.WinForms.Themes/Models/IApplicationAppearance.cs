using System.Drawing;
using System.Windows.Forms;
using RacerData.WinForms.Themes.Renderers;

namespace RacerData.WinForms.Themes.Models
{
    public interface IApplicationAppearance
    {
        Color WorkspaceColor { get; set; }

        IBaseAppearance DarkAccentAppearance { get; set; }
        IBaseAppearance LightAccentAppearance { get; set; }

        IButtonAppearance ButtonAppearance { get; set; }
        IDialogAppearance DialogAppearance { get; set; }

        IListAppearance ListAppearance { get; set; }

        ProfessionalColorTable MenuColorTable { get; set; }
        ToolStripCustomRenderer MenuRenderer { get; set; }
    }
}