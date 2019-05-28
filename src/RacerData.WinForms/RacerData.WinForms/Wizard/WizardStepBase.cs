using System;
using System.ComponentModel;

namespace RacerData.WinForms.Controls.Wizard
{
    class WizardStepBase<TContext> : IWizardStep<TContext>, INotifyPropertyChanged
    {
        #region events

        public event EventHandler RequestMoveNext;
        protected virtual void OnRequestMoveNext()
        {
            var handler = RequestMoveNext;
            handler?.Invoke(this, EventArgs.Empty);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region properties

        bool _next = false;
        public virtual bool CanGoNext
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
        bool _back = false;
        public virtual bool CanGoBack
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
        bool _valid = false;
        public virtual bool IsValid
        {
            get
            {
                return _valid;
            }
            set
            {
                _valid = value;
                OnPropertyChanged(nameof(IsValid));
            }
        }
        bool _busy = false;
        public virtual bool IsBusy
        {
            get
            {
                return _busy;
            }
            set
            {
                _busy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        public virtual TContext Context { get; set; }
        public virtual Type WizardStepControlType { get; set; }

        public virtual int Index { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual string HelpText { get; set; }

        #endregion

        #region public

        public virtual void SetAsActiveStep(StepDirection lastStep)
        {

        }

        public virtual void SetAsInactiveStep(StepDirection nextStep)
        {

        }

        #endregion
    }
}
