using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RacerData.Themes.TestApp
{
    public partial class ThemeNamePropertyGridForm : Form
    {
        public ThemeNamePropertyGridForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = button1;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = label1;
        }
    }
}
