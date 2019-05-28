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
    public partial class WizardStepControlInstance2 : WizardStepControl<TestContext>
    {
        public WizardStepControlInstance2()
        {
            InitializeComponent();
        }

        protected override void WizardStepControl_Load(object sender, System.EventArgs e)
        {
            checkBox1.Checked = WizardStep.Context.FirstChecked;

        }
    }
}
