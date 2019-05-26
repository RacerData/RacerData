namespace RacerData.WinForms.Themes.Models
{
    public interface IListAppearance : IBaseAppearance
    {
        IBaseAppearance ListItemAppearance { get; set; }
    }
}