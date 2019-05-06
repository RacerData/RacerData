using System.Collections.Generic;
using RacerData.rNascarApp.Models;

namespace RacerData.rNascarApp.Factories
{
    class ViewDisplayFormatFactory
    {
        public IList<ViewDisplayFormat> GetViewDisplayFormats()
        {
            var formats = new List<ViewDisplayFormat>();

            formats.Add(new ViewDisplayFormat()
            {
                Name = "Dec2.5L",
                Alignment = System.Windows.Forms.HorizontalAlignment.Left,
                Format = "##.###"
            });
            formats.Add(new ViewDisplayFormat()
            {
                Name = "Dec2.2L",
                Alignment = System.Windows.Forms.HorizontalAlignment.Left,
                Format = "##.##"
            });
            formats.Add(new ViewDisplayFormat()
            {
                Name = "Dec2.5R",
                Alignment = System.Windows.Forms.HorizontalAlignment.Right,
                Format = "##.##0"
            });
            formats.Add(new ViewDisplayFormat()
            {
                Name = "Dec2.2R",
                Alignment = System.Windows.Forms.HorizontalAlignment.Right,
                Format = "##.#0"
            });
            formats.Add(new ViewDisplayFormat()
            {
                Name = "Int3L",
                Alignment = System.Windows.Forms.HorizontalAlignment.Left,
                Format = "###"
            });
            formats.Add(new ViewDisplayFormat()
            {
                Name = "Int2L",
                Alignment = System.Windows.Forms.HorizontalAlignment.Left,
                Format = "##"
            });
            formats.Add(new ViewDisplayFormat()
            {
                Name = "Int2C",
                Alignment = System.Windows.Forms.HorizontalAlignment.Center,
                Format = "##"
            });
            formats.Add(new ViewDisplayFormat()
            {
                Name = "Int2R",
                Alignment = System.Windows.Forms.HorizontalAlignment.Right,
                Format = "##"
            });
            formats.Add(new ViewDisplayFormat()
            {
                Name = "Str30L",
                Alignment = System.Windows.Forms.HorizontalAlignment.Left,
                MaxWidth = 30
            });
            formats.Add(new ViewDisplayFormat()
            {
                Name = "Str30C",
                Alignment = System.Windows.Forms.HorizontalAlignment.Center,
                MaxWidth = 30
            });
            formats.Add(new ViewDisplayFormat()
            {
                Name = "Str30L",
                Alignment = System.Windows.Forms.HorizontalAlignment.Right,
                MaxWidth = 30
            });

            return formats;
        }
    }
}
