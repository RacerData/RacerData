using System;
using System.ComponentModel;

namespace RacerData.WinForms.Controls.Wizard
{
    public interface IWizardStep<TContext> : IWizardStepInfo, INotifyPropertyChanged
    {
        event EventHandler RequestMoveNext;

        bool CanGoNext { get; set; }
        bool CanGoBack { get; set; }
        bool IsValid { get; set; }
        bool IsBusy { get; set; }

        TContext Context { get; set; }
        Type WizardStepControlType { get; set; }

        void SetAsActiveStep(StepDirection lastStep);
        void SetAsInactiveStep(StepDirection nextStep);
    }
}
