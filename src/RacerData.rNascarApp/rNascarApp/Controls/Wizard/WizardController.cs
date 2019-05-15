using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace RacerData.rNascarApp.Controls.Wizard
{
    public class WizardController<TContext> : INotifyPropertyChanged
    {
        #region events

        public event EventHandler<BeforeStepChangesEventArgs<TContext>> BeforeStepChanges;
        protected void OnBeforeStepChanges(
            IWizardStep<TContext> movingFrom,
            IWizardStep<TContext> movingTo)
        {
            var handler = BeforeStepChanges;
            handler?.Invoke(this, new BeforeStepChangesEventArgs<TContext>(movingFrom, movingTo));
        }

        public event EventHandler<AfterStepChangedEventArgs<TContext>> AfterStepChanged;
        protected void OnAfterStepChanged(IWizardStep<TContext> currentStep)
        {
            var handler = AfterStepChanged;
            handler?.Invoke(this, new AfterStepChangedEventArgs<TContext>(currentStep));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region properties

        bool _next = true;
        public bool CanGoNext
        {
            get
            {
                return _next;
            }
            set
            {
                _next = value;
                OnPropertyChanged(nameof(CanGoNext));
            }
        }
        bool _back = true;
        public bool CanGoBack
        {
            get
            {
                return _back;
            }
            set
            {
                _back = value;
                OnPropertyChanged(nameof(CanGoBack));
            }
        }

        private bool _canSaveAndClose;
        public bool CanSaveAndClose
        {
            get
            {
                return _canSaveAndClose;
            }
            set
            {
                _canSaveAndClose = value;
                OnPropertyChanged(nameof(CanSaveAndClose));
            }
        }

        private bool _isFirstStep;
        public bool IsFirstStep
        {
            get
            {
                return _isFirstStep;
            }
            set
            {
                _isFirstStep = value;
                OnPropertyChanged(nameof(IsFirstStep));
            }
        }

        private bool _isLastStep;
        public bool IsLastStep
        {
            get
            {
                return _isLastStep;
            }
            set
            {
                _isLastStep = value;
                OnPropertyChanged(nameof(IsLastStep));
            }
        }

        private int _stepIndex;
        public int StepIndex
        {
            get
            {
                return _stepIndex;
            }
            set
            {
                _stepIndex = value;
                OnPropertyChanged(nameof(StepIndex));
            }
        }
        
        private IWizardStep<TContext> _currentStep;
        public IWizardStep<TContext> CurrentStep
        {
            get
            {
                return _currentStep;
            }
            set
            {
                _currentStep = value;
                OnPropertyChanged(nameof(CurrentStep));
            }
        }

        private IList<IWizardStep<TContext>> _steps;
        public IList<IWizardStep<TContext>> Steps
        {
            get
            {
                return _steps;
            }
            set
            {
                _steps = value;
                OnPropertyChanged(nameof(Steps));
            }
        }

        #endregion

        #region ctor

        public WizardController(IList<IWizardStep<TContext>> steps)
        {
            PropertyChanged += WizardController_PropertyChanged;

            BeforeStepChanges += WizardController_BeforeStepChanges;

            AfterStepChanged += WizardController_AfterStepChanged;

            Steps = steps;
        }

        #endregion

        #region public

        public void Start()
        {
            UpdateActiveStep(StepDirection.First);
        }

        public void Next()
        {
            UpdateActiveStep(StepDirection.Next);
        }

        public void Back()
        {
            UpdateActiveStep(StepDirection.Previous);
        }

        #endregion

        #region protected

        protected virtual void UpdateActiveStep(StepDirection step)
        {
            IWizardStep<TContext> targetStep = null;

            int newStepIndex = StepIndex;

            switch (step)
            {
                case StepDirection.First:
                    {
                        newStepIndex = 0;
                        break;
                    }
                case StepDirection.Previous:
                    {
                        if (newStepIndex - 1 < 0)
                            throw new IndexOutOfRangeException($"Error moving to last step:\r\nStep index {StepIndex - 1} out of range [0 - {Steps.Count - 1}]");

                        if (!CurrentStep.CanGoBack)
                            throw new InvalidOperationException("Cannot go back to last step right now");

                        newStepIndex = StepIndex - 1;

                        break;
                    }
                case StepDirection.Next:
                    {
                        if (StepIndex + 1 >= Steps.Count)
                            throw new IndexOutOfRangeException($"Error moving to next step:\r\nStep index {StepIndex + 1} out of range [0 - {Steps.Count - 1}]");

                        if (!CurrentStep.CanGoNext)
                            throw new InvalidOperationException("Cannot go to next step right now");

                        newStepIndex = StepIndex + 1;
                        break;
                    }
                case StepDirection.Last:
                    {
                        newStepIndex = Steps.Count - 1;
                        break;
                    }
            }

            targetStep = Steps[newStepIndex];

            OnBeforeStepChanges(CurrentStep, targetStep);

            targetStep.SetAsInactiveStep(step);

            CurrentStep = targetStep;

            targetStep.SetAsActiveStep(step);

            OnAfterStepChanged(targetStep);
        }

        #endregion

        #region private

        private void WizardController_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CurrentStep))
            {
                StepIndex = CurrentStep.Index;
                IsFirstStep = StepIndex == 0;
                IsLastStep = StepIndex == Steps.Count - 1;
                CanGoBack = !IsFirstStep;
                CanGoNext = !IsLastStep;
            }
        }

        private void WizardController_AfterStepChanged(object sender, AfterStepChangedEventArgs<TContext> e)
        {
            e.CurrentStep.PropertyChanged += CurrentStep_PropertyChanged;
            e.CurrentStep.RequestMoveNext += CurrentStep_RequestMoveNext;
        }

        private void WizardController_BeforeStepChanges(object sender, BeforeStepChangesEventArgs<TContext> e)
        {
            if (e.MovingFrom != null)
            {
                e.MovingFrom.PropertyChanged -= CurrentStep_PropertyChanged;
                e.MovingFrom.RequestMoveNext -= CurrentStep_RequestMoveNext;
            }
        }

        private void CurrentStep_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            IWizardStep<TContext> step = (IWizardStep<TContext>)sender;

            CanSaveAndClose = IsLastStep & step.IsValid & !step.IsBusy & step.CanGoNext;
            CanGoNext = step.CanGoNext;
            CanGoBack = step.CanGoBack;
        }

        private void CurrentStep_RequestMoveNext(object sender, EventArgs e)
        {
            IWizardStep<TContext> step = (IWizardStep<TContext>)sender;

            if (step.CanGoNext)
                UpdateActiveStep(StepDirection.Next);
        }

        #endregion
    }
}
