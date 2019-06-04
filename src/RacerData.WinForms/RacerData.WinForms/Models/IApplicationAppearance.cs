using System;
using System.Drawing;
using System.Windows.Forms;
using RacerData.WinForms.Renderers;

namespace RacerData.WinForms.Models
{
    public interface IApplicationAppearance
    {
        ButtonAppearance ButtonAppearance { get; set; }
        Appearance DarkAccentAppearance { get; set; }
        DialogAppearance DialogAppearance { get; set; }
        Guid Key { get; set; }
        Appearance LightAccentAppearance { get; set; }
        ListAppearance ListAppearance { get; set; }
        ProfessionalColorTable MenuColorTable { get; set; }
        ToolStripCustomRenderer MenuRenderer { get; set; }
        string Name { get; set; }
        Color WorkspaceColor { get; set; }

        ToolStripCustomRenderer GetRenderer();
    }
}