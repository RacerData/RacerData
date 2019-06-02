using System.Drawing;

namespace RacerData.WinForms.Models
{
    public class StaticField
    {
        #region properties

        public int Index { get; set; }
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public bool ShowCaption { get; set; }
        public CaptionAlignment CaptionAlignment { get; set; }

        public string Type { get; set; }
        public string Format { get; set; }
        public ContentAlignment Alignment { get; set; }

        public string DataSource { get; set; }
        public string DataMember { get; set; }
        public string DataPath { get; set; }

        #endregion
    }
}
