namespace RacerData.WinForms.Models
{
    public interface IListAppearance : IBaseAppearance
    {
        IBaseAppearance ListItemAppearance { get; set; }
    }
}