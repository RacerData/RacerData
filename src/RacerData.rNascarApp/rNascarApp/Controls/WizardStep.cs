using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;

namespace RacerData.rNascarApp.Controls
{
    public partial class WizardStep : UserControl, IWizardStep, INotifyPropertyChanged
    {
        #region events

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region properties

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
        public ILog Log { get; set; }

        #endregion

        #region ctor

        public WizardStep()
        {
            InitializeComponent();
        }

        #endregion

        #region public

        public virtual object GetDataSource()
        {
            return null;
        }

        public virtual void SetDataObject(object data)
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
