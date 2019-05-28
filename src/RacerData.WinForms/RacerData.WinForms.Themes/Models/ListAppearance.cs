namespace RacerData.WinForms.Themes.Models
{
    public class ListAppearance : Appearance
    {
        public Appearance ListItemAppearance { get; set; }

        public ListAppearance()
        {
            ListItemAppearance = new Appearance();
        }
    }
}
