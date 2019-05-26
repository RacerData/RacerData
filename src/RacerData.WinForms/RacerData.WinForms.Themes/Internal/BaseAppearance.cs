using System.Drawing;
using RacerData.WinForms.Themes.Models;

namespace RacerData.WinForms.Themes.Internal
{
    internal class BaseAppearance : IBaseAppearance
    {
        public virtual Font Font { get; set; }
        public virtual Color ForeColor { get; set; }
        public virtual Color BackColor { get; set; }
    }
}
