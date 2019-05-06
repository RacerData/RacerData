namespace RacerData.rNascarApp.Models
{
    public class ViewDisplayFormat
    {
        public string Name { get; set; }
        public System.Windows.Forms.HorizontalAlignment Alignment { get; set; }
        public string Format { get; set; }
        public int? MaxWidth { get; set; }

        public override string ToString()
        {
            if (MaxWidth.HasValue)
            {
                return $"{Name} ({MaxWidth} Max) {Alignment} Align";
            }
            else
            {
                return $"{Name} {Alignment} Align [{Format}]";
            }
        }
    }
}
