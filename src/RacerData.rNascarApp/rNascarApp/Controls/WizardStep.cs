﻿using System;
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
            if (handler != null)
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region properties

        protected static CreateViewContext CreateViewContext { get; set; } = null;

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
        public bool CanGoPrevious
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
        public bool IsComplete
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
        public bool CanGoNext
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

            CreateViewContext = new CreateViewContext();

            CreateViewContext.PropertyChanged += CreateViewContext_PropertyChanged;
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
            return null;
        }

        public virtual void SetDataObject(CreateViewContext data)
        {

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
#if DEBUG
            Console.WriteLine(ex);
#endif
            MessageBox.Show($"{message}: {ex.Message}");
        }

        #endregion
    }
}
