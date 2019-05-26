using RacerData.WinForms.Themes.Models;

namespace RacerData.WinForms.Themes.Internal
{
    internal class ListAppearance : BaseAppearance, IListAppearance
    {
        public IBaseAppearance ListItemAppearance { get; set; }
    }
}
