using System;
using System.ComponentModel;
using System.Windows.Forms;
using log4net;
using RacerData.rNascarApp.Controls.CreateViewWizard;

namespace RacerData.rNascarApp.Controls
{
    public partial class WizardStep : UserControl, IWizardStep, INotifyPropertyChanged
    {
        #region events

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event EventHandler AdvanceStepRequest;
        protected void OnAdvanceStepRequest()
        {
            if (!CanGoNext)
                return;

            var handler = AdvanceStepRequest;
            handler?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region properties

        protected static CreateViewContext Context { get; set; } = null;

        public int Index { get; set; }
        public string Caption { get; set; }
        public string Details { get; set; }
        private string _error;
        public string Error
        {
            get
            {
                return _error;
            }
            set
            {
                _error = value;
                OnPropertyChanged(nameof(Error));
            }
        }
        private bool _isBusy = false;
        public virtual bool CanGoPrevious
        {

            get
            {
                return _isBusy;
            }
            set
            {
                _isBusy = value;
                OnPropertyChanged(nameof(CanGoPrevious));
            }
        }
        private bool _isComplete = false;
        public virtual bool IsComplete
        {

            get
            {
                return _isComplete;
            }
            set
            {
                _isComplete = value;
                OnPropertyChanged(nameof(IsComplete));
            }
        }
        private bool _canGoNext = false;
        public virtual bool CanGoNext
        {

            get
            {
                return _canGoNext;
            }
            set
            {
                _canGoNext = value;
                OnPropertyChanged(nameof(CanGoNext));
            }
        }
        public ILog Log { get; set; }

        #endregion

        #region ctor

        public WizardStep()
        {
            InitializeComponent();

            Context = new CreateViewContext();

            Context.PropertyChanged += CreateViewContext_PropertyChanged;
        }

        private void CreateViewContext_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var handler = PropertyChanged;
            handler?.Invoke(sender, e);
        }

        #endregion

        #region public

        public virtual CreateViewContext GetDataSource()
        {
            return Context;
        }

        public virtual void SetDataObject(CreateViewContext data)
        {
            if (data != null)
                Context = data;
        }

        public virtual void ActivateStep()
        {

        }

        public virtual void DeactivateStep()
        {

        }

        public virtual bool ValidateStep()
        {
            return true;
        }

        #endregion

        #region protected

        protected virtual void ExceptionHandler(string message, Exception ex)
        {
            Log?.Error(message, ex);

            MessageBox.Show($"{message}: {ex.Message}");
        }

        #endregion
    }
}
