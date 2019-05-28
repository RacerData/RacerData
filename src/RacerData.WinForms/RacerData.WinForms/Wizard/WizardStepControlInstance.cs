using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RacerData.WinForms.Controls.Wizard
{
    public partial class WizardStepControlInstance : WizardStepControl<TestContext>
    {

        public WizardStepControlInstance()
            : base()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            WizardStep.Context.FirstChecked = checkBox1.Checked;
            WizardStep.CanGoNext = checkBox1.Checked;
        }
    }
}
