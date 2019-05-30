﻿using System;

namespace RacerData.WinForms.Controls.Wizard
{
    public class AfterStepChangedEventArgs<TContext> : EventArgs
    {
        public IWizardStep<TContext> CurrentStep { get; set; }

        public AfterStepChangedEventArgs()
        {

        }

        public AfterStepChangedEventArgs(IWizardStep<TContext> step)
        {
            CurrentStep = step;
        }
    }
}