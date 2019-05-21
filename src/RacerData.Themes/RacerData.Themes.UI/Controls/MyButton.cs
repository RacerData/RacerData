using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RacerData.Themes.UI.Controls
{
    public partial class MyButton : Button
    {
        public MyButton()
        {
            InitializeComponent();
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            Console.WriteLine("OnPaintBackground");
            base.OnPaintBackground(pevent);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            Console.WriteLine("OnPaint");
            base.OnPaint(pevent);
            var c = Color.FromKnownColor(KnownColor.Info);
        }
    }
}
