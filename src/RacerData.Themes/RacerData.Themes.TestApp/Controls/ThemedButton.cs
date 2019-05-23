using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RacerData.Themes.Models;

namespace RacerData.Themes.UI.Controls
{
    public partial class ThemedButton : Button, IThemedControl
    {
        public ThemedButton()
        {
            InitializeComponent();
        }

        public void ApplyTheme(Theme theme)
        {
//            this.BackColor = theme.
        }
    }
}
