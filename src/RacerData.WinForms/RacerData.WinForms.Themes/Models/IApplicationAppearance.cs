using System;
using System.Drawing;
using System.Windows.Forms;
using RacerData.Data.Ports;
using RacerData.WinForms.Themes.Renderers;

namespace RacerData.WinForms.Themes.Models
{
    public interface IApplicationAppearance : IKeyedItem<Guid>
    {
        Guid Key { get; set; }

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