using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacerData.WinForms.Controls.Wizard
{
    public class BeforeStepChangesEventArgs<TContext> : EventArgs
    {
        public IWizardStep<TContext> MovingFrom { get; set; }
        public IWizardStep<TContext> MovingTo { get; set; }

        public BeforeStepChangesEventArgs()
        {

        }

        public BeforeStepChangesEventArgs(IWizardStep<TContext> from, IWizardStep<TContext> to)
        {
            MovingFrom = from;
            MovingTo = to;
        }
    }
}
