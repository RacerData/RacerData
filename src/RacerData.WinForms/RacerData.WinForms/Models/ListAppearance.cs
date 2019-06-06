namespace RacerData.WinForms.Models
{
    public class ListAppearance : Appearance, IListAppearance
    {
        public Appearance ListItemAppearance { get; set; }
        public Appearance AlternatingListItemAppearance { get; set; }
        public Appearance CaptionAppearance { get; set; }

        public ListAppearance()
        {
            ListItemAppearance = new Appearance();
            AlternatingListItemAppearance = new Appearance();
        }
    }
}
