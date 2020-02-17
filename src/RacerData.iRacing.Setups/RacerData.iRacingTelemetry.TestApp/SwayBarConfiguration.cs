using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RacerData.iRacingTelemetry.TestApp.Models;
using RacerData.iRacingTelemetry.TestApp.Services;

namespace RacerData.iRacingTelemetry.TestApp
{
    public partial class SwayBarConfiguration : Form
    {
        public SwayBarModel Model { get; set; }

        public SwayBarConfiguration()
        {
            InitializeComponent();
        }

        private void SwayBarConfiguration_Load(object sender, EventArgs e)
        {
            if (Model == null)
                Model = new SwayBarModel();

            swayBarModelBindingSource.DataSource = Model;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SwayBarModel model = (SwayBarModel)swayBarModelBindingSource.Current;

            var rate = SwayBarService.CalculateRate(model);

            txtRate.Text = Math.Round(rate, 3).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SwayBarModel model = (SwayBarModel)swayBarModelBindingSource.Current;

            var rate = SwayBarService.CalculateRate(model);

            txtRate.Text = Math.Round(rate, 3).ToString();

            var leftTravel = double.Parse(txtLeftTravel.Text);
            var rightTravel = double.Parse(txtRightTravel.Text);

            var twist = SwayBarService.CalculateTwist(model, leftTravel, rightTravel);

            txtTwist.Text = Math.Round(twist, 3).ToString();

            var resistance = SwayBarService.CalculateForce(model, leftTravel, rightTravel);

            txtResistance.Text = Math.Round(resistance, 3).ToString();

            var wheelRate = double.Parse(txtWheelRate.Text);

            var wheelForce = resistance * wheelRate;

            txtWheelForce.Text = Math.Round(wheelForce, 3).ToString();
        }

        private void swayBarModelBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            Model = (SwayBarModel)swayBarModelBindingSource.Current;

            this.DialogResult = DialogResult.OK;
        }
    }
}
