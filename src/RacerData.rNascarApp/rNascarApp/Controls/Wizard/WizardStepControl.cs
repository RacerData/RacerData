using System.Windows.Forms;

namespace RacerData.rNascarApp.Controls.Wizard
{
    public partial class WizardStepControl<T> : UserControl
    {
        public IWizardStep<T> WizardStep { get; set; }

        public WizardStepControl()
        {
            InitializeComponent();
        }

        protected virtual void WizardStepControl_Load(object sender, System.EventArgs e)
        {

        }
    }
}
