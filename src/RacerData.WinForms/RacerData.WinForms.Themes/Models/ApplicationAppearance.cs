using System;
using System.Drawing;
using System.Windows.Forms;
using RacerData.Data.Ports;
using RacerData.WinForms.Themes.Renderers;

namespace RacerData.WinForms.Themes.Models
{
    public class ApplicationAppearance : Appearance, IKeyedItem<Guid>, IApplicationAppearance
    {
        public Guid Key { get; set; }
        public virtual string Name { get; set; }
        public virtual Color WorkspaceColor { get; set; }
        public virtual Appearance DarkAccentAppearance { get; set; }
        public virtual Appearance LightAccentAppearance { get; set; }
        public virtual DialogAppearance DialogAppearance { get; set; }
        public virtual ListAppearance ListAppearance { get; set; }
        public virtual ButtonAppearance ButtonAppearance { get; set; }
        public virtual ToolStripCustomRenderer MenuRenderer { get; set; }
        public virtual ProfessionalColorTable MenuColorTable { get; set; }

        public ApplicationAppearance()
        {
            WorkspaceColor = default(Color);
            DarkAccentAppearance = new Appearance();
            LightAccentAppearance = new Appearance();
            DialogAppearance = new DialogAppearance();
            ListAppearance = new ListAppearance();
            ButtonAppearance = new ButtonAppearance();
            MenuColorTable = new SimpleColorTable();
            MenuRenderer = new ToolStripCustomRenderer(MenuColorTable);
        }

        public ToolStripCustomRenderer GetRenderer()
        {
            return new ToolStripCustomRenderer(MenuColorTable);
        }
    }
}
