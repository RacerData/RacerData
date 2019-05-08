using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace RacerData.rNascarApp.Models
{
    public class ViewDisplayFormat
    {
        public string Name { get; set; }
        public HorizontalAlignment Alignment { get; set; }
        public string Format { get; set; }
        public int? MaxWidth { get; set; }
        public string Sample { get; set; }

        [JsonIgnore()]
        public ContentAlignment ContentAlignment
        {
            get
            {
                return Alignment == HorizontalAlignment.Left ?
                              ContentAlignment.MiddleLeft :
                                Alignment == HorizontalAlignment.Right ?
                                ContentAlignment.MiddleRight :
                              ContentAlignment.MiddleCenter;
            }
        }

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
