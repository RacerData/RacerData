using System.Drawing;

namespace RacerData.iRacing.Telemetry.Models
{
    public class FieldDisplayInfo : IFieldDisplayInfo
    {
        public string Name { get; set; }
        public string Key { get; set; }
        public string Path { get; set; }
        public int ColorA { get; set; }
        public int ColorR { get; set; }
        public int ColorG { get; set; }
        public int ColorB { get; set; }
        public float Thickness { get; set; }
        public float RangeMin { get; set; }
        public float RangeMax { get; set; }
        public string Format { get; set; }
        public string Unit { get; set; }
        public string Conversion { get; set; }
        public string ConvertedUnit { get; set; }
        public string Group { get; set; }
        public bool IsCalculated { get; set; }

        public Color GetColor()
        {
            return Color.FromArgb(ColorA, ColorR, ColorG, ColorB);
        }
        public void SetColor(Color color)
        {
            ColorA = color.A;
            ColorR = color.R;
            ColorG = color.G;
            ColorB = color.B;
        }
        public string GetUnit()
        {
            return string.IsNullOrEmpty(ConvertedUnit) ? Unit : ConvertedUnit;
        }

        public override string ToString()
        {
            return Key;
        }
    }
}
