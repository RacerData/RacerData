namespace RacerData.WinForms.Models
{
    public interface IListAppearance : IBaseAppearance
    {
        Appearance ListItemAppearance { get; set; }
        Appearance AlternatingListItemAppearance { get; set; }
        Appearance CaptionAppearance { get; set; }
    }
}